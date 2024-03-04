using Gestcom.Classes;
using Gestcom.ModelAdo;
using GestcomWF.DataAccess;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Reflection.Metadata;

namespace GestcomWF.Views
{
    public partial class edit_pesee : Form
    {


        private string selectedFilePath = string.Empty;
        private string moisExcel = string.Empty;
        DataPath dataPath = new DataPath();

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

        private void Excel()
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
                objApp.Visible = false;
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                //objSheet = (Excel._Worksheet)objSheets.get_Item(1);


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
                            objSheet = objBook.Sheets.Add(Missing.Value, objBook.Worksheets[objBook.Worksheets.Count], Missing.Value, Missing.Value);
                            objSheet.Name = nomFeuille;

                            objSheet.Cells[7, "D"].Value = entreeLotFrom.FRNDIR;
                            objSheet.Cells[8, "D"].Value = "Président " + entreeLotFrom.FRNOM;
                            objSheet.Cells[9, "D"].Value = entreeLotFrom.FRADR;
                            objSheet.Cells[10, "D"].Value = entreeLotFrom.FRCPOS + " " + entreeLotFrom.FRVILL;

                            objSheet.Cells[15, "A"].Value = "      TB/PB";
                            objSheet.Cells[16, "D"].Value = "Le" + " " + formattedDate;

                            objSheet.Cells[21, "B"].Value = "Monsieur le Président";
                            objSheet.Cells[23, "B"].Value = "Nous vous prions de bien vouloir trouver ci-dessous, le détail des";
                            objSheet.Cells[24, "B"].Value = "pesées concernant vos fabrications de ";

                            objSheet.Cells[24, "E"].Value = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                            objSheet.Cells[24, "E"].Font.Bold = true;
                            //objSheet.Cells[24, "E"].Style.Font.Bold = true;



                            objSheet.Range["B27", "F27"].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["B27", "F27"].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["B27", "F27"].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;

                            objSheet.Columns[1].Columnwidth = 27.53;
                            objSheet.Columns[2].Columnwidth = 12.27;
                            objSheet.Columns[3].Columnwidth = 12.27;
                            objSheet.Columns[4].Columnwidth = 12.27;
                            objSheet.Columns[5].Columnwidth = 12.27;

                            objSheet.Cells.Font.Name = "Arial";


