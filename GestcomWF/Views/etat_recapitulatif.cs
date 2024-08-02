using Gestcom.Classes;
using Gestcom.ModelAdo;
using GestcomWF.DataAccess;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestcomWF.Classes;

namespace GestcomWF.Views
{
    public partial class etat_recapitulatif : Form
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
        public etat_recapitulatif()
        {
            InitializeComponent();
            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";
            cbxMois.SelectedIndex = 1;

            AjusterAnnee();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel();
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
                // Récupération de toutes les entrées pour le mois et l'année donnés
                List<EtatRecap> etatRecaps = LotAdo.EtatRecap(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (etatRecaps.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {

                    // Initialisation de la feuille Excel avec le nom adapté
                    objSheet = objBook.Sheets.Add(Missing.Value, objBook.Worksheets[objBook.Worksheets.Count], Missing.Value, Missing.Value);

                    string moisFeuille;

                    if (moisNum.Numero < 10)
                    {
                        moisFeuille = "0" + moisNum.Numero;
                    }
                    else
                    {
                        moisFeuille = moisNum.Numero.ToString();
                    }

                    objSheet.Name = moisFeuille + " " + tbxAnnee.Text;

                    objSheet.Columns[1].Columnwidth = 0;
                    objSheet.Columns[2].Columnwidth = 26.56;
                    objSheet.Columns[3].Columnwidth = 7.71;
                    objSheet.Columns[4].Columnwidth = 11.43;
                    objSheet.Columns[5].Columnwidth = 7.57;
                    objSheet.Columns[6].Columnwidth = 9.57;
                    objSheet.Columns[7].Columnwidth = 9.57;
                    objSheet.Columns[8].Columnwidth = 9.57;
                    objSheet.Columns[9].Columnwidth = 9.29;
                    objSheet.Columns[10].Columnwidth = 9.57;
                    objSheet.Columns[11].Columnwidth = 9.86;
                    objSheet.Columns[12].Columnwidth = 14.71;
                    objSheet.Columns[13].Columnwidth = 11.14;
                    objSheet.Columns[14].Columnwidth = 1.14;
                    objSheet.Columns[15].Columnwidth = 0.75;

                    objSheet.Rows[1].Rowheight = 12.60;
                    objSheet.Rows[2].Rowheight = 18.30;
                    objSheet.Rows[3].Rowheight = 30.60;
                    objSheet.Rows[4].Rowheight = 18;

                    objSheet.Cells.Font.Name = "Arial";
                    objSheet.Cells.Font.Size = 10;

                    objSheet.Cells[2, "D"].Value = "CLASSEMENT/REGLEMENT DE FABRICATION :";
                    objSheet.Cells[2, "D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    objSheet.Cells[2, "D"].VerticalAlignment = XlVAlign.xlVAlignCenter;
                    objSheet.Cells[2, "D"].Font.Bold = true;


                    objSheet.Range["I2", "K2"].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["I2", "K2"].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium;
                    objSheet.Range["I2", "K2"].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;

                    objSheet.Cells[2, "I"].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[2, "I"].Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlMedium;
                    objSheet.Cells[2, "I"].Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = 0;

                    objSheet.Cells[2, "K"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[2, "K"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                    objSheet.Cells[2, "K"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    int color = HexToColor("#FFCC99");
                    objSheet.Range["I2", "K2"].Interior.Color = color;

                    int year = DateTime.Now.Year;
                    string firstTwoDigits = year.ToString().Substring(0, 2);

                    int colorText = HexToColor("#FF0000");
                    objSheet.Cells[2, "I"].Value = "     " + moisNum.Mois.ToUpper() + "     " + firstTwoDigits[0] + " " + firstTwoDigits[1] + " " + tbxAnnee.Text[0] + " " + tbxAnnee.Text[1];
                    objSheet.Cells[2, "I"].Font.Color = colorText;
                    objSheet.Cells[2, "I"].Font.Bold = true;
                    objSheet.Cells[2, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[2, "I"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Range["B4", "M4"].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["B4", "M4"].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium;
                    objSheet.Range["B4", "M4"].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;

                    objSheet.Range["M4", "M5"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["M4", "M5"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                    objSheet.Range["M4", "M5"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;


                    objSheet.Range["B4", "B5"].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["B4", "B5"].Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlMedium;
                    objSheet.Range["B4", "B5"].Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = 0;

                    objSheet.Cells[4, "B"].Value = "SOCIETES";
                    objSheet.Cells[4, "B"].Font.Bold = true;
                    objSheet.Cells[4, "B"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "B"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "C"].Value = "    COLLECTE";
                    objSheet.Cells[4, "C"].Font.Bold = true;
                    objSheet.Cells[4, "C"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "C"].Value = "  PAINS";
                    objSheet.Cells[5, "C"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "C"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "D"].Value = "   POIDS";
                    objSheet.Cells[5, "D"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "D"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "E"].Value = "    QUALITE A";
                    objSheet.Cells[4, "E"].Font.Bold = true;
                    objSheet.Cells[4, "E"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "E"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "E"].Value = "  PAINS";
                    objSheet.Cells[5, "E"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "E"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "F"].Value = "   POIDS";
                    objSheet.Cells[5, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "F"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "G"].Value = "  %";
                    objSheet.Cells[4, "G"].Font.Bold = true;
                    objSheet.Cells[4, "G"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "G"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "G"].Value = "QUAL.A";
                    objSheet.Cells[5, "G"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "G"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "H"].Value = "    QUALITE B";
                    objSheet.Cells[4, "H"].Font.Bold = true;
                    objSheet.Cells[4, "H"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "H"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "H"].Value = "  PAINS";
                    objSheet.Cells[5, "H"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "H"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "I"].Value = "   POIDS";
                    objSheet.Cells[5, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "I"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "J"].Value = "    QUALITE C";
                    objSheet.Cells[4, "J"].Font.Bold = true;
                    objSheet.Cells[4, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "J"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "J"].Value = "  PAINS";
                    objSheet.Cells[5, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "J"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "K"].Value = "   POIDS";
                    objSheet.Cells[5, "K"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "K"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "L"].Value = "   REGLEMENT";
                    objSheet.Cells[4, "L"].Font.Bold = true;
                    objSheet.Cells[4, "L"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "L"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "L"].Value = "TOTAL";
                    objSheet.Cells[5, "L"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "L"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[4, "M"].Value = " PRIX";
                    objSheet.Cells[4, "M"].Font.Bold = true;
                    objSheet.Cells[4, "M"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[4, "M"].VerticalAlignment = XlVAlign.xlVAlignCenter;

                    objSheet.Cells[5, "M"].Value = "AU KG";
                    objSheet.Cells[5, "M"].Font.Bold = true;
                    objSheet.Cells[5, "M"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[5, "M"].VerticalAlignment = XlVAlign.xlVAlignCenter;


                    objSheet.Range["B5", "M5"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["B5", "M5"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                    objSheet.Range["B5", "M5"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                    objSheet.Cells[7, "C"].Value = "MPN";
                    objSheet.Cells[7, "C"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[7, "C"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                    objSheet.Cells[7, "D"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                    objSheet.Cells[7, "F"].Value = "Coef Valeur :";
                    objSheet.Cells[7, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[7, "F"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                    objSheet.Cells[7, "H"].FormulaLocal = "=+M25/D7";
                    objSheet.Cells[7, "H"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                    objSheet.Cells[7, "H"].NumberFormat = "###,##%";

                    objSheet.Cells[7, "J"].Value = "Marge";
                    objSheet.Cells[7, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[7, "J"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                    objSheet.Cells[7, "K"].FormulaLocal = "=+(D7-M25)/D7";
                    objSheet.Cells[7, "K"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                    objSheet.Cells[7, "K"].NumberFormat = "###,##%";

                    objSheet.Cells[7, "L"].Value = "%";
                    objSheet.Cells[7, "L"].HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    objSheet.Cells[7, "L"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                    int cellNomFromFirst = 11;
                    int cellNomFrom = 11;

                    int colorTextTab = HexToColor("#0000FF");

                    int fondColorTab = HexToColor("#969696");

                    //string annee = (DateTime.Now.Year / 100).ToString();
                    // Traitement pour chaque entré
                    foreach (EtatRecap etatRecap in etatRecaps)
                    {
                        objSheet.Range["D" + (cellNomFrom - 1), "E" + (cellNomFrom + 1)].Interior.Color = fondColorTab;
                        objSheet.Range["H" + (cellNomFrom - 1), "H" + (cellNomFrom + 1)].Interior.Color = fondColorTab;
                        objSheet.Range["J" + (cellNomFrom - 1), "J" + (cellNomFrom + 1)].Interior.Color = fondColorTab;


                        objSheet.Cells[cellNomFrom, "B"].Value = etatRecap.FRNOM;
                        objSheet.Cells[cellNomFrom, "B"].Font.Bold = true;
                        objSheet.Cells[cellNomFrom, "B"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                        objSheet.Cells[cellNomFrom, "C"].Value = etatRecap.LOCEM1;
                        objSheet.Cells[cellNomFrom, "C"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "C"].Font.Color = colorTextTab;

                        objSheet.Cells[cellNomFrom, "D"].Value = etatRecap.LOCEN1;
                        objSheet.Cells[cellNomFrom, "D"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                        objSheet.Cells[cellNomFrom, "E"].Value = etatRecap.LOC11;
                        objSheet.Cells[cellNomFrom, "E"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                        objSheet.Cells[cellNomFrom, "F"].FormulaLocal = "=D" + cellNomFrom + "-I" + cellNomFrom + "-K" + cellNomFrom;
                        objSheet.Cells[cellNomFrom, "F"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "F"].Font.Color = colorTextTab;

                        objSheet.Cells[cellNomFrom, "G"].FormulaLocal = "=ARRONDI(E" + cellNomFrom + "/C" + cellNomFrom + "*100;2)";
                        objSheet.Cells[cellNomFrom, "G"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "G"].Font.Color = colorTextTab;
                        objSheet.Cells[cellNomFrom, "G"].NumberFormat = "0,00";


                        objSheet.Cells[cellNomFrom, "H"].Value = etatRecap.LOC12;
                        objSheet.Cells[cellNomFrom, "H"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                        objSheet.Cells[cellNomFrom, "I"].FormulaLocal = "=ARRONDI(+H" + cellNomFrom + "/$C" + cellNomFrom + "*$D" + cellNomFrom + ";0)";
                        objSheet.Cells[cellNomFrom, "I"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "I"].Font.Color = colorTextTab;

                        objSheet.Cells[cellNomFrom, "J"].Value = etatRecap.LOC13;
                        objSheet.Cells[cellNomFrom, "J"].VerticalAlignment = XlVAlign.xlVAlignBottom;

                        objSheet.Cells[cellNomFrom, "K"].FormulaLocal = "=ARRONDI(+J" + cellNomFrom + "/$C" + cellNomFrom + "*$D" + cellNomFrom + ";0)";
                        objSheet.Cells[cellNomFrom, "K"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "K"].Font.Color = colorTextTab;

                        objSheet.Cells[cellNomFrom, "L"].Value = etatRecap.MONTANT;
                        objSheet.Cells[cellNomFrom, "L"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "L"].NumberFormat = @"#\ ##0,00 €";

                        objSheet.Cells[cellNomFrom, "M"].FormulaLocal = "=ARRONDI(L" + cellNomFrom + "/D" + cellNomFrom + ";2)";
                        objSheet.Cells[cellNomFrom, "M"].VerticalAlignment = XlVAlign.xlVAlignBottom;
                        objSheet.Cells[cellNomFrom, "M"].NumberFormat = @"#\ ##0,00 €";


                        cellNomFrom = cellNomFrom + 2;

                    }

                    int finalCell = cellNomFrom + 1;

                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeTop].ColorIndex = 0;


                    objSheet.Cells[finalCell, "B"].Value = "TOTAL";
                    objSheet.Cells[finalCell, "B"].Font.Bold = true;

                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "B"].Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = 0;

                    objSheet.Cells[finalCell, "C"].FormulaLocal = "=SOMME(C" + cellNomFromFirst + ":C" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "C"].Font.Bold = true;

                    objSheet.Cells[finalCell, "C"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "C"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "C"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "D"].FormulaLocal = "=SOMME(D" + cellNomFromFirst + ":D" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "D"].Font.Bold = true;

                    objSheet.Cells[finalCell, "D"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "D"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "D"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "E"].FormulaLocal = "=SOMME(E" + cellNomFromFirst + ":E" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "E"].Font.Bold = true;

                    objSheet.Cells[finalCell, "E"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "E"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "E"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "F"].FormulaLocal = "=SOMME(F" + cellNomFromFirst + ":F" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "F"].Font.Bold = true;

                    objSheet.Cells[finalCell, "F"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "F"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "F"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "G"].FormulaLocal = "=ARRONDI(E" + finalCell + "/C" + finalCell + "*100;0)";
                    objSheet.Cells[finalCell, "G"].Font.Bold = true;


                    objSheet.Cells[finalCell, "G"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "G"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "G"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "H"].FormulaLocal = "=SOMME(H" + cellNomFromFirst + ":H" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "H"].Font.Bold = true;

                    objSheet.Cells[finalCell, "H"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "H"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "H"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "I"].FormulaLocal = "=SOMME(I" + cellNomFromFirst + ":I" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "I"].Font.Bold = true;

                    objSheet.Cells[finalCell, "I"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "I"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "I"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "J"].FormulaLocal = "=SOMME(J" + cellNomFromFirst + ":J" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "J"].Font.Bold = true;

                    objSheet.Cells[finalCell, "J"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "J"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "J"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "K"].FormulaLocal = "=SOMME(K" + cellNomFromFirst + ":K" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "K"].Font.Bold = true;
                    double somme = objSheet.Cells[finalCell, "K"].Value;
                    if (somme == 0)
                    {
                        objSheet.Cells[finalCell, "K"].Value = "-";
                        objSheet.Cells[finalCell, "K"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        objSheet.Cells[finalCell, "K"].Font.Bold = true;
                    }
                    objSheet.Cells[finalCell, "K"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "K"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "K"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "L"].FormulaLocal = "=SOMME(L" + cellNomFromFirst + ":L" + cellNomFrom + ")";
                    objSheet.Cells[finalCell, "L"].NumberFormat = @"#\ ##0,00 €";
                    objSheet.Cells[finalCell, "L"].Font.Bold = true;

                    objSheet.Cells[finalCell, "L"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "L"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "L"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Cells[finalCell, "M"].FormulaLocal = "=ARRONDI(L" + finalCell + "/D" + finalCell + "*1000;2)";
                    objSheet.Cells[finalCell, "M"].NumberFormat = @"#\ ##0,00 €";
                    objSheet.Cells[finalCell, "M"].Font.Bold = true;

                    objSheet.Cells[finalCell, "M"].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Cells[finalCell, "M"].Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
                    objSheet.Cells[finalCell, "M"].Borders[XlBordersIndex.xlEdgeRight].ColorIndex = 0;

                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                    objSheet.Range["B" + finalCell, "M" + finalCell].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                    int colorTotal = HexToColor("#FFFF99");
                    objSheet.Range["B" + finalCell, "M" + finalCell].Interior.Color = colorTotal;


                    try
                    {
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        string initialDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataPath.PathReglement));
                        saveFileDialog.InitialDirectory = initialDir;
                        if (moisNum.Numero < 10)
                        {
                            moisExcel = "0" + moisNum.Numero;
                        }
                        else
                        {
                            moisExcel = moisNum.Numero.ToString();
                        }
                        saveFileDialog.FileName = "Règlements_" + tbxAnnee.Text + moisExcel + ".xlsx";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;
                            objBook.SaveAs(path);
                            objBook.Close(false, Missing.Value, Missing.Value);
                            objApp.Quit();

                            // Nettoyer les interfaces COM
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheets);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(objBooks);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp);

                            objSheets = null;
                            objBook = null;
                            objBooks = null;
                            objApp = null;

                            // Forcer la collecte des objets non référencés
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = path,
                                UseShellExecute = true
                            };
                            System.Diagnostics.Process.Start(psi);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la création ou de l'enregistrement du fichier : " + ex.Message);
                    }
                }
            }
        }

        private void AjusterAnnee()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime dateTime = DateTime.Now;
            cbxMois.SelectedIndex = dateTime.Month - 1;
            tbxAnnee.Text = Convert.ToString(dateTime.Year % 100);
        }

        static int HexToColor(string hex)
        {
            // Remove the # at the front if it's there
            hex = hex.Replace("#", "");

            // Convert hex to an integer
            int argb = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            // Excel uses BGR (Blue, Green, Red) format, so we need to convert ARGB to BGR
            int blue = (argb & 0xFF) << 16;
            int green = argb & 0xFF00;
            int red = (argb & 0xFF0000) >> 16;

            return blue | green | red;
        }

        private void PrintAllSheets(string filePath)
        {
            // Initialise les objets pour l'application Excel et le classeur.
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            try
            {
                // Parcourir chaque feuille pour configurer l'orientation en paysage
                foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in workbook.Sheets)
                {
                    sheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;

                    // Réduction des marges (exemple de 0.5 pouce pour chaque marge)
                    sheet.PageSetup.TopMargin = excelApp.CentimetersToPoints(2.5);
                    sheet.PageSetup.BottomMargin = excelApp.CentimetersToPoints(2.5);
                    sheet.PageSetup.LeftMargin = excelApp.CentimetersToPoints(0.5);
                    sheet.PageSetup.RightMargin = excelApp.CentimetersToPoints(0.5);
                    sheet.PageSetup.FooterMargin = excelApp.CentimetersToPoints(1.3);
                    sheet.PageSetup.HeaderMargin = excelApp.CentimetersToPoints(1.3);

                    // Ajuster la feuille pour tenir sur une seule page
                    sheet.PageSetup.FitToPagesWide = 1;
                    sheet.PageSetup.FitToPagesTall = 1;

                    // Désactiver le zoom (au cas où)
                    sheet.PageSetup.Zoom = false;

                    // Configurer la taille de la page
                    sheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;

                }

                // Configure les paramètres d'impression pour Microsoft Print to PDF
                excelApp.PrintCommunication = false;
                excelApp.ActiveWorkbook.PrintOutEx(
                    From: 1,
                    To: workbook.Sheets.Count,
                    Copies: 1,
                    Preview: false,
                    PrintToFile: true,
                    Collate: true
                    
                    
                );
                excelApp.PrintCommunication = true;
            }
            catch (Exception ex)
            {
                // Affiche un message d'erreur en cas de problème lors de l'impression.
                MessageBox.Show($"Une erreur est survenue lors de la tentative d'impression: {ex.Message}");
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();

                // Nettoyer les interfaces COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                excelApp = null;
                workbook = null;

                // Forcer la collecte des objets non référencés
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
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
                string initialDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataPath.PathReglement));
                openFileDialog.InitialDirectory = initialDir;
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

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // Appelle la méthode pour permettre à l'utilisateur de rechercher un fichier Excel.
            RechercherXLS();
        }

        private void printExcel_Click(object sender, EventArgs e)
        {
            // Appelle la méthode pour ouvrir, imprimer et fermer le fichier Excel.
            OuvrirImprimerFermerXLS();
        }
    }
}
