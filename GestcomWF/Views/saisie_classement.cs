﻿using Gestcom.Classes;
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
                if (lotFroms == null || lotFroms.Count <= 0)
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
                            this.workSheet["D10"].Value = lotFrom.FRNOM;
                            this.workSheet["D11"].Value = lotFrom.FRNDIR;
                            this.workSheet["D12"].Value = lotFrom.FRADR;
                            this.workSheet["D13"].Value = lotFrom.FRCPOS + " " + lotFrom.FRVILL;
                            this.workSheet["A18"].Value = "      TB/PB";
                            this.workSheet["D19"].Value = "Le" + " " + DateTime.Now.ToString("D");
                            this.workSheet["B24"].Value = "Monsieur le Président";
                            this.workSheet["B26"].Value = "          Nous vous prions de bien vouloir trouver ci-dessous, pour information,";
                            this.workSheet["B27"].Value = "le classement de votre lot de fabrication ";

                            this.workSheet["F27"].StringValue = moisNum.Mois.ToUpper() + " " + (annee + tbxAnnee.Text);
                            this.workSheet["F27"].Style.Font.Bold = true;

                          
                            // Initialisez la ligne actuelle

                            //int currentRow = 30;
                            if(lotFrom.LOC11 != 0)
                            {
                                this.workSheet["B30"].Value = "- Catégorie A";
                                this.workSheet["B30"].Style.Font.Bold = true;

                            int currentRow = 30;




                            /* foreach (var dateEntry in entreeLotFroms.Where(item => item.FRNUM == entreeLotFrom.FRNUM))
                             {
                                 // Remplissez les données pour chaque entrée de fromagerie
                                 workSheet[$"B{currentRow}"].Value = dateEntry.Date_Entrée;

                                 this.workSheet[$"B{currentRow}"].FormatString = "dd/MM/yyyy";
                                 this.workSheet[$"B{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;

                                 workSheet[$"C{currentRow}"].Value = dateEntry.LOCENM;
                                 this.workSheet[$"C{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;



                                this.workSheet["C30"].Value = "………..";
                                this.workSheet["C30"].Style.Font.Bold = true;
                                this.workSheet["C30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                 workSheet[$"D{currentRow}"].Value = dateEntry.LOCENB;
                                 this.workSheet[$"D{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                                 workSheet[$"E{currentRow}"].Value = dateEntry.LOTAUX;
                                 this.workSheet[$"E{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;
                                 workSheet[$"F{currentRow}"].Value = dateEntry.LOCENN;
                                 this.workSheet[$"F{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.CenterSelection;


                                this.workSheet["F30"].Value = "pains";
                                this.workSheet["F30"].Style.Font.Bold = true;


                                workSheet["E30"].Value = lotFrom.LOC11;
                                this.workSheet["E30"].Style.Font.Bold = true;
                                this.workSheet["E30"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                            }
                            if (lotFrom.LOC12 != 0)
                            {
                                this.workSheet["B31"].Value = "- Catégorie B";
                                this.workSheet["B31"].Style.Font.Bold = true;


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


                                this.workSheet["C31"].Value = "………..";
                                this.workSheet["C31"].Style.Font.Bold = true;
                                this.workSheet["C31"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                this.workSheet["F31"].Value = "pains";
                                this.workSheet["F31"].Style.Font.Bold = true;

                                workSheet["E31"].Value = lotFrom.LOC12;
                                this.workSheet["E31"].Style.Font.Bold = true;
                                this.workSheet["E31"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                            }
                            if (lotFrom.LOC13 != 0)
                            {
                                this.workSheet["B32"].Value = "- Catégorie C";
                                this.workSheet["B32"].Style.Font.Bold = true;

                                this.workSheet["C32"].Value = "………..";
                                this.workSheet["C32"].Style.Font.Bold = true;
                                this.workSheet["C32"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;


                                this.workSheet["F32"].Value = "pains";
                                this.workSheet["F32"].Style.Font.Bold = true;

                                workSheet["E32"].Value = lotFrom.LOC13;
                                this.workSheet["E32"].Style.Font.Bold = true;
                                this.workSheet["E32"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                            }


                            foreach (var dateEntry in lotFroms.Where(item => item.FRNUM == lotFrom.FRNUM))
                             {
                                 // Remplissez les données pour chaque entrée de fromagerie
                                 workSheet[$"E{currentRow}"].Value = dateEntry.LOC11;
                                 this.workSheet[$"E{currentRow}"].Style.Font.Bold = true;
                                 this.workSheet[$"E{currentRow}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;

                                 currentRow++;
                             }

                            // Placez le total à 4 cellules en dessous de la dernière ligne remplie


                            // int totalRow = currentRow + 4;


                            this.workSheet["B34"].Value = "          Nous vous prions d'agréer, Monsieur le Président, nos";
                            this.workSheet["B35"].Value = "salutations distinguées";
                            this.workSheet["E38"].Value = "Service Technique";
                            this.workSheet[$"E38"].Style.Font.Bold = true;


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
                        col5.Width = 1647; // Set width

                       

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