                            objSheet.Cells[27, "B"] = "Date";
                            objSheet.Cells[27, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;


                            //this.workSheet["B27:B35"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet["B27:B35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                            objSheet.Cells[28, "B"] = "Entrée";
                            objSheet.Cells[28, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Cells[27, "C"] = "Nombres";
                            objSheet.Cells[27, "C"].HorizontalAlignment = XlHAlign.xlHAlignCenter;



                            objSheet.Cells[28, "C"] = "Meules";
                            objSheet.Cells[28, "C"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Cells[27, "D"] = "Poids";
                            objSheet.Cells[27, "D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;



                            objSheet.Cells[28, "D"] = "brut";
                            objSheet.Cells[28, "D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Cells[27, "E"] = "%";
                            objSheet.Cells[27, "E"].HorizontalAlignment = XlHAlign.xlHAlignCenter;



                            objSheet.Cells[28, "E"] = "Réfaction";
                            objSheet.Cells[28, "E"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Cells[27, "F"] = "Poids";
                            objSheet.Cells[27, "F"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Cells[28, "F"] = "Net";
                            objSheet.Cells[28, "F"].HorizontalAlignment = XlHAlign.xlHAlignCenter;


                            objSheet.Range["B28", "F28"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["B28", "F28"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["B28", "F28"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;



                            // Initialisez la ligne actuelle
                            int currentRow = 30;


                            foreach (var dateEntry in entreeLotFroms.Where(item => item.FRNUM == entreeLotFrom.FRNUM))
                            {
                                // Remplissez les données pour chaque entrée de fromagerie

                                objSheet.Cells[currentRow, "B"] = dateEntry.Date_Entrée.ToString("dd/MM/yyyy");
                                objSheet.Cells[currentRow, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                objSheet.Cells[currentRow, "C"] = dateEntry.LOCENM;
                                objSheet.Cells[currentRow, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[currentRow, "C"].NumberFormat = "# ##0    ";

                                objSheet.Cells[currentRow, "D"] = dateEntry.LOCENB;
                                objSheet.Cells[currentRow, "D"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[currentRow, "D"].NumberFormat = "# ##0    ";


                                objSheet.Cells[currentRow, "E"] = dateEntry.LOTAUX.ToString("F2") + "%";
                                objSheet.Cells[currentRow, "E"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                objSheet.Cells[currentRow, "F"] = dateEntry.LOCENN;
                                objSheet.Cells[currentRow, "F"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                objSheet.Cells[currentRow, "F"].NumberFormat = "# ##0    ";



                                currentRow++;
                            }

                            int totalRow = currentRow + 2;

                            objSheet.Range[objSheet.Cells[totalRow, "B"], objSheet.Cells[totalRow - 1, "B"]].Merge();

                            objSheet.Cells[totalRow - 1, "B"] = "Totaux";

                            // Appliquer l'alignement horizontal et vertical au contenu
                            objSheet.Cells[totalRow - 1, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            objSheet.Cells[totalRow - 1, "B"].VerticalAlignment = XlHAlign.xlHAlignCenter;

                            // Ligne en bas du tableau

                            objSheet.Range[$"B{totalRow}", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range[$"B{totalRow}", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                            objSheet.Range[$"B{totalRow}", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                            objSheet.Range[objSheet.Cells[totalRow, "C"], objSheet.Cells[totalRow - 1, "C"]].Merge();
                            objSheet.Range[objSheet.Cells[totalRow, "F"], objSheet.Cells[totalRow - 1, "F"]].Merge();

                            
                            //var sumRange = objSheet.Cells[30, "C"][$"C{currentRow - 1}"];
                            objSheet.Cells[totalRow - 1, "C"].Formula = "=SUM(C29:" + $"C{currentRow - 1})";

                            objSheet.Cells[totalRow - 1, "C"].Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            objSheet.Cells[totalRow - 1, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                            objSheet.Cells[totalRow - 1, "C"].NumberFormat = "# ##0    ";
                            objSheet.Cells[totalRow - 1, "C"].VerticalAlignment = XlHAlign.xlHAlignCenter;

                  

                            objSheet.Range[$"C{totalRow - 1}", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range[$"C{totalRow - 1}", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                            objSheet.Range[$"C{totalRow - 1}", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;

                            //var sumRangePoidsNet = workSheet[$"F30:F{currentRow - 1}"];
                            objSheet.Cells[totalRow - 1, "F"].Formula = "=SUM(F29:" + $"F{currentRow - 1})";
                            objSheet.Cells[totalRow - 1, "F"].Font.Bold = true;

                            // Appliquer l'alignement horizontal et vertical au contenu
                            objSheet.Cells[totalRow - 1, "F"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                            objSheet.Cells[totalRow - 1, "F"].NumberFormat = "# ##0    ";
                            objSheet.Cells[totalRow - 1, "F"].VerticalAlignment = XlHAlign.xlHAlignCenter;

                            objSheet.Range[$"F{totalRow - 1}", $"F{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range[$"F{totalRow - 1}", $"F{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                            objSheet.Range[$"F{totalRow - 1}", $"F{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;





                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.SetColor("#000000");
                            //this.workSheet[$"B27:B{totalRow}"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                            // Bordure à droite de la colonne C
                            objSheet.Range["C27", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["C27", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["C27", $"C{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                            // Ligne à droite de la cellule D
                            objSheet.Range["D27", $"D{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["D27", $"D{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["D27", $"D{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                            // Ligne à droite de la colonne E
                            objSheet.Range["E27", $"E{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["E27", $"E{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["E27", $"E{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                            // Ligne à droite du tableau
                            objSheet.Range["F27", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["F27", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["F27", $"F{totalRow}"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                            // Bordure à gauche du tableau
                            objSheet.Range["B27", $"B{totalRow}"].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["B27", $"B{totalRow}"].Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["B27", $"B{totalRow}"].Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = 0;

                            // Bordure à droite de la colonne B
                            objSheet.Range["B27", $"B{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                            objSheet.Range["B27", $"B{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                            objSheet.Range["B27", $"B{currentRow + 2}"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;


                            objSheet.Cells[39, "B"] = "          Vous en souhaitant bonne réception";
                            objSheet.Cells[41, "B"] = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                            objSheet.Cells[42, "B"] = "salutations distinguées";
                            objSheet.Cells[45, "E"] = "Service Technique";
                            objSheet.Cells[45, "E"].Font.Bold = true;

                            valeurPrecedente = entreeLotFrom.FRNUM;
                        }

                    }
                    // Propose à l'utilisateur d'enregistrer le fichier Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                    saveFileDialog.Title = "Enregistrez le fichier sous...";
                    saveFileDialog.InitialDirectory = dataPath.PathPesee;
                    MessageBox.Show(saveFileDialog.InitialDirectory);
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
                        objBook.SaveAs(path);
                        objBook.Close();

                    }
                }
            }
        }

        // Gestionnaire de l'événement clic sur le bouton1
        private void button1_Click(object sender, EventArgs e)
        {

            Excel();




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

