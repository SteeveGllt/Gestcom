﻿using System.Windows.Forms;

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
            btnImprimer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_annee
            // 
            lbl_annee.AutoSize = true;
            lbl_annee.Location = new System.Drawing.Point(256, 54);
            lbl_annee.Name = "lbl_annee";
            lbl_annee.Size = new System.Drawing.Size(47, 15);
            lbl_annee.TabIndex = 0;
            lbl_annee.Text = "Année :";
            // 
            // lbl_mois
            // 
            lbl_mois.AutoSize = true;
            lbl_mois.Location = new System.Drawing.Point(46, 54);
            lbl_mois.Name = "lbl_mois";
            lbl_mois.Size = new System.Drawing.Size(39, 15);
            lbl_mois.TabIndex = 1;
            lbl_mois.Text = "Mois :";
            // 
            // tbx_annee
            // 
            tbx_annee.Location = new System.Drawing.Point(312, 50);
            tbx_annee.Margin = new Padding(3, 2, 3, 2);
            tbx_annee.Name = "tbx_annee";
            tbx_annee.Size = new System.Drawing.Size(49, 23);
            tbx_annee.TabIndex = 2;
            tbx_annee.KeyDown += tbx_annee_KeyDown;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(273, 98);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new System.Drawing.Size(384, 206);
            dataGridView.TabIndex = 4;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick_1;
            // 
            // lbl_prix
            // 
            lbl_prix.AutoSize = true;
            lbl_prix.Location = new System.Drawing.Point(46, 120);
            lbl_prix.Name = "lbl_prix";
            lbl_prix.Size = new System.Drawing.Size(33, 15);
            lbl_prix.TabIndex = 5;
            lbl_prix.Text = "Prix :";
            // 
            // tbx_prix
            // 
            tbx_prix.Location = new System.Drawing.Point(102, 118);
            tbx_prix.Margin = new Padding(3, 2, 3, 2);
            tbx_prix.Name = "tbx_prix";
            tbx_prix.Size = new System.Drawing.Size(110, 23);
            tbx_prix.TabIndex = 6;
            tbx_prix.KeyDown += tbx_prix_KeyDown;
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(87, 163);
            btn_valider.Margin = new Padding(3, 2, 3, 2);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(97, 22);
            btn_valider.TabIndex = 7;
            btn_valider.Text = "Sauvegarder";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btn_valider_Click;
            // 
            // btn_valider_dg
            // 
            btn_valider_dg.Location = new System.Drawing.Point(444, 48);
            btn_valider_dg.Margin = new Padding(3, 2, 3, 2);
            btn_valider_dg.Name = "btn_valider_dg";
            btn_valider_dg.Size = new System.Drawing.Size(82, 22);
            btn_valider_dg.TabIndex = 8;
            btn_valider_dg.Text = "Afficher";
            btn_valider_dg.UseVisualStyleBackColor = true;
            btn_valider_dg.Click += btn_valider_dg_Click;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(102, 50);
            cbxMois.Margin = new Padding(3, 2, 3, 2);
            cbxMois.Name = "cbxMois";
            cbxMois.Size = new System.Drawing.Size(133, 23);
            cbxMois.TabIndex = 9;
            cbxMois.SelectedIndexChanged += cbxMois_SelectedIndexChanged;
            // 
            // checkBoxUpdateAll
            // 
            checkBoxUpdateAll.AutoSize = true;
            checkBoxUpdateAll.Location = new System.Drawing.Point(18, 201);
            checkBoxUpdateAll.Margin = new Padding(3, 2, 3, 2);
            checkBoxUpdateAll.Name = "checkBoxUpdateAll";
            checkBoxUpdateAll.Size = new System.Drawing.Size(89, 19);
            checkBoxUpdateAll.TabIndex = 10;
            checkBoxUpdateAll.Text = "Tous les lots";
            checkBoxUpdateAll.UseVisualStyleBackColor = true;
            checkBoxUpdateAll.CheckedChanged += checkBoxUpdateAll_CheckedChanged;
            // 
            // generate_excel
            // 
            generate_excel.Location = new System.Drawing.Point(468, 11);
            generate_excel.Name = "generate_excel";
            generate_excel.Size = new System.Drawing.Size(139, 23);
            generate_excel.TabIndex = 11;
            generate_excel.Text = "Générer le fichier Excel";
            generate_excel.UseVisualStyleBackColor = true;
            generate_excel.Click += generate_excel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(46, 86);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(128, 15);
            label1.TabIndex = 12;
            label1.Text = "Numéro de fromagerie";
            // 
            // tbxNumFromagerie
            // 
            tbxNumFromagerie.Enabled = false;
            tbxNumFromagerie.Location = new System.Drawing.Point(197, 84);
            tbxNumFromagerie.Name = "tbxNumFromagerie";
            tbxNumFromagerie.Size = new System.Drawing.Size(38, 23);
            tbxNumFromagerie.TabIndex = 13;
            // 
            // dtpAcompte
            // 
            dtpAcompte.Location = new System.Drawing.Point(87, 15);
            dtpAcompte.Name = "dtpAcompte";
            dtpAcompte.Size = new System.Drawing.Size(200, 23);
            dtpAcompte.TabIndex = 14;
            dtpAcompte.ValueChanged += dtpAcompte_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(46, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 15;
            label2.Text = "Date";
            // 
            // btnImprimer
            // 
            btnImprimer.Location = new System.Drawing.Point(613, 11);
            btnImprimer.Name = "btnImprimer";
            btnImprimer.Size = new System.Drawing.Size(75, 23);
            btnImprimer.TabIndex = 16;
            btnImprimer.Text = "Impression";
            btnImprimer.UseVisualStyleBackColor = true;
            btnImprimer.Click += btnImprimer_Click;
            // 
            // saisie_acompte
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 338);
            Controls.Add(btnImprimer);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnImprimer;
    }
}