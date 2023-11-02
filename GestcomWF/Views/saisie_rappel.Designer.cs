namespace GestcomWF.Views
{
    partial class saisie_rappel
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
            generate_excel = new Button();
            tbx_c = new TextBox();
            tbx_b = new TextBox();
            tbx_a = new TextBox();
            tbx_total = new TextBox();
            btn_valider = new Button();
            lbl_c = new Label();
            lbl_b = new Label();
            lbl_a = new Label();
            lbl_total = new Label();
            cbxMois = new ComboBox();
            tbxAnnee = new TextBox();
            labelMois = new Label();
            labelAnnee = new Label();
            buttonGenerer = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // generate_excel
            // 
            generate_excel.Location = new System.Drawing.Point(591, 36);
            generate_excel.Name = "generate_excel";
            generate_excel.Size = new System.Drawing.Size(177, 29);
            generate_excel.TabIndex = 31;
            generate_excel.Text = "Générer le fichier Excel";
            generate_excel.UseVisualStyleBackColor = true;
            // 
            // tbx_c
            // 
            tbx_c.Location = new System.Drawing.Point(96, 241);
            tbx_c.Margin = new Padding(3, 4, 3, 4);
            tbx_c.Name = "tbx_c";
            tbx_c.Size = new System.Drawing.Size(70, 27);
            tbx_c.TabIndex = 30;
            // 
            // tbx_b
            // 
            tbx_b.Location = new System.Drawing.Point(96, 197);
            tbx_b.Margin = new Padding(3, 4, 3, 4);
            tbx_b.Name = "tbx_b";
            tbx_b.Size = new System.Drawing.Size(70, 27);
            tbx_b.TabIndex = 29;
            // 
            // tbx_a
            // 
            tbx_a.Location = new System.Drawing.Point(96, 153);
            tbx_a.Margin = new Padding(3, 4, 3, 4);
            tbx_a.Name = "tbx_a";
            tbx_a.Size = new System.Drawing.Size(70, 27);
            tbx_a.TabIndex = 28;
            // 
            // tbx_total
            // 
            tbx_total.Location = new System.Drawing.Point(96, 113);
            tbx_total.Margin = new Padding(3, 4, 3, 4);
            tbx_total.Name = "tbx_total";
            tbx_total.Size = new System.Drawing.Size(70, 27);
            tbx_total.TabIndex = 27;
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(76, 308);
            btn_valider.Margin = new Padding(5, 4, 5, 4);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(101, 36);
            btn_valider.TabIndex = 26;
            btn_valider.Text = "Valider";
            btn_valider.UseVisualStyleBackColor = true;
            // 
            // lbl_c
            // 
            lbl_c.AutoSize = true;
            lbl_c.Location = new System.Drawing.Point(33, 245);
            lbl_c.Name = "lbl_c";
            lbl_c.Size = new System.Drawing.Size(21, 20);
            lbl_c.TabIndex = 25;
            lbl_c.Text = "C:";
            // 
            // lbl_b
            // 
            lbl_b.AutoSize = true;
            lbl_b.Location = new System.Drawing.Point(33, 201);
            lbl_b.Name = "lbl_b";
            lbl_b.Size = new System.Drawing.Size(21, 20);
            lbl_b.TabIndex = 24;
            lbl_b.Text = "B:";
            // 
            // lbl_a
            // 
            lbl_a.AutoSize = true;
            lbl_a.Location = new System.Drawing.Point(33, 157);
            lbl_a.Name = "lbl_a";
            lbl_a.Size = new System.Drawing.Size(22, 20);
            lbl_a.TabIndex = 23;
            lbl_a.Text = "A:";
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Location = new System.Drawing.Point(33, 117);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new System.Drawing.Size(45, 20);
            lbl_total.TabIndex = 22;
            lbl_total.Text = "Total:";
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(76, 32);
            cbxMois.Margin = new Padding(3, 4, 3, 4);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(138, 28);
            cbxMois.TabIndex = 21;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new System.Drawing.Point(281, 32);
            tbxAnnee.Margin = new Padding(3, 4, 3, 4);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new System.Drawing.Size(53, 27);
            tbxAnnee.TabIndex = 20;
            // 
            // labelMois
            // 
            labelMois.AutoSize = true;
            labelMois.Location = new System.Drawing.Point(27, 36);
            labelMois.Margin = new Padding(5, 0, 5, 0);
            labelMois.Name = "labelMois";
            labelMois.Size = new System.Drawing.Size(44, 20);
            labelMois.TabIndex = 16;
            labelMois.Text = "Mois:";
            // 
            // labelAnnee
            // 
            labelAnnee.AutoSize = true;
            labelAnnee.Location = new System.Drawing.Point(222, 36);
            labelAnnee.Margin = new Padding(5, 0, 5, 0);
            labelAnnee.Name = "labelAnnee";
            labelAnnee.Size = new System.Drawing.Size(54, 20);
            labelAnnee.TabIndex = 17;
            labelAnnee.Text = "Année:";
            // 
            // buttonGenerer
            // 
            buttonGenerer.Location = new System.Drawing.Point(363, 32);
            buttonGenerer.Margin = new Padding(5, 4, 5, 4);
            buttonGenerer.Name = "buttonGenerer";
            buttonGenerer.Size = new System.Drawing.Size(101, 36);
            buttonGenerer.TabIndex = 18;
            buttonGenerer.Text = "Générer";
            buttonGenerer.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.Location = new System.Drawing.Point(234, 113);
            dataGridView.Margin = new Padding(5, 4, 5, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new System.Drawing.Size(534, 231);
            dataGridView.TabIndex = 19;
            // 
            // saisie_rappel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 378);
            Controls.Add(generate_excel);
            Controls.Add(tbx_c);
            Controls.Add(tbx_b);
            Controls.Add(tbx_a);
            Controls.Add(tbx_total);
            Controls.Add(btn_valider);
            Controls.Add(lbl_c);
            Controls.Add(lbl_b);
            Controls.Add(lbl_a);
            Controls.Add(lbl_total);
            Controls.Add(cbxMois);
            Controls.Add(tbxAnnee);
            Controls.Add(labelMois);
            Controls.Add(labelAnnee);
            Controls.Add(buttonGenerer);
            Controls.Add(dataGridView);
            Name = "saisie_rappel";
            Text = "saisie_rappel";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generate_excel;
        private TextBox tbx_c;
        private TextBox tbx_b;
        private TextBox tbx_a;
        private TextBox tbx_total;
        private Button btn_valider;
        private Label lbl_c;
        private Label lbl_b;
        private Label lbl_a;
        private Label lbl_total;
        private ComboBox cbxMois;
        private TextBox tbxAnnee;
        private Label labelMois;
        private Label labelAnnee;
        private Button buttonGenerer;
        private DataGridView dataGridView;
    }
}