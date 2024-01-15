using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.Classes;
using IronXL;
using System.Windows.Forms;

namespace GestcomWF.Views
{

    public partial class saisie_classement : Form
    {
        // Membre pour garder une trace du lot actuel
        private Lot _currentLot = null;

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

        // Constructeur de la classe
        public saisie_classement()
        {
            InitializeComponent();
            InitializeDataGridView();
            // Initialiser la combobox avec les mois
            cbxMois.DataSource = listeObjets;
            cbxMois.DisplayMember = "Mois";
            cbxMois.SelectedIndex = 0;
            // Initialiser le DataGridView sans source de données
            dataGridView.DataSource = null;

            RemplirComboBox(DateTime.Now);
            AjusterAnneeAuDemarrage();
        }


        // Génère des lots basés sur le mois et l'année entrés
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
        private void CalculateRemaining()
        {
            int total = Convert.ToInt32(tbx_total.Text);  // Vous pouvez récupérer cette valeur depuis un autre champ si nécessaire
            int valueA = 0;
            int valueB = 0;
            int valueC = 0;

            int.TryParse(tbx_a.Text, out valueA);
            int.TryParse(tbx_b.Text, out valueB);
            int.TryParse(tbx_c.Text, out valueC);

            int remaining = total - valueA - valueB;

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
                CalculateRemaining();
                tbx_b.Focus();
            }

        }

        // Si l'utilisateur appuie sur Enter après avoir entré une valeur dans tbx_b
        private void tbx_b_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateRemaining();
                tbx_c.Focus();
            }

        }

        // Si l'utilisateur appuie sur Enter après avoir entré une valeur dans tbx_c
        private void tbx_c_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateRemaining();
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
                    _currentLot = null;
                    tbx_a.Text = "";
                    tbx_b.Text = "";
                    tbx_c.Text = "";
                    tbx_total.Text = "";

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
                                workSheet["D19"].Value = "Le" + " " + DateTime.Now.ToString("D");
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
            RemplirComboBox(dtpDate.Value);
            AjusterAnnee();
        }
        private void RemplirComboBox(DateTime dateSelectionnee)
        {
            // Calculer le mois précédent de 4 mois à partir de la date sélectionnée
            DateTime moisPrecedent = dateSelectionnee.AddMonths(-4);

            // Filtrer la liste des mois pour inclure uniquement ceux après le mois précédent
            List<MoisNum> moisFiltres = listeObjets
                .Where(mois => mois.Numero >= moisPrecedent.Month)
                .ToList();

            // Mettre à jour la ComboBox avec la liste filtrée
            cbxMois.DataSource = moisFiltres;
            cbxMois.DisplayMember = "Mois";
            cbxMois.ValueMember = "Numero";

            if (int.TryParse(tbxAnnee.Text, out int annee))
            {
                // Soustraire une année si le mois précédent est dans l'année actuelle
                if (moisPrecedent.Year == dateSelectionnee.Year)
                {
                    tbxAnnee.Text = (annee - 1).ToString();
                }
            }
        }
        private void AjusterAnneeAuDemarrage()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime dateDemarrage = DateTime.Now.AddMonths(-4);
            int anneeAjustee = dateDemarrage.Month <= 2 ? dateDemarrage.Year - 1 : dateDemarrage.Year;

            // Préremplir la TextBox avec l'année ajustée
            tbxAnnee.Text = (anneeAjustee % 100).ToString("00");
        }

        private void AjusterAnnee()
        {
            // Ajuster l'année en fonction du mois précédent de 4 mois
            DateTime moisPrecedent = dtpDate.Value.AddMonths(-4);
            int anneeAjustee = moisPrecedent.Month <= 2 ? moisPrecedent.Year - 1 : moisPrecedent.Year;
            tbxAnnee.Text = (anneeAjustee % 100).ToString("00");
        }
    }
}
