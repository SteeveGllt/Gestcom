using Gestcom.Classes;
using Gestcom.ModelAdo;
using Gestcom.Models;
using Microsoft.Office.Interop.Excel;
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
                                LotAdo.updateLotPrix(lot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, newPrice);
                                lot.LOPUAC = newPrice;
                            }
                        }
                        else
                        {
                            // Mettre à jour un seul lot
                            LotAdo.updateLotPrix(this._currentLot.LOFROM, Convert.ToDecimal(tbx_annee.Text), moisNum.Numero, newPrice);
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
    }
}
