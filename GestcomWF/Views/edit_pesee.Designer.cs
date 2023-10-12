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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(187, 93);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Validation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblMois
            // 
            lblMois.AutoSize = true;
            lblMois.Location = new Point(65, 50);
            lblMois.Name = "lblMois";
            lblMois.Size = new Size(39, 15);
            lblMois.TabIndex = 1;
            lblMois.Text = "Mois :";
            // 
            // lblAnnee
            // 
            lblAnnee.AutoSize = true;
            lblAnnee.Location = new Point(239, 50);
            lblAnnee.Name = "lblAnnee";
            lblAnnee.Size = new Size(47, 15);
            lblAnnee.TabIndex = 2;
            lblAnnee.Text = "Année :";
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new Point(110, 47);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new Size(121, 23);
            cbxMois.TabIndex = 3;
            cbxMois.SelectedIndexChanged += cbxMois_SelectedIndexChanged;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new Point(292, 47);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new Size(50, 23);
            tbxAnnee.TabIndex = 4;
            // 
            // printExcel
            // 
            printExcel.Location = new Point(292, 147);
            printExcel.Name = "printExcel";
            printExcel.Size = new Size(75, 23);
            printExcel.TabIndex = 5;
            printExcel.Text = "Imprimer";
            printExcel.UseVisualStyleBackColor = true;
            printExcel.Click += printExcel_Click;
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(76, 147);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(75, 23);
            btnRechercher.TabIndex = 6;
            btnRechercher.Text = "Rechercher";
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // edit_pesee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new Size(444, 243);
            Controls.Add(textBox1);
            Controls.Add(btnRechercher);
            Controls.Add(printExcel);
            Controls.Add(tbxAnnee);
            Controls.Add(cbxMois);
            Controls.Add(lblAnnee);
            Controls.Add(lblMois);
            Controls.Add(button1);
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
        private TextBox textBox1;
    }
}