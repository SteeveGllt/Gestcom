using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using GestcomWF.DataAccess;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace GestcomWF.Views
{

    public partial class saisie_classement : Form
    {
        // Membre pour garder une trace du lot actuel
        private Lot _currentLot = null;

        private string moisExcel = string.Empty;
        private int _temp = 0;
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

        // Constructeur de la classe
        public saisie_classement()
        {
            InitializeComponent();
            InitializeDataGridView();
            // Initialiser la combobox avec les mois
            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";
            // Initialiser le DataGridView sans source de données
            dataGridView.DataSource = null;
            buttonGenerer.Visible = false;

            AjusterAnnee();

            GenererValeurs();
        }


        // Génère des lots basés sur le mois et l'année entrés
        private void GenererValeurs()
        {


            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
            }
            else
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLot(Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero);
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

        // Événement lors du double clic sur une ligne du DataGridView
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) // Assurez-vous que le double-clic n'est pas sur l'en-tête
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (row != null && row.DataBoundItem is Lot lot)
            {
                tbx_total.Text = lot.LOCEM1.ToString();
                if (lot.LOC11 == 0)
                {
                    tbx_a.Text = lot.LOCEM1.ToString();
                }
                else
                {
                    tbx_a.Text = lot.LOC11.ToString();
                }

                tbx_b.Text = lot.LOC12.ToString();
                tbx_c.Text = lot.LOC13.ToString();
                this._currentLot = lot;
                // Assignez d'autres propriétés de l'objet `lot` à d'autres TextBox si nécessaire
            }
        }

        // Calcule et affiche le montant restant
        private void CalculateRemainingB()
        {
            int total = Convert.ToInt32(tbx_total.Text);  // Vous pouvez récupérer cette valeur depuis un autre champ si nécessaire
            int valueA = 0;

            int.TryParse(tbx_a.Text, out valueA);

            int remaining = total - valueA;
            _temp = remaining;

            tbx_b.Text = remaining.ToString();

            if (remaining < 0)
            {
                MessageBox.Show("La somme des valeurs dépasse le total!");
                // Réinitialiser la valeur du champ qui a causé le dépassement, ou ajuster selon votre logique
            }

        }
        private void CalculateRemainingC()
        {
            int total = Convert.ToInt32(tbx_total.Text);  // Vous pouvez récupérer cette valeur depuis un autre champ si nécessaire

            int valueA = 0;
            int valueB = 0;

            int.TryParse(tbx_a.Text, out valueA);
            int.TryParse(tbx_b.Text, out valueB);

            int remaining = _temp - valueB;

            tbx_c.Text = remaining.ToString();

            if (remaining < 0)
            {
                MessageBox.Show("La somme des valeurs dépasse le total!");
                // Réinitialiser la valeur du champ qui a causé le dépassement, ou ajuster selon votre logique
            }

        }

        // Si l'utilisateur appuie sur Enter après avoir entré une valeur dans tbx_a
        private void tbx_a_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateRemainingB();
                tbx_b.Focus();
            }

        }

        // Si l'utilisateur appuie sur Enter après avoir entré une valeur dans tbx_b
        private void tbx_b_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateRemainingC();
                tbx_c.Focus();
            }

        }

        // Si l'utilisateur appuie sur Enter après avoir entré une valeur dans tbx_c
        private void tbx_c_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }

        // Valide et met à jour le lot sélectionné
        private void btn_valider_Click(object sender, EventArgs e)
        {
            List<Lot> lots = dataGridView.DataSource as List<Lot>;

            if (lots != null)
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                if (_currentLot == null)
                {
                    MessageBox.Show("Veuillez sélectionner un lot");
                }
                else if (!IsNumber(tbx_a.Text) || !IsNumber(tbx_b.Text) || !IsNumber(tbx_c.Text))
                {
                    MessageBox.Show("Veuillez entrer des nombres valides dans chaque champ.");
                    return;
                }
                else if (!IsNonNegativeNumber(tbx_a.Text) || !IsNonNegativeNumber(tbx_b.Text) || !IsNonNegativeNumber(tbx_c.Text))
                {
                    MessageBox.Show("Veuillez entrer des nombres valides dans chaque champ.");
                    return;
                }
                else
                {

                    LotAdo.updateLotClassement(_currentLot.LOFROM, Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero, Convert.ToDecimal(tbx_a.Text), Convert.ToDecimal(tbx_b.Text), Convert.ToDecimal(tbx_c.Text));
                    this._currentLot.LOC11 = Convert.ToDecimal(tbx_a.Text);
                    this._currentLot.LOC12 = Convert.ToDecimal(tbx_b.Text);
                    this._currentLot.LOC13 = Convert.ToDecimal(tbx_c.Text);
                    _currentLot = null;
                    tbx_a.Text = "";
                    tbx_b.Text = "";
                    tbx_c.Text = "";
                    tbx_total.Text = "";
                    dataGridView.Refresh();

                }

            }

        }

        // Fonction pour vérifier si une chaîne est un nombre
        private bool IsNumber(string text)
        {
            int parsedValue;
            return int.TryParse(text, out parsedValue);
        }

        // Fonction pour vérifier si une chaîne est un nombre non négatif
        private bool IsNonNegativeNumber(string text)
        {
            int parsedValue;
            if (int.TryParse(text, out parsedValue))
            {
                return parsedValue >= 0;  // Retourne vrai si le nombre est non négatif
            }
            return false;
        }


        
        private void generate_excel_Click(object sender, EventArgs e)
        {
            Excel.Application objApp;
            Excel._Workbook objBook;
            // Vérification que le champ 'année' est correctement rempli
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
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
                objApp.Visible = true;
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                //objSheet = (Excel._Worksheet)objSheets.get_Item(1);


                Decimal valeurPrecedente = 0;


                // Récupération du mois sélectionné depuis la comboBox
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                // Récupération de toutes les entrées pour le mois et l'année donnés
                DateTime selectedDate = dtpDate.Value;
                string formattedDate = selectedDate.ToString("dd MMMM yyyy");
                List<LotFrom> lotFroms = LotAdo.generationFichierExcelClassement(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (lotFroms == null || lotFroms.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    try
                    {


                        string annee = (DateTime.Now.Year / 100).ToString();
                        // Traitement pour chaque entré
                        foreach (LotFrom lotFrom in lotFroms)
                        {
                            string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                            // Si l'entrée a une nouvelle valeur FRNUM
                            if (lotFrom.FRNUM != valeurPrecedente)
                            {
                                // Initialisation de la feuille Excel avec le nom adapté
                                objSheet = objBook.Sheets.Add(Missing.Value, objBook.Worksheets[objBook.Worksheets.Count], Missing.Value, Missing.Value);
                                objSheet.Name = nomFeuille;

                                objSheet.Cells[10, "D"] = lotFrom.FRNOM;
                                objSheet.Cells[11, "D"] = lotFrom.FRNDIR;
                                objSheet.Cells[12, "D"] = lotFrom.FRADR;
                                objSheet.Cells[12, "D"] = lotFrom.FRCPOS + " " + lotFrom.FRVILL;
                                objSheet.Cells[18, "A"] = "      TB/PB";
                                objSheet.Cells[19, "D"] = "Le" + " " + formattedDate;
                                objSheet.Cells[24, "B"] = "Monsieur le Président";
                                objSheet.Cells[26, "B"] = "          Nous vous prions de bien vouloir trouver ci-dessous, pour information,";
                                objSheet.Cells[27, "B"] = "le classement de votre lot de fabrication ";

                                objSheet.Cells[27, "F"].Value = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                objSheet.Cells[27, "F"].Font.Bold = true;

                                objSheet.Columns[1].Columnwidth = 13;
                                objSheet.Columns[2].Columnwidth = 13;
                                objSheet.Columns[3].Columnwidth = 12;
                                objSheet.Columns[4].Columnwidth = 3.71;
                                objSheet.Columns[5].Columnwidth = 7.57;
                                objSheet.Columns[6].Columnwidth = 5.71;


                                // Configuration du style de la feuille (police, ...)
                                objSheet.Cells.Font.Name = "Arial";
                                //objSheet.Cells[24, "E"].Style.Font.Bold = true;

                                // Initialisez la ligne actuelle

                                //int currentRow = 30;
                                if (lotFrom.LOC11 != 0)
                                {
                               
                                    objSheet.Cells[30, "B"].Value = "- Catégorie A";
                                    objSheet.Cells[30, "B"].Font.Bold = true;

                                    objSheet.Cells[30, "C"].Value = "………..";
                                    objSheet.Cells[30, "C"].Font.Bold = true;
                                    objSheet.Cells[30, "C"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[30, "F"].Value = "pains";
                                    objSheet.Cells[30, "F"].Font.Bold = true;

                                    objSheet.Cells[30, "E"] = lotFrom.LOC11;
                                    objSheet.Cells[30, "E"].Font.Bold = true;
                                    objSheet.Cells[30, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[30, "G"] = Math.Round((lotFrom.LOC11 / lotFrom.LOCEM1) * 100) + "%";
                                    objSheet.Cells[30, "G"].Font.Bold = true;
                                    objSheet.Cells[30, "G"].HorizontalAlignment = XlHAlign.xlHAlignRight;

                                }



                                if (lotFrom.LOC12 != 0)
                                {
                                    objSheet.Cells[31, "B"].Value = "- Catégorie B";
                                    objSheet.Cells[31, "B"].Font.Bold = true;

                                    objSheet.Cells[31, "C"].Value = "………..";
                                    objSheet.Cells[31, "C"].Font.Bold = true;
                                    objSheet.Cells[31, "C"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[31, "F"].Value = "pains";
                                    objSheet.Cells[31, "F"].Font.Bold = true;

                                    objSheet.Cells[31, "E"] = lotFrom.LOC12;
                                    objSheet.Cells[31, "E"].Font.Bold = true;
                                    objSheet.Cells[31, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[31, "G"] = Math.Round((lotFrom.LOC12 / lotFrom.LOCEM1) * 100) + "%";
                                    objSheet.Cells[31, "G"].Font.Bold = true;
                                    objSheet.Cells[31, "G"].HorizontalAlignment = XlHAlign.xlHAlignRight;

                                    // Placez le total à 4 cellules en dessous de la dernière ligne remplie

                                }
                                if (lotFrom.LOC13 != 0)
                                {
                                    objSheet.Cells[32, "B"].Value = "- Catégorie C";
                                    objSheet.Cells[32, "B"].Font.Bold = true;

                                    objSheet.Cells[32, "C"].Value = "………..";
                                    objSheet.Cells[32, "C"].Font.Bold = true;
                                    objSheet.Cells[32, "C"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[32, "F"].Value = "pains";
                                    objSheet.Cells[32, "F"].Font.Bold = true;

                                    objSheet.Cells[32, "E"] = lotFrom.LOC13;
                                    objSheet.Cells[32, "E"].Font.Bold = true;
                                    objSheet.Cells[32, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[32, "G"] = Math.Round((lotFrom.LOC13 / lotFrom.LOCEM1) * 100) + "%";
                                    objSheet.Cells[32, "G"].Font.Bold = true;
                                    objSheet.Cells[32, "G"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                }


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

                                objSheet.Cells[34, "B"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                                objSheet.Cells[35, "B"].Value = "salutations distinguées";
                                objSheet.Cells[38, "E"].Value = "Service Technique";
                                objSheet.Cells[38, "E"].Font.Bold = true;


                                valeurPrecedente = lotFrom.FRNUM;

                            }





                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.InitialDirectory = dataPath.PathClassement;
                        if (moisNum.Numero < 10)
                        {
                            moisExcel = "0" + moisNum.Numero;
                        }
                        else
                        {
                            moisExcel = moisNum.Numero.ToString();
                        }
                        saveFileDialog.FileName = "Classements_" + tbxAnnee.Text + moisExcel + ".xls";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;
                            _lastPathSaved = path;
                            objBook.SaveAs(path);
                            objBook.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            AjusterAnnee();
            GenererValeurs();
        }


        private void AjusterAnnee()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime moisPrecedent = dtpDate.Value.AddMonths(-4);
            cbxMois.SelectedIndex = moisPrecedent.Month - 1;
            tbxAnnee.Text = Convert.ToString(moisPrecedent.Year % 100);
        }

        private void cbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenererValeurs();
        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");
            }
            else
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLot(Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero);
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

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (string.IsNullOrEmpty(_lastPathSaved))
            {
                _lastPathSaved = GetLatestFilePath(dataPath.PathClassement);
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

            MessageBox.Show(latestFile?.FullName);
            return latestFile?.FullName;
        }
    }
}
