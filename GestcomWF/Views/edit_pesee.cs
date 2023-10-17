using Gestcom.Classes;
using Gestcom.ModelAdo;
using IronXL;
using System.Runtime.InteropServices;

namespace GestcomWF.Views
{
    public partial class edit_pesee : Form
    {
        WorkSheet workSheet;
        WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);

        private string selectedFilePath = string.Empty;

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
        public edit_pesee()
        {
            InitializeComponent();
            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";
            cbxMois.SelectedIndex = 1;

        }

        private void cbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");

            }
            else
            {

                Decimal valeurPrecedente = 0;



                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                List<EntreeLotFrom> entreeLotFroms = LotAdo.allEntreeEnFonctionDuMoisEtDeLannee(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (entreeLotFroms.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    /*this.workSheet = workbook.CreateWorkSheet("date");
               this.workSheet["B1"].Value = moisNum.Mois.ToUpper() + " " + tbxAnnee.Text;
               this.workSheet["B1"].FormatString = "MMMM yyyy";*/
                    string annee = (DateTime.Now.Year / 100).ToString();
                    foreach (EntreeLotFrom entreeLotFrom in entreeLotFroms)
                    {
                        string nomFeuille = entreeLotFrom.FRNOM.Replace("/", "-");



                        if (entreeLotFrom.FRNUM != valeurPrecedente)
                        {
                            this.workSheet = workbook.CreateWorkSheet(nomFeuille);
                            this.workSheet["D7"].Value = entreeLotFrom.FRNDIR;
                            this.workSheet["D8"].Value = "Président " + entreeLotFrom.FRNOM;
                            this.workSheet["D9"].Value = entreeLotFrom.FRADR;
                            this.workSheet["D10"].Value = entreeLotFrom.FRCPOS + " " + entreeLotFrom.FRVILL;
                            this.workSheet["A15"].Value = "      TB/PB";
                            this.workSheet["D16"].Value = "Le" + " " + DateTime.Now.ToString("D");
                            this.workSheet["B21"].Value = "Monsieur le Président";
                            this.workSheet["B23"].Value = "Nous vous prions de bien vouloir trouver ci-dessous, le détail des";
                            this.workSheet["B24"].Value = "pesées concernant vos fabrications de ";

                            this.workSheet["E24"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                            this.workSheet["E24"].Style.Font.Bold = true;


                            this.workSheet["B27:F27"].Style.TopBorder.SetColor("#000000");
                            this.workSheet["B27:F27"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            this.workSheet["B27"].Value = "Date";
                            this.workSheet["B27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            //this.workSheet["B27:B35"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet["B27:B35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                            this.workSheet["B28"].Value = "Entrée";
                            this.workSheet["B28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;


                            this.workSheet["C27"].Value = "Nombres";
                            this.workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            this.workSheet["C28"].Value = "Meules";
                            this.workSheet["C28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            this.workSheet["D27"].Value = "Poids";
                            this.workSheet["D27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            this.workSheet["D28"].Value = "brut";
                            this.workSheet["D28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            this.workSheet["E27"].Value = "%";
                            this.workSheet["E27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            this.workSheet["E28"].Value = "Réfaction";
                            this.workSheet["E28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            this.workSheet["F27"].Value = "Poids";
                            this.workSheet["F27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            this.workSheet["F28"].Value = "Net";
                            this.workSheet["F28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;




                            this.workSheet["B28:F28"].Style.BottomBorder.SetColor("#000000");
                            this.workSheet["B28:F28"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;


                            // Initialisez la ligne actuelle
                            int currentRow = 30;




                            foreach (var dateEntry in entreeLotFroms.Where(item => item.FRNUM == entreeLotFrom.FRNUM))
                            {
                                // Remplissez les données pour chaque entrée de fromagerie
                                workSheet[$"B{currentRow}"].Value = dateEntry.Date_Entrée;

                                this.workSheet[$"B{currentRow}"].FormatString = "dd/MM/yyyy";
                                this.workSheet[$"B{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                                workSheet[$"C{currentRow}"].Value = dateEntry.LOCENM;
                                this.workSheet[$"C{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                                workSheet[$"D{currentRow}"].Value = dateEntry.LOCENB;
                                this.workSheet[$"D{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                                workSheet[$"E{currentRow}"].Value = dateEntry.LOTAUX;
                                this.workSheet[$"E{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                                workSheet[$"F{currentRow}"].Value = dateEntry.LOCENN;
                                this.workSheet[$"F{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                                currentRow++;
                            }
                            // Placez le total à 4 cellules en dessous de la dernière ligne remplie


                            int totalRow = currentRow + 4;

                            workSheet.Merge($"B{totalRow}:B{totalRow - 1}");
                            workSheet[$"B{totalRow - 1}"].Value = "Totaux";

                            // Appliquer l'alignement horizontal et vertical au contenu
                            this.workSheet[$"B{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                            this.workSheet[$"B{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            // Ligne en bas du tableau
                            this.workSheet[$"B{totalRow}:F{totalRow}"].Style.BottomBorder.SetColor("#000000");
                            this.workSheet[$"B{totalRow}:F{totalRow}"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;





                            workSheet.Merge($"C{totalRow}:C{totalRow - 1}");
                            workSheet.Merge($"F{totalRow}:F{totalRow - 1}");

                            var sumRange = workSheet[$"C30:C{currentRow - 1}"];
                            workSheet[$"C{totalRow - 1}"].Value = sumRange.Sum();

                            this.workSheet[$"C{totalRow - 1}"].Style.Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            this.workSheet[$"C{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                            this.workSheet[$"C{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            this.workSheet[$"C{totalRow - 1}:C{currentRow + 4}"].Style.TopBorder.SetColor("#000000");
                            this.workSheet[$"C{totalRow - 1}:C{currentRow + 4}"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            var sumRangePoidsNet = workSheet[$"F30:F{currentRow - 1}"];
                            workSheet[$"F{totalRow - 1}"].Value = sumRangePoidsNet.Sum();

                            this.workSheet[$"F{totalRow - 1}"].Style.Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            this.workSheet[$"F{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                            this.workSheet[$"F{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            this.workSheet[$"F{totalRow - 1}:F{currentRow + 4}"].Style.TopBorder.SetColor("#000000");
                            this.workSheet[$"F{totalRow - 1}:F{currentRow + 4}"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            this.workSheet[$"C27:C{currentRow + 4}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"C27:C{currentRow + 4}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;



                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                            // Bordure à droite de la colonne C
                            this.workSheet[$"C27:C{currentRow + 4}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"C27:C{currentRow + 4}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite de la cellule D
                            this.workSheet[$"D27:D{currentRow + 4}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"D27:D{currentRow + 4}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite de la colonne E
                            this.workSheet[$"E27:E{currentRow + 4}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"E27:E{currentRow + 4}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite du tableau
                            this.workSheet[$"F27:F{totalRow}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"F27:F{totalRow}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Bordure à gauche du tableau
                            this.workSheet[$"B27:B{totalRow}"].Style.LeftBorder.SetColor("#000000");
                            this.workSheet[$"B27:B{totalRow}"].Style.LeftBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Bordure à droite de la colonne B
                            this.workSheet[$"B27:B{currentRow + 4}"].Style.RightBorder.SetColor("#000000");
                            this.workSheet[$"B27:B{currentRow + 4}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;


                            this.workSheet["B39"].Value = "          Vous en souhaitant bonne réception";
                            this.workSheet["B41"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                            this.workSheet["B42"].Value = "salutations distinguées";
                            this.workSheet["E45"].Value = "Service Technique";
                            this.workSheet[$"E45"].Style.Font.Bold = true;

                            valeurPrecedente = entreeLotFrom.FRNUM;
                        }



                        RangeColumn col0 = workSheet.GetColumn(0);
                        col0.Width = 7210; // Set width

                        RangeColumn col1 = workSheet.GetColumn(1);
                        col1.Width = 3300; // Set width

                        RangeColumn col2 = workSheet.GetColumn(2);
                        col2.Width = 3300; // Set width

                        RangeColumn col3 = workSheet.GetColumn(3);
                        col3.Width = 3300; // Set width

                        RangeColumn col4 = workSheet.GetColumn(4);
                        col4.Width = 3300; // Set width

                        RangeColumn col5 = workSheet.GetColumn(5);
                        col5.Width = 3300; // Set width


                        this.workSheet.Style.Font.Name = "Arial";

                    }
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                    saveFileDialog.Title = "Enregistrez le fichier sous...";
                    saveFileDialog.FileName = "saisie_pesee " + moisNum.Mois + ".xls";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;

                        workbook.SaveAs(@"D:\saisie_pesee " + moisNum.Mois + ".xls");
                        workbook.Close();

                    }
                }
            }


        }

        private void printExcel_Click(object sender, EventArgs e)
        {
            OuvrirImprimerFermerXLS();
        }
        private void OuvrirImprimerFermerXLS()
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Veuillez d'abord sélectionner un fichier.");
                return;
            }

            PrintAllSheets(selectedFilePath);

        }




        private void RechercherXLS()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xls; *.xlsx)|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    tbxRecherche.Text = selectedFilePath.ToString();
                }
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            RechercherXLS();
        }

        private void PrintAllSheets(string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            try
            {
                foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                {
                    worksheet.PrintOutEx();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la tentative d'impression: {ex.Message}");
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}

