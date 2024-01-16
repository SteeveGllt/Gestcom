namespace GestcomWF.Views
{
    partial class saisie_classement
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
            labelMois = new Label();
            labelAnnee = new Label();
            buttonGenerer = new Button();
            dataGridView = new DataGridView();
            tbxAnnee = new TextBox();
            cbxMois = new ComboBox();
            lbl_total = new Label();
            lbl_a = new Label();
            lbl_b = new Label();
            lbl_c = new Label();
            btn_valider = new Button();
            tbx_total = new TextBox();
            tbx_a = new TextBox();
            tbx_b = new TextBox();
            tbx_c = new TextBox();
            generate_excel = new Button();
            dtpDate = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // labelMois
            // 
            labelMois.AutoSize = true;
            labelMois.Location = new System.Drawing.Point(25, 57);
            labelMois.Margin = new Padding(5, 0, 5, 0);
            labelMois.Name = "labelMois";
            labelMois.Size = new System.Drawing.Size(44, 20);
            labelMois.TabIndex = 0;
            labelMois.Text = "Mois:";
            // 
            // labelAnnee
            // 
            labelAnnee.AutoSize = true;
            labelAnnee.Location = new System.Drawing.Point(220, 57);
            labelAnnee.Margin = new Padding(5, 0, 5, 0);
            labelAnnee.Name = "labelAnnee";
            labelAnnee.Size = new System.Drawing.Size(54, 20);
            labelAnnee.TabIndex = 1;
            labelAnnee.Text = "Année:";
            // 
            // buttonGenerer
            // 
            buttonGenerer.Location = new System.Drawing.Point(352, 15);
            buttonGenerer.Margin = new Padding(5, 4, 5, 4);
            buttonGenerer.Name = "buttonGenerer";
            buttonGenerer.Size = new System.Drawing.Size(101, 36);
            buttonGenerer.TabIndex = 2;
            buttonGenerer.Text = "Afficher";
            buttonGenerer.UseVisualStyleBackColor = true;
            buttonGenerer.Click += buttonGenerer_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.Location = new System.Drawing.Point(184, 115);
            dataGridView.Margin = new Padding(5, 4, 5, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new System.Drawing.Size(534, 231);
            dataGridView.TabIndex = 3;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new System.Drawing.Point(279, 53);
            tbxAnnee.Margin = new Padding(3, 4, 3, 4);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new System.Drawing.Size(53, 27);
            tbxAnnee.TabIndex = 4;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(74, 53);
            cbxMois.Margin = new Padding(3, 4, 3, 4);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(138, 28);
            cbxMois.TabIndex = 5;
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Location = new System.Drawing.Point(23, 119);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new System.Drawing.Size(45, 20);
            lbl_total.TabIndex = 6;
            lbl_total.Text = "Total:";
            // 
            // lbl_a
            // 
            lbl_a.AutoSize = true;
            lbl_a.Location = new System.Drawing.Point(23, 159);
            lbl_a.Name = "lbl_a";
            lbl_a.Size = new System.Drawing.Size(22, 20);
            lbl_a.TabIndex = 7;
            lbl_a.Text = "A:";
            // 
            // lbl_b
            // 
            lbl_b.AutoSize = true;
            lbl_b.Location = new System.Drawing.Point(23, 203);
            lbl_b.Name = "lbl_b";
            lbl_b.Size = new System.Drawing.Size(21, 20);
            lbl_b.TabIndex = 8;
            lbl_b.Text = "B:";
            // 
            // lbl_c
            // 
            lbl_c.AutoSize = true;
            lbl_c.Location = new System.Drawing.Point(23, 247);
            lbl_c.Name = "lbl_c";
            lbl_c.Size = new System.Drawing.Size(21, 20);
            lbl_c.TabIndex = 9;
            lbl_c.Text = "C:";
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(55, 309);
            btn_valider.Margin = new Padding(5, 4, 5, 4);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(101, 36);
            btn_valider.TabIndex = 10;
            btn_valider.Text = "Sauvegarder";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btn_valider_Click;
            // 
            // tbx_total
            // 
            tbx_total.Enabled = false;
            tbx_total.Location = new System.Drawing.Point(86, 115);
            tbx_total.Margin = new Padding(3, 4, 3, 4);
            tbx_total.Name = "tbx_total";
            tbx_total.Size = new System.Drawing.Size(70, 27);
            tbx_total.TabIndex = 11;
            // 
            // tbx_a
            // 
            tbx_a.Location = new System.Drawing.Point(86, 155);
            tbx_a.Margin = new Padding(3, 4, 3, 4);
            tbx_a.Name = "tbx_a";
            tbx_a.Size = new System.Drawing.Size(70, 27);
            tbx_a.TabIndex = 12;
            tbx_a.KeyUp += tbx_a_KeyUp;
            // 
            // tbx_b
            // 
            tbx_b.Location = new System.Drawing.Point(86, 199);
            tbx_b.Margin = new Padding(3, 4, 3, 4);
            tbx_b.Name = "tbx_b";
            tbx_b.Size = new System.Drawing.Size(70, 27);
            tbx_b.TabIndex = 13;
            tbx_b.KeyUp += tbx_b_KeyUp;
            // 
            // tbx_c
            // 
            tbx_c.Location = new System.Drawing.Point(86, 243);
            tbx_c.Margin = new Padding(3, 4, 3, 4);
            tbx_c.Name = "tbx_c";
            tbx_c.Size = new System.Drawing.Size(70, 27);
            tbx_c.TabIndex = 14;
            tbx_c.KeyUp += tbx_c_KeyUp;
            // 
            // generate_excel
            // 
            generate_excel.Location = new System.Drawing.Point(570, 15);
            generate_excel.Name = "generate_excel";
            generate_excel.Size = new System.Drawing.Size(177, 29);
            generate_excel.TabIndex = 15;
            generate_excel.Text = "Générer le fichier Excel";
            generate_excel.UseVisualStyleBackColor = true;
            generate_excel.Click += generate_excel_Click;
            // 
            // dtpDate
            // 
            dtpDate.Location = new System.Drawing.Point(72, 11);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(228, 27);
            dtpDate.TabIndex = 16;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 20);
            label1.TabIndex = 17;
            label1.Text = "Date";
            // 
            // saisie_classement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(759, 373);
            Controls.Add(label1);
            Controls.Add(dtpDate);
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
            Margin = new Padding(5, 4, 5, 4);
            Name = "saisie_classement";
            Text = "Saisie classement";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeDataGridView()
        {
            dataGridView.ReadOnly = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOFROM",
                HeaderText = "Numéro"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOCEM1",
                HeaderText = "Total"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC11",
                HeaderText = "A"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC12",
                HeaderText = "B"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC13",
                HeaderText = "C"
            });
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        #endregion

        private Label labelMois;
        private Label labelAnnee;
        private Button buttonGenerer;
        private DataGridView dataGridView;
        private TextBox tbxAnnee;
        private ComboBox cbxMois;
        private Label lbl_total;
        private Label lbl_a;
        private Label lbl_b;
        private Label lbl_c;
        private Button btn_valider;
        private TextBox tbx_total;
        private TextBox tbx_a;
        private TextBox tbx_b;
        private TextBox tbx_c;
        private Button generate_excel;
        private DateTimePicker dtpDate;
        private Label label1;
    }
}