using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using GestcomWF.DataAccess;
using System.Globalization;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using IronXL;

namespace GestcomWF.Views
{
    public partial class saisie_rappel : Form
    {
        private Lot _currentLot = null;
        private decimal testMontant = 0m;
        private decimal _currentMontant = 0m;
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
        public saisie_rappel()
        {
            InitializeComponent();
            InitializeDataGridView();

            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";
            cbxMois.SelectedIndex = 0;
            // Initialiser le DataGridView sans source de données
            dataGridView.DataSource = null;
            tbxNumFromagerie.Enabled = false;
            dataGridView.DefaultCellStyle.Format = "0";
            dataGridView.Columns[4].DefaultCellStyle.Format = "N5";
            dataGridView.Columns[6].DefaultCellStyle.Format = "N5";
            dataGridView.Columns[8].DefaultCellStyle.Format = "N5";
            dataGridView.Columns[9].DefaultCellStyle.Format = "N2";
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            AjusterAnnee();

            GenererValeurs();

        }

        public decimal CustomParse(string incomingValue)
        {
            decimal val;
            if (!decimal.TryParse(incomingValue.Replace(".", "").Replace(",", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))
                return 0;
            return val / 100;
        }
        private void btn_valider_Click(object sender, EventArgs e)
        {

            decimal a, b, c;


            if (decimal.TryParse(tbx_a.Text, out a) && decimal.TryParse(tbx_b.Text, out b) && decimal.TryParse(tbx_c.Text, out c))
            {

                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                if (_currentLot == null)
                {
                    MessageBox.Show("Veuillez sélectionner un lot");
                }

                else if (!IsNonNegativeNumber(tbx_a.Text) || !IsNonNegativeNumber(tbx_b.Text) || !IsNonNegativeNumber(tbx_c.Text))
                {
                    MessageBox.Show("Veuillez entrer des nombres valides dans chaque champ.");
                    return;
                }

                else
                {
                    var montant = ((_currentLot.LOC11 * Convert.ToDecimal(tbx_a.Text) + _currentLot.LOC12 * Convert.ToDecimal(tbx_b.Text) + _currentLot.LOC13 * Convert.ToDecimal(tbx_c.Text)) / _currentLot.LOCEM1) * _currentLot.LOCEN1;
                    double valueA = Convert.ToDouble(a);
                    double valueB = Convert.ToDouble(b);
                    double valueC = Convert.ToDouble(c);
                    LotAdo.updateLotRappel(_currentLot.LOFROM, Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero, Math.Round(valueA, 5), Math.Round(valueB, 5), Math.Round(valueC, 5), Convert.ToDouble(Math.Round(montant, 2)));
                    this._currentLot.LOPU1 = Math.Round(a, 5);
                    this._currentLot.LOPU2 = Math.Round(b, 5);
                    this._currentLot.LOPU3 = Math.Round(c, 5);
                    this._currentLot.MONTANT = montant;
                    _currentLot = null;
                    tbx_a.Text = "";
                    tbx_b.Text = "";
                    tbx_c.Text = "";
                    tbx_total.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Ce n'est pas un decimal !");
            }
            dataGridView.Refresh();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) // Assurez-vous que le double-clic n'est pas sur l'en-tête
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (row != null && row.DataBoundItem is Lot lot)
            {
                tbx_total.Text = lot.LOCEM1.ToString();
                tbx_a.Text = lot.LOPU1.ToString();
                tbx_b.Text = lot.LOPU2.ToString();
                tbx_c.Text = lot.LOPU3.ToString();
                tbxNumFromagerie.Text = lot.LOFROM.ToString();

                this._currentLot = lot;
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                _currentMontant = Math.Round(LotAdo.MontantLot(_currentLot.LOFROM, Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero), 2);
                tbxMontant.Text = _currentMontant.ToString();
                // Assignez d'autres propriétés de l'objet `lot` à d'autres TextBox si nécessaire
            }
        }

        /*private void buttonGenerer_Click(object sender, EventArgs e)
        {
            decimal annee;
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");
            }
            if (decimal.TryParse(tbxAnnee.Text, out annee))
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLotRappel(annee, moisNum.Numero);
                if (lots == null || lots.Count == 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    dataGridView.DataSource = lots;

                }
            }
            else
            {

                MessageBox.Show("Veuillez entrer un nombre");

            }
        }*/
        private void GenererValeurs()
        {
            decimal annee;
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {

            }
            if (decimal.TryParse(tbxAnnee.Text, out annee))
            {
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;
                List<Lot> lots = LotAdo.allLotRappel(annee, moisNum.Numero);
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



        // Fonction pour vérifier si une chaîne est un nombre non négatif
        private bool IsNonNegativeNumber(string text)
        {
            decimal parsedValue;
            parsedValue = Convert.ToDecimal(text);
            if (parsedValue < 0)
            {
                return false;
            }
            else if (decimal.TryParse(text, out parsedValue))
            {
                return parsedValue >= 0;  // Retourne vrai si le nombre est non négatif
            }
            return false;
        }

        private void generate_excel_Click(object sender, EventArgs e)
        {
            try
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

                    Decimal valeurPrecedente = 0;


                    // Récupération du mois sélectionné depuis la comboBox
                    MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;


                    decimal moisNumValue = moisNum.Numero;
                    decimal anneeValue = Convert.ToDecimal(tbxAnnee.Text);

                    DateTime selectedDate = dtpDate.Value;
                    string formattedDate = selectedDate.ToString("dd MMMM yyyy");


                    string nomMoisDecale = "";
                    decimal moisDecale = 0;

                    // Récupération de toutes les entrées pour le mois et l'année donnés
                    List<LotFrom> lotFroms = LotAdo.generationFichierExcelRappel(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                    if (lotFroms == null || lotFroms.Count <= 0)
                    {
                        MessageBox.Show("Aucune valeur");
                    }
                    else
                    {
                        decimal poidsMoyen = 0;
                        decimal acompte = 0;
                        string annee = (DateTime.Now.Year / 100).ToString();
                        bool anneeDejaReduite = false;

                        // Traitement pour chaque entré
                        foreach (LotFrom lotFrom in lotFroms)
                        {

                            if (lotFrom.FACTURATION == -5)
                            {
                                moisDecale = moisNumValue;
                            }
                            else if (lotFrom.FACTURATION == -6)
                            {
                                moisDecale = moisNumValue - 1;
                            }

                            if (moisDecale <= 0)
                            {
                                moisDecale += 12;
                                if (!anneeDejaReduite)
                                {
                                    anneeValue -= 1;
                                    anneeDejaReduite = true;
                                }
                            }

                            MoisNum moisDecaleValue = listeObjets.FirstOrDefault(m => m.Numero == moisDecale);

                            if (moisDecaleValue != null)
                            {
                                // Utilisez moisDecale.Mois pour obtenir le nom du mois décalé
                                nomMoisDecale = moisDecaleValue.Mois;
                                // Vous pouvez maintenant utiliser nomMoisDecale pour vos besoins
                            }

                            poidsMoyen = lotFrom.LOCEN1 / lotFrom.LOCEM1;
                            acompte = lotFrom.LOPUAC * lotFrom.LOCEN1;
                            string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                            // Si l'entrée a une nouvelle valeur FRNUM
                            if (lotFrom.FRNUM != valeurPrecedente)
                            {
                                // Initialisation de la feuille Excel avec le nom adapté
                                objSheet = objBook.Sheets.Add(Missing.Value, objBook.Worksheets[objBook.Worksheets.Count], Missing.Value, Missing.Value);
                                objSheet.Name = nomFeuille;

                                objSheet.Cells[8, "F"].Value = lotFrom.FRNDIR;
                                objSheet.Cells[9, "F"].Value = lotFrom.FRNOM;
                                objSheet.Cells[10, "F"].Value = lotFrom.FRADR;
                                objSheet.Cells[11, "F"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;

                                objSheet.Cells[16, "A"].Value = "      TB/PB";
                                objSheet.Cells[16, "G"].Value = "Le" + " " + formattedDate;
                                objSheet.Cells[20, "B"].Value = "Monsieur le Président";
                                objSheet.Cells[22, "B"].Value = "          Conformément à nos conditions d'achat, le décompte de votre";
                                objSheet.Cells[23, "B"].Value = "lot de fabrication " + nomMoisDecale.ToUpper() + " " + annee + anneeValue + " s'établit comme suit :";

                                /* this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                 this.workSheet["F27"].Style.Font.Bold = true;*/


                                // Initialisez la ligne actuelle

                                //int currentRow = 30;
                                if (lotFrom.LOC11 != 0)
                                {
                                    objSheet.Cells[25, "B"].Value = "A";
                                    objSheet.Cells[25, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[25, "C"].Value = lotFrom.LOC11;
                                    objSheet.Cells[25, "C"].Font.Bold = true;
                                    objSheet.Cells[25, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[25, "D"].Value = "pains";

                                    objSheet.Cells[25, "E"].Value = Math.Round((poidsMoyen * lotFrom.LOC11) / 1000, 3);
                                    objSheet.Cells[25, "E"].Font.Bold = true;
                                    objSheet.Cells[25, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[25, "E"].NumberFormat = @"#\ ##0,00€";

                                    objSheet.Cells[25, "F"].Value = "T";
                                    objSheet.Cells[25, "F"].Font.Bold = true;
                                    objSheet.Cells[25, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[25, "G"].Value = "x";
                                    objSheet.Cells[25, "G"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[25, "H"].Value = Math.Round(lotFrom.LOPU1 * 1000, 2);
                                    objSheet.Cells[25, "H"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[25, "H"].NumberFormat = @"#\ ##0,00 ";

                                    objSheet.Cells[25, "I"].Value = "€/T";
                                    objSheet.Cells[25, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[25, "J"].Value = " =";
                                    objSheet.Cells[25, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;


                                    objSheet.Cells[25, "K"].Value = Math.Round((poidsMoyen * lotFrom.LOC11) * lotFrom.LOPU1, 2);
                                    objSheet.Cells[25, "K"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[25, "K"].NumberFormat = @"#\ ##0,00€";

                                }



                                if (lotFrom.LOC12 != 0)
                                {
                                    objSheet.Cells[26, "B"].Value = "B";
                                    objSheet.Cells[26, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[26, "C"].Value = lotFrom.LOC12;
                                    objSheet.Cells[26, "C"].Font.Bold = true;
                                    objSheet.Cells[26, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[26, "D"].Value = "pains";

                                    objSheet.Cells[26, "E"].Value = Math.Round(poidsMoyen * lotFrom.LOC12 / 1000, 3);
                                    objSheet.Cells[26, "E"].Font.Bold = true;
                                    objSheet.Cells[26, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[26, "E"].NumberFormat = @"#\ ##0,000";


                                    objSheet.Cells[26, "F"].Value = "T";
                                    objSheet.Cells[26, "F"].Font.Bold = true;
                                    objSheet.Cells[26, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[26, "G"].Value = "x";
                                    objSheet.Cells[26, "G"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[26, "H"].Value = Math.Round(lotFrom.LOPU2 * 1000, 2);
                                    objSheet.Cells[26, "H"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[26, "H"].NumberFormat = @"#\ ##0,00 ";

                                    objSheet.Cells[26, "I"].Value = "€/T";
                                    objSheet.Cells[26, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[26, "J"].Value = " =";
                                    objSheet.Cells[26, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[26, "K"].Value = Math.Round((poidsMoyen * lotFrom.LOC12) * lotFrom.LOPU2, 2);
                                    objSheet.Cells[26, "K"].HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    objSheet.Cells[26, "K"].NumberFormat = "# ##0.00€";


                                }
                                if (lotFrom.LOC13 != 0)
                                {
                                    objSheet.Cells[27, "B"].Value = "C";
                                    objSheet.Cells[27, "B"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[27, "C"].Value = lotFrom.LOC13;
                                    objSheet.Cells[27, "C"].Font.Bold = true;
                                    objSheet.Cells[27, "C"].HorizontalAlignment = XlHAlign.xlHAlignRight;


                                    objSheet.Cells[27, "D"].Value = "pains";

                                    objSheet.Cells[27, "E"].Value = Math.Round(poidsMoyen * lotFrom.LOC13 / 1000, 3);
                                    objSheet.Cells[27, "E"].Font.Bold = true;
                                    objSheet.Cells[27, "E"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[27, "E"].NumberFormat = @"#\ ##0,000";

                                    objSheet.Cells[27, "F"].Value = "T";
                                    objSheet.Cells[27, "F"].Font.Bold = true;
                                    objSheet.Cells[27, "F"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[27, "G"].Value = "x";
                                    objSheet.Cells[27, "G"].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                                    objSheet.Cells[27, "H"].Value = Math.Round(lotFrom.LOPU3 * 1000, 2);
                                    objSheet.Cells[27, "H"].HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[27, "H"].NumberFormat = @"#\ ##0,00 ";

                                    objSheet.Cells[27, "I"].Value = "€/T";
                                    objSheet.Cells[27, "I"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[27, "J"].Value = " =";
                                    objSheet.Cells[27, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                    objSheet.Cells[27, "K"].Value = Math.Round((poidsMoyen * lotFrom.LOC13) * lotFrom.LOPU3, 2);
                                    objSheet.Cells[27, "K"].Style.HorizontalAlignment = XlHAlign.xlHAlignRight;
                                    objSheet.Cells[27, "K"].NumberFormat = @"#\ ##0,00€";

                                }

                                if (lotFrom.LOC11 != 0 && lotFrom.LOC12 == 0 && lotFrom.LOC13 == 0)
                                {
                                    if (lotFrom.FRPRIME > 0)
                                    {
                                        objSheet.Cells[27, "B"].Value = "Prime qualité:";
                                        objSheet.Cells[27, "E"].Value = objSheet.Cells[25, "E"].Value;
                                        objSheet.Cells[27, "F"].Value = "T";
                                        objSheet.Cells[27, "G"].Value = "x";

                                        objSheet.Cells[27, "H"].Value = Math.Round((lotFrom.LOPU1 * 1000) * (lotFrom.FRPRIME / 100), 2);

                                        objSheet.Cells[27, "J"].Value = " =";
                                        objSheet.Cells[27, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                        var valeurE27 = Math.Round((poidsMoyen * lotFrom.LOC11) / 1000, 3);
                                        var valeurH27 = Math.Round((lotFrom.LOPU1 * 1000) * (lotFrom.FRPRIME / 100), 2);
                                        objSheet.Cells[27, "K"].Value = Math.Round(valeurE27 * valeurH27, 2);
                                        objSheet.Cells[27, "K"].NumberFormat = @"#\ ##0,00€";

                                        objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                        objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                        objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;


                                        objSheet.Cells[31, "B"].Value = "Total";
                                        var sumRangePrix = objSheet.Range["K25", "K27"].Value;
                                        objSheet.Cells[31, "K"].Value = sumRangePrix.Sum();

                                        var total = objSheet.Cells[31, "K"].Value;
                                        objSheet.Cells[35, "K"].Value = Math.Round(total - acompte, 2);
                                        objSheet.Cells[35, "K"].NumberFormat = @"#\ ##0,00€";

                                        objSheet.Cells[36, "K"].Value = objSheet.Cells[35, "K"].Value * 5.5m / 100;
                                        objSheet.Cells[36, "K"].NumberFormat = @"#\ ##0,00€";

                                        var sumQuandPrime = objSheet.Range["K35", "K36"].Value;
                                        objSheet.Cells[38, "K"].Value = Math.Round(sumQuandPrime.Sum(), 2);
                                        objSheet.Cells[38, "K"].Font.Bold = true;
                                        objSheet.Cells[38, "K"].NumberFormat = @"#\ ##0,00€";
                                    }
                                    else
                                    {
                                        var resultatSumPrixTotal = objSheet.Cells[25, "K"].Value;
                                        var resultatSumPoidsTotal = objSheet.Cells[25, "E"].Value;

                                        var test = resultatSumPrixTotal / resultatSumPoidsTotal;
                                        decimal temp = Math.Round((poidsMoyen * lotFrom.LOC11) * lotFrom.LOPU1, 2);

                                        objSheet.Cells[31, "E"].Value = Math.Round(test, 2);

                                        objSheet.Cells[35, "K"].Value = Math.Round(temp - acompte, 2);
                                        objSheet.Cells[35, "K"].NumberFormat = @"#\ ##0,00€";


                                        objSheet.Cells[36, "K"].Value = Math.Round((temp - acompte) * 5.5m) / 100;
                                        objSheet.Cells[36, "K"].NumberFormat = @"#\ ##0,00€";

                                        var sum = objSheet.Range["K35", "K36"].Value;
                                        objSheet.Cells[38, "K"].Value = Math.Round(sum.Sum(), 2);
                                        objSheet.Cells[38, "K"].Font.Bold = true;
                                        objSheet.Cells[38, "K"].NumberFormat = @"#\ ##0,00€";
                                    }

                                }

                                if (lotFrom.LOC12 != 0 && lotFrom.LOC13 == 0)
                                {
                                    objSheet.Cells[26, "C"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[26, "C"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[26, "C"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                                    objSheet.Cells[26, "E"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[26, "E"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[26, "E"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;


                                    objSheet.Cells[26, "K"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[26, "K"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[26, "K"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                                    objSheet.Cells[27, "D"].Value = "pains";

                                    objSheet.Cells[27, "F"].Value = "T";

                                    var sumRangePains = objSheet.Range["C25", "C26"].Value;
                                    objSheet.Cells[27, "C"].Value = sumRangePains.Sum();

                                    objSheet.Cells[27, "C"].Font.Bold = true;

                                    var sumRangePoids = objSheet.Range["E25", "E26"].Value;
                                    objSheet.Cells[27, "E"].Value = sumRangePoids.Sum();


                                    objSheet.Cells[27, "E"].Font.Bold = true;

                                    var sumRangePrix = objSheet.Range["K25", "K26"].Value;
                                    objSheet.Cells[27, "K"].Value = sumRangePrix.Sum();
                                    objSheet.Cells[27, "K"].NumberFormat = @"#\ ##0,00€";

                                    objSheet.Cells[27, "K"].Font.Bold = true;

                                    var resultatSumPrixTotal = objSheet.Cells[27, "K"];
                                    var resultatSumPoidsTotal = objSheet.Cells[27, "E"];

                                    var test = resultatSumPrixTotal.Value / resultatSumPoidsTotal.Value;

                                    objSheet.Cells[31, "E"].Value = Math.Round(test, 2);


                                    decimal resultatSumPrixAcompte = Math.Round(sumRangePrix.Sum() - acompte, 2);

                                    objSheet.Cells[35, "K"].Value = resultatSumPrixAcompte;
                                    objSheet.Cells[35, "K"].NumberFormat = @"#\ ##0,00€";

                                    objSheet.Cells[36, "K"].Value = Math.Round(resultatSumPrixAcompte * 5.5m) / 100;
                                    objSheet.Cells[36, "K"].NumberFormat = @"#\ ##0,00€";

                                    var sum = objSheet.Range["K35", "K36"].Value;
                                    objSheet.Cells[38, "K"].Value = Math.Round(sum.Sum(), 2);
                                    objSheet.Cells[38, "K"].Font.Bold = true;
                                    objSheet.Cells[38, "K"].NumberFormat = @"#\ ##0,00€";

                                    if (lotFrom.FRPRIME > 0)
                                    {
                                        objSheet.Cells[29, "B"].Value = "Prime qualité:";
                                        objSheet.Cells[29, "E"].Value = objSheet.Cells[27, "E"].Value;
                                        objSheet.Cells[29, "F"].Value = "T";
                                        objSheet.Cells[29, "G"].Value = "x";

                                        var sumLopu12 = Math.Round((lotFrom.LOPU1 * 1000) + (lotFrom.LOPU2 * 1000), 2);

                                        objSheet.Cells[29, "H"].Value = Math.Round(sumLopu12 * (lotFrom.FRPRIME / 100), 2);

                                        objSheet.Cells[29, "J"].Value = " =";
                                        objSheet.Cells[29, "J"].HorizontalAlignment = XlHAlign.xlHAlignLeft;

                                        var valeurE27 = objSheet.Cells[27, "E"].Value;
                                        var valeurH29 = objSheet.Cells[29, "H"].Value;
                                        objSheet.Cells[29, "K"].Value = Math.Round(valeurE27 * valeurH29, 2);
                                        objSheet.Cells[29, "K"].NumberFormat = @"#\ ##0,00€";


                                        objSheet.Cells[29, "K"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                        objSheet.Cells[29, "K"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                        objSheet.Cells[29, "K"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;


                                        objSheet.Cells[31, "H"].Value = "Total";
                                        var sumRangeAvecPrime = objSheet.Range["K27", "K29"].Value;
                                        objSheet.Cells[31, "K"].Value = sumRangeAvecPrime.Sum();
                                        objSheet.Cells[31, "K"].NumberFormat = @"#\ ##0,00€";

                                        var total = objSheet.Cells[31, "K"].Value;
                                        objSheet.Cells[35, "K"].Value = Math.Round(total - acompte, 2);
                                        objSheet.Cells[35, "K"].NumberFormat = @"#\ ##0,00€";

                                        objSheet.Cells[36, "K"].Value = objSheet.Cells[35, "K"].Value * 5.5m / 100;
                                        objSheet.Cells[36, "K"].NumberFormat = @"#\ ##0,00€";

                                        var sumQuandPrime = objSheet.Range["K35", "K36"].Value;
                                        objSheet.Cells[38, "K"].Value = Math.Round(sumQuandPrime.Sum(), 2);
                                        objSheet.Cells[38, "K"].Font.Bold = true;
                                        objSheet.Cells[38, "K"].NumberFormat = @"#\ ##0,00€";
                                    }


                                }
                                if (lotFrom.LOC12 != 0 && lotFrom.LOC13 != 0)
                                {

                                    objSheet.Cells[27, "C"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[27, "C"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[27, "C"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                                    objSheet.Cells[27, "E"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[27, "E"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[27, "E"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                                    objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                                    objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                                    objSheet.Cells[27, "K"].Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = 0;

                                    objSheet.Cells[28, "D"].Value = "pains";
                                    objSheet.Cells[28, "F"].Value = "T";

                                    var sumRangePains = objSheet.Range["C25", "C27"].Value;
                                    objSheet.Cells[28, "C"].Value = sumRangePains.Sum();


                                    objSheet.Cells[28, "C"].Font.Bold = true;

                                    var sumRangePoids = objSheet.Range["E25", "E27"].Value;
                                    objSheet.Cells[28, "E"].Value = sumRangePoids.Sum();


                                    objSheet.Cells[28, "E"].Font.Bold = true;

                                    var sumRangePrix = objSheet.Range["K25", "K27"].Value;
                                    objSheet.Cells[28, "K"].Value = sumRangePrix.Sum();
                                    objSheet.Cells[28, "K"].NumberFormat = @"#\ ##0,00€";

                                    objSheet.Cells[28, "K"].Font.Bold = true;

                                    var resultatSumPrixTotal = objSheet.Cells[28, "K"];
                                    var resultatSumPoidsTotal = objSheet.Cells[28, "E"];

                                    var test = resultatSumPrixTotal.Value / resultatSumPoidsTotal.Value;
                                    decimal resultatSumPrixAcompte = Math.Round(sumRangePrix.Sum() - acompte, 2);
                                    objSheet.Cells[31, "E"].Value = Math.Round(test, 2);

                                    objSheet.Cells[35, "K"].Value = resultatSumPrixAcompte;
                                    objSheet.Cells[36, "K"] = Math.Round(resultatSumPrixAcompte * 5.5m / 100, 2);
                                    objSheet.Cells[35, "K"].NumberFormat = @"#\ ##0,00€";
                                    objSheet.Cells[36, "K"].NumberFormat = @"#\ ##0,00€";

                                    var sum = objSheet.Range["K35", "K36"].Value;
                                    objSheet.Cells[38, "K"].Value = Math.Round(sum.Sum(), 2);
                                    objSheet.Cells[38, "K"].Font.Bold = true;
                                    objSheet.Cells[38, "K"].NumberFormat = @"#\ ##0,00€";

                                    if (lotFrom.FRPRIME > 0)
                                    {
                                       /* objSheet.Cells[29, "B"].Value = "Prime qualité:";
                                        workSheet["E29"].Value = workSheet["E28"].Value;
                                        workSheet["F29"].Value = "T";
                                        workSheet["G29"].Value = "x";

                                        var sumLopu123 = Math.Round((lotFrom.LOPU1 * 1000) + (lotFrom.LOPU2 * 1000) + (lotFrom.LOPU3 * 1000), 2);

                                        workSheet["H29"].Value = Math.Round(sumLopu123 * (lotFrom.FRPRIME / 100), 2);

                                        workSheet["J29"].Value = " =";
                                        workSheet["J29"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                        var valeurE28 = workSheet["E28"].Value;
                                        var valeurH29 = workSheet["H29"].Value;
                                        workSheet["K29"].Value = Math.Round(valeurE28 * valeurH29, 2);
                                        workSheet["K29"].FormatString = "# ##0.00€";
                                        workSheet["K29"].Style.BottomBorder.SetColor("#000000");
                                        workSheet["K29"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;


                                        workSheet["H31"].Value = "Total";
                                        var sumRangeAvecPrime = workSheet["K28:K29"];
                                        workSheet["K31"].Value = sumRangeAvecPrime.Sum();
                                        workSheet["K31"].FormatString = "# ##0.00€";

                                        var total = workSheet["K31"].Value;
                                        workSheet["K35"].Value = Math.Round(total - acompte, 2);
                                        workSheet["K35"].FormatString = "# ##0.00€";

                                        workSheet["K36"].Value = workSheet["K35"].Value * 5.5m / 100;
                                        workSheet["K36"].FormatString = "# ##0.00€";

                                        var sumQuandPrime = workSheet["K35:K36"];
                                        workSheet["K38"].Value = Math.Round(sumQuandPrime.Sum(), 2);
                                        workSheet["K38"].Style.Font.Bold = true;
                                        workSheet["K38"].FormatString = "# ##0.00€";*/
                                    }
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

                               /* workSheet["K33"].Style.BottomBorder.SetColor("#000000");
                                workSheet["K33"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                workSheet["K33"].Value = Math.Round(acompte, 2);
                                workSheet["K33"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                workSheet["K33"].FormatString = "-# ##0.00€";

                                workSheet["K36"].Style.BottomBorder.SetColor("#000000");
                                workSheet["K36"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                workSheet["B31"].Value = "Soit au kg blanc : ";
                                workSheet["F31"].Value = "€/T";
                                workSheet["D33"].Value = "A déduire N/Acompte du ";
                                workSheet["G35"].Value = "Total Hors Taxes";
                                workSheet["G36"].Value = "T.V.A";
                                workSheet["I36"].Value = "5,5";
                                workSheet["J36"].Value = "%";
                                workSheet["G38"].Value = "Total Réglé";
                                workSheet["G38"].Style.Font.Bold = true;


                                workSheet["B40"].Value = "          Vous en souhaitant bonne réception";
                                workSheet["B42"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                                workSheet["B43"].Value = "salutations distinguées";
                                workSheet["H45"].Value = "Service Comptabilité";
                                workSheet[$"H45"].Style.Font.Bold = true;
                                var sumPs = workSheet["K38"].Value;

                                workSheet["B50"].Value = "PS : Nous virons ce jour, sur votre compte N° " + lotFrom.FRBANQ + " " + lotFrom.FRGUIC + " " + lotFrom.FRCOM1 + " " + lotFrom.FRCOM2;
                                workSheet["B51"].Value = lotFrom.FRDOMI + ", la somme de";
                                workSheet["H51"].Value = sumPs;
                                workSheet["H51"].FormatString = "# ##0.00€";*/

                                valeurPrecedente = lotFrom.FRNUM;

                            }

                           /* RangeColumn col0 = workSheet.GetColumn(0);
                            col0.Width = 5086; // Set width

                            RangeColumn col1 = workSheet.GetColumn(1);
                            col1.Width = 1098; // Set width

                            RangeColumn col2 = workSheet.GetColumn(2);
                            col2.Width = 1720; // Set width

                            RangeColumn col3 = workSheet.GetColumn(3);
                            col3.Width = 1939; // Set width

                            RangeColumn col4 = workSheet.GetColumn(4);
                            col4.Width = 3037; // Set width

                            RangeColumn col5 = workSheet.GetColumn(5);
                            col5.Width = 1098; // Set width

                            RangeColumn col6 = workSheet.GetColumn(6);
                            col6.Width = 805; // Set width

                            RangeColumn col7 = workSheet.GetColumn(7);
                            col7.Width = 3330; // Set width

                            RangeColumn col8 = workSheet.GetColumn(8);
                            col8.Width = 1317; // Set width

                            RangeColumn col9 = workSheet.GetColumn(9);
                            col9.Width = 842; // Set width

                            RangeColumn col10 = workSheet.GetColumn(10);
                            col10.Width = 3257; // Set width

                            workSheet["A30"].Value = " ";
                            RangeRow row1 = workSheet.GetRow(29);
                            row1.Height = 87; // Set height

                            workSheet["A34"].Value = " ";
                            RangeRow row2 = workSheet.GetRow(33);
                            row2.Height = 87; // Set height

                            workSheet["A37"].Value = " ";
                            RangeRow row3 = workSheet.GetRow(36);
                            row3.Height = 87; // Set height



                            // Configuration du style de la feuille (police, ...)
                            workSheet.Style.Font.Name = "Arial";*/



                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.InitialDirectory = dataPath.PathRappel;
                        if (moisNum.Numero < 10)
                        {
                            moisExcel = "0" + moisNum.Numero;
                        }
                        else
                        {
                            moisExcel = moisNum.Numero.ToString();
                        }
                        saveFileDialog.FileName = "Rappels_" + tbxAnnee.Text + moisExcel + ".xlsx";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;

                            objBook.SaveAs(path);
                            objBook.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue ou le fichier est déjà généré");
            }
        }

        private void tbx_a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                // Insérer une virgule à la position du curseur dans le TextBox
                int selectionStart = tbx_a.SelectionStart;
                tbx_a.Text = tbx_a.Text.Insert(selectionStart, ",");

                // Mettre à jour la position du curseur
                tbx_a.SelectionStart = selectionStart + 1;

                // Empêcher la gestion ultérieure de cette touche
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter)
            {

                decimal montant = decimal.Parse(tbx_a.Text) + decimal.Parse(tbx_b.Text) + decimal.Parse(tbx_c.Text);
                decimal montantRounded = Math.Round(_currentMontant + montant, 5);
                tbxMontant.Text = montantRounded.ToString();

                //testMontant = Math.Round(currentMontant + montant, 2);
                decimal a;
                if (decimal.TryParse(tbx_a.Text, out a))
                {

                    this._currentLot.LOPU1 = Math.Round(a, 5);
                    this._currentLot.MONTANT = montantRounded;

                }
                dataGridView.Refresh();
                tbx_b.Focus();
            }
        }

        private void tbx_b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                // Insérer une virgule à la position du curseur dans le TextBox
                int selectionStart = tbx_b.SelectionStart;
                tbx_b.Text = tbx_b.Text.Insert(selectionStart, ",");

                // Mettre à jour la position du curseur
                tbx_b.SelectionStart = selectionStart + 1;

                // Empêcher la gestion ultérieure de cette touche
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                decimal montant = decimal.Parse(tbx_a.Text) + decimal.Parse(tbx_b.Text) + decimal.Parse(tbx_c.Text);
                decimal montantRounded = Math.Round(_currentMontant + montant, 5);
                tbxMontant.Text = montantRounded.ToString();
                decimal b;
                if (decimal.TryParse(tbx_b.Text, out b))
                {

                    this._currentLot.LOPU2 = Math.Round(b, 5);
                    this._currentLot.MONTANT = montantRounded;

                }
                dataGridView.Refresh();
                tbx_c.Focus();
            }
        }

        private void tbx_c_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                // Insérer une virgule à la position du curseur dans le TextBox
                int selectionStart = tbx_c.SelectionStart;
                tbx_c.Text = tbx_c.Text.Insert(selectionStart, ",");

                // Mettre à jour la position du curseur
                tbx_c.SelectionStart = selectionStart + 1;

                // Empêcher la gestion ultérieure de cette touche
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                decimal montant = decimal.Parse(tbx_a.Text) + decimal.Parse(tbx_b.Text) + decimal.Parse(tbx_c.Text);
                decimal montantRounded = Math.Round(_currentMontant + montant, 5);
                tbxMontant.Text = montantRounded.ToString();
                decimal c;
                if (decimal.TryParse(tbx_c.Text, out c))
                {

                    this._currentLot.LOPU3 = Math.Round(c, 5);
                    this._currentLot.MONTANT = montantRounded;

                }
                dataGridView.Refresh();
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
            DateTime moisPrecedent = dtpDate.Value.AddMonths(-5);
            cbxMois.SelectedIndex = moisPrecedent.Month - 1;
            tbxAnnee.Text = Convert.ToString(moisPrecedent.Year % 100);
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
                _lastPathSaved = GetLatestFilePath(dataPath.PathRappel);
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

        private void tbxAnnee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxAnnee.Text.Length == 2)
                {
                    GenererValeurs();
                }

            }
        }
    }
}
