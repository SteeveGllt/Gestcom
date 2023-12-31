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

        private void entr�eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entree_lot entree_Lot = new entree_lot();
            entree_Lot.MdiParent = this;
            entree_Lot.Show();
        }

        private void saisiePes�esToolStripMenuItem_Click(object sender, EventArgs e)
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
                    // L'utilisateur a choisi une imprimante et a cliqu� sur "OK"
                    // Si n�cessaire, vous pouvez maintenant imprimer le document en utilisant:
                    // printDocument.Print();

                    // Pour r�cup�rer le nom de l'imprimante s�lectionn�e:
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

        private void saisieAcompteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saisie_acompte saisie_Acompte = new saisie_acompte();
            saisie_Acompte.MdiParent = this;
            saisie_Acompte.Show();
        }

        private void saisieRappelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saisie_rappel saisie_Rappel = new saisie_rappel();
            saisie_Rappel.MdiParent = this;
            saisie_Rappel.Show();
        }
    }
}