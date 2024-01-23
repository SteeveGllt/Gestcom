using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using IronXL;
using System.Globalization;

namespace GestcomWF.Views
{
    public partial class saisie_rappel : Form
    {
        private Lot _currentLot = null;
        private decimal testMontant = 0m;
        private string moisExcel = string.Empty;

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
            dataGridView.DefaultCellStyle.Format = "N2";
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
                    LotAdo.updateLotRappel(_currentLot.LOFROM, Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero, Convert.ToDouble(a), Convert.ToDouble(b), Convert.ToDouble(c), Convert.ToDouble(Math.Round(montant, 2)));
                    this._currentLot.LOPU1 = Math.Round(a, 2);
                    this._currentLot.LOPU2 = Math.Round(b, 2);
                    this._currentLot.LOPU3 = Math.Round(c, 2);
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


                    decimal moisNumValue = moisNum.Numero;
                    decimal anneeValue = Convert.ToDecimal(tbxAnnee.Text);

                    DateTime selectedDate = dtpDate.Value;
                    string formattedDate = selectedDate.ToString("dd MMMM yyyy");




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

                        // Traitement pour chaque entré
                        foreach (LotFrom lotFrom in lotFroms)
                        {



                            poidsMoyen = lotFrom.LOCEN1 / lotFrom.LOCEM1;
                            acompte = lotFrom.LOPUAC * lotFrom.LOCEN1;
                            string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                            // Si l'entrée a une nouvelle valeur FRNUM
                            if (lotFrom.FRNUM != valeurPrecedente)
                            {
                                // Initialisation de la feuille Excel avec le nom adapté
                                workSheet = workbook.CreateWorkSheet(nomFeuille);
                                workSheet["F8"].Value = lotFrom.FRNDIR;
                                workSheet["F9"].Value = lotFrom.FRNOM;
                                workSheet["F10"].Value = lotFrom.FRADR;
                                workSheet["F11"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;

                                workSheet["A16"].Value = "      TB/PB";
                                workSheet["G16"].Value = "Le" + " " + formattedDate;
                                workSheet["B20"].Value = "Monsieur le Président";
                                workSheet["B22"].Value = "          Conformément à nos conditions d'achat, le décompte de votre";
                                workSheet["B23"].Value = "lot de fabrication " + moisNum.Mois.ToUpper() + " " + annee + anneeValue + " s'établit comme suit :";

                                /* this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                 this.workSheet["F27"].Style.Font.Bold = true;*/


                                // Initialisez la ligne actuelle

                                //int currentRow = 30;
                                if (lotFrom.LOC11 != 0)
                                {
                                    workSheet["B25"].Value = "A";
                                    workSheet["B25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["C25"].Value = lotFrom.LOC11;
                                    workSheet["C25"].Style.Font.Bold = true;
                                    workSheet["C25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                    workSheet["D25"].Value = "pains";

                                    workSheet["E25"].Value = Math.Round((poidsMoyen * lotFrom.LOC11) / 1000, 3);
                                    workSheet["E25"].Style.Font.Bold = true;
                                    workSheet["C25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["E25"].FormatString = "# ##0.000";

                                    workSheet["F25"].Value = "T";
                                    workSheet["F25"].Style.Font.Bold = true;
                                    workSheet["F25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["G25"].Value = "x";
                                    workSheet["G25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["H25"].Value = Math.Round(lotFrom.LOPU1 * 1000, 2);
                                    workSheet["H25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["H25"].FormatString = "# ##0.00€";

                                    workSheet["I25"].Value = "€/T";
                                    workSheet["I25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["J25"].Value = " =";
                                    workSheet["J25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;


                                    workSheet["K25"].Value = Math.Round((poidsMoyen * lotFrom.LOC11) * lotFrom.LOPU1, 2);
                                    workSheet["K25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["K25"].FormatString = "# ##0.00€";

                                }



                                if (lotFrom.LOC12 != 0)
                                {
                                    workSheet["B26"].Value = "B";
                                    workSheet["B26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["C26"].Value = lotFrom.LOC12;
                                    workSheet["C26"].Style.Font.Bold = true;
                                    workSheet["C26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                    workSheet["D26"].Value = "pains";

                                    workSheet["E26"].Value = Math.Round(poidsMoyen * lotFrom.LOC12 / 1000, 3);
                                    workSheet["E26"].Style.Font.Bold = true;
                                    workSheet["C26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["E26"].FormatString = "# ##0.000";


                                    workSheet["F26"].Value = "T";
                                    workSheet["F26"].Style.Font.Bold = true;
                                    workSheet["F26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["G26"].Value = "x";
                                    workSheet["G26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["H26"].Value = Math.Round(lotFrom.LOPU2 * 1000, 2);
                                    workSheet["H26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["H26"].FormatString = "# ##0.00€";

                                    workSheet["I26"].Value = "€/T";
                                    workSheet["I26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["J26"].Value = " =";
                                    workSheet["J26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["K26"].Value = Math.Round((poidsMoyen * lotFrom.LOC12) * lotFrom.LOPU2, 2);
                                    workSheet["K26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["K26"].FormatString = "# ##0.00€";

                                }
                                if (lotFrom.LOC13 != 0)
                                {
                                    workSheet["B27"].Value = "C";
                                    workSheet["B27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["C27"].Value = lotFrom.LOC13;
                                    workSheet["C27"].Style.Font.Bold = true;
                                    workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                    workSheet["D27"].Value = "pains";

                                    workSheet["E27"].Value = Math.Round(poidsMoyen * lotFrom.LOC13 / 1000, 3);
                                    workSheet["E27"].Style.Font.Bold = true;
                                    workSheet["E27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["E27"].FormatString = "# ##0.000";

                                    workSheet["F27"].Value = "T";
                                    workSheet["F27"].Style.Font.Bold = true;
                                    workSheet["F27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["G27"].Value = "x";
                                    workSheet["G27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                    workSheet["H27"].Value = Math.Round(lotFrom.LOPU3 * 1000, 2);
                                    workSheet["H27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["H27"].FormatString = "# ##0.00€";

                                    workSheet["I27"].Value = "€/T";
                                    workSheet["I27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["J27"].Value = " =";
                                    workSheet["J27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                    workSheet["K27"].Value = Math.Round((poidsMoyen * lotFrom.LOC13) * lotFrom.LOPU3, 2);
                                    workSheet["K27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                                    workSheet["K27"].FormatString = "# ##0.00€";
                                }

                                if (lotFrom.LOC11 != 0 && lotFrom.LOC12 == 0 && lotFrom.LOC13 == 0)
                                {
                                    var resultatSumPrixTotal = workSheet["K25"];
                                    var resultatSumPoidsTotal = workSheet["E25"];

                                    var test = resultatSumPrixTotal.DecimalValue / resultatSumPoidsTotal.DecimalValue;
                                    decimal temp = Math.Round((poidsMoyen * lotFrom.LOC11) * lotFrom.LOPU1, 2);

                                    workSheet["E31"].Value = Math.Round(test, 2);

                                    workSheet["K35"].Value = Math.Round(temp - acompte, 2);
                                    workSheet["K35"].FormatString = "# ##0.00€";


                                    workSheet["K36"].Value = Math.Round((temp - acompte) * 5.5m) / 100;
                                    workSheet["K36"].FormatString = "# ##0.00€";

                                    var sum = workSheet["K35:K36"];
                                    workSheet["K38"].Value = Math.Round(sum.Sum(), 2);
                                    workSheet["K38"].Style.Font.Bold = true;
                                    workSheet["K38"].FormatString = "# ##0.00€";
                                }

                                if (lotFrom.LOC12 != 0 && lotFrom.LOC13 == 0)
                                {
                                    workSheet["C26"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["C26"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["E26"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["E26"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["K26"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["K26"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["D27"].Value = "pains";

                                    workSheet["F27"].Value = "T";

                                    var sumRangePains = workSheet["C25:C26"];
                                    workSheet["C27"].Value = sumRangePains.Sum();

                                    workSheet["C27"].Style.Font.Bold = true;

                                    var sumRangePoids = workSheet["E25:E26"];
                                    workSheet["E27"].Value = sumRangePoids.Sum();


                                    workSheet["E27"].Style.Font.Bold = true;

                                    var sumRangePrix = workSheet["K25:K26"];
                                    workSheet["K27"].Value = sumRangePrix.Sum();
                                    workSheet["K27"].FormatString = "# ##0.00€";

                                    workSheet["K27"].Style.Font.Bold = true;

                                    var resultatSumPrixTotal = workSheet["K27"];
                                    var resultatSumPoidsTotal = workSheet["E27"];

                                    var test = resultatSumPrixTotal.DecimalValue / resultatSumPoidsTotal.DecimalValue;

                                    workSheet["E31"].Value = Math.Round(test, 2);


                                    decimal resultatSumPrixAcompte = Math.Round(sumRangePrix.Sum() - acompte, 2);

                                    workSheet["K35"].Value = resultatSumPrixAcompte;
                                    workSheet["K35"].FormatString = "# ##0.00€";

                                    workSheet["K36"].Value = Math.Round(resultatSumPrixAcompte * 5.5m) / 100;
                                    workSheet["K36"].FormatString = "# ##0.00€";

                                    var sum = workSheet["K35:K36"];
                                    workSheet["K38"].Value = Math.Round(sum.Sum(), 2);
                                    workSheet["K38"].Style.Font.Bold = true;
                                    workSheet["K38"].FormatString = "# ##0.00€";




                                }
                                if (lotFrom.LOC12 != 0 && lotFrom.LOC13 != 0)
                                {
                                    workSheet["C27"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["C27"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["E27"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["E27"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["K27"].Style.BottomBorder.SetColor("#000000");
                                    workSheet["K27"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;

                                    workSheet["D28"].Value = "pains";
                                    workSheet["F28"].Value = "T";

                                    var sumRangePains = workSheet["C25:C27"];
                                    workSheet["C28"].Value = sumRangePains.Sum();


                                    workSheet["C28"].Style.Font.Bold = true;

                                    var sumRangePoids = workSheet["E25:E27"];
                                    workSheet["E28"].Value = sumRangePoids.Sum();


                                    workSheet["E28"].Style.Font.Bold = true;

                                    var sumRangePrix = workSheet["K25:K27"];
                                    workSheet["K28"].Value = sumRangePrix.Sum();
                                    workSheet["K28"].FormatString = "# ##0.00€";

                                    workSheet["K28"].Style.Font.Bold = true;

                                    var resultatSumPrixTotal = workSheet["K28"];
                                    var resultatSumPoidsTotal = workSheet["E28"];

                                    var test = resultatSumPrixTotal.DecimalValue / resultatSumPoidsTotal.DecimalValue;
                                    decimal resultatSumPrixAcompte = Math.Round(sumRangePrix.Sum() - acompte, 2);
                                    workSheet["E31"].Value = Math.Round(test, 2);

                                    workSheet["K35"].Value = resultatSumPrixAcompte;
                                    workSheet["K36"].Value = Math.Round(resultatSumPrixAcompte * 5.5m / 100, 2);
                                    workSheet["K35"].FormatString = "# ##0.00€";
                                    workSheet["K36"].FormatString = "# ##0.00€";

                                    var sum = workSheet["K35:K36"];
                                    workSheet["K38"].Value = Math.Round(sum.Sum(), 2);
                                    workSheet["K38"].Style.Font.Bold = true;
                                    workSheet["K38"].FormatString = "# ##0.00€";


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

                                workSheet["K33"].Style.BottomBorder.SetColor("#000000");
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
                                workSheet["H51"].FormatString = "# ##0.00€";

                                valeurPrecedente = lotFrom.FRNUM;

                            }

                            RangeColumn col0 = workSheet.GetColumn(0);
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
                            workSheet.Style.Font.Name = "Arial";



                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.InitialDirectory = @"C:\DIRECTORY\Documents\Rappel\";
                        if (moisNum.Numero < 10)
                        {
                            moisExcel = "0" + moisNum.Numero;
                        }
                        else
                        {
                            moisExcel = moisNum.Numero.ToString();
                        }
                        saveFileDialog.FileName = "Rappels_" + tbxAnnee.Text + moisExcel + ".xls";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;

                            workbook.SaveAs(path);
                            workbook.Close();

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
                tbxMontant.Text = montant.ToString();
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
                tbxMontant.Text = montant.ToString();
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
                tbxMontant.Text = montant.ToString();
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
    }
}
