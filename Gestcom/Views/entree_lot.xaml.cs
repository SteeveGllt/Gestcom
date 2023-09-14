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

        public entree_lot()
        {
            InitializeComponent();
            // Combobox Mois initialisé avec les numéros des mois
            this.cbxMois.ItemsSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            this.cbxMois.SelectedItem = DateTime.Now.Month;

            // DataPickers configurés avec la date du jour
            dtpDateEntree.SelectedDate = DateTime.Now;
            dtpDateDebut.SelectedDate = DateTime.Now;
            dtpDateFin.SelectedDate = DateTime.Now;
        }
    }
}
