using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

namespace GestcomWF.Views
{
    partial class entree_lot
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
                Console.WriteLine("test");
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
            lblFromagerie = new Label();
            lblMois = new Label();
            lblAnnee = new Label();
            lblDate_entree = new Label();
            lblDate_fin = new Label();
            lblDate_debut = new Label();
            lblNb_pains = new Label();
            lblPoids_brut = new Label();
            lblFreinte = new Label();
            lblPoids_net = new Label();
            label1 = new Label();
            tbxAnnee = new TextBox();
            tbxPains = new TextBox();
            tbxPoidsBrut = new TextBox();
            tbxFreinte = new TextBox();
            tbxPoidsNet = new TextBox();
            cbxFromagerie = new ComboBox();
            cbxMois = new ComboBox();
            dtpDateEntree = new DateTimePicker();
            dtpDateDebut = new DateTimePicker();
            dtpDateFin = new DateTimePicker();
            button1 = new Button();
            cbAffiner = new CheckBox();
            SuspendLayout();
            // 
            // lblFromagerie
            // 
            lblFromagerie.AutoSize = true;
            lblFromagerie.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFromagerie.Location = new Point(26, 27);
            lblFromagerie.Name = "lblFromagerie";
            lblFromagerie.Size = new Size(98, 18);
            lblFromagerie.TabIndex = 0;
            lblFromagerie.Text = "Fromagerie :";
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMois.Location = new Point(26, 60);
            lblMois.Name = "lblMois";
            lblMois.Size = new Size(50, 18);
            lblMois.TabIndex = 1;
            lblMois.Text = "Mois :";
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnnee.Location = new Point(26, 94);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(61, 18);
            lblAnnee.TabIndex = 2;
            lblAnnee.Text = "Année :";
            // 
            // lblDate_entree
            // 
            lblDate_entree.AutoSize = true;
            lblDate_entree.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_entree.Location = new Point(26, 128);
            lblDate_entree.Name = "lblDate_entree";
            lblDate_entree.Size = new Size(100, 18);
            lblDate_entree.TabIndex = 3;
            lblDate_entree.Text = "Date Entrée :";
            // 
            // lblDate_fin
            // 
            lblDate_fin.AutoSize = true;
            lblDate_fin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_fin.Location = new Point(26, 199);
            lblDate_fin.Name = "lblDate_fin";
            lblDate_fin.Size = new Size(76, 18);
            lblDate_fin.TabIndex = 4;
            lblDate_fin.Text = "Date Fin :";
            // 
            // lblDate_debut
            // 
            lblDate_debut.AutoSize = true;
            lblDate_debut.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_debut.Location = new Point(26, 162);
            lblDate_debut.Name = "lblDate_debut";
            lblDate_debut.Size = new Size(96, 18);
            lblDate_debut.TabIndex = 5;
            lblDate_debut.Text = "Date Début :";
            // 
            // lblNb_pains
            // 
            lblNb_pains.AutoSize = true;
            lblNb_pains.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNb_pains.Location = new Point(26, 233);
            lblNb_pains.Name = "lblNb_pains";
            lblNb_pains.Size = new Size(80, 18);
            lblNb_pains.TabIndex = 6;
            lblNb_pains.Text = "Nb Pains :";
            // 
            // lblPoids_brut
            // 
            lblPoids_brut.AutoSize = true;
            lblPoids_brut.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPoids_brut.Location = new Point(26, 269);
            lblPoids_brut.Name = "lblPoids_brut";
            lblPoids_brut.Size = new Size(89, 18);
            lblPoids_brut.TabIndex = 7;
            lblPoids_brut.Text = "Poids Brut :";
            // 
            // lblFreinte
            // 
            lblFreinte.AutoSize = true;
            lblFreinte.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFreinte.Location = new Point(26, 303);
            lblFreinte.Name = "lblFreinte";
            lblFreinte.Size = new Size(57, 18);
            lblFreinte.TabIndex = 8;
            lblFreinte.Text = "Freinte";
            // 
            // lblPoids_net
            // 
            lblPoids_net.AutoSize = true;
            lblPoids_net.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPoids_net.Location = new Point(26, 341);
            lblPoids_net.Name = "lblPoids_net";
            lblPoids_net.Size = new Size(85, 18);
            lblPoids_net.TabIndex = 9;
            lblPoids_net.Text = "Poids Net :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(345, 246);
            label1.Name = "label1";
            label1.Size = new Size(50, 18);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new Point(163, 94);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new Size(50, 23);
            tbxAnnee.TabIndex = 13;
            // 
            // tbxPains
            // 
            tbxPains.Location = new Point(163, 233);
            tbxPains.MaxLength = 3;
            tbxPains.Name = "tbxPains";
            tbxPains.Size = new Size(87, 23);
            tbxPains.TabIndex = 17;
            // 
            // tbxPoidsBrut
            // 
            tbxPoidsBrut.Location = new Point(163, 269);
            tbxPoidsBrut.MaxLength = 5;
            tbxPoidsBrut.Name = "tbxPoidsBrut";
            tbxPoidsBrut.Size = new Size(100, 23);
            tbxPoidsBrut.TabIndex = 18;
            tbxPoidsBrut.KeyUp += tbxPoidsBrut_KeyUp;
            // 
            // tbxFreinte
            // 
            tbxFreinte.Location = new Point(163, 303);
            tbxFreinte.Name = "tbxFreinte";
            tbxFreinte.Size = new Size(100, 23);
            tbxFreinte.TabIndex = 19;
            tbxFreinte.KeyUp += tbxFreinte_KeyUp;
            // 
            // tbxPoidsNet
            // 
            tbxPoidsNet.Location = new Point(163, 336);
            tbxPoidsNet.Name = "tbxPoidsNet";
            tbxPoidsNet.Size = new Size(100, 23);
            tbxPoidsNet.TabIndex = 20;
            // 
            // cbxFromagerie
            // 
            cbxFromagerie.FormattingEnabled = true;
            cbxFromagerie.Location = new Point(163, 27);
            cbxFromagerie.Name = "cbxFromagerie";
            cbxFromagerie.Size = new Size(67, 23);
            cbxFromagerie.TabIndex = 21;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new Point(163, 60);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new Size(67, 23);
            cbxMois.TabIndex = 22;
            // 
            // dtpDateEntree
            // 
            dtpDateEntree.Location = new Point(163, 128);
            dtpDateEntree.Name = "dtpDateEntree";
            dtpDateEntree.Size = new Size(200, 23);
            dtpDateEntree.TabIndex = 23;
            dtpDateEntree.ValueChanged += dtpDateEntree_ValueChanged;
            // 
            // dtpDateDebut
            // 
            dtpDateDebut.Location = new Point(163, 162);
            dtpDateDebut.Name = "dtpDateDebut";
            dtpDateDebut.Size = new Size(200, 23);
            dtpDateDebut.TabIndex = 24;
            dtpDateDebut.ValueChanged += dtpDateDebut_ValueChanged;
            // 
            // dtpDateFin
            // 
            dtpDateFin.Location = new Point(163, 199);
            dtpDateFin.Name = "dtpDateFin";
            dtpDateFin.Size = new Size(200, 23);
            dtpDateFin.TabIndex = 25;
            dtpDateFin.ValueChanged += dtpDateFin_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(163, 390);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 26;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cbAffiner
            // 
            cbAffiner.AutoSize = true;
            cbAffiner.Location = new Point(377, 26);
            cbAffiner.Name = "cbAffiner";
            cbAffiner.Size = new Size(58, 19);
            cbAffiner.TabIndex = 27;
            cbAffiner.Text = "Affiné";
            cbAffiner.UseVisualStyleBackColor = true;
            cbAffiner.CheckedChanged += cbAffiner_CheckedChanged;
            // 
            // entree_lot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new Size(571, 547);
            Controls.Add(cbAffiner);
            Controls.Add(button1);
            Controls.Add(dtpDateFin);
            Controls.Add(dtpDateDebut);
            Controls.Add(dtpDateEntree);
            Controls.Add(cbxMois);
            Controls.Add(cbxFromagerie);
            Controls.Add(tbxPoidsNet);
            Controls.Add(tbxFreinte);
            Controls.Add(tbxPoidsBrut);
            Controls.Add(tbxPains);
            Controls.Add(tbxAnnee);
            Controls.Add(label1);
            Controls.Add(lblPoids_net);
            Controls.Add(lblFreinte);
            Controls.Add(lblPoids_brut);
            Controls.Add(lblNb_pains);
            Controls.Add(lblDate_debut);
            Controls.Add(lblDate_fin);
            Controls.Add(lblDate_entree);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(lblFromagerie);
            MaximumSize = new Size(587, 586);
            MinimumSize = new Size(587, 586);
            Name = "entree_lot";
            Text = "entree_lot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFromagerie;
        private Label lblMois;
        private Label lblAnnee;
        private Label lblDate_entree;
        private Label lblDate_fin;
        private Label lblDate_debut;
        private Label lblNb_pains;
        private Label lblPoids_brut;
        private Label lblFreinte;
        private Label lblPoids_net;
        private Label label1;
        private TextBox tbxAnnee;
        private TextBox tbxPains;
        private TextBox tbxPoidsBrut;
        private TextBox tbxFreinte;
        private TextBox tbxPoidsNet;
        private ComboBox cbxFromagerie;
        private ComboBox cbxMois;
        private DateTimePicker dtpDateEntree;
        private DateTimePicker dtpDateDebut;
        private DateTimePicker dtpDateFin;
        private Button button1;
        private CheckBox cbAffiner;
    }
}