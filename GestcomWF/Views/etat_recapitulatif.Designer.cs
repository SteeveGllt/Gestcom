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
            tbxRecherche.Location = new System.Drawing.Point(159, 205);
            tbxRecherche.Margin = new Padding(3, 4, 3, 4);
            tbxRecherche.Name = "tbxRecherche";
            tbxRecherche.Size = new System.Drawing.Size(114, 27);
            tbxRecherche.TabIndex = 15;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new System.Drawing.Point(49, 204);
            btnRechercher.Margin = new Padding(3, 4, 3, 4);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new System.Drawing.Size(86, 31);
            btnRechercher.TabIndex = 14;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            // 
            // printExcel
            // 
            printExcel.Location = new System.Drawing.Point(298, 204);
            printExcel.Margin = new Padding(3, 4, 3, 4);
            printExcel.Name = "printExcel";
            printExcel.Size = new System.Drawing.Size(86, 31);
            printExcel.TabIndex = 13;
            printExcel.Text = "Imprimer";
            printExcel.UseVisualStyleBackColor = true;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new System.Drawing.Point(352, 34);
            tbxAnnee.Margin = new Padding(3, 4, 3, 4);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new System.Drawing.Size(57, 27);
            tbxAnnee.TabIndex = 12;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(103, 34);
            cbxMois.Margin = new Padding(3, 4, 3, 4);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(138, 28);
            cbxMois.TabIndex = 11;
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new System.Drawing.Point(283, 37);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new System.Drawing.Size(58, 20);
            lblAnnee.TabIndex = 10;
            lblAnnee.Text = "Année :";
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Location = new System.Drawing.Point(49, 37);
            lblMois.Name = "lblMois";
            lblMois.Size = new System.Drawing.Size(48, 20);
            lblMois.TabIndex = 9;
            lblMois.Text = "Mois :";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(225, 94);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(86, 31);
            button1.TabIndex = 8;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // etat_recapitulatif
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(531, 307);
            Controls.Add(tbxRecherche);
            Controls.Add(btnRechercher);
            Controls.Add(printExcel);
            Controls.Add(tbxAnnee);
            Controls.Add(cbxMois);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(button1);
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