using Gestcom.ModelAdo;
using Gestcom.Models;
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
    public partial class fromageries : Form
    {
        List<Fromagerie> froms;
        public fromageries()
        {
            InitializeComponent();
            InitializeFromagerie();

        }

        private void InitializeFromagerie()
        {
            this.froms = FromagerieAdo.all();
            listBox1.DataSource = null;
            listBox1.DataSource = this.froms;
            listBox1.DisplayMember = "FRNUM";
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
