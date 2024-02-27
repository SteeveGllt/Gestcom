using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.ModelAdo;
using GestcomWF.Models;
using SixLabors.Fonts;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GestcomWF.Views
{
    public partial class article : Form
    {
        private Article _articleSelectionne = null;
        public article()
        {
            InitializeComponent();
            InitializeListView();

            listViewArticle.View = View.Details;
            listViewArticle.Columns.Add("ARNUM", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARDESI", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARFAMI", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARUNIT", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARPRIX", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARTVA", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARPOID", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARCEC", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARCOMP1", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARCOMP2", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARDLUO", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("AREAN13", -2, System.Windows.Forms.HorizontalAlignment.Left);
        }
        private void InitializeListView()
        {
            List<Article> articles = ArticleAdo.all();
            foreach (Article article in articles)
            {
                var item = new ListViewItem(article.ARNUM.ToString());
                item.SubItems.Add(article.ARDESI);
                item.SubItems.Add(article.ARFAMI);
                item.SubItems.Add(article.ARUNIT);
                item.SubItems.Add(article.ARPRIX.ToString());
                item.SubItems.Add(article.ARTVA.ToString());
                item.SubItems.Add(article.ARPOID.ToString());
                item.SubItems.Add(article.ARCEC);
                item.SubItems.Add(article.ARCOMP1.ToString());
                item.SubItems.Add(article.ARCOMP2.ToString());
                item.SubItems.Add(article.ARDLUO.ToString());
                item.SubItems.Add(article.AREAN13.ToString());
                listViewArticle.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewArticle.Items.Clear();
            InitializeListView();
        }

        private void listViewArticle_DoubleClick(object sender, EventArgs e)
        {
            if (listViewArticle.SelectedItems.Count == 0) { return; }

            string numeroArticle = listViewArticle.SelectedItems[0].Text;

            Article articleDetails = ArticleAdo.GetArticletDetails(numeroArticle);


            tbxNumArt.Text = articleDetails.ARNUM.ToString();
            tbxDesiArt.Text = articleDetails.ARDESI;
            tbxFamiArt.Text = articleDetails.ARFAMI;
            tbxUnitArt.Text = articleDetails.ARUNIT;
            tbxPrixArt.Text = articleDetails.ARPRIX.ToString();
            tbxTvaArt.Text = articleDetails.ARTVA.ToString();
            tbxPoidArt.Text = articleDetails.ARPOID.ToString();
            tbxCecArt.Text = articleDetails.ARCEC;
            tbxComp1.Text = articleDetails.ARCOMP1.ToString();
            tbxComp2.Text = articleDetails.ARCOMP2.ToString();
            tbxDluo.Text = articleDetails.ARDLUO.ToString();
            tbxEan13.Text = articleDetails.AREAN13.ToString();

            _articleSelectionne = articleDetails;

            button1.Enabled = true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_articleSelectionne != null)
            {
                ArticleAdo.updateArticle(Convert.ToDecimal(tbxNumArt.Text), tbxDesiArt.Text, tbxFamiArt.Text, tbxUnitArt.Text, Convert.ToDecimal(tbxPrixArt.Text), Convert.ToDecimal(tbxTvaArt.Text), Convert.ToDecimal(tbxPoidArt.Text), tbxCecArt.Text, Convert.ToInt32(tbxComp1.Text), Convert.ToInt32(tbxComp2.Text), Convert.ToInt32(tbxDluo.Text), Convert.ToInt32(tbxEan13.Text));
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un article");
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (_articleSelectionne == null)
            {
                MessageBox.Show("Pas d'article sélectionné");
            }
            else
            {
                //clientSelectionne.CLNUM = 9999;
                //ClientAdo.CreateClient(clientSelectionne);
                /* var item = new ListViewItem(clientSelectionne.CLNUM.ToString());
                 item.SubItems.Add(clientSelectionne.CLNOM);
                 listView1.Items.Add(item);*/

                Article article = ArticleAdo.ExisteNumArticle(Convert.ToDecimal(tbxNumArt.Text));
                if (article != null)
                {
                    MessageBox.Show("Veuillez changer le numéro de l'article.");
                    article = null;
                }
                else
                {
                    Article articleNew = new Article();
                    articleNew.ARNUM = Convert.ToDecimal(tbxNumArt.Text);
                    articleNew.ARDESI = tbxDesiArt.Text;
                    articleNew.ARFAMI = tbxFamiArt.Text;
                    articleNew.ARUNIT = tbxUnitArt.Text;
                    articleNew.ARPRIX = Convert.ToDecimal(tbxPrixArt.Text);
                    articleNew.ARTVA = Convert.ToDecimal(tbxTvaArt.Text);
                    articleNew.ARPOID = Convert.ToDecimal(tbxPoidArt.Text);
                    articleNew.ARCEC = tbxCecArt.Text;
                    articleNew.ARCOMP1 = Convert.ToInt16(tbxComp1.Text);
                    articleNew.ARCOMP2 = Convert.ToInt16(tbxComp2.Text);
                    articleNew.ARDLUO = Convert.ToInt16(tbxDluo.Text);
                    articleNew.AREAN13 = Convert.ToInt16(tbxEan13.Text);

                    ArticleAdo.createArticle(articleNew);
                    listViewArticle.Items.Clear();
                    InitializeListView();
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(_articleSelectionne != null)
            {
                decimal numArt = _articleSelectionne.ARNUM;
                DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Suppression", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ArticleAdo.deleteArticle(numArt);
                    listViewArticle.Items.Clear();
                    InitializeListView();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            } else
            {
                MessageBox.Show("Veuillez selectionner un article");
            }
           
        }
    }
}
