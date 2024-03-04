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
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(320, 232);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(140, 50);
            button1.TabIndex = 0;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Location = new Point(50, 134);
            lblMois.Margin = new Padding(5, 0, 5, 0);
            lblMois.Name = "lblMois";
            lblMois.Size = new Size(78, 32);
            lblMois.TabIndex = 1;
            lblMois.Text = "Mois :";
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new Point(431, 134);
            lblAnnee.Margin = new Padding(5, 0, 5, 0);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(95, 32);
            lblAnnee.TabIndex = 2;
            lblAnnee.Text = "Année :";
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new Point(138, 130);
            cbxMois.Margin = new Padding(5, 6, 5, 6);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new Size(222, 40);
            cbxMois.TabIndex = 3;
            cbxMois.SelectedIndexChanged += cbxMois_SelectedIndexChanged;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new Point(543, 130);
            tbxAnnee.Margin = new Padding(5, 6, 5, 6);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new Size(90, 39);
            tbxAnnee.TabIndex = 4;
            // 
            // printExcel
            // 
            printExcel.Location = new Point(455, 402);
            printExcel.Margin = new Padding(5, 6, 5, 6);
            printExcel.Name = "printExcel";
            printExcel.Size = new Size(140, 50);
            printExcel.TabIndex = 5;
            printExcel.Text = "Imprimer";
            printExcel.UseVisualStyleBackColor = true;
            printExcel.Click += printExcel_Click;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(50, 402);
            btnRechercher.Margin = new Padding(5, 6, 5, 6);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(140, 50);
            btnRechercher.TabIndex = 6;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // tbxRecherche
            // 
            tbxRecherche.Location = new Point(229, 403);
            tbxRecherche.Margin = new Padding(5, 6, 5, 6);
            tbxRecherche.Name = "tbxRecherche";
            tbxRecherche.Size = new Size(183, 39);
            tbxRecherche.TabIndex = 7;
            // 
            // dtpDateExcel
            // 
            dtpDateExcel.Location = new Point(138, 46);
            dtpDateExcel.Margin = new Padding(5, 6, 5, 6);
            dtpDateExcel.Name = "dtpDateExcel";
            dtpDateExcel.Size = new Size(368, 39);
            dtpDateExcel.TabIndex = 8;
            dtpDateExcel.ValueChanged += dtpDateExcel_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 59);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 32);
            label1.TabIndex = 9;
            label1.Text = "Date";
            // 
            // button2
            // 
            button2.Location = new Point(604, 248);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 10;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // edit_pesee
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new Size(824, 518);
            Controls.Add(button2);
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
            Margin = new Padding(5, 6, 5, 6);
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
        private Button button2;
    }
}