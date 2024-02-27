using Gestcom.Classes;
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

        private Fromagerie _currentFromagerie;
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



        private void btnModifier_Click(object sender, EventArgs e)
        {



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Récupère l'élément sélectionné, en supposant que la ListBox est liée à une liste d'objets `Lot`
                Fromagerie fromagerie = listBox1.SelectedItem as Fromagerie;

                if (fromagerie != null)
                {
                    Fromagerie fromagerieComplete = FromagerieAdo.allData(fromagerie.FRNUM);

                    tbxFrNum.Text = fromagerieComplete.FRNUM.ToString();
                    tbxFrNom.Text = fromagerieComplete.FRNOM;
                    tbxFrAdr.Text = fromagerieComplete.FRADR;
                    tbxFrCpos.Text = fromagerieComplete.FRCPOS.ToString();
                    tbxFrVill.Text = fromagerieComplete.FRVILL;
                    tbxFrNdir.Text = fromagerieComplete.FRNDIR;
                    tbxFrType.Text = fromagerieComplete.FRTYPE.ToString();
                    tbxFrTcon.Text = fromagerieComplete.FRTCON.ToString();
                    tbxFrCmeu.Text = fromagerieComplete.FRCMEU.ToString();
                    tbxFrCpoi.Text = fromagerieComplete.FRCPOI.ToString();
                    tbxFrModr.Text = fromagerieComplete.FRMODR;
                    tbxFrDomi.Text = fromagerieComplete.FRDOMI;
                    tbxFrBanq.Text = fromagerieComplete.FRBANQ.ToString();
                    tbxFrGuic.Text = fromagerieComplete.FRGUIC.ToString();
                    tbxFrCom1.Text = fromagerieComplete.FRCOM1;
                    tbxFrCom2.Text = fromagerieComplete.FRCOM2;
                    tbxCoe1.Text = fromagerieComplete.COE1.ToString();
                    tbxCoe2.Text = fromagerieComplete.COE2.ToString();
                    tbxCoe3.Text = fromagerieComplete.COE3.ToString();
                    tbxCoe4.Text = fromagerieComplete.COE4.ToString();
                    tbxFrRefa.Text = fromagerieComplete.FRREFA.ToString();
                    tbxFrPuac.Text = fromagerieComplete.FRPUAC.ToString();
                    tbxFrEtre.Text = fromagerieComplete.FRETRE.ToString();
                    tbxFrHive.Text = fromagerieComplete.FRHIVE;
                    tbxFrCver.Text = fromagerieComplete.FRCVER;
                    tbxFrVver.Text = fromagerieComplete.FRVVER.ToString();
                    tbxFrEver.Text = fromagerieComplete.FREVER;
                    tbxFrActif.Text = fromagerieComplete.FRACTIF.ToString();
                    tbxFacturation.Text = fromagerieComplete.FACTURATION.ToString();
                    tbxPrime.Text = fromagerieComplete.FRPRIME.ToString();
                    //tbxFacturation.Text = fromagerieComplete.FACTURATION.ToString();
                    this._currentFromagerie = fromagerieComplete;
                    // Assignez d'autres propriétés de l'objet `lot` à d'autres TextBox si nécessaire
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxFrNum.Text == "" ||
    tbxFrNom.Text == "" ||
    tbxFrAdr.Text == "" ||
    tbxFrCpos.Text == "" ||
    tbxFrVill.Text == "" ||
    tbxFrNdir.Text == "" ||
    tbxFrType.Text == "" ||
    tbxFrTcon.Text == "" ||
    tbxFrCmeu.Text == "" ||
    tbxFrCpoi.Text == "" ||
    tbxFrModr.Text == "" ||
    tbxFrDomi.Text == "" ||
    tbxFrBanq.Text == "" ||
    tbxFrGuic.Text == "" ||
    tbxFrCom1.Text == "" ||
    tbxFrCom2.Text == "" ||
    tbxCoe1.Text == "" ||
    tbxCoe2.Text == "" ||
    tbxCoe3.Text == "" ||
    tbxCoe4.Text == "" ||
    tbxFrRefa.Text == "" ||
    tbxFrPuac.Text == "" ||
    tbxFrEtre.Text == "" ||
    tbxFrHive.Text == "" ||
    tbxFrCver.Text == "" ||
    tbxFrVver.Text == "" ||
    tbxFrEver.Text == "" ||
    tbxFrActif.Text == "")
            {
                // Gestion de l'erreur ou message à l'utilisateur
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            else
            {
                if (this._currentFromagerie != null)
                {
                    Fromagerie fromagerie = new Fromagerie(

                    // Mettre à jour l'objet fromagerie avec les valeurs actuelles des TextBox
                    Convert.ToDecimal(tbxFrNum.Text),
                    tbxFrNom.Text,
                    tbxFrAdr.Text,
                   Convert.ToDecimal(tbxFrCpos.Text),
                    tbxFrVill.Text,
                    tbxFrNdir.Text,
                    Convert.ToDecimal(tbxFrType.Text),
                   Convert.ToDecimal(tbxFrTcon.Text),
                    Convert.ToDecimal(tbxFrCmeu.Text),
                    Convert.ToDecimal(tbxFrCpoi.Text),
                   tbxFrModr.Text,
                   tbxFrDomi.Text,
                    Convert.ToDecimal(tbxFrBanq.Text),
                    Convert.ToDecimal(tbxFrGuic.Text),
                    tbxFrCom1.Text,
                    tbxFrCom2.Text,
                    Convert.ToDecimal(tbxCoe1.Text),
                    Convert.ToDecimal(tbxCoe2.Text),
                    Convert.ToDecimal(tbxCoe3.Text),
                    Convert.ToDecimal(tbxCoe4.Text),
                    Convert.ToDecimal(tbxFrRefa.Text),
                    Convert.ToDecimal(tbxFrPuac.Text),
                    Convert.ToDecimal(tbxFrEtre.Text),
                    tbxFrHive.Text,
                   tbxFrCver.Text,
                    Convert.ToDecimal(tbxFrVver.Text),
                    tbxFrEver.Text,
                    Convert.ToBoolean(tbxFrActif.Text),
                    Convert.ToDecimal(tbxFacturation.Text),
                    Convert.ToDecimal(tbxPrime.Text)
                        );

                    // Appeler la méthode pour mettre à jour la base de données avec le fromagerie modifié
                    FromagerieAdo.updateFromagerie(fromagerie);


                }
                else
                {
                    MessageBox.Show("Aucune fromagerie sélectionnée pour mise à jour");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
