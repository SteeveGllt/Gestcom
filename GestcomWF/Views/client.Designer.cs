using System.Windows.Forms;

namespace GestcomWF.Views
{
    partial class client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listView1 = new ListView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbxAdresse2 = new TextBox();
            tbxVille = new TextBox();
            tbxCp = new TextBox();
            tbxAdresse1 = new TextBox();
            tbxMtdi = new TextBox();
            tbxNom = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            tbxDom = new TextBox();
            label12 = new Label();
            tbxRib = new TextBox();
            label11 = new Label();
            tbxCompte = new TextBox();
            label10 = new Label();
            tbxGui = new TextBox();
            label9 = new Label();
            tbxBanque = new TextBox();
            label8 = new Label();
            tabPage3 = new TabPage();
            btnCreate = new Button();
            label13 = new Label();
            cbxRegl = new ComboBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            tbxBase = new TextBox();
            tbxDepa = new TextBox();
            tbxEche = new TextBox();
            tbxArri = new TextBox();
            tbxFact = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(218, 435);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(250, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(388, 435);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbxAdresse2);
            tabPage1.Controls.Add(tbxVille);
            tabPage1.Controls.Add(tbxCp);
            tabPage1.Controls.Add(tbxAdresse1);
            tabPage1.Controls.Add(tbxMtdi);
            tabPage1.Controls.Add(tbxNom);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new System.Drawing.Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(380, 402);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Informations générales";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxAdresse2
            // 
            tbxAdresse2.Location = new System.Drawing.Point(6, 128);
            tbxAdresse2.Name = "tbxAdresse2";
            tbxAdresse2.Size = new System.Drawing.Size(136, 27);
            tbxAdresse2.TabIndex = 12;
            // 
            // tbxVille
            // 
            tbxVille.Location = new System.Drawing.Point(250, 84);
            tbxVille.Name = "tbxVille";
            tbxVille.Size = new System.Drawing.Size(124, 27);
            tbxVille.TabIndex = 11;
            // 
            // tbxCp
            // 
            tbxCp.Location = new System.Drawing.Point(152, 85);
            tbxCp.Name = "tbxCp";
            tbxCp.Size = new System.Drawing.Size(89, 27);
            tbxCp.TabIndex = 10;
            // 
            // tbxAdresse1
            // 
            tbxAdresse1.Location = new System.Drawing.Point(6, 84);
            tbxAdresse1.Name = "tbxAdresse1";
            tbxAdresse1.Size = new System.Drawing.Size(136, 27);
            tbxAdresse1.TabIndex = 9;
            // 
            // tbxMtdi
            // 
            tbxMtdi.Location = new System.Drawing.Point(122, 26);
            tbxMtdi.Name = "tbxMtdi";
            tbxMtdi.Size = new System.Drawing.Size(100, 27);
            tbxMtdi.TabIndex = 8;
            // 
            // tbxNom
            // 
            tbxNom.Location = new System.Drawing.Point(6, 26);
            tbxNom.Name = "tbxNom";
            tbxNom.Size = new System.Drawing.Size(100, 27);
            tbxNom.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 110);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 20);
            label7.TabIndex = 6;
            label7.Text = "Adresse 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(250, 67);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(38, 20);
            label6.TabIndex = 5;
            label6.Text = "Ville";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(152, 67);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 20);
            label5.TabIndex = 4;
            label5.Text = "Code postal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 67);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "Adresse 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(120, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "MTDI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Nom";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 23);
            label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tbxDom);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(tbxRib);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(tbxCompte);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(tbxGui);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(tbxBanque);
            tabPage2.Controls.Add(label8);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(380, 402);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Banque";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbxDom
            // 
            tbxDom.Location = new System.Drawing.Point(9, 145);
            tbxDom.Name = "tbxDom";
            tbxDom.Size = new System.Drawing.Size(213, 27);
            tbxDom.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 127);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(99, 20);
            label12.TabIndex = 9;
            label12.Text = "Domiciliation";
            // 
            // tbxRib
            // 
            tbxRib.Location = new System.Drawing.Point(185, 78);
            tbxRib.MaxLength = 2;
            tbxRib.Name = "tbxRib";
            tbxRib.Size = new System.Drawing.Size(58, 27);
            tbxRib.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(185, 60);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(31, 20);
            label11.TabIndex = 7;
            label11.Text = "RIB";
            // 
            // tbxCompte
            // 
            tbxCompte.Location = new System.Drawing.Point(9, 78);
            tbxCompte.MaxLength = 11;
            tbxCompte.Name = "tbxCompte";
            tbxCompte.Size = new System.Drawing.Size(155, 27);
            tbxCompte.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(9, 60);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(141, 20);
            label10.TabIndex = 5;
            label10.Text = "Numéro de Compte";
            // 
            // tbxGui
            // 
            tbxGui.Location = new System.Drawing.Point(126, 21);
            tbxGui.MaxLength = 5;
            tbxGui.Name = "tbxGui";
            tbxGui.Size = new System.Drawing.Size(82, 27);
            tbxGui.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(126, 3);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(98, 20);
            label9.TabIndex = 3;
            label9.Text = "Code Guichet";
            // 
            // tbxBanque
            // 
            tbxBanque.Location = new System.Drawing.Point(9, 21);
            tbxBanque.MaxLength = 5;
            tbxBanque.Name = "tbxBanque";
            tbxBanque.Size = new System.Drawing.Size(100, 27);
            tbxBanque.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 3);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(98, 20);
            label8.TabIndex = 0;
            label8.Text = "Code Banque";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tbxFact);
            tabPage3.Controls.Add(tbxArri);
            tabPage3.Controls.Add(tbxEche);
            tabPage3.Controls.Add(tbxDepa);
            tabPage3.Controls.Add(tbxBase);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(cbxRegl);
            tabPage3.Controls.Add(label13);
            tabPage3.Location = new System.Drawing.Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new System.Drawing.Size(380, 402);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Règlement";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new System.Drawing.Point(559, 453);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(75, 23);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Créer";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 12);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(141, 20);
            label13.TabIndex = 0;
            label13.Text = "Mode de règlement";
            // 
            // cbxRegl
            // 
            cbxRegl.FormattingEnabled = true;
            cbxRegl.Location = new System.Drawing.Point(153, 9);
            cbxRegl.Name = "cbxRegl";
            cbxRegl.Size = new System.Drawing.Size(68, 28);
            cbxRegl.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(6, 58);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(145, 20);
            label14.TabIndex = 2;
            label14.Text = "Date de base départ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(6, 94);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(120, 20);
            label15.TabIndex = 3;
            label15.Text = "Décalage départ";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(6, 133);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(199, 20);
            label16.TabIndex = 4;
            label16.Text = "Nombre de jours d'échéance";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 174);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(113, 20);
            label17.TabIndex = 5;
            label17.Text = "Décalage arrivé";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(6, 211);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(120, 20);
            label18.TabIndex = 6;
            label18.Text = "Code facturation";
            // 
            // tbxBase
            // 
            tbxBase.Location = new System.Drawing.Point(153, 55);
            tbxBase.MaxLength = 1;
            tbxBase.Name = "tbxBase";
            tbxBase.Size = new System.Drawing.Size(39, 27);
            tbxBase.TabIndex = 7;
            // 
            // tbxDepa
            // 
            tbxDepa.Location = new System.Drawing.Point(132, 91);
            tbxDepa.MaxLength = 1;
            tbxDepa.Name = "tbxDepa";
            tbxDepa.Size = new System.Drawing.Size(37, 27);
            tbxDepa.TabIndex = 8;
            // 
            // tbxEche
            // 
            tbxEche.Location = new System.Drawing.Point(211, 130);
            tbxEche.MaxLength = 3;
            tbxEche.Name = "tbxEche";
            tbxEche.Size = new System.Drawing.Size(55, 27);
            tbxEche.TabIndex = 9;
            // 
            // tbxArri
            // 
            tbxArri.Location = new System.Drawing.Point(132, 171);
            tbxArri.MaxLength = 1;
            tbxArri.Name = "tbxArri";
            tbxArri.Size = new System.Drawing.Size(37, 27);
            tbxArri.TabIndex = 10;
            // 
            // tbxFact
            // 
            tbxFact.Location = new System.Drawing.Point(132, 208);
            tbxFact.MaxLength = 1;
            tbxFact.Name = "tbxFact";
            tbxFact.Size = new System.Drawing.Size(37, 27);
            tbxFact.TabIndex = 11;
            // 
            // client
            // 
            ClientSize = new System.Drawing.Size(650, 481);
            Controls.Add(btnCreate);
            Controls.Add(tabControl1);
            Controls.Add(listView1);
            Name = "client";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        private void LayoutControls()
        {
            // Set the size and position of each control
            // You'll need to set these properties according to your design requirements
        }


        #endregion
        private ListView listView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox tbxAdresse2;
        private TextBox tbxVille;
        private TextBox tbxCp;
        private TextBox tbxAdresse1;
        private TextBox tbxMtdi;
        private TextBox tbxNom;
        private TextBox tbxBanque;
        private Label label8;
        private TextBox tbxDom;
        private Label label12;
        private TextBox tbxRib;
        private Label label11;
        private TextBox tbxCompte;
        private Label label10;
        private TextBox tbxGui;
        private Label label9;
        private TabPage tabPage3;
        private Button btnCreate;
        private ComboBox cbxRegl;
        private Label label13;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private TextBox tbxFact;
        private TextBox tbxArri;
        private TextBox tbxEche;
        private TextBox tbxDepa;
        private TextBox tbxBase;
    }
}