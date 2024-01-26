using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using IronXL;
using System.Drawing.Printing;
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
            // Vérification que le champ 'année' est correctement rempli
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");
            }
            else
            {
                WorkSheet workSheet = null;
                WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);


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
                                workSheet = workbook.CreateWorkSheet(nomFeuille);
                                workSheet["D10"].Value = lotFrom.FRNOM;
                                workSheet["D11"].Value = lotFrom.FRNDIR;
                                workSheet["D12"].Value = lotFrom.FRADR;
                                workSheet["D13"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;
                                workSheet["A18"].Value = "      TB/PB";
                                workSheet["D19"].Value = "Le" + " " + formattedDate;
                                workSheet["B24"].Value = "Monsieur le Président";
                                workSheet["B26"].Value = "          Nous vous prions de bien vouloir trouver ci-dessous, pour information,";
                                workSheet["B27"].Value = "le classement de votre lot de fabrication ";

                                workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                workSheet["F27"].Style.Font.Bold = true;


                                // Initialisez la ligne actuelle

                                //int currentRow = 30;
                                if (lotFrom.LOC11 != 0)
                                {
                                    workSheet["B30"].Value = "- Catégorie A";
                                    workSheet["B30"].Style.Font.Bold = true;

                                    workSheet["C30"].Value = "………..";
                                    workSheet["C30"].Style.Font.Bold = true;
                                    workSheet["C30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                    workSheet["F30"].Value = "pains";
                                    workSheet["F30"].Style.Font.Bold = true;

                                    workSheet["E30"].Value = lotFrom.LOC11;
                                    workSheet["E30"].Style.Font.Bold = true;
                                    workSheet["E30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                    workSheet["G30"].Value = Math.Round((lotFrom.LOC11 / lotFrom.LOCEM1) * 100) + "%";
                                    workSheet["G30"].Style.Font.Bold = true;
                                    workSheet["G30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                }



                                if (lotFrom.LOC12 != 0)
                                {
                                    workSheet["B31"].Value = "- Catégorie B";
                                    workSheet["B31"].Style.Font.Bold = true;



                                    // Placez le total à 4 cellules en dessous de la dernière ligne remplie



                                    workSheet["C31"].Value = "………..";
                                    workSheet["C31"].Style.Font.Bold = true;
                                    workSheet["C31"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                    workSheet["F31"].Value = "pains";
                                    workSheet["F31"].Style.Font.Bold = true;

                                    workSheet["E31"].Value = lotFrom.LOC12;
                                    workSheet["E31"].Style.Font.Bold = true;
                                    workSheet["E31"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                    workSheet["G31"].Value = Math.Round((lotFrom.LOC12 / lotFrom.LOCEM1) * 100) + "%";
                                    workSheet["G31"].Style.Font.Bold = true;
                                    workSheet["G31"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                }
                                if (lotFrom.LOC13 != 0)
                                {
                                    workSheet["B32"].Value = "- Catégorie C";
                                    workSheet["B32"].Style.Font.Bold = true;

                                    workSheet["C32"].Value = "………..";
                                    workSheet["C32"].Style.Font.Bold = true;
                                    workSheet["C32"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                    workSheet["F32"].Value = "pains";
                                    workSheet["F32"].Style.Font.Bold = true;

                                    workSheet["E32"].Value = lotFrom.LOC13;
                                    workSheet["E32"].Style.Font.Bold = true;
                                    workSheet["E32"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                    workSheet["G32"].Value = Math.Round((lotFrom.LOC13 / lotFrom.LOCEM1) * 100) + "%";
                                    workSheet["G32"].Style.Font.Bold = true;
                                    workSheet["G32"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
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


                                workSheet["B34"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                                workSheet["B35"].Value = "salutations distinguées";
                                workSheet["E38"].Value = "Service Technique";
                                workSheet[$"E38"].Style.Font.Bold = true;


                                valeurPrecedente = lotFrom.FRNUM;

                            }

                            RangeColumn col0 = workSheet.GetColumn(0);
                            col0.Width = 3513; // Set width

                            RangeColumn col1 = workSheet.GetColumn(1);
                            col1.Width = 3513; // Set width

                            RangeColumn col2 = workSheet.GetColumn(2);
                            col2.Width = 3257; // Set width

                            RangeColumn col3 = workSheet.GetColumn(3);
                            col3.Width = 1134; // Set width

                            RangeColumn col4 = workSheet.GetColumn(4);
                            col4.Width = 2123; // Set width

                            RangeColumn col5 = workSheet.GetColumn(5);
                            col5.Width = 1647; // Set





                            // Configuration du style de la feuille (police, ...)
                            workSheet.Style.Font.Name = "Arial";



                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.InitialDirectory = @"C:\DIRECTORY\Documents\Classement\";
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
                            workbook.SaveAs(path);
                            workbook.Close();
                            workSheet.ClearContents();
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
                _lastPathSaved = GetLatestFilePath("E:/Dossier Dev/Informatique/Excel");
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
