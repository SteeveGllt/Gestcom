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
            this.labelMois = new System.Windows.Forms.Label();
            this.labelAnnee = new System.Windows.Forms.Label();
            this.buttonGenerer = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tbxAnnee = new System.Windows.Forms.TextBox();
            this.cbxMois = new System.Windows.Forms.ComboBox();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_a = new System.Windows.Forms.Label();
            this.lbl_b = new System.Windows.Forms.Label();
            this.lbl_c = new System.Windows.Forms.Label();
            this.btn_valider = new System.Windows.Forms.Button();
            this.tbx_total = new System.Windows.Forms.TextBox();
            this.tbx_a = new System.Windows.Forms.TextBox();
            this.tbx_b = new System.Windows.Forms.TextBox();
            this.tbx_c = new System.Windows.Forms.TextBox();
            this.generate_excel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMois
            // 
            this.labelMois.AutoSize = true;
            this.labelMois.Location = new System.Drawing.Point(31, 72);
            this.labelMois.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMois.Name = "labelMois";
            this.labelMois.Size = new System.Drawing.Size(55, 25);
            this.labelMois.TabIndex = 0;
            this.labelMois.Text = "Mois:";
            // 
            // labelAnnee
            // 
            this.labelAnnee.AutoSize = true;
            this.labelAnnee.Location = new System.Drawing.Point(274, 72);
            this.labelAnnee.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAnnee.Name = "labelAnnee";
            this.labelAnnee.Size = new System.Drawing.Size(66, 25);
            this.labelAnnee.TabIndex = 1;
            this.labelAnnee.Text = "Année:";
            // 
            // buttonGenerer
            // 
            this.buttonGenerer.Location = new System.Drawing.Point(440, 18);
            this.buttonGenerer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonGenerer.Name = "buttonGenerer";
            this.buttonGenerer.Size = new System.Drawing.Size(126, 45);
            this.buttonGenerer.TabIndex = 2;
            this.buttonGenerer.Text = "Afficher";
            this.buttonGenerer.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeight = 29;
            this.dataGridView.Location = new System.Drawing.Point(230, 143);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(667, 288);
            this.dataGridView.TabIndex = 3;
            // 
            // tbxAnnee
            // 
            this.tbxAnnee.Location = new System.Drawing.Point(349, 67);
            this.tbxAnnee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxAnnee.MaxLength = 2;
            this.tbxAnnee.Name = "tbxAnnee";
            this.tbxAnnee.Size = new System.Drawing.Size(65, 31);
            this.tbxAnnee.TabIndex = 4;
            // 
            // cbxMois
            // 
            this.cbxMois.FormattingEnabled = true;
            this.cbxMois.Location = new System.Drawing.Point(93, 67);
            this.cbxMois.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMois.Name = "cbxMois";
            this.cbxMois.Size = new System.Drawing.Size(171, 33);
            this.cbxMois.TabIndex = 5;
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(29, 148);
            this.lbl_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(53, 25);
            this.lbl_total.TabIndex = 6;
            this.lbl_total.Text = "Total:";
            // 
            // lbl_a
            // 
            this.lbl_a.AutoSize = true;
            this.lbl_a.Location = new System.Drawing.Point(29, 198);
            this.lbl_a.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_a.Name = "lbl_a";
            this.lbl_a.Size = new System.Drawing.Size(28, 25);
            this.lbl_a.TabIndex = 7;
            this.lbl_a.Text = "A:";
            // 
            // lbl_b
            // 
            this.lbl_b.AutoSize = true;
            this.lbl_b.Location = new System.Drawing.Point(29, 253);
            this.lbl_b.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_b.Name = "lbl_b";
            this.lbl_b.Size = new System.Drawing.Size(26, 25);
            this.lbl_b.TabIndex = 8;
            this.lbl_b.Text = "B:";
            // 
            // lbl_c
            // 
            this.lbl_c.AutoSize = true;
            this.lbl_c.Location = new System.Drawing.Point(29, 308);
            this.lbl_c.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_c.Name = "lbl_c";
            this.lbl_c.Size = new System.Drawing.Size(27, 25);
            this.lbl_c.TabIndex = 9;
            this.lbl_c.Text = "C:";
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(69, 387);
            this.btn_valider.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(126, 45);
            this.btn_valider.TabIndex = 10;
            this.btn_valider.Text = "Sauvegarder";
            this.btn_valider.UseVisualStyleBackColor = true;
            // 
            // tbx_total
            // 
            this.tbx_total.Enabled = false;
            this.tbx_total.Location = new System.Drawing.Point(107, 143);
            this.tbx_total.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_total.Name = "tbx_total";
            this.tbx_total.Size = new System.Drawing.Size(87, 31);
            this.tbx_total.TabIndex = 11;
            // 
            // tbx_a
            // 
            this.tbx_a.Location = new System.Drawing.Point(107, 193);
            this.tbx_a.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_a.Name = "tbx_a";
            this.tbx_a.Size = new System.Drawing.Size(87, 31);
            this.tbx_a.TabIndex = 12;
            // 
            // tbx_b
            // 
            this.tbx_b.Location = new System.Drawing.Point(107, 248);
            this.tbx_b.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_b.Name = "tbx_b";
            this.tbx_b.Size = new System.Drawing.Size(87, 31);
            this.tbx_b.TabIndex = 13;
            // 
            // tbx_c
            // 
            this.tbx_c.Location = new System.Drawing.Point(107, 303);
            this.tbx_c.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbx_c.Name = "tbx_c";
            this.tbx_c.Size = new System.Drawing.Size(87, 31);
            this.tbx_c.TabIndex = 14;
            // 
            // generate_excel
            // 
            this.generate_excel.Location = new System.Drawing.Point(713, 18);
            this.generate_excel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.generate_excel.Name = "generate_excel";
            this.generate_excel.Size = new System.Drawing.Size(221, 37);
            this.generate_excel.TabIndex = 15;
            this.generate_excel.Text = "Générer le fichier Excel";
            this.generate_excel.UseVisualStyleBackColor = true;
            this.generate_excel.Click += new System.EventHandler(this.generate_excel_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(90, 13);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(284, 31);
            this.dtpDate.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Date";
            // 
            // btnImprimer
            // 
            this.btnImprimer.Location = new System.Drawing.Point(760, 90);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(107, 38);
            this.btnImprimer.TabIndex = 18;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = true;
            // 
            // saisie_classement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 467);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.generate_excel);
            this.Controls.Add(this.tbx_c);
            this.Controls.Add(this.tbx_b);
            this.Controls.Add(this.tbx_a);
            this.Controls.Add(this.tbx_total);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.lbl_c);
            this.Controls.Add(this.lbl_b);
            this.Controls.Add(this.lbl_a);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.cbxMois);
            this.Controls.Add(this.tbxAnnee);
            this.Controls.Add(this.labelMois);
            this.Controls.Add(this.labelAnnee);
            this.Controls.Add(this.buttonGenerer);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "saisie_classement";
            this.Text = "Saisie classement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button btnImprimer;
    }
}