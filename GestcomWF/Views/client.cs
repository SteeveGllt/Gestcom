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
        public client()
        {
            InitializeComponent();
            InitializeListView();

            listView1.View = View.Details;
            listView1.Columns.Add("Numéro", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Nom", -2, HorizontalAlignment.Left);
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
            if (listView1.SelectedItems.Count == 0) { return; }

            string numeroClient = listView1.SelectedItems[0].Text;

            Client clientDetails = ClientAdo.GetClientDetails(numeroClient);

            tbxNom.Text = clientDetails.CLNOM;
            tbxMtdi.Text = clientDetails.CLMTDI;
            tbxAdresse1.Text = clientDetails.CLADR1;
            tbxAdresse2.Text = clientDetails.CLADR2;
            tbxCp.Text = clientDetails.CLCPOS.ToString();
            tbxVille.Text = clientDetails.CLVILL;
            tbxBanque.Text = clientDetails.CLBQUE.ToString();
            tbxGui.Text = clientDetails.CLGUI.ToString();
            tbxCompte.Text = clientDetails.CLGUI.ToString();
            tbxRib.Text = clientDetails.CLRIB.ToString();
            tbxDom.Text = clientDetails.CLDOM.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            creation_client creation_Client = new creation_client();
            creation_Client.MdiParent = this;
            creation_Client.Show();
        }
    }
}
