using Gestcom.ModelAdo;
using Gestcom.Models;
using GestcomWF.ModelAdo;
using GestcomWF.Models;
using SixLabors.Fonts;

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
            listViewArticle.Columns.Add("ARDIV", -2, System.Windows.Forms.HorizontalAlignment.Left);
            listViewArticle.Columns.Add("ARSUPP", -2, System.Windows.Forms.HorizontalAlignment.Left);
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
                item.SubItems.Add(article.ARDIV);
                item.SubItems.Add(article.ARSUPP);
                listViewArticle.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

            _articleSelectionne = articleDetails;

            button1.Enabled = true;
        }
    }
}
