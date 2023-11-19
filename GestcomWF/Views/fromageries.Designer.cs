namespace GestcomWF.Views
{
    partial class fromageries
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
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnAjouter = new Button();
            btnActif = new CheckBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnModifier
            // 
            btnModifier.Location = new System.Drawing.Point(688, 63);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new System.Drawing.Size(75, 23);
            btnModifier.TabIndex = 1;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new System.Drawing.Point(688, 92);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new System.Drawing.Size(75, 23);
            btnSupprimer.TabIndex = 2;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new System.Drawing.Point(688, 34);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new System.Drawing.Size(75, 23);
            btnAjouter.TabIndex = 3;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            // 
            // btnActif
            // 
            btnActif.AutoSize = true;
            btnActif.Location = new System.Drawing.Point(656, 134);
            btnActif.Name = "btnActif";
            btnActif.Size = new System.Drawing.Size(89, 19);
            btnActif.TabIndex = 4;
            btnActif.Text = "Rendre actif";
            btnActif.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new System.Drawing.Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(614, 199);
            listBox1.TabIndex = 5;
            // 
            // fromageries
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(btnActif);
            Controls.Add(btnAjouter);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Name = "fromageries";
            Text = "fromageries";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnAjouter;
        private CheckBox btnActif;
        private ListBox listBox1;
    }
}