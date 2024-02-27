namespace GestcomWF.Views
{
    partial class article
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            tbxNumArt = new TextBox();
            tbxDesiArt = new TextBox();
            tbxFamiArt = new TextBox();
            tbxUnitArt = new TextBox();
            tbxTvaArt = new TextBox();
            tbxPoidArt = new TextBox();
            tbxCecArt = new TextBox();
            listViewArticle = new ListView();
            comboBox1 = new ComboBox();
            button1 = new Button();
            btnModifier = new Button();
            btnEnregistrer = new Button();
            btnSupprimer = new Button();
            tbxPrixArt = new TextBox();
            label8 = new Label();
            tbxComp1 = new TextBox();
            label9 = new Label();
            tbxComp2 = new TextBox();
            label10 = new Label();
            tbxDluo = new TextBox();
            label11 = new Label();
            tbxEan13 = new TextBox();
            label12 = new Label();
            tbxDiv = new TextBox();
            label13 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Numéro d'article";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(181, 18);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Désignation";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(318, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 2;
            label3.Text = "Famille";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(437, 18);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 15);
            label4.TabIndex = 3;
            label4.Text = "Unité";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(543, 18);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(27, 15);
            label5.TabIndex = 4;
            label5.Text = "TVA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(639, 18);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 15);
            label6.TabIndex = 5;
            label6.Text = "Poids";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(740, 18);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(29, 15);
            label7.TabIndex = 6;
            label7.Text = "CEC";
            // 
            // tbxNumArt
            // 
            tbxNumArt.Location = new System.Drawing.Point(23, 36);
            tbxNumArt.Name = "tbxNumArt";
            tbxNumArt.Size = new System.Drawing.Size(96, 23);
            tbxNumArt.TabIndex = 7;
            // 
            // tbxDesiArt
            // 
            tbxDesiArt.Location = new System.Drawing.Point(181, 36);
            tbxDesiArt.Name = "tbxDesiArt";
            tbxDesiArt.Size = new System.Drawing.Size(122, 23);
            tbxDesiArt.TabIndex = 8;
            // 
            // tbxFamiArt
            // 
            tbxFamiArt.Location = new System.Drawing.Point(318, 36);
            tbxFamiArt.MaxLength = 2;
            tbxFamiArt.Name = "tbxFamiArt";
            tbxFamiArt.Size = new System.Drawing.Size(45, 23);
            tbxFamiArt.TabIndex = 9;
            // 
            // tbxUnitArt
            // 
            tbxUnitArt.Location = new System.Drawing.Point(437, 36);
            tbxUnitArt.MaxLength = 1;
            tbxUnitArt.Name = "tbxUnitArt";
            tbxUnitArt.Size = new System.Drawing.Size(35, 23);
            tbxUnitArt.TabIndex = 10;
            // 
            // tbxTvaArt
            // 
            tbxTvaArt.Location = new System.Drawing.Point(543, 36);
            tbxTvaArt.Name = "tbxTvaArt";
            tbxTvaArt.Size = new System.Drawing.Size(27, 23);
            tbxTvaArt.TabIndex = 11;
            // 
            // tbxPoidArt
            // 
            tbxPoidArt.Location = new System.Drawing.Point(639, 36);
            tbxPoidArt.Name = "tbxPoidArt";
            tbxPoidArt.Size = new System.Drawing.Size(36, 23);
            tbxPoidArt.TabIndex = 12;
            // 
            // tbxCecArt
            // 
            tbxCecArt.Location = new System.Drawing.Point(740, 36);
            tbxCecArt.MaxLength = 1;
            tbxCecArt.Name = "tbxCecArt";
            tbxCecArt.Size = new System.Drawing.Size(36, 23);
            tbxCecArt.TabIndex = 13;
            // 
            // listViewArticle
            // 
            listViewArticle.FullRowSelect = true;
            listViewArticle.Location = new System.Drawing.Point(12, 186);
            listViewArticle.Name = "listViewArticle";
            listViewArticle.Size = new System.Drawing.Size(1006, 252);
            listViewArticle.TabIndex = 14;
            listViewArticle.UseCompatibleStateImageBehavior = false;
            listViewArticle.DoubleClick += listViewArticle_DoubleClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(585, 157);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(712, 156);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Actualiser";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new System.Drawing.Point(205, 143);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new System.Drawing.Size(75, 23);
            btnModifier.TabIndex = 17;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new System.Drawing.Point(311, 143);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new System.Drawing.Size(75, 23);
            btnEnregistrer.TabIndex = 18;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new System.Drawing.Point(418, 143);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new System.Drawing.Size(75, 23);
            btnSupprimer.TabIndex = 19;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // tbxPrixArt
            // 
            tbxPrixArt.Location = new System.Drawing.Point(478, 36);
            tbxPrixArt.Name = "tbxPrixArt";
            tbxPrixArt.Size = new System.Drawing.Size(59, 23);
            tbxPrixArt.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(478, 18);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(27, 15);
            label8.TabIndex = 21;
            label8.Text = "Prix";
            // 
            // tbxComp1
            // 
            tbxComp1.Location = new System.Drawing.Point(23, 93);
            tbxComp1.Name = "tbxComp1";
            tbxComp1.Size = new System.Drawing.Size(30, 23);
            tbxComp1.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(23, 75);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(100, 15);
            label9.TabIndex = 22;
            label9.Text = "Compte compta1";
            // 
            // tbxComp2
            // 
            tbxComp2.Location = new System.Drawing.Point(181, 93);
            tbxComp2.Name = "tbxComp2";
            tbxComp2.Size = new System.Drawing.Size(30, 23);
            tbxComp2.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(181, 75);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(100, 15);
            label10.TabIndex = 24;
            label10.Text = "Compte compta2";
            // 
            // tbxDluo
            // 
            tbxDluo.Location = new System.Drawing.Point(318, 93);
            tbxDluo.Name = "tbxDluo";
            tbxDluo.Size = new System.Drawing.Size(31, 23);
            tbxDluo.TabIndex = 27;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(318, 75);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(38, 15);
            label11.TabIndex = 26;
            label11.Text = "DLUO";
            // 
            // tbxEan13
            // 
            tbxEan13.Location = new System.Drawing.Point(437, 93);
            tbxEan13.Name = "tbxEan13";
            tbxEan13.Size = new System.Drawing.Size(42, 23);
            tbxEan13.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(437, 75);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(42, 15);
            label12.TabIndex = 28;
            label12.Text = "EAN13";
            // 
            // tbxDiv
            // 
            tbxDiv.Location = new System.Drawing.Point(870, 36);
            tbxDiv.Name = "tbxDiv";
            tbxDiv.Size = new System.Drawing.Size(36, 23);
            tbxDiv.TabIndex = 31;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(870, 18);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(25, 15);
            label13.TabIndex = 30;
            label13.Text = "DIV";
            // 
            // article
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1030, 450);
            Controls.Add(tbxDiv);
            Controls.Add(label13);
            Controls.Add(tbxEan13);
            Controls.Add(label12);
            Controls.Add(tbxDluo);
            Controls.Add(label11);
            Controls.Add(tbxComp2);
            Controls.Add(label10);
            Controls.Add(tbxComp1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tbxPrixArt);
            Controls.Add(btnSupprimer);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnModifier);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(listViewArticle);
            Controls.Add(tbxCecArt);
            Controls.Add(tbxPoidArt);
            Controls.Add(tbxTvaArt);
            Controls.Add(tbxUnitArt);
            Controls.Add(tbxFamiArt);
            Controls.Add(tbxDesiArt);
            Controls.Add(tbxNumArt);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "article";
            Text = "article";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tbxNumArt;
        private TextBox tbxDesiArt;
        private TextBox tbxFamiArt;
        private TextBox tbxUnitArt;
        private TextBox tbxTvaArt;
        private TextBox tbxPoidArt;
        private TextBox tbxCecArt;
        private ListView listViewArticle;
        private ComboBox comboBox1;
        private Button button1;
        private Button btnModifier;
        private Button btnEnregistrer;
        private Button btnSupprimer;
        private TextBox tbxPrixArt;
        private Label label8;
        private TextBox tbxComp1;
        private Label label9;
        private TextBox tbxComp2;
        private Label label10;
        private TextBox tbxDluo;
        private Label label11;
        private TextBox tbxEan13;
        private Label label12;
        private TextBox tbxDiv;
        private Label label13;
    }
}