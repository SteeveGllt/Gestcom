namespace GestcomWF.Views
{
    partial class etat_recapitulatif
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
            tbxRecherche = new TextBox();
            btnRechercher = new Button();
            printExcel = new Button();
            tbxAnnee = new TextBox();
            cbxMois = new ComboBox();
            lblAnnee = new Label();
            lblMois = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // tbxRecherche
            // 
            tbxRecherche.Location = new System.Drawing.Point(139, 154);
            tbxRecherche.Name = "tbxRecherche";
            tbxRecherche.Size = new System.Drawing.Size(100, 23);
            tbxRecherche.TabIndex = 15;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new System.Drawing.Point(43, 153);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new System.Drawing.Size(75, 23);
            btnRechercher.TabIndex = 14;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // printExcel
            // 
            printExcel.Location = new System.Drawing.Point(261, 153);
            printExcel.Name = "printExcel";
            printExcel.Size = new System.Drawing.Size(75, 23);
            printExcel.TabIndex = 13;
            printExcel.Text = "Imprimer";
            printExcel.UseVisualStyleBackColor = true;
            printExcel.Click += printExcel_Click;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new System.Drawing.Point(308, 26);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new System.Drawing.Size(50, 23);
            tbxAnnee.TabIndex = 12;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(90, 26);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(121, 23);
            cbxMois.TabIndex = 11;
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new System.Drawing.Point(248, 28);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new System.Drawing.Size(47, 15);
            lblAnnee.TabIndex = 10;
            lblAnnee.Text = "Année :";
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Location = new System.Drawing.Point(43, 28);
            lblMois.Name = "lblMois";
            lblMois.Size = new System.Drawing.Size(39, 15);
            lblMois.TabIndex = 9;
            lblMois.Text = "Mois :";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(197, 70);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // etat_recapitulatif
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(465, 230);
            Controls.Add(tbxRecherche);
            Controls.Add(btnRechercher);
            Controls.Add(printExcel);
            Controls.Add(tbxAnnee);
            Controls.Add(cbxMois);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "etat_recapitulatif";
            Text = "etat_recapitulatif";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxRecherche;
        private Button btnRechercher;
        private Button printExcel;
        private TextBox tbxAnnee;
        private ComboBox cbxMois;
        private Label lblAnnee;
        private Label lblMois;
        private Button button1;
    }
}