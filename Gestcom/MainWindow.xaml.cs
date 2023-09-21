using Gestcom.ModelAdo;
using Gestcom.Models;
using Gestcom.Views;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestcom
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
         

        }

        private void Entree_Click(object sender, RoutedEventArgs e)
        {
            entree_lot entree = new entree_lot();
            entree.Show();
        }

        private void Pesée_Click(object sender, RoutedEventArgs e)
        {
            edit_pesee edit = new edit_pesee();
            edit.Show();
        }
    }
}
