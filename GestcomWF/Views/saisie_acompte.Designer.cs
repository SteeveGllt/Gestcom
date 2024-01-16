using System.Windows.Forms;

namespace GestcomWF.Views
{
    partial class saisie_acompte
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
            lbl_annee = new Label();
            lbl_mois = new Label();
            tbx_annee = new TextBox();
            dataGridView = new DataGridView();
            lbl_prix = new Label();
            tbx_prix = new TextBox();
            btn_valider = new Button();
            btn_valider_dg = new Button();
            cbxMois = new ComboBox();
            checkBoxUpdateAll = new CheckBox();
            generate_excel = new Button();
            label1 = new Label();
            tbxNumFromagerie = new TextBox();
            dtpAcompte = new DateTimePicker();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_annee
            // 
            lbl_annee.AutoSize = true;
            lbl_annee.Location = new System.Drawing.Point(293, 72);
            lbl_annee.Name = "lbl_annee";
            lbl_annee.Size = new System.Drawing.Size(58, 20);
            lbl_annee.TabIndex = 0;
            lbl_annee.Text = "Année :";
            // 
            // lbl_mois
            // 
            lbl_mois.AutoSize = true;
            lbl_mois.Location = new System.Drawing.Point(52, 72);
            lbl_mois.Name = "lbl_mois";
            lbl_mois.Size = new System.Drawing.Size(48, 20);
            lbl_mois.TabIndex = 1;
            lbl_mois.Text = "Mois :";
            // 
            // tbx_annee
            // 
            tbx_annee.Location = new System.Drawing.Point(357, 66);
            tbx_annee.Name = "tbx_annee";
            tbx_annee.Size = new System.Drawing.Size(55, 27);
            tbx_annee.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(312, 131);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new System.Drawing.Size(439, 275);
            dataGridView.TabIndex = 4;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick_1;
            // 
            // lbl_prix
            // 
            lbl_prix.AutoSize = true;
            lbl_prix.Location = new System.Drawing.Point(52, 160);
            lbl_prix.Name = "lbl_prix";
            lbl_prix.Size = new System.Drawing.Size(40, 20);
            lbl_prix.TabIndex = 5;
            lbl_prix.Text = "Prix :";
            // 
            // tbx_prix
            // 
            tbx_prix.Location = new System.Drawing.Point(117, 157);
            tbx_prix.Name = "tbx_prix";
            tbx_prix.Size = new System.Drawing.Size(125, 27);
            tbx_prix.TabIndex = 6;
            tbx_prix.KeyDown += tbx_prix_KeyDown;
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(99, 217);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(111, 29);
            btn_valider.TabIndex = 7;
            btn_valider.Text = "Sauvegarder";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btn_valider_Click;
            // 
            // btn_valider_dg
            // 
            btn_valider_dg.Location = new System.Drawing.Point(507, 64);
            btn_valider_dg.Name = "btn_valider_dg";
            btn_valider_dg.Size = new System.Drawing.Size(94, 29);
            btn_valider_dg.TabIndex = 8;
            btn_valider_dg.Text = "Afficher";
            btn_valider_dg.UseVisualStyleBackColor = true;
            btn_valider_dg.Click += btn_valider_dg_Click;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(117, 66);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(151, 28);
            cbxMois.TabIndex = 9;
            // 
            // checkBoxUpdateAll
            // 
            checkBoxUpdateAll.AutoSize = true;
            checkBoxUpdateAll.Location = new System.Drawing.Point(21, 268);
            checkBoxUpdateAll.Name = "checkBoxUpdateAll";
            checkBoxUpdateAll.Size = new System.Drawing.Size(111, 24);
            checkBoxUpdateAll.TabIndex = 10;
            checkBoxUpdateAll.Text = "Tous les lots";
            checkBoxUpdateAll.UseVisualStyleBackColor = true;
            checkBoxUpdateAll.CheckedChanged += checkBoxUpdateAll_CheckedChanged;
            // 
            // generate_excel
            // 
            generate_excel.Location = new System.Drawing.Point(627, 16);
            generate_excel.Margin = new Padding(3, 4, 3, 4);
            generate_excel.Name = "generate_excel";
            generate_excel.Size = new System.Drawing.Size(159, 31);
            generate_excel.TabIndex = 11;
            generate_excel.Text = "Générer le fichier Excel";
            generate_excel.UseVisualStyleBackColor = true;
            generate_excel.Click += generate_excel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(52, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(162, 20);
            label1.TabIndex = 12;
            label1.Text = "Numéro de fromagerie";
            // 
            // tbxNumFromagerie
            // 
            tbxNumFromagerie.Enabled = false;
            tbxNumFromagerie.Location = new System.Drawing.Point(225, 112);
            tbxNumFromagerie.Margin = new Padding(3, 4, 3, 4);
            tbxNumFromagerie.Name = "tbxNumFromagerie";
            tbxNumFromagerie.Size = new System.Drawing.Size(43, 27);
            tbxNumFromagerie.TabIndex = 13;
            // 
            // dtpAcompte
            // 
            dtpAcompte.Location = new System.Drawing.Point(99, 20);
            dtpAcompte.Margin = new Padding(3, 4, 3, 4);
            dtpAcompte.Name = "dtpAcompte";
            dtpAcompte.Size = new System.Drawing.Size(228, 27);
            dtpAcompte.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(52, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 20);
            label2.TabIndex = 15;
            label2.Text = "Date";
            // 
            // saisie_acompte
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 451);
            Controls.Add(label2);
            Controls.Add(dtpAcompte);
            Controls.Add(tbxNumFromagerie);
            Controls.Add(label1);
            Controls.Add(generate_excel);
            Controls.Add(checkBoxUpdateAll);
            Controls.Add(cbxMois);
            Controls.Add(btn_valider_dg);
            Controls.Add(btn_valider);
            Controls.Add(tbx_prix);
            Controls.Add(lbl_prix);
            Controls.Add(dataGridView);
            Controls.Add(tbx_annee);
            Controls.Add(lbl_mois);
            Controls.Add(lbl_annee);
            Name = "saisie_acompte";
            Text = "saisie_acompte";
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
                DataPropertyName = "LOPUAC",
                HeaderText = "PRIX"
            });
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        #endregion

        private Label lbl_annee;
        private Label lbl_mois;
        private TextBox tbx_annee;
        private DataGridView dataGridView;
        private Label lbl_prix;
        private TextBox tbx_prix;
        private Button btn_valider;
        private Button btn_valider_dg;
        private ComboBox cbxMois;
        private CheckBox checkBoxUpdateAll;
        private Button generate_excel;
        private Label label1;
        private TextBox tbxNumFromagerie;
        private DateTimePicker dtpAcompte;
        private Label label2;
    }
}