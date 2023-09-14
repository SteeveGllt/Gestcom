using Gestcom.ModelAdo;
using Gestcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestcom.Views
{
    /// <summary>
    /// Logique d'interaction pour entree_lot.xaml
    /// </summary>
    public partial class entree_lot : Window
    {
        List<Fromagerie> fromageries;
        public entree_lot()
        {
            InitializeComponent();
            //Récupération des numéros de Fromagerie
            this.fromageries = FromagerieAdo.all();
            cbxFromagerie.ItemsSource = null;
            cbxFromagerie.ItemsSource = this.fromageries;
            cbxFromagerie.DisplayMemberPath = "FRNUM";
            cbxFromagerie.SelectedIndex = 0;

            // Combobox Mois initialisé avec les numéros des mois
            this.cbxMois.ItemsSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            this.cbxMois.SelectedItem = DateTime.Now.Month;

            // DataPickers configurés avec la date du jour
            dtpDateEntree.SelectedDate = DateTime.Now;
            dtpDateDebut.SelectedDate = DateTime.Now;
            dtpDateFin.SelectedDate = DateTime.Now;
            Console.WriteLine((dtpDateEntree.SelectedDate.Value.Month < 2 && dtpDateEntree.SelectedDate.Value.Day < 10));
            if (dtpDateEntree.SelectedDate.Value.Month < 2 && dtpDateEntree.SelectedDate.Value.Day < 10)
            {
                tbxAnnee.Text = (dtpDateEntree.SelectedDate.Value.Year - 2001).ToString();
            } else
            {
                tbxAnnee.Text = (dtpDateEntree.SelectedDate.Value.Year - 2000).ToString();
            }


            tbxFreinte.IsReadOnly = true;
            tbxPoidsNet.IsReadOnly = true;

            cbxFromagerie.Focus();
        }

        private void dtpDateDebut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbxFreinte.Text = Calcul_Freinte().ToString();
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }

        private void dtpDateEntree_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbxFreinte.Text = Calcul_Freinte().ToString();
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }
        private void dtpDateFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tbxFreinte.Text = Calcul_Freinte().ToString();
            tbxPoidsNet.Text = Calcul_Pds_Net().ToString();
        }
        private decimal Calcul_Freinte()
        {
            // Date de début
            DateTime? dateDebut = dtpDateDebut.SelectedDate;
           

            // Date d'entrée
            DateTime? dateEntree = dtpDateEntree.SelectedDate;
           
           

            // Date de fin
            DateTime? dateFin = dtpDateFin.SelectedDate;
            

            if (dateDebut.HasValue && dateEntree.HasValue && dateFin.HasValue)
            {
               
                // Calcul de la différence entre les dates en jours
                TimeSpan diffDebutEntree = dateEntree.Value - dateFin.Value;
                
                TimeSpan diffEntreeFin = dateFin.Value - dateDebut.Value;
             
                long nbjours = diffDebutEntree.Days + (long)Math.Floor((double)diffEntreeFin.Days / 2);
         
                lblAfficheNbJours.Content = nbjours.ToString();

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

       
    }
}
