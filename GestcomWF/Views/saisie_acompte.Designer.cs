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
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_annee
            // 
            lbl_annee.AutoSize = true;
            lbl_annee.Location = new System.Drawing.Point(284, 50);
            lbl_annee.Name = "lbl_annee";
            lbl_annee.Size = new System.Drawing.Size(58, 20);
            lbl_annee.TabIndex = 0;
            lbl_annee.Text = "Année :";
            // 
            // lbl_mois
            // 
            lbl_mois.AutoSize = true;
            lbl_mois.Location = new System.Drawing.Point(42, 50);
            lbl_mois.Name = "lbl_mois";
            lbl_mois.Size = new System.Drawing.Size(48, 20);
            lbl_mois.TabIndex = 1;
            lbl_mois.Text = "Mois :";
            // 
            // tbx_annee
            // 
            tbx_annee.Location = new System.Drawing.Point(348, 46);
            tbx_annee.Name = "tbx_annee";
            tbx_annee.Size = new System.Drawing.Size(125, 27);
            tbx_annee.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(312, 130);
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
            lbl_prix.Location = new System.Drawing.Point(50, 130);
            lbl_prix.Name = "lbl_prix";
            lbl_prix.Size = new System.Drawing.Size(40, 20);
            lbl_prix.TabIndex = 5;
            lbl_prix.Text = "Prix :";
            // 
            // tbx_prix
            // 
            tbx_prix.Location = new System.Drawing.Point(107, 130);
            tbx_prix.Name = "tbx_prix";
            tbx_prix.Size = new System.Drawing.Size(125, 27);
            tbx_prix.TabIndex = 6;
            // 
            // btn_valider
            // 
            btn_valider.Location = new System.Drawing.Point(138, 184);
            btn_valider.Name = "btn_valider";
            btn_valider.Size = new System.Drawing.Size(94, 29);
            btn_valider.TabIndex = 7;
            btn_valider.Text = "Valider";
            btn_valider.UseVisualStyleBackColor = true;
            btn_valider.Click += btn_valider_Click;
            // 
            // btn_valider_dg
            // 
            btn_valider_dg.Location = new System.Drawing.Point(493, 46);
            btn_valider_dg.Name = "btn_valider_dg";
            btn_valider_dg.Size = new System.Drawing.Size(94, 29);
            btn_valider_dg.TabIndex = 8;
            btn_valider_dg.Text = "Valider";
            btn_valider_dg.UseVisualStyleBackColor = true;
            btn_valider_dg.Click += btn_valider_dg_Click;
            // 
            // cbxMois
            // 
            cbxMois.FormattingEnabled = true;
            cbxMois.Location = new System.Drawing.Point(107, 46);
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
            // saisie_acompte
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
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
    }
}