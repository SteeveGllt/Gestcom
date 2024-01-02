using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using IronXL;

namespace GestcomWF.Views
{
    public partial class saisie_acompte : Form
    {
        // Membre pour garder une trace du lot actuel
        private Lot _currentLot = null;

        private bool updateAllPrices = false;

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
                                LotAdo.updateLotPrix(lot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, Convert.ToDouble(newPrice));
                                lot.LOPUAC = newPrice;
                            }
                        }
                        else
                        {

                            // Mettre à jour un seul lot
                            LotAdo.updateLotPrix(this._currentLot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, Convert.ToDouble(newPrice));
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

                // Vérification que le champ 'année' est correctement rempli
                if (tbx_annee.Text == "" || tbx_annee.Text.Length < 2)
                {
                    MessageBox.Show("Veuillez entrer une année en deux chiffres");

                }
                else
                {
                    WorkSheet workSheet = null;
                    WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);

                    decimal valeurPrecedente = 0;



                    // Récupération du mois sélectionné depuis la comboBox
                    MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                    decimal moisNumValue = moisNum.Numero;
                    decimal anneeValue = Convert.ToDecimal(tbx_annee.Text);
                    string nomMoisDecale = "";

                    decimal moisDecale = moisNumValue - 2;
                    if (moisDecale <= 0)
                    {
                        moisDecale += 12;
                        anneeValue -= 1;
                    }

                    MoisNum moisDecaleValue = listeObjets.FirstOrDefault(m => m.Numero == moisDecale);

                    if (moisDecaleValue != null)
                    {
                        // Utilisez moisDecale.Mois pour obtenir le nom du mois décalé
                        nomMoisDecale = moisDecaleValue.Mois;
                    }

                    Console.WriteLine(moisDecale);

                    // Récupération de toutes les entrées pour le mois et l'année donnés
                    List<LotFrom> lotFroms = LotAdo.generationFichierExcelAcompte(moisDecale, Convert.ToDecimal(tbx_annee.Text));
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

                            prix = Math.Round(lotFrom.LOCEN1 * lotFrom.LOPUAC, 2);
                            acompte = lotFrom.LOPUAC * lotFrom.LOCEN1;
                            string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                            // Si l'entrée a une nouvelle valeur FRNUM
                            if (lotFrom.FRNUM != valeurPrecedente)
                            {
                                // Initialisation de la feuille Excel avec le nom adapté
                                workSheet = workbook.CreateWorkSheet(nomFeuille);
                                workSheet["F10"].Value = lotFrom.FRNDIR;
                                workSheet["F11"].Value = lotFrom.FRNOM;
                                workSheet["F12"].Value = lotFrom.FRADR;
                                workSheet["F13"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;

                                workSheet["A18"].Value = "      TB/PB";
                                workSheet["G28"].Value = "Le" + " " + DateTime.Now.ToString("D");
                                workSheet["B23"].Value = "Monsieur le Président";
                                workSheet["B25"].Value = "          Nous vous prions de bien vouloir trouver ci-dessous, le détail";
                                workSheet["B26"].Value = "du premier acompte sur votre lot de fabrication " + nomMoisDecale.ToUpper() + " " + annee + anneeValue;

                                /* this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                                 this.workSheet["F27"].Style.Font.Bold = true;*/


                                // Initialisez la ligne actuelle


                                workSheet["B28"].Value = "-";
                                workSheet["B28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                workSheet["C28"].Value = lotFrom.LOCEM1;
                                workSheet["C28"].Style.Font.Bold = true;
                                workSheet["C28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                workSheet["D28"].Value = "pains";

                                workSheet["E28"].Value = lotFrom.LOCEN1;
                                workSheet["E28"].Style.Font.Bold = true;
                                workSheet["E28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                workSheet["F28"].Value = "T";
                                workSheet["F28"].Style.Font.Bold = true;
                                workSheet["F28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                workSheet["G28"].Value = "x";
                                workSheet["G28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                workSheet["H28"].Value = lotFrom.LOPUAC + " €";
                                workSheet["H28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;



                                workSheet["I28"].Value = "'=";
                                workSheet["I28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                workSheet["J28"].Value = prix + " €";
                                workSheet["J28"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                workSheet["J30"].Value = prix + " €";
                                workSheet["J30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;



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

                                workSheet["J28"].Style.BottomBorder.SetColor("#000000");
                                workSheet["J28"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;



                                workSheet["J31"].Style.BottomBorder.SetColor("#000000");
                                workSheet["J31"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Thin;



                                //this.workSheet["D33"].Value = "A déduire N/Acompte du ";
                                workSheet["F30"].Value = "Total HT";
                                workSheet["F31"].Value = "T.V.A";
                                workSheet["H31"].Value = "5,5";
                                workSheet["I31"].Value = "%";
                                workSheet["J31"].Value = prix * 5.5m / 100;

                                workSheet["F33"].Value = "Total Réglé";
                                workSheet["F33"].Style.Font.Bold = true;

                                var sumPrixTVA = workSheet["J30:J31"];

                                workSheet["J33"].Value = sumPrixTVA.Sum() + "€";
                                workSheet["J33"].Style.Font.Bold = true;



                                workSheet["B35"].Value = "          Vous en souhaitant bonne réception";
                                workSheet["B37"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                                workSheet["B38"].Value = "salutations distinguées";
                                workSheet["H40"].Value = "Service Comptabilité";
                                workSheet["H40"].Style.Font.Bold = true;


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
                            col9.Width = 4094; // Set width


                            workSheet["A29"].Value = " ";
                            RangeRow row1 = workSheet.GetRow(28);
                            row1.Height = 87; // Set height

                            workSheet["A32"].Value = " ";
                            RangeRow row2 = workSheet.GetRow(31);
                            row2.Height = 87; // Set height




                            // Configuration du style de la feuille (police, ...)
                            workSheet.Style.Font.Name = "Arial";



                        }
                        // Propose à l'utilisateur d'enregistrer le fichier Excel
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                        saveFileDialog.Title = "Enregistrez le fichier sous...";
                        saveFileDialog.FileName = "acompte " + moisNum.Mois + ".xls";
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
    }
}
