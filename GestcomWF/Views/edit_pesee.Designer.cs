using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

namespace GestcomWF.Views
{
    partial class edit_pesee
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
            button1 = new Button();
            lblMois = new Label();
            lblAnnee = new Label();
            cbxMois = new ComboBox();
            tbxAnnee = new TextBox();
            printExcel = new Button();
            btnRechercher = new Button();
            tbxRecherche = new TextBox();
            dtpDateExcel = new DateTimePicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(197, 145);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 0;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Location = new Point(31, 84);
            lblMois.Name = "lblMois";
            lblMois.Size = new Size(48, 20);
            lblMois.TabIndex = 1;
            lblMois.Text = "Mois :";
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new Point(265, 84);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(58, 20);
            lblAnnee.TabIndex = 2;
            lblAnnee.Text = "Année :";
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new Point(85, 81);
            cbxMois.Margin = new Padding(3, 4, 3, 4);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new Size(138, 28);
            cbxMois.TabIndex = 3;
            cbxMois.SelectedIndexChanged += cbxMois_SelectedIndexChanged;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new Point(334, 81);
            tbxAnnee.Margin = new Padding(3, 4, 3, 4);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new Size(57, 27);
            tbxAnnee.TabIndex = 4;
            // 
            // printExcel
            // 
            printExcel.Location = new Point(280, 251);
            printExcel.Margin = new Padding(3, 4, 3, 4);
            printExcel.Name = "printExcel";
            printExcel.Size = new Size(86, 31);
            printExcel.TabIndex = 5;
            printExcel.Text = "Imprimer";
            printExcel.UseVisualStyleBackColor = true;
            printExcel.Click += printExcel_Click;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(31, 251);
            btnRechercher.Margin = new Padding(3, 4, 3, 4);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(86, 31);
            btnRechercher.TabIndex = 6;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // tbxRecherche
            // 
            tbxRecherche.Location = new Point(141, 252);
            tbxRecherche.Margin = new Padding(3, 4, 3, 4);
            tbxRecherche.Name = "tbxRecherche";
            tbxRecherche.Size = new Size(114, 27);
            tbxRecherche.TabIndex = 7;
            // 
            // dtpDateExcel
            // 
            dtpDateExcel.Location = new Point(85, 29);
            dtpDateExcel.Margin = new Padding(3, 4, 3, 4);
            dtpDateExcel.Name = "dtpDateExcel";
            dtpDateExcel.Size = new Size(228, 27);
            dtpDateExcel.TabIndex = 8;
            dtpDateExcel.ValueChanged += dtpDateExcel_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 37);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 9;
            label1.Text = "Date";
            // 
            // edit_pesee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new Size(507, 324);
            Controls.Add(label1);
            Controls.Add(dtpDateExcel);
            Controls.Add(tbxRecherche);
            Controls.Add(btnRechercher);
            Controls.Add(printExcel);
            Controls.Add(tbxAnnee);
            Controls.Add(cbxMois);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "edit_pesee";
            Text = "edit_pesee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblMois;
        private Label lblAnnee;
        private ComboBox cbxMois;
        private TextBox tbxAnnee;
        private Button printExcel;
        private Button btnRechercher;
        private TextBox tbxRecherche;
        private DateTimePicker dtpDateExcel;
        private Label label1;
    }
}