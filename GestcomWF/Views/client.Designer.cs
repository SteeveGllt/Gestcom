using System.Windows.Forms;

namespace GestcomWF.Views
{
    partial class client
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

        private void InitializeComponent()
        {
            listView1 = new ListView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbxAdresse2 = new TextBox();
            tbxVille = new TextBox();
            tbxCp = new TextBox();
            tbxAdresse1 = new TextBox();
            tbxMtdi = new TextBox();
            tbxNom = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            tbxDom = new TextBox();
            label12 = new Label();
            tbxRib = new TextBox();
            label11 = new Label();
            tbxCompte = new TextBox();
            label10 = new Label();
            tbxGui = new TextBox();
            label9 = new Label();
            tbxBanque = new TextBox();
            label8 = new Label();
            tabPage3 = new TabPage();
            btnCreate = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(218, 435);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(250, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(388, 435);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbxAdresse2);
            tabPage1.Controls.Add(tbxVille);
            tabPage1.Controls.Add(tbxCp);
            tabPage1.Controls.Add(tbxAdresse1);
            tabPage1.Controls.Add(tbxMtdi);
            tabPage1.Controls.Add(tbxNom);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(380, 407);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Informations générales";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxAdresse2
            // 
            tbxAdresse2.Location = new System.Drawing.Point(6, 128);
            tbxAdresse2.Name = "tbxAdresse2";
            tbxAdresse2.Size = new System.Drawing.Size(136, 23);
            tbxAdresse2.TabIndex = 12;
            // 
            // tbxVille
            // 
            tbxVille.Location = new System.Drawing.Point(250, 84);
            tbxVille.Name = "tbxVille";
            tbxVille.Size = new System.Drawing.Size(124, 23);
            tbxVille.TabIndex = 11;
            // 
            // tbxCp
            // 
            tbxCp.Location = new System.Drawing.Point(152, 85);
            tbxCp.Name = "tbxCp";
            tbxCp.Size = new System.Drawing.Size(89, 23);
            tbxCp.TabIndex = 10;
            // 
            // tbxAdresse1
            // 
            tbxAdresse1.Location = new System.Drawing.Point(6, 84);
            tbxAdresse1.Name = "tbxAdresse1";
            tbxAdresse1.Size = new System.Drawing.Size(136, 23);
            tbxAdresse1.TabIndex = 9;
            // 
            // tbxMtdi
            // 
            tbxMtdi.Location = new System.Drawing.Point(122, 26);
            tbxMtdi.Name = "tbxMtdi";
            tbxMtdi.Size = new System.Drawing.Size(100, 23);
            tbxMtdi.TabIndex = 8;
            // 
            // tbxNom
            // 
            tbxNom.Location = new System.Drawing.Point(6, 26);
            tbxNom.Name = "tbxNom";
            tbxNom.Size = new System.Drawing.Size(100, 23);
            tbxNom.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 110);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 15);
            label7.TabIndex = 6;
            label7.Text = "Adresse 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(250, 67);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 15);
            label6.TabIndex = 5;
            label6.Text = "Ville";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(152, 67);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(70, 15);
            label5.TabIndex = 4;
            label5.Text = "Code postal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 67);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 3;
            label4.Text = "Adresse 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(120, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 15);
            label3.TabIndex = 2;
            label3.Text = "MTDI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Nom";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 23);
            label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tbxDom);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(tbxRib);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(tbxCompte);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(tbxGui);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(tbxBanque);
            tabPage2.Controls.Add(label8);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(380, 407);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Banque";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbxDom
            // 
            tbxDom.Location = new System.Drawing.Point(9, 145);
            tbxDom.Name = "tbxDom";
            tbxDom.Size = new System.Drawing.Size(100, 23);
            tbxDom.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 127);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 15);
            label12.TabIndex = 9;
            label12.Text = "DOM";
            // 
            // tbxRib
            // 
            tbxRib.Location = new System.Drawing.Point(185, 78);
            tbxRib.Name = "tbxRib";
            tbxRib.Size = new System.Drawing.Size(58, 23);
            tbxRib.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(185, 60);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(24, 15);
            label11.TabIndex = 7;
            label11.Text = "RIB";
            // 
            // tbxCompte
            // 
            tbxCompte.Location = new System.Drawing.Point(9, 78);
            tbxCompte.Name = "tbxCompte";
            tbxCompte.Size = new System.Drawing.Size(155, 23);
            tbxCompte.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(9, 60);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(50, 15);
            label10.TabIndex = 5;
            label10.Text = "Compte";
            // 
            // tbxGui
            // 
            tbxGui.Location = new System.Drawing.Point(126, 21);
            tbxGui.Name = "tbxGui";
            tbxGui.Size = new System.Drawing.Size(82, 23);
            tbxGui.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(126, 3);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(26, 15);
            label9.TabIndex = 3;
            label9.Text = "GUI";
            // 
            // tbxBanque
            // 
            tbxBanque.Location = new System.Drawing.Point(9, 21);
            tbxBanque.Name = "tbxBanque";
            tbxBanque.Size = new System.Drawing.Size(100, 23);
            tbxBanque.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 3);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(47, 15);
            label8.TabIndex = 0;
            label8.Text = "Banque";
            // 
            // tabPage3
            // 
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new System.Drawing.Size(380, 407);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new System.Drawing.Point(559, 453);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(75, 23);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Créer";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // client
            // 
            ClientSize = new System.Drawing.Size(650, 481);
            Controls.Add(btnCreate);
            Controls.Add(tabControl1);
            Controls.Add(listView1);
            Name = "client";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        private void LayoutControls()
        {
            // Set the size and position of each control
            // You'll need to set these properties according to your design requirements
        }


        #endregion
        private ListView listView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox tbxAdresse2;
        private TextBox tbxVille;
        private TextBox tbxCp;
        private TextBox tbxAdresse1;
        private TextBox tbxMtdi;
        private TextBox tbxNom;
        private TextBox tbxBanque;
        private Label label8;
        private TextBox tbxDom;
        private Label label12;
        private TextBox tbxRib;
        private Label label11;
        private TextBox tbxCompte;
        private Label label10;
        private TextBox tbxGui;
        private Label label9;
        private TabPage tabPage3;
        private Button btnCreate;
    }
}