﻿using System.Windows.Forms;

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
            tbxNumClient = new TextBox();
            label32 = new Label();
            tbxIntra = new TextBox();
            label31 = new Label();
            tbxDiv = new TextBox();
            label30 = new Label();
            tbxEnse = new TextBox();
            label29 = new Label();
            tbxTVA = new TextBox();
            tbxLivr = new TextBox();
            tbxTran = new TextBox();
            label28 = new Label();
            tbxCode = new TextBox();
            label27 = new Label();
            tbxRemi = new TextBox();
            label26 = new Label();
            tbxRist = new TextBox();
            label25 = new Label();
            tbxComp = new TextBox();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            tbxEdit = new TextBox();
            label21 = new Label();
            tbxRep = new TextBox();
            label20 = new Label();
            tbxFamilleClient = new TextBox();
            label19 = new Label();
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
            tbxFacturation = new TextBox();
            label18 = new Label();
            tbxDecalageArrive = new TextBox();
            label17 = new Label();
            tbxEche = new TextBox();
            label16 = new Label();
            tbxDecalageDepart = new TextBox();
            label15 = new Label();
            tbxBaseDepart = new TextBox();
            label14 = new Label();
            cbxReglement = new ComboBox();
            label13 = new Label();
            btnCreate = new Button();
            button1 = new Button();
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
            tabPage1.Controls.Add(tbxNumClient);
            tabPage1.Controls.Add(label32);
            tabPage1.Controls.Add(tbxIntra);
            tabPage1.Controls.Add(label31);
            tabPage1.Controls.Add(tbxDiv);
            tabPage1.Controls.Add(label30);
            tabPage1.Controls.Add(tbxEnse);
            tabPage1.Controls.Add(label29);
            tabPage1.Controls.Add(tbxTVA);
            tabPage1.Controls.Add(tbxLivr);
            tabPage1.Controls.Add(tbxTran);
            tabPage1.Controls.Add(label28);
            tabPage1.Controls.Add(tbxCode);
            tabPage1.Controls.Add(label27);
            tabPage1.Controls.Add(tbxRemi);
            tabPage1.Controls.Add(label26);
            tabPage1.Controls.Add(tbxRist);
            tabPage1.Controls.Add(label25);
            tabPage1.Controls.Add(tbxComp);
            tabPage1.Controls.Add(label24);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(label22);
            tabPage1.Controls.Add(tbxEdit);
            tabPage1.Controls.Add(label21);
            tabPage1.Controls.Add(tbxRep);
            tabPage1.Controls.Add(label20);
            tabPage1.Controls.Add(tbxFamilleClient);
            tabPage1.Controls.Add(label19);
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
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(380, 407);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Informations générales";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxNumClient
            // 
            tbxNumClient.Location = new System.Drawing.Point(97, 3);
            tbxNumClient.Name = "tbxNumClient";
            tbxNumClient.Size = new System.Drawing.Size(100, 23);
            tbxNumClient.TabIndex = 40;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(8, 9);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(83, 15);
            label32.TabIndex = 39;
            label32.Text = "Numéro client";
            // 
            // tbxIntra
            // 
            tbxIntra.Location = new System.Drawing.Point(326, 327);
            tbxIntra.Name = "tbxIntra";
            tbxIntra.Size = new System.Drawing.Size(46, 23);
            tbxIntra.TabIndex = 38;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(218, 330);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(102, 15);
            label31.TabIndex = 37;
            label31.Text = "Numéro intracom";
            // 
            // tbxDiv
            // 
            tbxDiv.Location = new System.Drawing.Point(107, 369);
            tbxDiv.Name = "tbxDiv";
            tbxDiv.Size = new System.Drawing.Size(265, 23);
            tbxDiv.TabIndex = 36;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(8, 372);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(80, 15);
            label30.TabIndex = 35;
            label30.Text = "Commentaire";
            // 
            // tbxEnse
            // 
            tbxEnse.Location = new System.Drawing.Point(264, 287);
            tbxEnse.Name = "tbxEnse";
            tbxEnse.Size = new System.Drawing.Size(46, 23);
            tbxEnse.TabIndex = 34;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(177, 290);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(85, 15);
            label29.TabIndex = 33;
            label29.Text = "Code enseigne";
            // 
            // tbxTVA
            // 
            tbxTVA.Location = new System.Drawing.Point(228, 246);
            tbxTVA.Name = "tbxTVA";
            tbxTVA.Size = new System.Drawing.Size(46, 23);
            tbxTVA.TabIndex = 32;
            // 
            // tbxLivr
            // 
            tbxLivr.Location = new System.Drawing.Point(133, 287);
            tbxLivr.Name = "tbxLivr";
            tbxLivr.Size = new System.Drawing.Size(39, 23);
            tbxLivr.TabIndex = 31;
            // 
            // tbxTran
            // 
            tbxTran.Location = new System.Drawing.Point(117, 252);
            tbxTran.Name = "tbxTran";
            tbxTran.Size = new System.Drawing.Size(39, 23);
            tbxTran.TabIndex = 30;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(164, 249);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(58, 15);
            label28.TabIndex = 29;
            label28.Text = "Code TVA";
            // 
            // tbxCode
            // 
            tbxCode.Location = new System.Drawing.Point(313, 213);
            tbxCode.Name = "tbxCode";
            tbxCode.Size = new System.Drawing.Size(46, 23);
            tbxCode.TabIndex = 28;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(164, 216);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(143, 15);
            label27.TabIndex = 27;
            label27.Text = "Code remise (P ou V ou /)";
            // 
            // tbxRemi
            // 
            tbxRemi.Location = new System.Drawing.Point(277, 172);
            tbxRemi.Name = "tbxRemi";
            tbxRemi.Size = new System.Drawing.Size(46, 23);
            tbxRemi.TabIndex = 26;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(164, 175);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(107, 15);
            label26.TabIndex = 25;
            label26.Text = "% ou valeur remise";
            // 
            // tbxRist
            // 
            tbxRist.Location = new System.Drawing.Point(313, 133);
            tbxRist.Name = "tbxRist";
            tbxRist.Size = new System.Drawing.Size(46, 23);
            tbxRist.TabIndex = 24;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(164, 136);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(133, 15);
            label25.TabIndex = 23;
            label25.Text = "Numéro client ristourne";
            // 
            // tbxComp
            // 
            tbxComp.Location = new System.Drawing.Point(157, 327);
            tbxComp.Name = "tbxComp";
            tbxComp.Size = new System.Drawing.Size(46, 23);
            tbxComp.TabIndex = 22;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(8, 330);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(143, 15);
            label24.TabIndex = 21;
            label24.Text = "Numéro client comptable";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(8, 290);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(128, 15);
            label23.TabIndex = 20;
            label23.Text = "Code livraison habituel";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(7, 255);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(103, 15);
            label22.TabIndex = 19;
            label22.Text = "Code transporteur";
            // 
            // tbxEdit
            // 
            tbxEdit.Location = new System.Drawing.Point(117, 211);
            tbxEdit.Name = "tbxEdit";
            tbxEdit.Size = new System.Drawing.Size(39, 23);
            tbxEdit.TabIndex = 18;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(7, 214);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(110, 15);
            label21.TabIndex = 17;
            label21.Text = "Code édition sur BL";
            // 
            // tbxRep
            // 
            tbxRep.Location = new System.Drawing.Point(117, 172);
            tbxRep.Name = "tbxRep";
            tbxRep.Size = new System.Drawing.Size(39, 23);
            tbxRep.TabIndex = 16;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(7, 175);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(104, 15);
            label20.TabIndex = 15;
            label20.Text = "Code représentant";
            // 
            // tbxFamilleClient
            // 
            tbxFamilleClient.Location = new System.Drawing.Point(107, 133);
            tbxFamilleClient.Name = "tbxFamilleClient";
            tbxFamilleClient.Size = new System.Drawing.Size(36, 23);
            tbxFamilleClient.TabIndex = 14;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(7, 136);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(94, 15);
            label19.TabIndex = 13;
            label19.Text = "Famille du client";
            // 
            // tbxAdresse2
            // 
            tbxAdresse2.Location = new System.Drawing.Point(236, 95);
            tbxAdresse2.Name = "tbxAdresse2";
            tbxAdresse2.Size = new System.Drawing.Size(136, 23);
            tbxAdresse2.TabIndex = 12;
            // 
            // tbxVille
            // 
            tbxVille.Location = new System.Drawing.Point(47, 95);
            tbxVille.Name = "tbxVille";
            tbxVille.Size = new System.Drawing.Size(124, 23);
            tbxVille.TabIndex = 11;
            // 
            // tbxCp
            // 
            tbxCp.Location = new System.Drawing.Point(283, 64);
            tbxCp.Name = "tbxCp";
            tbxCp.Size = new System.Drawing.Size(89, 23);
            tbxCp.TabIndex = 10;
            // 
            // tbxAdresse1
            // 
            tbxAdresse1.Location = new System.Drawing.Point(66, 64);
            tbxAdresse1.Name = "tbxAdresse1";
            tbxAdresse1.Size = new System.Drawing.Size(136, 23);
            tbxAdresse1.TabIndex = 9;
            // 
            // tbxMtdi
            // 
            tbxMtdi.Location = new System.Drawing.Point(197, 29);
            tbxMtdi.Name = "tbxMtdi";
            tbxMtdi.Size = new System.Drawing.Size(100, 23);
            tbxMtdi.TabIndex = 8;
            // 
            // tbxNom
            // 
            tbxNom.Location = new System.Drawing.Point(46, 29);
            tbxNom.Name = "tbxNom";
            tbxNom.Size = new System.Drawing.Size(100, 23);
            tbxNom.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(177, 98);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 15);
            label7.TabIndex = 6;
            label7.Text = "Adresse 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 98);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 15);
            label6.TabIndex = 5;
            label6.Text = "Ville";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(208, 67);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 15);
            label5.TabIndex = 4;
            label5.Text = "Code postal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 67);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 3;
            label4.Text = "Adresse 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(156, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 15);
            label3.TabIndex = 2;
            label3.Text = "MTDI";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Nom";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 24);
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
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(380, 407);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Banque";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbxDom
            // 
            tbxDom.Location = new System.Drawing.Point(9, 145);
            tbxDom.Name = "tbxDom";
            tbxDom.Size = new System.Drawing.Size(100, 23);
            tbxDom.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 127);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 15);
            label12.TabIndex = 9;
            label12.Text = "DOM";
            // 
            // tbxRib
            // 
            tbxRib.Location = new System.Drawing.Point(185, 78);
            tbxRib.Name = "tbxRib";
            tbxRib.Size = new System.Drawing.Size(58, 23);
            tbxRib.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(185, 60);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(24, 15);
            label11.TabIndex = 7;
            label11.Text = "RIB";
            // 
            // tbxCompte
            // 
            tbxCompte.Location = new System.Drawing.Point(9, 78);
            tbxCompte.Name = "tbxCompte";
            tbxCompte.Size = new System.Drawing.Size(155, 23);
            tbxCompte.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(9, 60);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 15);
            label10.TabIndex = 5;
            label10.Text = "Compte";
            // 
            // tbxGui
            // 
            tbxGui.Location = new System.Drawing.Point(126, 21);
            tbxGui.Name = "tbxGui";
            tbxGui.Size = new System.Drawing.Size(82, 23);
            tbxGui.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(126, 3);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(26, 15);
            label9.TabIndex = 3;
            label9.Text = "GUI";
            // 
            // tbxBanque
            // 
            tbxBanque.Location = new System.Drawing.Point(9, 21);
            tbxBanque.Name = "tbxBanque";
            tbxBanque.Size = new System.Drawing.Size(100, 23);
            tbxBanque.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 3);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(47, 15);
            label8.TabIndex = 0;
            label8.Text = "Banque";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tbxFacturation);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(tbxDecalageArrive);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(tbxEche);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(tbxDecalageDepart);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(tbxBaseDepart);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(cbxReglement);
            tabPage3.Controls.Add(label13);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new System.Drawing.Size(380, 407);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Règlement";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbxFacturation
            // 
            tbxFacturation.Location = new System.Drawing.Point(133, 234);
            tbxFacturation.MaxLength = 1;
            tbxFacturation.Name = "tbxFacturation";
            tbxFacturation.Size = new System.Drawing.Size(49, 23);
            tbxFacturation.TabIndex = 11;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(16, 237);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(96, 15);
            label18.TabIndex = 10;
            label18.Text = "Code facturation";
            // 
            // tbxDecalageArrive
            // 
            tbxDecalageArrive.Location = new System.Drawing.Point(133, 188);
            tbxDecalageArrive.MaxLength = 1;
            tbxDecalageArrive.Name = "tbxDecalageArrive";
            tbxDecalageArrive.Size = new System.Drawing.Size(49, 23);
            tbxDecalageArrive.TabIndex = 9;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(16, 191);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(87, 15);
            label17.TabIndex = 8;
            label17.Text = "Décalage arrivé";
            // 
            // tbxEche
            // 
            tbxEche.Location = new System.Drawing.Point(181, 142);
            tbxEche.MaxLength = 2;
            tbxEche.Name = "tbxEche";
            tbxEche.Size = new System.Drawing.Size(49, 23);
            tbxEche.TabIndex = 7;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(16, 145);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(159, 15);
            label16.TabIndex = 6;
            label16.Text = "Nombre de jours d'échéance";
            // 
            // tbxDecalageDepart
            // 
            tbxDecalageDepart.Location = new System.Drawing.Point(133, 95);
            tbxDecalageDepart.MaxLength = 1;
            tbxDecalageDepart.Name = "tbxDecalageDepart";
            tbxDecalageDepart.Size = new System.Drawing.Size(49, 23);
            tbxDecalageDepart.TabIndex = 5;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(16, 98);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(92, 15);
            label15.TabIndex = 4;
            label15.Text = "Décalage départ";
            // 
            // tbxBaseDepart
            // 
            tbxBaseDepart.Location = new System.Drawing.Point(133, 53);
            tbxBaseDepart.Name = "tbxBaseDepart";
            tbxBaseDepart.Size = new System.Drawing.Size(49, 23);
            tbxBaseDepart.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(16, 56);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(111, 15);
            label14.TabIndex = 2;
            label14.Text = "Date de base départ";
            // 
            // cbxReglement
            // 
            cbxReglement.FormattingEnabled = true;
            cbxReglement.Location = new System.Drawing.Point(133, 11);
            cbxReglement.Name = "cbxReglement";
            cbxReglement.Size = new System.Drawing.Size(49, 23);
            cbxReglement.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(16, 14);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(111, 15);
            label13.TabIndex = 0;
            label13.Text = "Mode de réglement";
            // 
            // btnCreate
            // 
            btnCreate.Location = new System.Drawing.Point(559, 453);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(75, 23);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Dupliquer";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(478, 453);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Modifier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // client
            // 
            ClientSize = new System.Drawing.Size(650, 486);
            Controls.Add(button1);
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
        private Label label24;
        private Label label26;
        private TextBox tbxRist;
        private Label label25;
        private TextBox tbxComp;
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
    }
}