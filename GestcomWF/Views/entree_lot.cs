using Gestcom.ModelAdo;
using Gestcom.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GestcomWF.Views
{
    public partial class entree_lot : Form
    {
        // Constantes pour calculer l'année
        private const int MAGIC_YEAR_START = 2000;
        private const int MAGIC_YEAR_DIFFERENCE = 2001;
        List<Fromagerie> fromageries; // Liste des fromageries

        // Constructeur
        public entree_lot()
        {
            InitializeComponent();
            InitializeFromagerie();
            InitializeComboboxMois();
            InitializeDatePickers();
            InitializeTextBoxes();
            cbxFromagerie.Focus();

        }

        // Initialisation de la liste des fromageries à partir de la base de données
        private void InitializeFromagerie()
        {
            this.fromageries = FromagerieAdo.all();
            cbxFromagerie.DataSource = null;
            cbxFromagerie.DataSource = this.fromageries;
            cbxFromagerie.DisplayMember = "FRNUM";
            cbxFromagerie.SelectedIndex = 0;
        }

        // Initialisation de la combobox des mois
        private void InitializeComboboxMois()
        {
            this.cbxMois.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            this.cbxMois.SelectedItem = DateTime.Now.Month;
        }

        // Initialisation des DateTimePickers avec la date courante
        private void InitializeDatePickers()
        {
            DateTime currentDateTime = DateTime.Now;
            dtpDateEntree.Value = currentDateTime;
            dtpDateDebut.Value = currentDateTime;
            dtpDateFin.Value = currentDateTime;
        }

        // Initialisation des TextBoxes
        private void InitializeTextBoxes()
        {
            tbxPoidsNet.ReadOnly = true;
            tbxAnnee.Text = ComputeAnnee(dtpDateEntree.Value).ToString();
        }

        // Calcul de l'année basé sur la date
        private int ComputeAnnee(DateTime date)
        {
            if (date.Month < 2 && date.Day < 10)
            {
                return date.Year - MAGIC_YEAR_DIFFERENCE;
            }
            else
            {
                return date.Year - MAGIC_YEAR_START;
            }
        }

        // Mettre à jour les champs de Freinte et PoidsNet
        private void UpdateFreinteAndPoidsNet()
        {
            tbxFreinte.Text = Calcul_Freinte().ToString();
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }

        // Événements lors du changement des dates
        private void dtpDateEntree_ValueChanged(object sender, EventArgs e)
        {
            UpdateFreinteAndPoidsNet();
        }

        private void dtpDateDebut_ValueChanged(object sender, EventArgs e)
        {
            UpdateFreinteAndPoidsNet();
        }

        private void dtpDateFin_ValueChanged(object sender, EventArgs e)
        {
            UpdateFreinteAndPoidsNet();
        }

        // Calcul de la freinte basé sur les dates
        private decimal Calcul_Freinte()
        {
            // Récupération des dates
            // Date de début
            DateTime? dateDebut = dtpDateDebut.Value;


            // Date d'entrée
            DateTime? dateEntree = dtpDateEntree.Value;



            // Date de fin
            DateTime? dateFin = dtpDateFin.Value;


            if (dateDebut.HasValue && dateEntree.HasValue && dateFin.HasValue)
            {

                // Calcul de la différence entre les dates en jours
                TimeSpan diffDebutEntree = dateEntree.Value - dateFin.Value;

                TimeSpan diffEntreeFin = dateFin.Value - dateDebut.Value;

                long nbjours = diffDebutEntree.Days + (long)Math.Floor((double)diffEntreeFin.Days / 2);

                label1.Text = nbjours.ToString();

                if (nbjours <= 0)
                {
                    return 6;
                }
                else if (nbjours <= 2)
                {

                    return 6 - (nbjours - 1) * 1.5m;
                }
                else if (nbjours <= 5)
                {
                    return 4.5m - (nbjours - 2) * 0.5m;
                }
                else if (nbjours <= 35)
                {
                    return 3m - (nbjours - 5) * 0.1m;
                }
                else if (nbjours < 40)
                {
                    return 0;
                }
                else if (nbjours <= 45)
                {
                    return -0.1m * (nbjours - 39);
                }
                else
                {
                    return -0.6m;
                }
            }
            return Math.Round(1m);
        }

        // Calcul du poids net
        private int Calcul_Pds_Net()
        {
            try
            {
                double poidsBrut = Convert.ToDouble(tbxPoidsBrut.Text);
                double freinte = Convert.ToDouble(tbxFreinte.Text);
                int resultat = (int)(poidsBrut * (1 - freinte / 100));
                return resultat;
            }
            catch (FormatException)
            {
                // Gérer l'exception de format si la conversion échoue
                return 0; // Ou une autre valeur par défaut appropriée
            }
        }

        // Événement lors du clic sur le bouton1
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxPains.Text != "" && tbxPoidsBrut.Text != "")
            {
                Lot lot = LotAdo.ExisteLot(Convert.ToDecimal(cbxFromagerie.Text), Convert.ToDecimal(tbxAnnee.Text), Convert.ToDecimal(cbxMois.Text));
                if (lot != null)
                {
                    CultureInfo culture = new CultureInfo("fr-FR");
                    Console.WriteLine(lot.LOFROM + " " + lot.LOANNE + " " + lot.LOMOIS);
                    lot.LOCEM1 = Convert.ToDecimal(tbxPains.Text);
                    lot.LOCEB1 = Convert.ToDecimal(tbxPoidsBrut.Text);

                    lot.LOCEN1 = Convert.ToDecimal(tbxPoidsNet.Text);
                    Console.WriteLine(lot.LOCEM1 + " " + lot.LOCEB1 + " " + lot.LOCEN1);
                    LotAdo.updateLot(lot.LOFROM, lot.LOANNE, lot.LOMOIS, lot.LOCEM1, lot.LOCEB1, lot.LOCEN1);
                }
                else
                {
                    Lot newLot = new Lot();
                    newLot.LOFROM = Convert.ToDecimal(cbxFromagerie.Text);
                    newLot.LOANNE = Convert.ToDecimal(tbxAnnee.Text);
                    newLot.LOMOIS = Convert.ToDecimal(cbxMois.Text);
                    newLot.LOCEM1 = Convert.ToDecimal(tbxPains.Text);
                    newLot.LOCEB1 = Convert.ToDecimal(tbxPoidsBrut.Text);
                    newLot.LOCEN1 = Convert.ToDecimal(tbxPoidsNet.Text);
                    LotAdo.createLot(newLot);
                }
                if (cbAffiner.Checked)
                {
                    EntreeLot entreeLotAffiner = new EntreeLot();
                    entreeLotAffiner.LOFROM = Convert.ToDecimal(cbxFromagerie.Text);
                    entreeLotAffiner.LOANNE = Convert.ToDecimal(tbxAnnee.Text);
                    entreeLotAffiner.LOMOIS = Convert.ToDecimal(cbxMois.Text);
                    entreeLotAffiner.Date_Entrée = dtpDateEntree.Value;
                    entreeLotAffiner.LOCENM = Convert.ToDecimal(tbxPains.Text);
                    entreeLotAffiner.LOCENB = Convert.ToDecimal(tbxPoidsBrut.Text);
                    entreeLotAffiner.LOCENN = Convert.ToDecimal(tbxPoidsNet.Text);
                    entreeLotAffiner.LOTAUX = Convert.ToDouble(tbxFreinte.Text);
                    LotAdo.createEntreeLotAffine(entreeLotAffiner);
                }
                else
                {
                    EntreeLot entreeLot = new EntreeLot();
                    entreeLot.LOFROM = Convert.ToDecimal(cbxFromagerie.Text);
                    entreeLot.LOANNE = Convert.ToDecimal(tbxAnnee.Text);
                    entreeLot.LOMOIS = Convert.ToDecimal(cbxMois.Text);
                    entreeLot.Date_Entrée = dtpDateEntree.Value;
                    entreeLot.Date_Début = dtpDateDebut.Value;
                    entreeLot.DAte_Fin = dtpDateFin.Value;
                    entreeLot.LOCENM = Convert.ToDecimal(tbxPains.Text);
                    entreeLot.LOCENB = Convert.ToDecimal(tbxPoidsBrut.Text);
                    entreeLot.LOCENN = Convert.ToDecimal(tbxPoidsNet.Text);
                    entreeLot.LOTAUX = Convert.ToDouble(tbxFreinte.Text);

                    LotAdo.createEntreeLot(entreeLot);
                }
                ResetForm();
            }
            else
            {
                MessageBox.Show("Veuillez entrer des valeurs dans les champs Nb Pains et Poids Brut");
            }
        }

        // Événements lors de la saisie dans les champs PoidsBrut et Freinte
        private void tbxPoidsBrut_KeyUp(object sender, KeyEventArgs e)
        {
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }

        private void tbxFreinte_KeyUp(object sender, KeyEventArgs e)
        {
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }

        // Événement lors du changement de l'état de la checkbox Affiner
        private void cbAffiner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAffiner.Checked)
            {
                this.fromageries = FromagerieAdo.allNonActif();
                cbxFromagerie.DataSource = null;
                cbxFromagerie.DataSource = this.fromageries;
                cbxFromagerie.DisplayMember = "FRNUM";
                cbxFromagerie.SelectedIndex = 0;

                tbxFreinte.Text = "0";
                tbxPoidsNet.Text = Calcul_Pds_Net().ToString();

                lblDate_debut.Visible = false;
                lblDate_fin.Visible = false;
                dtpDateDebut.Visible = false;
                dtpDateFin.Visible = false;
            }
            else
            {
                InitializeFromagerie();

                tbxFreinte.Text = Calcul_Freinte().ToString();
                tbxPoidsNet.Text = Calcul_Pds_Net().ToString();


                lblDate_debut.Visible = true;
                lblDate_fin.Visible = true;
                dtpDateDebut.Visible = true;
                dtpDateFin.Visible = true;
            }
        }

        // Méthode pour réinitialiser le formulaire
        private void ResetForm()
        {
            // Remettre à zéro les ComboBox
            cbxFromagerie.SelectedIndex = 0;
            cbxMois.SelectedItem = DateTime.Now.Month;

            // Remettre à zéro les DateTimePickers
            dtpDateEntree.Value = DateTime.Now;
            dtpDateDebut.Value = DateTime.Now;
            dtpDateFin.Value = DateTime.Now;

            // Remettre à zéro les TextBox
            tbxPoidsNet.Text = "";
            tbxPains.Text = "";
            tbxPoidsBrut.Text = "";
            tbxFreinte.Text = Calcul_Freinte().ToString();
            tbxAnnee.Text = (dtpDateEntree.Value.Year - 2000).ToString();

            cbAffiner.Checked = false;
        }

        private void cbxFromagerie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
