using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using GestcomWF.DataAccess;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System.Reflection;

namespace GestcomWF.Views
{
    public partial class saisie_acompte : Form
    {
        // Membre pour garder une trace du lot actuel
        private Lot _currentLot = null;

        private bool updateAllPrices = false;

        private string moisExcel = string.Empty;
        private string _lastPathSaved = string.Empty;
        DataPath dataPath = new DataPath();

        // Liste des mois pour la combobox
        List<MoisNum> listeObjets = new List<MoisNum> {
            new MoisNum { Mois = "Janvier", Numero = 1 },
            new MoisNum { Mois = "Février", Numero = 2 },
            new MoisNum { Mois = "Mars", Numero = 3 },
            new MoisNum { Mois = "Avril", Numero = 4 },
            new MoisNum { Mois = "Mai", Numero = 5 },
            new MoisNum { Mois = "Juin", Numero = 6 },
            new MoisNum { Mois = "Juillet", Numero = 7 },
            new MoisNum { Mois = "Août", Numero = 8 },
            new MoisNum { Mois = "Septembre", Numero = 9 },
            new MoisNum { Mois = "Octobre", Numero = 10 },
            new MoisNum { Mois = "Novembre", Numero = 11 },
            new MoisNum { Mois = "Décembre", Numero = 12 }
            };
        public saisie_acompte()
        {
            InitializeComponent();
            InitializeDataGridView();

            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";

            cbxMois.SelectedIndex = 0;
            // Initialiser le DataGridView sans source de données
            dataGridView.DataSource = null;

            checkBoxUpdateAll.Checked = true;

            btn_valider_dg.Visible = false;

            AjusterAnnee();

            GenererValeurs();
        }
        private void GenererValeurs()
        {

            if (tbx_annee.Text == "" || tbx_annee.Text.Length < 2)
            {

            }
            else
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLotAcompte(Convert.ToDecimal(tbx_annee.Text), moisNum.Numero);
                /*if (lots == null || lots.Count == 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    dataGridView.DataSource = lots;

                }*/
                dataGridView.DataSource = lots;
            }
        }
        private void btn_valider_dg_Click(object sender, EventArgs e)
        {

            if (tbx_annee.Text == "" || tbx_annee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");
            }
            else
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLotAcompte(Convert.ToDecimal(tbx_annee.Text), moisNum.Numero);
                if (lots == null || lots.Count == 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    dataGridView.DataSource = lots;

                }
            }
        }

        private void dataGridView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) // Assurez-vous que le double-clic n'est pas sur l'en-tête
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (row != null && row.DataBoundItem is Lot lot)
            {
                tbx_prix.Text = lot.LOPUAC.ToString();
                tbxNumFromagerie.Text = lot.LOFROM.ToString();

                this._currentLot = lot;
                // Assignez d'autres propriétés de l'objet `lot` à d'autres TextBox si nécessaire
            }
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

            if (this._currentLot != null)
            {
                decimal newPrice;
                if (decimal.TryParse(tbx_prix.Text, out newPrice))
                {
                    List<Lot> lots = dataGridView.DataSource as List<Lot>;
                    if (lots != null)
                    {
                        if (updateAllPrices)
                        {
                            // Mettre à jour le prix pour chaque lot affiché dans le DataGridView
                            foreach (Lot lot in lots)
                            {
                                LotAdo.updateLotPrix(lot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, Convert.ToDouble(newPrice * 1000));
                                lot.LOPUAC = newPrice;
                            }
                        }
                        else
                        {
                            // Mettre à jour un seul lot
                            LotAdo.updateLotPrix(this._currentLot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, Convert.ToDouble(newPrice * 1000));
                            this._currentLot.LOPUAC = newPrice;
                        }
                        // Rafraîchissez le DataGridView
                        dataGridView.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Prix invalide");
                }
            }
        }

        private void checkBoxUpdateAll_CheckedChanged(object sender, EventArgs e)
        {
            updateAllPrices = checkBoxUpdateAll.Checked;
        }

        private void generate_excel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application objApp;
                Excel._Workbook objBook;
                // Vérification que le champ 'année' est correctement rempli
                if (tbx_annee.Text == "" || tbx_annee.Text.Length < 2)
                {
                    MessageBox.Show("Veuillez entrer une année en deux chiffres");
                }
                else
                {
                    Excel.Workbooks objBooks;
                    Excel.Sheets objSheets;
                    Excel._Worksheet objSheet;
                    Excel.Range range;

                    objApp = new Excel.Application();
                    objApp.Visible = false;
                    objBooks = objApp.Workbooks;
                    objBook = objBooks.Add(Missing.Value);
                    objSheets = objBook.Worksheets;

                    decimal valeurPrecedente = 0;



                    // Récupération du mois sélectionné depuis la comboBox
                    MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                    decimal moisNumValue = moisNum.Numero;
                    decimal anneeValue = Convert.ToDecimal(tbx_annee.Text);

                    DateTime selectedDate = dtpAcompte.Value;
                    string formattedDate = selectedDate.ToString("dd MMMM yyyy");

                    // Récupération de toutes les entrées pour le mois et l'année donnés
                    List<LotFrom> lotFroms = LotAdo.generationFichierExcelAcompte(moisNumValue, Convert.ToDecimal(tbx_annee.Text));
                    if (lotFroms == null || lotFroms.Count <= 0)
                    {
                        MessageBox.Show("Aucune valeur");
                    }
                    else
                    {

                        decimal prix = 0;
                        decimal acompte = 0;
                        string annee = (DateTime.Now.Year / 100).ToString();
                        // Traitement pour chaque entré
                        foreach (LotFrom lotFrom in lotFroms)
                        {

                            prix = Math.Round((lotFrom.LOCEN1 / 1000) * (lotFrom.LOPUAC / 1000), 2);
                            acompte = lotFrom.LOPUAC * lotFrom.LOCEN1;
                            string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                            // Si l'entrée a une nouvelle valeur FRNUM
                            if (lotFrom.FRNUM != valeurPrecedente)
                            {
                                // Initialisation de la feuille Excel avec le nom adapté
                                objSheet = objBook.Sheets.Add(Missing.Value, objBook.Worksheets[objBook.Worksheets.Count], Missing.Value, Missing.Value);
                                objSheet.Name = nomFeuille;

                                objSheet.Cells[10, "F"].Value = lotFrom.FRNDIR;
                                objSheet.Cells[11, "F"].Value = lotFrom.FRNOM;
                                objSheet.Cells[12, "F"].Value = lotFrom.FRADR;
                                objSheet.Cells[13, "F"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;
                                objSheet.Cells[28, "G"].Value = "Le" + " " + formattedDate;
                                objSheet.Cells[18, "A"].Value = "      TB/PB";
                                objSheet.Cells[23, "B"].Value = "Monsieur le Président";
                                objSheet.Cells[25, "B"].Value = "          Nous vous prions de bien vouloir trouver ci-dessous, le détail";
                                objSheet.Cells[26, "B"].Value = "du premier acompte sur votre lot de fabrication " + moisNum.Mois.ToUpper() + " " + annee + anneeValue;


                                objSheet.Columns[1].Columnwidth = 19.11;
                                objSheet.Columns[2].Columnwidth = 3.56;
                                objSheet.Columns[3].Columnwidth = 5.89;
                                objSheet.Columns[4].Columnwidth = 6.78;
                                objSheet.Columns[5].Columnwidth = 11.11;
                                objSheet.Columns[6].Columnwidth = 3.56;
                                objSheet.Columns[7].Columnwidth = 2.33;
                                objSheet.Columns[8].Columnwidth = 12.22;
                                objSheet.Columns[9].Columnwidth = 4.33;
                                objSheet.Columns[10].Columnwidth = 15.22;

                                objSheet.Rows[29].Rowheight = 4.20;
                                objSheet.Rows[32].Rowheight = 4.20;


                                // Configuration du style de la feuille (police, ...)
                                objSheet.Cells.Font.Name = "Arial";

                                /* this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                 this.workSheet["F27"].Style.Font.Bold = true;*/


                                // Initialisez la ligne actuelle


                                objSheet.Cells[28, "B"].Value = "-";
                                objSheet.Cells[28, "B"].HorizontalAlignment = XlHAlign.xlHAlignRight;

                                objSheet.Cells[28, "C"].Value = lotFrom.LOCEM1;
                                objSheet.Cells[28, "C"].Font.Bold = true;
                                objSheet.Cells[28, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;



                                objSheet.Cells[28, "D"].Value = "pains";

                                objSheet.Cells[28, "E"].Value = Math.Round(lotFrom.LOCEN1 / 1000, 3);
                                objSheet.Cells[28, "E"].Font.Bold = true;
                                objSheet.Cells[28, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[28, "E"].NumberFormat = @"#\ ##0,000";

                                objSheet.Cells[28, "F"].Value = "T";
                                objSheet.Cells[28, "F"].Font.Bold = true;
                                objSheet.Cells[28, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                objSheet.Cells[28, "G"].Value = "x";
                                objSheet.Cells[28, "G"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                objSheet.Cells[28, "H"].Value = lotFrom.LOPUAC / 1000;
                                objSheet.Cells[28, "H"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[28, "H"].NumberFormat = @"#\ ##0,00€";


                                objSheet.Cells[28, "I"].Value = " =";
                                objSheet.Cells[28, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                objSheet.Cells[28, "J"].Value = prix;
                                objSheet.Cells[28, "J"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[28, "J"].NumberFormat = @"#\ ##0,00€";

                                objSheet.Cells[30, "J"].Value = prix;
                                objSheet.Cells[30, "J"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[30, "J"].NumberFormat = @"#\ ##0,00€";


                                /*foreach (var dateEntry in lotFroms.Where(item => item.FRNUM == lotFrom.FRNUM))
                                 {
                                     // Remplissez les données pour chaque entrée de fromagerie
                                     workSheet[$"E{currentRow}"].Value = dateEntry.LOC11;
                                     this.workSheet[$"E{currentRow}"].Style.Font.Bold = true;
                                     this.workSheet[$"E{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                     currentRow++;
                                 }*/

                                // Placez le total à 4 cellules en dessous de la dernière ligne remplie


                                // int totalRow = currentRow + 4;


                                objSheet.Cells[28, "J"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                objSheet.Cells[28, "J"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                objSheet.Cells[28, "J"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;


                                objSheet.Cells[31, "J"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                objSheet.Cells[31, "J"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                objSheet.Cells[31, "J"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;



                                //this.workSheet["D33"].Value = "A déduire N/Acompte du ";
                                objSheet.Cells[30, "F"].Value = "Total HT";
                                objSheet.Cells[31, "F"].Value = "T.V.A";
                                objSheet.Cells[31, "H"].Value = "5,5";
                                objSheet.Cells[31, "H"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[31, "I"].Value = "%";
                                objSheet.Cells[31, "J"].Value = prix * 5.5m / 100;
                                objSheet.Cells[31, "J"].NumberFormat = @"#\ ##0,00€";

                                objSheet.Cells[33, "F"].Value = "Total Réglé";
                                objSheet.Cells[33, "F"].Font.Bold = true;

                                //var sumPrixTVA = workSheet["J30:J31"];

                                objSheet.Cells[33, "J"].Formula = "=SUM(J30:J31)";
                                objSheet.Cells[33, "J"].Font.Bold = true;
                                objSheet.Cells[33, "J"].NumberFormat = @"#\ ##0,00€";
                                var sum = objSheet.Cells[33, "J"].Value;


                                objSheet.Cells[35, "B"].Value = "          Vous en souhaitant bonne réception";
                                objSheet.Cells[37, "B"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                                objSheet.Cells[38, "B"].Value = "salutations distinguées";
                                objSheet.Cells[40, "H"].Value = "Service Comptabilité";
                                objSheet.Cells[40, "H"].Font.Bold = true;

                                objSheet.Cells[46, "B"].Value = "PS : Nous virons ce jour, sur votre compte N° " + lotFrom.FRBANQ + " " + lotFrom.FRGUIC + " " + lotFrom.FRCOM1 + " " + lotFrom.FRCOM2;
                                objSheet.Cells[47, "B"].Value = lotFrom.FRDOMI + ", la somme de";
                                objSheet.Cells[47, "J"].Value = sum;
                                objSheet.Cells[47, "J"].NumberFormat = @"#\ ##0,00€";


                                valeurPrecedente = lotFrom.FRNUM;
                            }


                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.InitialDirectory = dataPath.PathAcompte;
                        if (moisNum.Numero < 10)
                        {
                            moisExcel = "0" + moisNum.Numero;
                        }
                        else
                        {
                            moisExcel = moisNum.Numero.ToString();
                        }
                        saveFileDialog.FileName = "Acomptes_" + tbx_annee.Text + moisExcel + ".xlsx";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;

                            objBook.SaveAs(path);
                            objBook.Close();
                            objApp.Quit();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue ou le fichier est déjà généré");

            }
        }

        private void tbx_prix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                // Insérer une virgule à la position du curseur dans le TextBox
                int selectionStart = tbx_prix.SelectionStart;
                tbx_prix.Text = tbx_prix.Text.Insert(selectionStart, ",");

                // Mettre à jour la position du curseur
                tbx_prix.SelectionStart = selectionStart + 1;

                // Empêcher la gestion ultérieure de cette touche
                e.SuppressKeyPress = true;
            }
        }

        private void dtpAcompte_ValueChanged(object sender, EventArgs e)
        {
            AjusterAnnee();
            GenererValeurs();
        }

        private void AjusterAnnee()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime moisPrecedent = dtpAcompte.Value.AddMonths(-2);
            cbxMois.SelectedIndex = moisPrecedent.Month - 1;
            tbx_annee.Text = Convert.ToString(moisPrecedent.Year % 100);
        }

        private void cbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenererValeurs();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (string.IsNullOrEmpty(_lastPathSaved))
            {
                _lastPathSaved = GetLatestFilePath(dataPath.PathAcompte);
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPrinter = printDialog.PrinterSettings.PrinterName;
                    // Utilisez selectedPrinter avec votre méthode d'impression
                    PrintAllSheets(_lastPathSaved, selectedPrinter);
                }
            }
            else
            {

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPrinter = printDialog.PrinterSettings.PrinterName;
                    // Utilisez selectedPrinter avec votre méthode d'impression
                    PrintAllSheets(_lastPathSaved, selectedPrinter);
                }
            }

        }

        private void PrintAllSheets(string filePath, string printerName)
        {
            // Initialise les objets pour l'application Excel et le classeur.
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            try
            {
                // Parcourt et imprime chaque feuille du classeur.
                foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                {
                    worksheet.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing, printerName);
                }
            }
            catch (Exception ex)
            {
                // Affiche un message d'erreur en cas de problème lors de l'impression.
                MessageBox.Show($"Une erreur est survenue lors de la tentative d'impression: {ex.Message}");
            }
            finally
            {
                // Ferme le classeur et l'application Excel.
                workbook.Close(false);
                excelApp.Quit();

                // Libère les ressources pour éviter les fuites de mémoire.
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        string GetLatestFilePath(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
            {
                throw new ArgumentException("Le chemin du répertoire est invalide.");
            }

            var directoryInfo = new DirectoryInfo(directoryPath);
            var latestFile = directoryInfo.GetFiles()
                                          .OrderByDescending(f => f.LastWriteTime)
                                          .FirstOrDefault();

            return latestFile?.FullName;
        }

        private void tbx_annee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbx_annee.Text.Length == 2)
                {
                    GenererValeurs();
                }
            }
        }
    }
}
