using Gestcom.Classes;
using Gestcom.ModelAdo;
using IronXL;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace GestcomWF.Views
{
    public partial class edit_pesee : Form
    {


        private string selectedFilePath = string.Empty;
        private string moisExcel = string.Empty;

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

            AjusterAnnee();

        }

        private void cbxMois_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Gestionnaire de l'événement clic sur le bouton1
        private void button1_Click(object sender, EventArgs e)
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

                DateTime selectedDate = dtpDateExcel.Value;
                string formattedDate = selectedDate.ToString("dd MMMM yyyy");
                // Récupération de toutes les entrées pour le mois et l'année donnés
                List<EntreeLotFrom> entreeLotFroms = LotAdo.allEntreeEnFonctionDuMoisEtDeLannee(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (entreeLotFroms.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    string annee = (DateTime.Now.Year / 100).ToString();
                    // Traitement pour chaque entré
                    foreach (EntreeLotFrom entreeLotFrom in entreeLotFroms)
                    {
                        string nomFeuille = entreeLotFrom.FRNOM.Replace("/", "-");

                        // Si l'entrée a une nouvelle valeur FRNUM
                        if (entreeLotFrom.FRNUM != valeurPrecedente)
                        {

                            // Initialisation de la feuille Excel avec le nom adapté
                            workSheet = workbook.CreateWorkSheet(nomFeuille);
                            workSheet["D7"].Value = entreeLotFrom.FRNDIR;
                            workSheet["D8"].Value = "Président " + entreeLotFrom.FRNOM;
                            workSheet["D9"].Value = entreeLotFrom.FRADR;
                            workSheet["D10"].Value = entreeLotFrom.FRCPOS + " " + entreeLotFrom.FRVILL;
                            workSheet["A15"].Value = "      TB/PB";
                            workSheet["D16"].Value = "Le" + " " + formattedDate;
                            workSheet["B21"].Value = "Monsieur le Président";
                            workSheet["B23"].Value = "Nous vous prions de bien vouloir trouver ci-dessous, le détail des";
                            workSheet["B24"].Value = "pesées concernant vos fabrications de ";

                            workSheet["E24"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                            workSheet["E24"].Style.Font.Bold = true;


                            workSheet["B27:F27"].Style.TopBorder.SetColor("#000000");
                            workSheet["B27:F27"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            workSheet["B27"].Value = "Date";
                            workSheet["B27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            //this.workSheet["B27:B35"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet["B27:B35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                            workSheet["B28"].Value = "Entrée";
                            workSheet["B28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;


                            workSheet["C27"].Value = "Nombres";
                            workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            workSheet["C28"].Value = "Meules";
                            workSheet["C28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            workSheet["D27"].Value = "Poids";
                            workSheet["D27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            workSheet["D28"].Value = "brut";
                            workSheet["D28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            workSheet["E27"].Value = "%";
                            workSheet["E27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                            workSheet["E28"].Value = "Réfaction";
                            workSheet["E28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            workSheet["F27"].Value = "Poids";
                            workSheet["F27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                            workSheet["F28"].Value = "Net";
                            workSheet["F28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;




                            workSheet["B28:F28"].Style.BottomBorder.SetColor("#000000");
                            workSheet["B28:F28"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;


                            // Initialisez la ligne actuelle
                            int currentRow = 30;




                            foreach (var dateEntry in entreeLotFroms.Where(item => item.FRNUM == entreeLotFrom.FRNUM))
                            {
                                // Remplissez les données pour chaque entrée de fromagerie
                                workSheet[$"B{currentRow}"].Value = dateEntry.Date_Entrée;

                                workSheet[$"B{currentRow}"].FormatString = "dd/MM/yyyy";
                                workSheet[$"B{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                                workSheet[$"C{currentRow}"].Value = dateEntry.LOCENM;
                                workSheet[$"C{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                workSheet[$"C{currentRow}"].FormatString = "# ##0    "; ;

                                workSheet[$"D{currentRow}"].Value = dateEntry.LOCENB;
                                workSheet[$"D{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                workSheet[$"D{currentRow}"].FormatString = "# ##0    "; ;


                                workSheet[$"E{currentRow}"].Value = dateEntry.LOTAUX.ToString("F2") + "%";
                                workSheet[$"E{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                                workSheet[$"F{currentRow}"].Value = dateEntry.LOCENN;
                                workSheet[$"F{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                workSheet[$"F{currentRow}"].FormatString = "# ##0    ";



                                currentRow++;
                            }

                            int totalRow = currentRow + 2;

                            workSheet.Merge($"B{totalRow}:B{totalRow - 1}");
                            workSheet[$"B{totalRow - 1}"].Value = "Totaux";

                            // Appliquer l'alignement horizontal et vertical au contenu
                            workSheet[$"B{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                            workSheet[$"B{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            // Ligne en bas du tableau
                            workSheet[$"B{totalRow}:F{totalRow}"].Style.BottomBorder.SetColor("#000000");
                            workSheet[$"B{totalRow}:F{totalRow}"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;





                            workSheet.Merge($"C{totalRow}:C{totalRow - 1}");
                            workSheet.Merge($"F{totalRow}:F{totalRow - 1}");

                            var sumRange = workSheet[$"C30:C{currentRow - 1}"];
                            workSheet[$"C{totalRow - 1}"].Formula = "=SUM(C29:" + $"C{currentRow - 1})";

                            workSheet[$"C{totalRow - 1}"].Style.Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            workSheet[$"C{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                            workSheet[$"C{totalRow - 1}"].FormatString = "# ##0    ";
                            workSheet[$"C{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            workSheet[$"C{totalRow - 1}:C{currentRow + 2}"].Style.TopBorder.SetColor("#000000");
                            workSheet[$"C{totalRow - 1}:C{currentRow + 2}"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            var sumRangePoidsNet = workSheet[$"F30:F{currentRow - 1}"];
                            workSheet[$"F{totalRow - 1}"].Formula = "=SUM(F29:" + $"F{currentRow - 1})";
                            workSheet[$"F{totalRow - 1}"].Style.Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            workSheet[$"F{totalRow - 1}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                            workSheet[$"F{totalRow - 1}"].FormatString = "# ##0    ";
                            workSheet[$"F{totalRow - 1}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;

                            workSheet[$"F{totalRow - 1}:F{currentRow + 2}"].Style.TopBorder.SetColor("#000000");
                            workSheet[$"F{totalRow - 1}:F{currentRow + 2}"].Style.TopBorder.Type = IronXL.Styles.BorderType.Thin;

                            workSheet[$"C27:C{currentRow + 2}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"C27:C{currentRow + 2}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;



                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                            // Bordure à droite de la colonne C
                            workSheet[$"C27:C{currentRow + 2}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"C27:C{currentRow + 2}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite de la cellule D
                            workSheet[$"D27:D{currentRow + 2}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"D27:D{currentRow + 2}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite de la colonne E
                            workSheet[$"E27:E{currentRow + 2}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"E27:E{currentRow + 2}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Ligne à droite du tableau
                            workSheet[$"F27:F{totalRow}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"F27:F{totalRow}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Bordure à gauche du tableau
                            workSheet[$"B27:B{totalRow}"].Style.LeftBorder.SetColor("#000000");
                            workSheet[$"B27:B{totalRow}"].Style.LeftBorder.Type = IronXL.Styles.BorderType.Thin;

                            // Bordure à droite de la colonne B
                            workSheet[$"B27:B{currentRow + 2}"].Style.RightBorder.SetColor("#000000");
                            workSheet[$"B27:B{currentRow + 2}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Thin;


                            workSheet["B39"].Value = "          Vous en souhaitant bonne réception";
                            workSheet["B41"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                            workSheet["B42"].Value = "salutations distinguées";
                            workSheet["E45"].Value = "Service Technique";
                            workSheet[$"E45"].Style.Font.Bold = true;

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

                        // Configuration du style de la feuille (police, ...)
                        workSheet.Style.Font.Name = "Arial";

                    }
                    // Propose à l'utilisateur d'enregistrer le fichier Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                    saveFileDialog.Title = "Enregistrez le fichier sous...";
                    saveFileDialog.InitialDirectory = @"C:\DIRECTORY\Documents\Pesée\";
                    if (moisNum.Numero < 10)
                    {
                        moisExcel = "0" + moisNum.Numero;
                    }
                    else
                    {
                        moisExcel = moisNum.Numero.ToString();
                    }
                    saveFileDialog.FileName = "Pesées_" + tbxAnnee.Text + moisExcel + ".xls";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        workbook.SaveAs(path);
                        workbook.Close();

                    }
                }
            }
        }
        // Gestionnaire d'événement pour le clic sur le bouton d'impression Excel.
        private void printExcel_Click(object sender, EventArgs e)
        {
            // Appelle la méthode pour ouvrir, imprimer et fermer le fichier Excel.
            OuvrirImprimerFermerXLS();
        }
        private void OuvrirImprimerFermerXLS()
        {
            // Vérifie si un fichier a été sélectionné.
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                // Affiche un message si aucun fichier n'a été sélectionné.
                MessageBox.Show("Veuillez d'abord sélectionner un fichier.");
                return;
            }

            // Appelle la méthode pour imprimer toutes les feuilles du fichier Excel.
            PrintAllSheets(selectedFilePath);

        }



        // Permet à l'utilisateur de rechercher et de sélectionner un fichier Excel.
        private void RechercherXLS()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filtre les fichiers pour n'afficher que les fichiers Excel
                openFileDialog.Filter = "Excel files (*.xls; *.xlsx)|*.xls;*.xlsx";

                // Affiche la boîte de dialogue de sélection de fichier.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Stocke le chemin du fichier sélectionné.
                    selectedFilePath = openFileDialog.FileName;

                    // Affiche le chemin du fichier dans le TextBox.
                    tbxRecherche.Text = selectedFilePath.ToString();
                }
            }
        }

        // Gestionnaire d'événement pour le clic sur le bouton de recherche de fichier Excel.
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // Appelle la méthode pour permettre à l'utilisateur de rechercher un fichier Excel.
            RechercherXLS();
        }

        // Imprime toutes les feuilles de calcul du fichier Excel spécifié.
        private void PrintAllSheets(string filePath)
        {
            // Initialise les objets pour l'application Excel et le classeur.
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            try
            {
                // Parcourt et imprime chaque feuille du classeur.
                foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                {
                    worksheet.PrintOutEx();
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

        private void dtpDateExcel_ValueChanged(object sender, EventArgs e)
        {
            AjusterAnnee();
        }

        private void AjusterAnnee()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime moisPrecedent = dtpDateExcel.Value.AddMonths(-1);
            cbxMois.SelectedIndex = moisPrecedent.Month - 1;
            tbxAnnee.Text = Convert.ToString(moisPrecedent.Year % 100);
        }
    }
}

