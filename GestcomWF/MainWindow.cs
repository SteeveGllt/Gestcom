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

        private void classementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saisie_classement saisie_classement = new saisie_classement();
            saisie_classement.MdiParent = this;
            saisie_classement.Show();
        }

        private void calculatriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculatrice calculatrice = new calculatrice();
            calculatrice.MdiParent = this;
            calculatrice.Show();
        }


        private void fromageriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromageries fromageries = new fromageries();
            fromageries.MdiParent = this;
            fromageries.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client client = new client();
            client.MdiParent = this;
            client.Show();
        }

        private void fichiersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saisieÉditionDesAcomptesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saisie_acompte saisie_Acompte = new saisie_acompte();
            saisie_Acompte.MdiParent = this;
            saisie_Acompte.Show();
        }

        private void saisieÉditionDesRappelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saisie_rappel saisie_Rappel = new saisie_rappel();
            saisie_Rappel.MdiParent = this;
            saisie_Rappel.Show();
        }

        private void editionDesPeséesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_pesee edit_Pesee = new edit_pesee();
            edit_Pesee.MdiParent = this;
            edit_Pesee.Show();
        }
    }
}