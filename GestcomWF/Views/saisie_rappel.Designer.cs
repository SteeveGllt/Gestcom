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
            label1 = new Label();
            dtpDate = new DateTimePicker();
            label2 = new Label();
            tbxNumFromagerie = new TextBox();
            label3 = new Label();
            tbxMontant = new TextBox();
            btnImprimer = new Button();
            tbxPrime = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // generate_excel
            // 
            generate_excel.Location = new System.Drawing.Point(576, 14);
            generate_excel.Margin = new Padding(3, 2, 3, 2);
            generate_excel.Name = "generate_excel";
            generate_excel.Size = new System.Drawing.Size(155, 22);
            generate_excel.TabIndex = 31;
            generate_excel.Text = "Générer le fichier Excel";
            generate_excel.UseVisualStyleBackColor = true;
            generate_excel.Click += generate_excel_Click;
            // 
            // tbx_c
            // 
            tbx_c.Location = new System.Drawing.Point(82, 211);
            tbx_c.Name = "tbx_c";
            tbx_c.Size = new System.Drawing.Size(62, 23);
            tbx_c.TabIndex = 30;
            tbx_c.KeyDown += tbx_c_KeyDown;
            // 
            // tbx_b
            // 
            tbx_b.Location = new System.Drawing.Point(82, 178);
            tbx_b.Name = "tbx_b";
            tbx_b.Size = new System.Drawing.Size(62, 23);
            tbx_b.TabIndex = 29;
            tbx_b.KeyDown += tbx_b_KeyDown;
            // 
            // tbx_a
            // 
            tbx_a.Location = new System.Drawing.Point(82, 145);
            tbx_a.Name = "tbx_a";
            tbx_a.Size = new System.Drawing.Size(62, 23);
            tbx_a.TabIndex = 28;
            tbx_a.KeyDown += tbx_a_KeyDown;
            // 
            // tbx_total
            // 
            tbx_total.Location = new System.Drawing.Point(82, 115);
            tbx_total.Name = "tbx_total";
            tbx_total.Size = new System.Drawing.Size(62, 23);
            tbx_total.TabIndex = 27;
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(70, 325);
            btn_valider.Margin = new Padding(4, 3, 4, 3);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(88, 27);
            btn_valider.TabIndex = 26;
            btn_valider.Text = "Sauvegarder";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btn_valider_Click;
            // 
            // lbl_c
            // 
            lbl_c.AutoSize = true;
            lbl_c.Location = new System.Drawing.Point(27, 214);
            lbl_c.Name = "lbl_c";
            lbl_c.Size = new System.Drawing.Size(18, 15);
            lbl_c.TabIndex = 25;
            lbl_c.Text = "C:";
            // 
            // lbl_b
            // 
            lbl_b.AutoSize = true;
            lbl_b.Location = new System.Drawing.Point(27, 181);
            lbl_b.Name = "lbl_b";
            lbl_b.Size = new System.Drawing.Size(17, 15);
            lbl_b.TabIndex = 24;
            lbl_b.Text = "B:";
            // 
            // lbl_a
            // 
            lbl_a.AutoSize = true;
            lbl_a.Location = new System.Drawing.Point(27, 148);
            lbl_a.Name = "lbl_a";
            lbl_a.Size = new System.Drawing.Size(18, 15);
            lbl_a.TabIndex = 23;
            lbl_a.Text = "A:";
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Location = new System.Drawing.Point(27, 118);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new System.Drawing.Size(35, 15);
            lbl_total.TabIndex = 22;
            lbl_total.Text = "Total:";
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(71, 46);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(121, 23);
            cbxMois.TabIndex = 21;
            cbxMois.SelectedIndexChanged += cbxMois_SelectedIndexChanged;
            // 
            // tbxAnnee
            // 
            tbxAnnee.Location = new System.Drawing.Point(251, 46);
            tbxAnnee.MaxLength = 2;
            tbxAnnee.Name = "tbxAnnee";
            tbxAnnee.Size = new System.Drawing.Size(47, 23);
            tbxAnnee.TabIndex = 20;
            tbxAnnee.KeyDown += tbxAnnee_KeyDown;
            // 
            // labelMois
            // 
            labelMois.AutoSize = true;
            labelMois.Location = new System.Drawing.Point(29, 50);
            labelMois.Margin = new Padding(4, 0, 4, 0);
            labelMois.Name = "labelMois";
            labelMois.Size = new System.Drawing.Size(36, 15);
            labelMois.TabIndex = 16;
            labelMois.Text = "Mois:";
            // 
            // labelAnnee
            // 
            labelAnnee.AutoSize = true;
            labelAnnee.Location = new System.Drawing.Point(200, 50);
            labelAnnee.Margin = new Padding(4, 0, 4, 0);
            labelAnnee.Name = "labelAnnee";
            labelAnnee.Size = new System.Drawing.Size(44, 15);
            labelAnnee.TabIndex = 17;
            labelAnnee.Text = "Année:";
            // 
            // buttonGenerer
            // 
            buttonGenerer.Location = new System.Drawing.Point(323, 46);
            buttonGenerer.Margin = new Padding(4, 3, 4, 3);
            buttonGenerer.Name = "buttonGenerer";
            buttonGenerer.Size = new System.Drawing.Size(88, 27);
            buttonGenerer.TabIndex = 18;
            buttonGenerer.Text = "Générer";
            buttonGenerer.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeight = 29;
            dataGridView.Location = new System.Drawing.Point(205, 85);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new System.Drawing.Size(746, 267);
            dataGridView.TabIndex = 19;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 33;
            label1.Text = "Date";
            // 
            // dtpDate
            // 
            dtpDate.Location = new System.Drawing.Point(70, 10);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(200, 23);
            dtpDate.TabIndex = 32;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(2, 79);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 15);
            label2.TabIndex = 34;
            label2.Text = "Numéro de fromagerie";
            // 
            // tbxNumFromagerie
            // 
            tbxNumFromagerie.Location = new System.Drawing.Point(149, 75);
            tbxNumFromagerie.Name = "tbxNumFromagerie";
            tbxNumFromagerie.Size = new System.Drawing.Size(49, 23);
            tbxNumFromagerie.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(29, 252);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 36;
            label3.Text = "Montant :";
            // 
            // tbxMontant
            // 
            tbxMontant.Location = new System.Drawing.Point(97, 250);
            tbxMontant.Name = "tbxMontant";
            tbxMontant.Size = new System.Drawing.Size(95, 23);
            tbxMontant.TabIndex = 37;
            // 
            // btnImprimer
            // 
            btnImprimer.Location = new System.Drawing.Point(736, 14);
            btnImprimer.Name = "btnImprimer";
            btnImprimer.Size = new System.Drawing.Size(100, 23);
            btnImprimer.TabIndex = 38;
            btnImprimer.Text = "Impression";
            btnImprimer.UseVisualStyleBackColor = true;
            btnImprimer.Click += btnImprimer_Click;
            // 
            // tbxPrime
            // 
            tbxPrime.Location = new System.Drawing.Point(82, 289);
            tbxPrime.Name = "tbxPrime";
            tbxPrime.Size = new System.Drawing.Size(95, 23);
            tbxPrime.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 292);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 15);
            label4.TabIndex = 39;
            label4.Text = "Prime :";
            // 
            // saisie_rappel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(964, 380);
            Controls.Add(tbxPrime);
            Controls.Add(label4);
            Controls.Add(btnImprimer);
            Controls.Add(tbxMontant);
            Controls.Add(label3);
            Controls.Add(tbxNumFromagerie);
            Controls.Add(label2);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "saisie_rappel";
            Text = "saisie_rappel";
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
                DataPropertyName = "LOCEN1",
                HeaderText = "Poids Net"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC11",
                HeaderText = "A"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOPU1",
                HeaderText = "Prix A"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC12",
                HeaderText = "B"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOPU2",
                HeaderText = "Prix B"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOC13",
                HeaderText = "C"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LOPU3",
                HeaderText = "Prix C"
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MONTANT",
                HeaderText = "Montant"
            });

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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
        private Label label1;
        private DateTimePicker dtpDate;
        private Label label2;
        private TextBox tbxNumFromagerie;
        private Label label3;
        private TextBox tbxMontant;
        private Button btnImprimer;
        private TextBox tbxPrime;
        private Label label4;
    }
}