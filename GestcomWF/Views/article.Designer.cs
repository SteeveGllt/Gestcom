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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            tbxPrixArt = new TextBox();
            label8 = new Label();
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
            tbxFamiArt.Name = "tbxFamiArt";
            tbxFamiArt.Size = new System.Drawing.Size(45, 23);
            tbxFamiArt.TabIndex = 9;
            // 
            // tbxUnitArt
            // 
            tbxUnitArt.Location = new System.Drawing.Point(437, 36);
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
            tbxCecArt.Name = "tbxCecArt";
            tbxCecArt.Size = new System.Drawing.Size(36, 23);
            tbxCecArt.TabIndex = 13;
            // 
            // listViewArticle
            // 
            listViewArticle.FullRowSelect = true;
            listViewArticle.Location = new System.Drawing.Point(12, 186);
            listViewArticle.Name = "listViewArticle";
            listViewArticle.Size = new System.Drawing.Size(776, 252);
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
            // button2
            // 
            button2.Location = new System.Drawing.Point(196, 92);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Modifier";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(302, 92);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Enregistrer";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(409, 92);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 19;
            button4.Text = "Supprimer";
            button4.UseVisualStyleBackColor = true;
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
            // article
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(label8);
            Controls.Add(tbxPrixArt);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
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
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox tbxPrixArt;
        private Label label8;
    }
}