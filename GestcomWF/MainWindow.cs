using GestcomWF.Views;
namespace GestcomWF
{
    public partial class MainWindow : Form
    {
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

        private void editPes�eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_pesee edit_Pesee = new edit_pesee();
            edit_Pesee.MdiParent = this;
            edit_Pesee.Show();
        }
    }
}