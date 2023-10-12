using GestcomWF.Views;
using System.Drawing.Printing;

namespace GestcomWF
{
    public partial class MainWindow : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void entréeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entree_lot entree_Lot = new entree_lot();
            entree_Lot.MdiParent = this;
            entree_Lot.Show();
        }

        private void editPeséeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_pesee edit_Pesee = new edit_pesee();
            edit_Pesee.MdiParent = this;
            edit_Pesee.Show();
        }

        private void imprimantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // L'utilisateur a choisi une imprimante et a cliqué sur "OK"
                    // Si nécessaire, vous pouvez maintenant imprimer le document en utilisant:
                    // printDocument.Print();

                    // Pour récupérer le nom de l'imprimante sélectionnée:
                    string printerName = printDocument.PrinterSettings.PrinterName;
                    MessageBox.Show($"Vous avez choisi l'imprimante: {printerName}");
                }
            }
        }
    }
}