using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using IronXL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestcomWF.Views
{
    public partial class saisie_rappel : Form
    {
        private Lot _currentLot = null;

        WorkSheet workSheet;
        WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);

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
        }

        private void btn_valider_Click(object sender, EventArgs e)
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

                LotAdo.updateLotRappel(_currentLot.LOFROM, Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero, Convert.ToDecimal(tbx_a.Text), Convert.ToDecimal(tbx_b.Text), Convert.ToDecimal(tbx_c.Text));
                _currentLot = null;
                tbx_a.Text = "";
                tbx_b.Text = "";
                tbx_c.Text = "";
                tbx_total.Text = "";
            }

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
                this._currentLot = lot;
                // Assignez d'autres propriétés de l'objet `lot` à d'autres TextBox si nécessaire
            }
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
                List<Lot> lots = LotAdo.allLotRappel(Convert.ToDecimal(tbxAnnee.Text), moisNum.Numero);
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
            // Vérification que le champ 'année' est correctement rempli
            if (tbxAnnee.Text == "" || tbxAnnee.Text.Length < 2)
            {
                MessageBox.Show("Veuillez entrer une année en deux chiffres");

            }
            else
            {

                Decimal valeurPrecedente = 0;


                // Récupération du mois sélectionné depuis la comboBox
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                // Récupération de toutes les entrées pour le mois et l'année donnés
                List<LotFrom> lotFroms = LotAdo.generationFichierExcelRappel(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (lotFroms == null || lotFroms.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
                {
                    decimal poidsMoyen = 0;
                    string annee = (DateTime.Now.Year / 100).ToString();
                    // Traitement pour chaque entré
                    foreach (LotFrom lotFrom in lotFroms)
                    {

                        poidsMoyen = lotFrom.LOCEN1 / lotFrom.LOCEM1;
                        string nomFeuille = lotFrom.FRNOM.Replace("/", "-");

                        // Si l'entrée a une nouvelle valeur FRNUM
                        if (lotFrom.FRNUM != valeurPrecedente)
                        {
                            // Initialisation de la feuille Excel avec le nom adapté
                            this.workSheet = workbook.CreateWorkSheet(nomFeuille);
                            this.workSheet["F8"].Value = lotFrom.FRNDIR;
                            this.workSheet["F9"].Value = lotFrom.FRNOM;
                            this.workSheet["F10"].Value = lotFrom.FRADR;
                            this.workSheet["F11"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;

                            this.workSheet["A16"].Value = "      TB/PB";
                            this.workSheet["G16"].Value = "Le" + " " + DateTime.Now.ToString("D");
                            this.workSheet["B20"].Value = "Monsieur le Président";
                            this.workSheet["B22"].Value = "          Conformément à nos conditions d'achat, le décompte de votre";
                            this.workSheet["B23"].Value = "lot de fabrication SEPTEMBRE 2022 s'établit comme suit :";

                           /* this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                            this.workSheet["F27"].Style.Font.Bold = true;*/


                            // Initialisez la ligne actuelle

                            //int currentRow = 30;
                            if (lotFrom.LOC11 != 0)
                            {
                                this.workSheet["B25"].Value = "A";
                                this.workSheet["B25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["C25"].Value = lotFrom.LOC11;
                                this.workSheet["C25"].Style.Font.Bold = true;
                                this.workSheet["C25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                this.workSheet["D25"].Value = "pains";

                                this.workSheet["E25"].Value = Math.Round(poidsMoyen * lotFrom.LOC11, 2);
                                this.workSheet["E25"].Style.Font.Bold = true;
                                this.workSheet["C25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["F25"].Value = "T";
                                this.workSheet["F25"].Style.Font.Bold = true;
                                this.workSheet["F25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["G25"].Value = "x";
                                this.workSheet["G25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["H25"].Value = lotFrom.LOPU1;
                                this.workSheet["H25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["I25"].Value = "€/T";
                                this.workSheet["I25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["J25"].Value = "'=";
                                this.workSheet["J25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["K25"].Value = Math.Round((poidsMoyen * lotFrom.LOC11) * lotFrom.LOPU1, 2) + " €";
                                this.workSheet["K25"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                            }



                            if (lotFrom.LOC12 != 0)
                            {
                                this.workSheet["B26"].Value = "B";
                                this.workSheet["B26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["C26"].Value = lotFrom.LOC12;
                                this.workSheet["C26"].Style.Font.Bold = true;
                                this.workSheet["C26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                this.workSheet["D26"].Value = "pains";

                                this.workSheet["E26"].Value = Math.Round(poidsMoyen * lotFrom.LOC12, 2);
                                this.workSheet["E26"].Style.Font.Bold = true;
                                this.workSheet["C26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["F26"].Value = "T";
                                this.workSheet["F26"].Style.Font.Bold = true;
                                this.workSheet["F26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["G26"].Value = "x";
                                this.workSheet["G26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["H26"].Value = lotFrom.LOPU2;
                                this.workSheet["H26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["I26"].Value = "€/T";
                                this.workSheet["I26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["J26"].Value = "'=";
                                this.workSheet["J26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["K26"].Value = Math.Round((poidsMoyen * lotFrom.LOC12) * lotFrom.LOPU2, 2) + " €";
                                this.workSheet["K26"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                            }
                            if (lotFrom.LOC13 != 0)
                            {
                                this.workSheet["B27"].Value = "C";
                                this.workSheet["B27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["C27"].Value = lotFrom.LOC13;
                                this.workSheet["C27"].Style.Font.Bold = true;
                                this.workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;


                                this.workSheet["D27"].Value = "pains";

                                this.workSheet["E27"].Value = Math.Round(poidsMoyen * lotFrom.LOC13, 2);
                                this.workSheet["E27"].Style.Font.Bold = true;
                                this.workSheet["C27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["F27"].Value = "T";
                                this.workSheet["F27"].Style.Font.Bold = true;
                                this.workSheet["F27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["G27"].Value = "x";
                                this.workSheet["G27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;

                                this.workSheet["H27"].Value = lotFrom.LOPU3;
                                this.workSheet["H27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                this.workSheet["I27"].Value = "€/T";
                                this.workSheet["I27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;

                                this.workSheet["J27"].Value = "'=";
                                this.workSheet["J27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Left;
                                
                                this.workSheet["K27"].Value = Math.Round((poidsMoyen * lotFrom.LOC13) * lotFrom.LOPU3, 2) + " €";
                                this.workSheet["K27"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
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


                            this.workSheet["B31"].Value = "Soit au kg blanc : ";
                            this.workSheet["D33"].Value = "A déduire N/Acompte du ";
                            this.workSheet["G35"].Value = "Total Hors Taxes";
                            this.workSheet["G36"].Value = "T.V.A";
                            this.workSheet["I36"].Value = "5,5";
                            this.workSheet["J36"].Value = "%";
                            this.workSheet["G38"].Value = "Total Réglé";


                            this.workSheet["B40"].Value = "          Vous en souhaitant bonne réception";
                            this.workSheet["B42"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                            this.workSheet["B43"].Value = "salutations distinguées";
                            this.workSheet["H45"].Value = "Service Comptabilité";
                            this.workSheet[$"H45"].Style.Font.Bold = true;


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



                        // Configuration du style de la feuille (police, ...)
                        this.workSheet.Style.Font.Name = "Arial";



                    }
                    // Propose à l'utilisateur d'enregistrer le fichier Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                    saveFileDialog.Title = "Enregistrez le fichier sous...";
                    saveFileDialog.FileName = "classement " + moisNum.Mois + ".xls";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;

                        workbook.SaveAs(path);
                        workbook.Close();

                    }
                }
            }
        }
    }
}
