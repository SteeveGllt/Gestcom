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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestcomWF.Views
{

    public partial class saisie_classement : Form
    {
        // Membre pour garder une trace du lot actuel
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
                tbx_a.Text = lot.LOC11.ToString();
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

                Decimal valeurPrecedente = 0;


                // Récupération du mois sélectionné depuis la comboBox
                MoisNum moisNum = (MoisNum)cbxMois.SelectedItem;

                // Récupération de toutes les entrées pour le mois et l'année donnés
                List<LotFrom> lotFroms = LotAdo.generationFichierExcelClassement(moisNum.Numero, Convert.ToDecimal(tbxAnnee.Text));
                if (lotFroms.Count <= 0)
                {
                    MessageBox.Show("Aucune valeur");
                }
                else
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
                            this.workSheet = workbook.CreateWorkSheet(nomFeuille);
                            this.workSheet["D7"].Value = lotFrom.FRNDIR;
                            this.workSheet["D8"].Value = "Président " + lotFrom.FRNOM;
                            this.workSheet["D9"].Value = lotFrom.FRADR;
                            this.workSheet["D10"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL; // JE ME SUIS ARRETE LA
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




                            /* foreach (var dateEntry in entreeLotFroms.Where(item => item.FRNUM == entreeLotFrom.FRNUM))
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
                             }*/
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

                            // valeurPrecedente = entreeLotFrom.FRNUM;
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
                        this.workSheet.Style.Font.Name = "Arial";

                    }
                    // Propose à l'utilisateur d'enregistrer le fichier Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files(*.xls; *.xlsx)| *.xls; *.xlsx";
                    saveFileDialog.Title = "Enregistrez le fichier sous...";
                    saveFileDialog.FileName = "saisie_pesee " + moisNum.Mois + ".xls";
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
