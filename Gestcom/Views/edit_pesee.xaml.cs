using Gestcom.Classes;
using System.Collections.Generic;
using System.Windows;
using IronXL;
using Gestcom.Models;
using Gestcom.ModelAdo;
using System;
using System.Linq;

namespace Gestcom.Views
{
    /// <summary>
    /// Logique d'interaction pour edit_pesee.xaml
    /// </summary>
    public partial class edit_pesee : Window
    {
        WorkSheet workSheet;

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
            cbxMois.ItemsSource = listeObjets;
            cbxMois.DisplayMemberPath = "Mois";
            cbxMois.SelectedIndex = 8;

            tbxAnnee.Text = "23";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Decimal valeurPrecedente = 0;


            WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);
            MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
            Console.WriteLine(moisNum.Numero);
            List<EntreeLotFrom> entreeLotFroms = LotAdo.allEntreeEnFonctionDuMoisEtDeLannee(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
            foreach (EntreeLotFrom entreeLotFrom in entreeLotFroms)
            {
                Console.WriteLine(entreeLotFrom.FRNUM + " " + entreeLotFrom.Date_Entrée);
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
                    this.workSheet["E24"].Value = moisNum.Mois + " " + tbxAnnee.Text;
                    //this.workSheet["E24"].Value = moisNum.Mois + " " + DateTime.Now.Year.ToString(). + tbxAnnee.Text;
                    this.workSheet["E24"].Style.Font.Bold = true;

                    this.workSheet["B27:F27"].Style.TopBorder.SetColor("#000000");
                    this.workSheet["B27:F27"].Style.TopBorder.Type = IronXL.Styles.BorderType.Medium;

                    this.workSheet["B27"].Value = "Date";
                    this.workSheet["B27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["B27:B35"].Style.RightBorder.SetColor("#000000");
                    this.workSheet["B27:B35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                    this.workSheet["B28"].Value = "Entrée";
                    this.workSheet["B28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;


                    this.workSheet["C27"].Value = "Nombres";
                    this.workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["C27:C35"].Style.RightBorder.SetColor("#000000");
                    this.workSheet["C27:C35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                    this.workSheet["C28"].Value = "Meules";
                    this.workSheet["C28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["D27"].Value = "Poids";
                    this.workSheet["D27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["D27:D35"].Style.RightBorder.SetColor("#000000");
                    this.workSheet["D27:D35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                    this.workSheet["D28"].Value = "brut";
                    this.workSheet["D28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["E27"].Value = "%";
                    this.workSheet["E27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["E27:E35"].Style.RightBorder.SetColor("#000000");
                    this.workSheet["E27:E35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;

                    this.workSheet["E28"].Value = "Réfaction";
                    this.workSheet["E28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["F27"].Value = "Poids";
                    this.workSheet["F27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["F28"].Value = "Net";
                    this.workSheet["F28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                    this.workSheet["B35:F35"].Style.BottomBorder.SetColor("#000000");
                    this.workSheet["B35:F35"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Medium;


                    this.workSheet["B28:F28"].Style.BottomBorder.SetColor("#000000");
                    this.workSheet["B28:F28"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Medium;


                    // Initialisez la ligne actuelle
                    int currentRow = 30;
                    int endRow = currentRow + entreeLotFroms.Count();



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
                    workSheet[$"B{totalRow}"].Value = "Totaux";

                    var sumRange = workSheet[$"C30:C{currentRow - 1}"];
                    workSheet[$"C{totalRow}"].Value = sumRange.Sum();




                    this.workSheet["F27:F35"].Style.RightBorder.SetColor("#000000");
                    this.workSheet["F27:F35"].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                    this.workSheet["B27:B35"].Style.LeftBorder.SetColor("#000000");
                    this.workSheet["B27:B35"].Style.LeftBorder.Type = IronXL.Styles.BorderType.Medium;


                    this.workSheet["B39"].Value = "          Vous en souhaitant bonne réception";
                    this.workSheet["B41"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                    this.workSheet["B42"].Value = "salutations distinguées";
                    this.workSheet["E45"].Value = "Service Technique";

                    valeurPrecedente = entreeLotFrom.FRNUM;
                }

                RangeColumn col = workSheet.GetColumn(1);
                col.Width = 3000; // Set width

                RangeColumn col2 = workSheet.GetColumn(0);
                col2.Width = 7210; // Set width

                this.workSheet.Style.Font.Name = "Arial";

            }




            workbook.SaveAs(@"D:\example_workbook.xlsx");






        }
    }
}
