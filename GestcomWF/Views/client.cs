using GestcomWF.ModelAdo;
using GestcomWF.Models;
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
    public partial class client : Form
    {
        Client clientSelectionne = null;
        public client()
        {
            InitializeComponent();
            InitializeListView();

            listView1.View = View.Details;
            listView1.Columns.Add("Numéro", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Nom", -2, HorizontalAlignment.Left);

            button1.Enabled = false;
            btnCreate.Enabled = false;
            pbComptaCroix.Visible = false;
            pbRistCroix.Visible = false;
            pbRistCheck.Visible = false;
            pbCheckCompta.Visible = false;
        }

        private void InitializeListView()
        {
            List<Client> clients = ClientAdo.GetClients();
            foreach (Client client in clients)
            {
                var item = new ListViewItem(client.CLNUM.ToString());
                item.SubItems.Add(client.CLNOM);
                listView1.Items.Add(item);
            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (clientSelectionne != null)
            {
                clientSelectionne = null;
            }
            if (listView1.SelectedItems.Count == 0) { return; }

            string numeroClient = listView1.SelectedItems[0].Text;

            Client clientDetails = ClientAdo.GetClientDetails(numeroClient);

            tbxNumClient.Text = clientDetails.CLNUM.ToString();
            tbxNom.Text = clientDetails.CLNOM;
            tbxMtdi.Text = clientDetails.CLMTDI;
            tbxAdresse1.Text = clientDetails.CLADR1;
            tbxAdresse2.Text = clientDetails.CLADR2;
            tbxCp.Text = clientDetails.CLCPOS.ToString();
            tbxVille.Text = clientDetails.CLVILL;
            cbxReglement.Text = clientDetails.CLREGL;
            tbxBaseDepart.Text = clientDetails.CLBASE.ToString();
            tbxDecalageDepart.Text = clientDetails.CLDEPA.ToString();
            tbxEche.Text = clientDetails.CLECHE.ToString();
            tbxDecalageArrive.Text = clientDetails.CLARRI.ToString();
            tbxBanque.Text = clientDetails.CLBQUE.ToString();
            tbxGui.Text = clientDetails.CLGUI.ToString();
            tbxCompte.Text = clientDetails.CLGUI.ToString();
            tbxRib.Text = clientDetails.CLRIB.ToString();
            tbxDom.Text = clientDetails.CLDOM.ToString();
            tbxRep.Text = clientDetails.CLREP.ToString();
            tbxEdit.Text = clientDetails.CLEDIT.ToString();
            tbxFamilleClient.Text = clientDetails.CLFAMI;
            tbxTran.Text = clientDetails.CLTRAN;
            tbxLivr.Text = clientDetails.CLLIVR.ToString();
            tbxFacturation.Text = clientDetails.CLFACT.ToString();
            tbxComp.Text = clientDetails.CLCOMP.ToString();
            tbxRist.Text = clientDetails.CLRIST.ToString();
            tbxRemi.Text = clientDetails.CLREMI.ToString();
            tbxCode.Text = clientDetails.CLCODE;
            tbxTVA.Text = clientDetails.CLTVA.ToString();
            tbxEnse.Text = clientDetails.CLENSE.ToString();
            tbxDiv.Text = clientDetails.CLDIV;
            tbxIntra.Text = clientDetails.CLINTRA;
            tbxDluo.Text = clientDetails.CLDLUO.ToString();
            tbxCompteEbp.Text = clientDetails.CLEBP.ToString();


            clientSelectionne = clientDetails;

            button1.Enabled = true;
            btnCreate.Enabled = true;

            Test();

        }
        private void Test()
        {
            List<Decimal> list = ClientAdo.ExisteNumList();
            foreach (Decimal item in list)
            {
                if (decimal.Parse(tbxComp.Text) != item)
                {
                    pbComptaCroix.Visible = true;
                    pbCheckCompta.Visible = false;
                }
                else
                {
                    pbComptaCroix.Visible = false;
                    pbCheckCompta.Visible = true;
                }
                if (decimal.Parse(tbxRist.Text) != item)
                {
                    pbRistCroix.Visible = true;
                    pbRistCheck.Visible = false;
                }
                else
                {
                    pbRistCroix.Visible = false;
                    pbRistCheck.Visible = true;
                }

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (clientSelectionne == null)
            {
                MessageBox.Show("Pas de client sélectionné");
            }
            else
            {
                //clientSelectionne.CLNUM = 9999;
                //ClientAdo.CreateClient(clientSelectionne);
                /* var item = new ListViewItem(clientSelectionne.CLNUM.ToString());
                 item.SubItems.Add(clientSelectionne.CLNOM);
                 listView1.Items.Add(item);*/

                Client client = ClientAdo.ExisteNumClient(Convert.ToDecimal(tbxNumClient.Text));
                if (client != null)
                {
                    MessageBox.Show("Veuillez changer le numéro de client.");
                    client = null;
                }
                else
                {
                    Client clientUpdate = new Client();
                    clientUpdate.CLNUM = Convert.ToDecimal(tbxNumClient.Text);
                    clientUpdate.CLNOM = tbxNom.Text ?? string.Empty;
                    clientUpdate.CLMTDI = tbxMtdi.Text ?? string.Empty;
                    clientUpdate.CLADR1 = tbxAdresse1.Text ?? string.Empty;
                    clientUpdate.CLADR2 = tbxAdresse2.Text ?? string.Empty;
                    clientUpdate.CLCPOS = Convert.ToDecimal(tbxCp.Text);
                    clientUpdate.CLVILL = tbxVille.Text ?? string.Empty;
                    clientUpdate.CLREGL = cbxReglement.Text ?? string.Empty;
                    clientUpdate.CLBASE = Convert.ToDecimal(tbxBaseDepart.Text);
                    clientUpdate.CLDEPA = Convert.ToDecimal(tbxDecalageDepart.Text);
                    clientUpdate.CLECHE = Convert.ToDecimal(tbxEche.Text);
                    clientUpdate.CLARRI = Convert.ToDecimal(tbxDecalageArrive.Text);
                    clientUpdate.CLBQUE = Convert.ToDecimal(tbxBanque.Text);
                    clientUpdate.CLGUI = Convert.ToDecimal(tbxGui.Text);
                    clientUpdate.CLCPTE = tbxCompte.Text ?? string.Empty;
                    clientUpdate.CLRIB = tbxRib.Text ?? string.Empty;
                    clientUpdate.CLDOM = tbxDom.Text ?? string.Empty;
                    clientUpdate.CLREP = Convert.ToDecimal(tbxRep.Text);
                    clientUpdate.CLEDIT = Convert.ToDecimal(tbxEdit.Text);
                    clientUpdate.CLFAMI = tbxFamilleClient.Text ?? string.Empty;
                    clientUpdate.CLTRAN = tbxTran.Text ?? string.Empty;
                    clientUpdate.CLLIVR = Convert.ToDecimal(tbxLivr.Text);
                    clientUpdate.CLFACT = Convert.ToDecimal(tbxFacturation.Text);
                    clientUpdate.CLCOMP = Convert.ToDecimal(tbxComp.Text);
                    clientUpdate.CLRIST = Convert.ToDecimal(tbxRist.Text);
                    clientUpdate.CLREMI = Convert.ToDecimal(tbxRemi.Text);
                    clientUpdate.CLCODE = tbxCode.Text ?? string.Empty;
                    clientUpdate.CLTVA = Convert.ToDecimal(tbxTVA.Text);
                    clientUpdate.CLENSE = Convert.ToDecimal(tbxEnse.Text);
                    clientUpdate.CLDIV = tbxDiv.Text ?? string.Empty;
                    clientUpdate.CLINTRA = tbxIntra.Text ?? string.Empty;
                    clientUpdate.CLSUPP = " ";
                    clientUpdate.CLDLUO = Convert.ToInt32(tbxDluo.Text);
                    clientUpdate.CLEBP = Convert.ToDecimal(tbxCompteEbp.Text);

                    ClientAdo.CreateClient(clientUpdate);
                    listView1.Items.Clear();
                    InitializeListView();
                }


            }
            //InitializeListView();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment modifier ?", "Modifier", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                decimal ancienneValeur = clientSelectionne.CLNUM;
                Client clientUpdate = new Client();
                clientUpdate.CLNUM = Convert.ToDecimal(tbxNumClient.Text);
                clientUpdate.CLNOM = tbxNom.Text ?? string.Empty;
                clientUpdate.CLMTDI = tbxMtdi.Text ?? string.Empty;
                clientUpdate.CLADR1 = tbxAdresse1.Text ?? string.Empty;
                clientUpdate.CLADR2 = tbxAdresse2.Text ?? string.Empty;
                clientUpdate.CLCPOS = Convert.ToDecimal(tbxCp.Text);
                clientUpdate.CLVILL = tbxVille.Text ?? string.Empty;
                clientUpdate.CLREGL = cbxReglement.Text ?? string.Empty;
                clientUpdate.CLBASE = Convert.ToDecimal(tbxBaseDepart.Text);
                clientUpdate.CLDEPA = Convert.ToDecimal(tbxDecalageDepart.Text);
                clientUpdate.CLECHE = Convert.ToDecimal(tbxEche.Text);
                clientUpdate.CLARRI = Convert.ToDecimal(tbxDecalageArrive.Text);
                clientUpdate.CLBQUE = Convert.ToDecimal(tbxBanque.Text);
                clientUpdate.CLGUI = Convert.ToDecimal(tbxGui.Text);
                clientUpdate.CLCPTE = tbxCompte.Text ?? string.Empty;
                clientUpdate.CLRIB = tbxRib.Text ?? string.Empty;
                clientUpdate.CLDOM = tbxDom.Text ?? string.Empty;
                clientUpdate.CLREP = Convert.ToDecimal(tbxRep.Text);
                clientUpdate.CLEDIT = Convert.ToDecimal(tbxEdit.Text);
                clientUpdate.CLFAMI = tbxFamilleClient.Text ?? string.Empty;
                clientUpdate.CLTRAN = tbxTran.Text ?? string.Empty;
                clientUpdate.CLLIVR = Convert.ToDecimal(tbxLivr.Text);
                clientUpdate.CLFACT = Convert.ToDecimal(tbxFacturation.Text);
                clientUpdate.CLCOMP = Convert.ToDecimal(tbxComp.Text);
                clientUpdate.CLRIST = Convert.ToDecimal(tbxRist.Text);
                clientUpdate.CLREMI = Convert.ToDecimal(tbxRemi.Text);
                clientUpdate.CLCODE = tbxCode.Text ?? string.Empty;
                clientUpdate.CLTVA = Convert.ToDecimal(tbxTVA.Text);
                clientUpdate.CLENSE = Convert.ToDecimal(tbxEnse.Text);
                clientUpdate.CLDIV = tbxDiv.Text ?? string.Empty;
                clientUpdate.CLINTRA = tbxIntra.Text ?? string.Empty;
                clientUpdate.CLDLUO = Convert.ToInt32(tbxDluo.Text);
                clientUpdate.CLEBP = Convert.ToDecimal(tbxCompteEbp.Text);


                ClientAdo.updateClient(clientUpdate, ancienneValeur);
                listView1.Items.Clear();
                InitializeListView();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
