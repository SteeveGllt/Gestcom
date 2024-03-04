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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client));
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbRistCheck = new System.Windows.Forms.PictureBox();
            this.pbRistCroix = new System.Windows.Forms.PictureBox();
            this.tbxNumClient = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbxIntra = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDiv = new System.Windows.Forms.TextBox();
            this.tbxCp = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbxVille = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxEnse = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbxTVA = new System.Windows.Forms.TextBox();
            this.tbxLivr = new System.Windows.Forms.TextBox();
            this.tbxTran = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbxRemi = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbxRist = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxEdit = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbxRep = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxFamilleClient = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxAdresse2 = new System.Windows.Forms.TextBox();
            this.tbxAdresse1 = new System.Windows.Forms.TextBox();
            this.tbxMtdi = new System.Windows.Forms.TextBox();
            this.tbxNom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbxDom = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxRib = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxCompte = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxGui = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxBanque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbxFacturation = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxDecalageArrive = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxEche = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxDecalageDepart = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxBaseDepart = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxReglement = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbxCompteEbp = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.pbCheckCompta = new System.Windows.Forms.PictureBox();
            this.pbComptaCroix = new System.Windows.Forms.PictureBox();
            this.tbxDluo = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbxComp = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRistCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRistCroix)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckCompta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComptaCroix)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(315, 567);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(344, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 571);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pbRistCheck);
            this.tabPage1.Controls.Add(this.pbRistCroix);
            this.tabPage1.Controls.Add(this.tbxNumClient);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.tbxIntra);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbxDiv);
            this.tabPage1.Controls.Add(this.tbxCp);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.tbxVille);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbxEnse);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.tbxTVA);
            this.tabPage1.Controls.Add(this.tbxLivr);
            this.tabPage1.Controls.Add(this.tbxTran);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.tbxCode);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.tbxRemi);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.tbxRist);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.tbxEdit);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.tbxRep);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.tbxFamilleClient);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.tbxAdresse2);
            this.tabPage1.Controls.Add(this.tbxAdresse1);
            this.tabPage1.Controls.Add(this.tbxMtdi);
            this.tabPage1.Controls.Add(this.tbxNom);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations générales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbRistCheck
            // 
            this.pbRistCheck.Image = ((System.Drawing.Image)(resources.GetObject("pbRistCheck.Image")));
            this.pbRistCheck.Location = new System.Drawing.Point(439, 217);
            this.pbRistCheck.Name = "pbRistCheck";
            this.pbRistCheck.Size = new System.Drawing.Size(29, 27);
            this.pbRistCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRistCheck.TabIndex = 42;
            this.pbRistCheck.TabStop = false;
            // 
            // pbRistCroix
            // 
            this.pbRistCroix.Image = ((System.Drawing.Image)(resources.GetObject("pbRistCroix.Image")));
            this.pbRistCroix.Location = new System.Drawing.Point(412, 219);
            this.pbRistCroix.Name = "pbRistCroix";
            this.pbRistCroix.Size = new System.Drawing.Size(21, 21);
            this.pbRistCroix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRistCroix.TabIndex = 41;
            this.pbRistCroix.TabStop = false;
            // 
            // tbxNumClient
            // 
            this.tbxNumClient.Location = new System.Drawing.Point(122, 18);
            this.tbxNumClient.MaxLength = 4;
            this.tbxNumClient.Name = "tbxNumClient";
            this.tbxNumClient.Size = new System.Drawing.Size(30, 31);
            this.tbxNumClient.TabIndex = 40;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(123, 25);
            this.label32.TabIndex = 39;
            this.label32.Text = "Numéro client";
            // 
            // tbxIntra
            // 
            this.tbxIntra.Location = new System.Drawing.Point(138, 450);
            this.tbxIntra.Name = "tbxIntra";
            this.tbxIntra.Size = new System.Drawing.Size(130, 31);
            this.tbxIntra.TabIndex = 38;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 453);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(152, 25);
            this.label31.TabIndex = 37;
            this.label31.Text = "Numéro intracom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Code postal";
            // 
            // tbxDiv
            // 
            this.tbxDiv.Location = new System.Drawing.Point(105, 488);
            this.tbxDiv.Name = "tbxDiv";
            this.tbxDiv.Size = new System.Drawing.Size(374, 31);
            this.tbxDiv.TabIndex = 36;
            // 
            // tbxCp
            // 
            this.tbxCp.Location = new System.Drawing.Point(426, 181);
            this.tbxCp.Name = "tbxCp";
            this.tbxCp.Size = new System.Drawing.Size(53, 31);
            this.tbxCp.TabIndex = 10;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 491);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(119, 25);
            this.label30.TabIndex = 35;
            this.label30.Text = "Commentaire";
            // 
            // tbxVille
            // 
            this.tbxVille.Location = new System.Drawing.Point(51, 181);
            this.tbxVille.Name = "tbxVille";
            this.tbxVille.Size = new System.Drawing.Size(271, 31);
            this.tbxVille.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ville";
            // 
            // tbxEnse
            // 
            this.tbxEnse.Location = new System.Drawing.Point(328, 371);
            this.tbxEnse.Name = "tbxEnse";
            this.tbxEnse.Size = new System.Drawing.Size(37, 31);
            this.tbxEnse.TabIndex = 34;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(215, 374);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(129, 25);
            this.label29.TabIndex = 33;
            this.label29.Text = "Code enseigne";
            // 
            // tbxTVA
            // 
            this.tbxTVA.Location = new System.Drawing.Point(276, 336);
            this.tbxTVA.Name = "tbxTVA";
            this.tbxTVA.Size = new System.Drawing.Size(25, 31);
            this.tbxTVA.TabIndex = 32;
            // 
            // tbxLivr
            // 
            this.tbxLivr.Location = new System.Drawing.Point(170, 371);
            this.tbxLivr.Name = "tbxLivr";
            this.tbxLivr.Size = new System.Drawing.Size(27, 31);
            this.tbxLivr.TabIndex = 31;
            // 
            // tbxTran
            // 
            this.tbxTran.Location = new System.Drawing.Point(132, 336);
            this.tbxTran.Name = "tbxTran";
            this.tbxTran.Size = new System.Drawing.Size(25, 31);
            this.tbxTran.TabIndex = 30;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(189, 339);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(90, 25);
            this.label28.TabIndex = 29;
            this.label28.Text = "Code TVA";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(377, 300);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(29, 31);
            this.tbxCode.TabIndex = 28;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(192, 300);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(216, 25);
            this.label27.TabIndex = 27;
            this.label27.Text = "Code remise (P ou V ou /)";
            // 
            // tbxRemi
            // 
            this.tbxRemi.Location = new System.Drawing.Point(336, 256);
            this.tbxRemi.Name = "tbxRemi";
            this.tbxRemi.Size = new System.Drawing.Size(29, 31);
            this.tbxRemi.TabIndex = 26;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(196, 259);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(162, 25);
            this.label26.TabIndex = 25;
            this.label26.Text = "% ou valeur remise";
            // 
            // tbxRist
            // 
            this.tbxRist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRist.Location = new System.Drawing.Point(371, 217);
            this.tbxRist.Name = "tbxRist";
            this.tbxRist.Size = new System.Drawing.Size(35, 31);
            this.tbxRist.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(200, 220);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(198, 25);
            this.label25.TabIndex = 23;
            this.label25.Text = "Numéro client ristourne";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 374);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(192, 25);
            this.label23.TabIndex = 20;
            this.label23.Text = "Code livraison habituel";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 339);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(157, 25);
            this.label22.TabIndex = 19;
            this.label22.Text = "Code transporteur";
            // 
            // tbxEdit
            // 
            this.tbxEdit.Location = new System.Drawing.Point(147, 297);
            this.tbxEdit.Name = "tbxEdit";
            this.tbxEdit.Size = new System.Drawing.Size(24, 31);
            this.tbxEdit.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 298);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(166, 25);
            this.label21.TabIndex = 17;
            this.label21.Text = "Code édition sur BL";
            // 
            // tbxRep
            // 
            this.tbxRep.Location = new System.Drawing.Point(143, 256);
            this.tbxRep.Name = "tbxRep";
            this.tbxRep.Size = new System.Drawing.Size(28, 31);
            this.tbxRep.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 259);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(158, 25);
            this.label20.TabIndex = 15;
            this.label20.Text = "Code représentant";
            // 
            // tbxFamilleClient
            // 
            this.tbxFamilleClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFamilleClient.Location = new System.Drawing.Point(129, 217);
            this.tbxFamilleClient.Name = "tbxFamilleClient";
            this.tbxFamilleClient.Size = new System.Drawing.Size(28, 31);
            this.tbxFamilleClient.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 220);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 25);
            this.label19.TabIndex = 13;
            this.label19.Text = "Famille du client";
            // 
            // tbxAdresse2
            // 
            this.tbxAdresse2.Location = new System.Drawing.Point(92, 137);
            this.tbxAdresse2.Name = "tbxAdresse2";
            this.tbxAdresse2.Size = new System.Drawing.Size(387, 31);
            this.tbxAdresse2.TabIndex = 12;
            // 
            // tbxAdresse1
            // 
            this.tbxAdresse1.Location = new System.Drawing.Point(92, 97);
            this.tbxAdresse1.Name = "tbxAdresse1";
            this.tbxAdresse1.Size = new System.Drawing.Size(387, 31);
            this.tbxAdresse1.TabIndex = 9;
            // 
            // tbxMtdi
            // 
            this.tbxMtdi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMtdi.Location = new System.Drawing.Point(235, 17);
            this.tbxMtdi.Name = "tbxMtdi";
            this.tbxMtdi.Size = new System.Drawing.Size(244, 31);
            this.tbxMtdi.TabIndex = 8;
            // 
            // tbxNom
            // 
            this.tbxNom.Location = new System.Drawing.Point(61, 58);
            this.tbxNom.Name = "tbxNom";
            this.tbxNom.Size = new System.Drawing.Size(418, 31);
            this.tbxNom.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Adresse 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adresse 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "MTDI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbxDom);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbxRib);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbxCompte);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbxGui);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbxBanque);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Banque";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbxDom
            // 
            this.tbxDom.Location = new System.Drawing.Point(115, 160);
            this.tbxDom.Name = "tbxDom";
            this.tbxDom.Size = new System.Drawing.Size(259, 31);
            this.tbxDom.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 25);
            this.label12.TabIndex = 9;
            this.label12.Text = "Domiciliation";
            // 
            // tbxRib
            // 
            this.tbxRib.Location = new System.Drawing.Point(343, 107);
            this.tbxRib.MaxLength = 2;
            this.tbxRib.Name = "tbxRib";
            this.tbxRib.Size = new System.Drawing.Size(31, 31);
            this.tbxRib.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(306, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "RIB";
            // 
            // tbxCompte
            // 
            this.tbxCompte.Location = new System.Drawing.Point(157, 107);
            this.tbxCompte.MaxLength = 11;
            this.tbxCompte.Name = "tbxCompte";
            this.tbxCompte.Size = new System.Drawing.Size(123, 31);
            this.tbxCompte.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Numéro de Compte";
            // 
            // tbxGui
            // 
            this.tbxGui.Location = new System.Drawing.Point(114, 54);
            this.tbxGui.MaxLength = 5;
            this.tbxGui.Name = "tbxGui";
            this.tbxGui.Size = new System.Drawing.Size(50, 31);
            this.tbxGui.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Code Guichet";
            // 
            // tbxBanque
            // 
            this.tbxBanque.Location = new System.Drawing.Point(114, 7);
            this.tbxBanque.MaxLength = 5;
            this.tbxBanque.Name = "tbxBanque";
            this.tbxBanque.Size = new System.Drawing.Size(50, 31);
            this.tbxBanque.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Code Banque";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbxFacturation);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.tbxDecalageArrive);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.tbxEche);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.tbxDecalageDepart);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.tbxBaseDepart);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.cbxReglement);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(596, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Règlement";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbxFacturation
            // 
            this.tbxFacturation.Location = new System.Drawing.Point(142, 234);
            this.tbxFacturation.MaxLength = 1;
            this.tbxFacturation.Name = "tbxFacturation";
            this.tbxFacturation.Size = new System.Drawing.Size(30, 31);
            this.tbxFacturation.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 237);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 25);
            this.label18.TabIndex = 10;
            this.label18.Text = "Code facturation";
            // 
            // tbxDecalageArrive
            // 
            this.tbxDecalageArrive.Location = new System.Drawing.Point(133, 188);
            this.tbxDecalageArrive.MaxLength = 1;
            this.tbxDecalageArrive.Name = "tbxDecalageArrive";
            this.tbxDecalageArrive.Size = new System.Drawing.Size(28, 31);
            this.tbxDecalageArrive.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 25);
            this.label17.TabIndex = 8;
            this.label17.Text = "Décalage arrivé";
            // 
            // tbxEche
            // 
            this.tbxEche.Location = new System.Drawing.Point(221, 142);
            this.tbxEche.MaxLength = 2;
            this.tbxEche.Name = "tbxEche";
            this.tbxEche.Size = new System.Drawing.Size(30, 31);
            this.tbxEche.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(239, 25);
            this.label16.TabIndex = 6;
            this.label16.Text = "Nombre de jours d\'échéance";
            // 
            // tbxDecalageDepart
            // 
            this.tbxDecalageDepart.Location = new System.Drawing.Point(142, 95);
            this.tbxDecalageDepart.MaxLength = 1;
            this.tbxDecalageDepart.Name = "tbxDecalageDepart";
            this.tbxDecalageDepart.Size = new System.Drawing.Size(30, 31);
            this.tbxDecalageDepart.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 25);
            this.label15.TabIndex = 4;
            this.label15.Text = "Décalage départ";
            // 
            // tbxBaseDepart
            // 
            this.tbxBaseDepart.Location = new System.Drawing.Point(163, 53);
            this.tbxBaseDepart.Name = "tbxBaseDepart";
            this.tbxBaseDepart.Size = new System.Drawing.Size(28, 31);
            this.tbxBaseDepart.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 25);
            this.label14.TabIndex = 2;
            this.label14.Text = "Date de base départ";
            // 
            // cbxReglement
            // 
            this.cbxReglement.FormattingEnabled = true;
            this.cbxReglement.Location = new System.Drawing.Point(163, 11);
            this.cbxReglement.Name = "cbxReglement";
            this.cbxReglement.Size = new System.Drawing.Size(52, 33);
            this.cbxReglement.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mode de réglement";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbxCompteEbp);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.pbCheckCompta);
            this.tabPage4.Controls.Add(this.pbComptaCroix);
            this.tabPage4.Controls.Add(this.tbxDluo);
            this.tabPage4.Controls.Add(this.label33);
            this.tabPage4.Controls.Add(this.tbxComp);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(596, 533);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Autre";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbxCompteEbp
            // 
            this.tbxCompteEbp.Location = new System.Drawing.Point(163, 99);
            this.tbxCompteEbp.MaxLength = 10;
            this.tbxCompteEbp.Name = "tbxCompteEbp";
            this.tbxCompteEbp.Size = new System.Drawing.Size(48, 31);
            this.tbxCompteEbp.TabIndex = 45;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(15, 102);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(177, 25);
            this.label34.TabIndex = 44;
            this.label34.Text = "Numéro compte EBP";
            // 
            // pbCheckCompta
            // 
            this.pbCheckCompta.Image = ((System.Drawing.Image)(resources.GetObject("pbCheckCompta.Image")));
            this.pbCheckCompta.Location = new System.Drawing.Point(243, 14);
            this.pbCheckCompta.Name = "pbCheckCompta";
            this.pbCheckCompta.Size = new System.Drawing.Size(25, 23);
            this.pbCheckCompta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCheckCompta.TabIndex = 43;
            this.pbCheckCompta.TabStop = false;
            // 
            // pbComptaCroix
            // 
            this.pbComptaCroix.Image = ((System.Drawing.Image)(resources.GetObject("pbComptaCroix.Image")));
            this.pbComptaCroix.Location = new System.Drawing.Point(216, 14);
            this.pbComptaCroix.Name = "pbComptaCroix";
            this.pbComptaCroix.Size = new System.Drawing.Size(21, 21);
            this.pbComptaCroix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbComptaCroix.TabIndex = 28;
            this.pbComptaCroix.TabStop = false;
            // 
            // tbxDluo
            // 
            this.tbxDluo.Location = new System.Drawing.Point(126, 52);
            this.tbxDluo.MaxLength = 10;
            this.tbxDluo.Name = "tbxDluo";
            this.tbxDluo.Size = new System.Drawing.Size(48, 31);
            this.tbxDluo.TabIndex = 26;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(15, 55);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(147, 25);
            this.label33.TabIndex = 25;
            this.label33.Text = "Nombre de jours";
            // 
            // tbxComp
            // 
            this.tbxComp.Location = new System.Drawing.Point(178, 11);
            this.tbxComp.MaxLength = 4;
            this.tbxComp.Name = "tbxComp";
            this.tbxComp.Size = new System.Drawing.Size(32, 31);
            this.tbxComp.TabIndex = 24;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(213, 25);
            this.label24.TabIndex = 23;
            this.label24.Text = "Numéro client comptable";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(792, 598);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(152, 38);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Dupliquer";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Modifier";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // client
            // 
            this.ClientSize = new System.Drawing.Size(966, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.Name = "client";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRistCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRistCroix)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckCompta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbComptaCroix)).EndInit();
            this.ResumeLayout(false);

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
        private Label label13;
        private Label label14;
        private ComboBox cbxReglement;
        private Label label17;
        private TextBox tbxEche;
        private Label label16;
        private TextBox tbxDecalageDepart;
        private Label label15;
        private TextBox tbxBaseDepart;
        private TextBox tbxFacturation;
        private Label label18;
        private TextBox tbxDecalageArrive;
        private Label label19;
        private TextBox tbxFamilleClient;
        private TextBox tbxRep;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox tbxEdit;
        private Label label23;
        private Label label26;
        private TextBox tbxRist;
        private Label label25;
        private TextBox tbxRemi;
        private Label label27;
        private Label label28;
        private TextBox tbxCode;
        private TextBox tbxLivr;
        private TextBox tbxTran;
        private TextBox tbxTVA;
        private TextBox tbxDiv;
        private Label label30;
        private TextBox tbxEnse;
        private Label label29;
        private TextBox tbxIntra;
        private Label label31;
        private Label label32;
        private TextBox tbxNumClient;
        private Button button1;
        private TabPage tabPage4;
        private TextBox tbxDluo;
        private Label label33;
        private TextBox tbxComp;
        private Label label24;
        private PictureBox pbComptaCroix;
        private PictureBox pbRistCroix;
        private PictureBox pbRistCheck;
        private PictureBox pbCheckCompta;
        private TextBox tbxCompteEbp;
        private Label label34;
    }
}