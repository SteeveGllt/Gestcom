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
            label1 = new Label();
            tbxAnnee = new TextBox();
            cbxFromagerie = new ComboBox();
            cbxMois = new ComboBox();
            button1 = new Button();
            cbAffiner = new CheckBox();
            panelAffine = new Panel();
            tbxPoidsNetAffine = new TextBox();
            tbxPainsAffine = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lbPrixUnitaire = new Label();
            tbxPrixUnitaire = new TextBox();
            dtpDateEntree = new DateTimePicker();
            lblDate_entree = new Label();
            panelBlanc = new Panel();
            dtpDateFin = new DateTimePicker();
            dtpDateDebut = new DateTimePicker();
            tbxPoidsNet = new TextBox();
            tbxFreinte = new TextBox();
            tbxPoidsBrut = new TextBox();
            tbxPains = new TextBox();
            lblPoids_net = new Label();
            lblFreinte = new Label();
            lblPoids_brut = new Label();
            lblNb_pains = new Label();
            lblDate_fin = new Label();
            lblDate_debut = new Label();
            panelAffine.SuspendLayout();
            panelBlanc.SuspendLayout();
            SuspendLayout();
            // 
            // lblFromagerie
            // 
            lblFromagerie.AutoSize = true;
            lblFromagerie.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFromagerie.Location = new Point(30, 36);
            lblFromagerie.Name = "lblFromagerie";
            lblFromagerie.Size = new Size(123, 23);
            lblFromagerie.TabIndex = 0;
            lblFromagerie.Text = "Fromagerie :";
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMois.Location = new Point(30, 80);
            lblMois.Name = "lblMois";
            lblMois.Size = new Size(64, 23);
            lblMois.TabIndex = 1;
            lblMois.Text = "Mois :";
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAnnee.Location = new Point(30, 125);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(77, 23);
            lblAnnee.TabIndex = 2;
            lblAnnee.Text = "Année :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(303, 119);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new Point(186, 125);
            tbxAnnee.Margin = new Padding(3, 4, 3, 4);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new Size(57, 27);
            tbxAnnee.TabIndex = 13;
            // 
            // cbxFromagerie
            // 
            cbxFromagerie.FormattingEnabled = true;
            cbxFromagerie.Location = new Point(186, 36);
            cbxFromagerie.Margin = new Padding(3, 4, 3, 4);
            cbxFromagerie.Name = "cbxFromagerie";
            cbxFromagerie.Size = new Size(76, 28);
            cbxFromagerie.TabIndex = 21;
            cbxFromagerie.SelectedIndexChanged += cbxFromagerie_SelectedIndexChanged;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new Point(186, 80);
            cbxMois.Margin = new Padding(3, 4, 3, 4);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new Size(76, 28);
            cbxMois.TabIndex = 22;
            // 
            // button1
            // 
            button1.Location = new Point(186, 520);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 31);
            button1.TabIndex = 26;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cbAffiner
            // 
            cbAffiner.AutoSize = true;
            cbAffiner.Location = new Point(431, 35);
            cbAffiner.Margin = new Padding(3, 4, 3, 4);
            cbAffiner.Name = "cbAffiner";
            cbAffiner.Size = new Size(71, 24);
            cbAffiner.TabIndex = 27;
            cbAffiner.Text = "Affiné";
            cbAffiner.UseVisualStyleBackColor = true;
            cbAffiner.CheckedChanged += cbAffiner_CheckedChanged;
            // 
            // panelAffine
            // 
            panelAffine.Controls.Add(tbxPoidsNetAffine);
            panelAffine.Controls.Add(tbxPainsAffine);
            panelAffine.Controls.Add(label2);
            panelAffine.Controls.Add(label3);
            panelAffine.Controls.Add(lbPrixUnitaire);
            panelAffine.Controls.Add(tbxPrixUnitaire);
            panelAffine.Location = new Point(30, 203);
            panelAffine.Name = "panelAffine";
            panelAffine.Size = new Size(283, 186);
            panelAffine.TabIndex = 30;
            panelAffine.Visible = false;
            // 
            // tbxPoidsNetAffine
            // 
            tbxPoidsNetAffine.Location = new Point(155, 99);
            tbxPoidsNetAffine.Margin = new Padding(3, 4, 3, 4);
            tbxPoidsNetAffine.MaxLength = 7;
            tbxPoidsNetAffine.Name = "tbxPoidsNetAffine";
            tbxPoidsNetAffine.Size = new Size(114, 27);
            tbxPoidsNetAffine.TabIndex = 35;
            // 
            // tbxPainsAffine
            // 
            tbxPainsAffine.Location = new Point(155, 59);
            tbxPainsAffine.Margin = new Padding(3, 4, 3, 4);
            tbxPainsAffine.MaxLength = 3;
            tbxPainsAffine.Name = "tbxPainsAffine";
            tbxPainsAffine.Size = new Size(99, 27);
            tbxPainsAffine.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 105);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
            label2.TabIndex = 33;
            label2.Text = "Poids Net :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 59);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 32;
            label3.Text = "Nb Pains :";
            // 
            // lbPrixUnitaire
            // 
            lbPrixUnitaire.AutoSize = true;
            lbPrixUnitaire.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPrixUnitaire.Location = new Point(0, 19);
            lbPrixUnitaire.Name = "lbPrixUnitaire";
            lbPrixUnitaire.Size = new Size(112, 23);
            lbPrixUnitaire.TabIndex = 30;
            lbPrixUnitaire.Text = "Prix unitaire";
            lbPrixUnitaire.Visible = false;
            // 
            // tbxPrixUnitaire
            // 
            tbxPrixUnitaire.Location = new Point(155, 19);
            tbxPrixUnitaire.Margin = new Padding(3, 4, 3, 4);
            tbxPrixUnitaire.MaxLength = 7;
            tbxPrixUnitaire.Name = "tbxPrixUnitaire";
            tbxPrixUnitaire.Size = new Size(86, 27);
            tbxPrixUnitaire.TabIndex = 31;
            tbxPrixUnitaire.Visible = false;
            // 
            // dtpDateEntree
            // 
            dtpDateEntree.Location = new Point(186, 169);
            dtpDateEntree.Margin = new Padding(3, 4, 3, 4);
            dtpDateEntree.Name = "dtpDateEntree";
            dtpDateEntree.Size = new Size(228, 27);
            dtpDateEntree.TabIndex = 39;
            dtpDateEntree.ValueChanged += dtpDateEntree_ValueChanged;
            // 
            // lblDate_entree
            // 
            lblDate_entree.AutoSize = true;
            lblDate_entree.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_entree.Location = new Point(30, 169);
            lblDate_entree.Name = "lblDate_entree";
            lblDate_entree.Size = new Size(128, 23);
            lblDate_entree.TabIndex = 38;
            lblDate_entree.Text = "Date Entrée :";
            // 
            // panelBlanc
            // 
            panelBlanc.Controls.Add(dtpDateFin);
            panelBlanc.Controls.Add(dtpDateDebut);
            panelBlanc.Controls.Add(tbxPoidsNet);
            panelBlanc.Controls.Add(tbxFreinte);
            panelBlanc.Controls.Add(tbxPoidsBrut);
            panelBlanc.Controls.Add(tbxPains);
            panelBlanc.Controls.Add(lblPoids_net);
            panelBlanc.Controls.Add(lblFreinte);
            panelBlanc.Controls.Add(lblPoids_brut);
            panelBlanc.Controls.Add(label1);
            panelBlanc.Controls.Add(lblNb_pains);
            panelBlanc.Controls.Add(lblDate_fin);
            panelBlanc.Controls.Add(lblDate_debut);
            panelBlanc.Location = new Point(30, 203);
            panelBlanc.Name = "panelBlanc";
            panelBlanc.Size = new Size(399, 285);
            panelBlanc.TabIndex = 31;
            // 
            // dtpDateFin
            // 
            dtpDateFin.Location = new Point(159, 64);
            dtpDateFin.Margin = new Padding(3, 4, 3, 4);
            dtpDateFin.Name = "dtpDateFin";
            dtpDateFin.Size = new Size(228, 27);
            dtpDateFin.TabIndex = 39;
            dtpDateFin.ValueChanged += dtpDateFin_ValueChanged;
            // 
            // dtpDateDebut
            // 
            dtpDateDebut.Location = new Point(159, 13);
            dtpDateDebut.Margin = new Padding(3, 4, 3, 4);
            dtpDateDebut.Name = "dtpDateDebut";
            dtpDateDebut.Size = new Size(228, 27);
            dtpDateDebut.TabIndex = 38;
            dtpDateDebut.ValueChanged += dtpDateDebut_ValueChanged;
            // 
            // tbxPoidsNet
            // 
            tbxPoidsNet.Location = new Point(159, 247);
            tbxPoidsNet.Margin = new Padding(3, 4, 3, 4);
            tbxPoidsNet.Name = "tbxPoidsNet";
            tbxPoidsNet.Size = new Size(114, 27);
            tbxPoidsNet.TabIndex = 36;
            tbxPoidsNet.KeyUp += tbxFreinte_KeyUp;
            // 
            // tbxFreinte
            // 
            tbxFreinte.Location = new Point(159, 203);
            tbxFreinte.Margin = new Padding(3, 4, 3, 4);
            tbxFreinte.Name = "tbxFreinte";
            tbxFreinte.Size = new Size(114, 27);
            tbxFreinte.TabIndex = 35;
            // 
            // tbxPoidsBrut
            // 
            tbxPoidsBrut.Location = new Point(159, 157);
            tbxPoidsBrut.Margin = new Padding(3, 4, 3, 4);
            tbxPoidsBrut.MaxLength = 10;
            tbxPoidsBrut.Name = "tbxPoidsBrut";
            tbxPoidsBrut.Size = new Size(114, 27);
            tbxPoidsBrut.TabIndex = 34;
            tbxPoidsBrut.KeyUp += tbxPoidsBrut_KeyUp;
            // 
            // tbxPains
            // 
            tbxPains.Location = new Point(159, 109);
            tbxPains.Margin = new Padding(3, 4, 3, 4);
            tbxPains.MaxLength = 3;
            tbxPains.Name = "tbxPains";
            tbxPains.Size = new Size(99, 27);
            tbxPains.TabIndex = 33;
            // 
            // lblPoids_net
            // 
            lblPoids_net.AutoSize = true;
            lblPoids_net.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPoids_net.Location = new Point(3, 253);
            lblPoids_net.Name = "lblPoids_net";
            lblPoids_net.Size = new Size(107, 23);
            lblPoids_net.TabIndex = 32;
            lblPoids_net.Text = "Poids Net :";
            // 
            // lblFreinte
            // 
            lblFreinte.AutoSize = true;
            lblFreinte.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFreinte.Location = new Point(3, 203);
            lblFreinte.Name = "lblFreinte";
            lblFreinte.Size = new Size(71, 23);
            lblFreinte.TabIndex = 31;
            lblFreinte.Text = "Freinte";
            // 
            // lblPoids_brut
            // 
            lblPoids_brut.AutoSize = true;
            lblPoids_brut.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPoids_brut.Location = new Point(3, 157);
            lblPoids_brut.Name = "lblPoids_brut";
            lblPoids_brut.Size = new Size(113, 23);
            lblPoids_brut.TabIndex = 30;
            lblPoids_brut.Text = "Poids Brut :";
            // 
            // lblNb_pains
            // 
            lblNb_pains.AutoSize = true;
            lblNb_pains.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNb_pains.Location = new Point(3, 109);
            lblNb_pains.Name = "lblNb_pains";
            lblNb_pains.Size = new Size(100, 23);
            lblNb_pains.TabIndex = 29;
            lblNb_pains.Text = "Nb Pains :";
            // 
            // lblDate_fin
            // 
            lblDate_fin.AutoSize = true;
            lblDate_fin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_fin.Location = new Point(3, 64);
            lblDate_fin.Name = "lblDate_fin";
            lblDate_fin.Size = new Size(96, 23);
            lblDate_fin.TabIndex = 27;
            lblDate_fin.Text = "Date Fin :";
            // 
            // lblDate_debut
            // 
            lblDate_debut.AutoSize = true;
            lblDate_debut.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate_debut.Location = new Point(3, 13);
            lblDate_debut.Name = "lblDate_debut";
            lblDate_debut.Size = new Size(122, 23);
            lblDate_debut.TabIndex = 28;
            lblDate_debut.Text = "Date Début :";
            // 
            // entree_lot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new Size(649, 713);
            Controls.Add(dtpDateEntree);
            Controls.Add(lblDate_entree);
            Controls.Add(panelBlanc);
            Controls.Add(panelAffine);
            Controls.Add(cbAffiner);
            Controls.Add(button1);
            Controls.Add(cbxMois);
            Controls.Add(cbxFromagerie);
            Controls.Add(tbxAnnee);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(lblFromagerie);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(667, 760);
            MinimumSize = new Size(667, 760);
            Name = "entree_lot";
            Text = "entree_lot";
            panelAffine.ResumeLayout(false);
            panelAffine.PerformLayout();
            panelBlanc.ResumeLayout(false);
            panelBlanc.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFromagerie;
        private Label lblMois;
        private Label lblAnnee;
        private Label label1;
        private TextBox tbxAnnee;
        private ComboBox cbxFromagerie;
        private ComboBox cbxMois;
        private Button button1;
        private CheckBox cbAffiner;
        private Panel panelAffine;
        private Label lbPrixUnitaire;
        private TextBox tbxPrixUnitaire;
        private TextBox tbxPoidsNetAffine;
        private TextBox tbxPainsAffine;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDateEntree;
        private Label lblDate_entree;
        private Panel panelBlanc;
        private DateTimePicker dtpDateFin;
        private DateTimePicker dtpDateDebut;
        private TextBox tbxPoidsNet;
        private TextBox tbxFreinte;
        private TextBox tbxPoidsBrut;
        private TextBox tbxPains;
        private Label lblPoids_net;
        private Label lblFreinte;
        private Label lblPoids_brut;
        private Label lblNb_pains;
        private Label lblDate_fin;
        private Label lblDate_debut;
    }
}