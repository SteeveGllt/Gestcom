using System.Drawing;
using Size = System.Drawing.Size;

namespace GestcomWF
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fichiersToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            articlesToolStripMenuItem = new ToolStripMenuItem();
            tarifsToolStripMenuItem = new ToolStripMenuItem();
            lieuxDeLivraisonToolStripMenuItem = new ToolStripMenuItem();
            fromageriesToolStripMenuItem = new ToolStripMenuItem();
            lotsToolStripMenuItem = new ToolStripMenuItem();
            entréeToolStripMenuItem = new ToolStripMenuItem();
            classementToolStripMenuItem = new ToolStripMenuItem();
            imprimantesToolStripMenuItem = new ToolStripMenuItem();
            editPeséeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichiersToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1671, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            fichiersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, articlesToolStripMenuItem, tarifsToolStripMenuItem, lieuxDeLivraisonToolStripMenuItem, fromageriesToolStripMenuItem, lotsToolStripMenuItem, imprimantesToolStripMenuItem, editPeséeToolStripMenuItem });
            fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            fichiersToolStripMenuItem.Size = new Size(59, 20);
            fichiersToolStripMenuItem.Text = "Fichiers";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(180, 22);
            clientsToolStripMenuItem.Text = "Clients";
            // 
            // articlesToolStripMenuItem
            // 
            articlesToolStripMenuItem.Name = "articlesToolStripMenuItem";
            articlesToolStripMenuItem.Size = new Size(180, 22);
            articlesToolStripMenuItem.Text = "Articles";
            // 
            // tarifsToolStripMenuItem
            // 
            tarifsToolStripMenuItem.Name = "tarifsToolStripMenuItem";
            tarifsToolStripMenuItem.Size = new Size(180, 22);
            tarifsToolStripMenuItem.Text = "Tarifs";
            // 
            // lieuxDeLivraisonToolStripMenuItem
            // 
            lieuxDeLivraisonToolStripMenuItem.Name = "lieuxDeLivraisonToolStripMenuItem";
            lieuxDeLivraisonToolStripMenuItem.Size = new Size(180, 22);
            lieuxDeLivraisonToolStripMenuItem.Text = "Lieux de Livraison";
            // 
            // fromageriesToolStripMenuItem
            // 
            fromageriesToolStripMenuItem.Name = "fromageriesToolStripMenuItem";
            fromageriesToolStripMenuItem.Size = new Size(180, 22);
            fromageriesToolStripMenuItem.Text = "Fromageries";
            // 
            // lotsToolStripMenuItem
            // 
            lotsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entréeToolStripMenuItem, classementToolStripMenuItem });
            lotsToolStripMenuItem.Name = "lotsToolStripMenuItem";
            lotsToolStripMenuItem.Size = new Size(180, 22);
            lotsToolStripMenuItem.Text = "Lots";
            // 
            // entréeToolStripMenuItem
            // 
            entréeToolStripMenuItem.Name = "entréeToolStripMenuItem";
            entréeToolStripMenuItem.Size = new Size(135, 22);
            entréeToolStripMenuItem.Text = "Entrée";
            entréeToolStripMenuItem.Click += entréeToolStripMenuItem_Click;
            // 
            // classementToolStripMenuItem
            // 
            classementToolStripMenuItem.Name = "classementToolStripMenuItem";
            classementToolStripMenuItem.Size = new Size(135, 22);
            classementToolStripMenuItem.Text = "Classement";
            // 
            // imprimantesToolStripMenuItem
            // 
            imprimantesToolStripMenuItem.Name = "imprimantesToolStripMenuItem";
            imprimantesToolStripMenuItem.Size = new Size(180, 22);
            imprimantesToolStripMenuItem.Text = "Imprimantes";
            imprimantesToolStripMenuItem.Click += imprimantesToolStripMenuItem_Click;
            // 
            // editPeséeToolStripMenuItem
            // 
            editPeséeToolStripMenuItem.Name = "editPeséeToolStripMenuItem";
            editPeséeToolStripMenuItem.Size = new Size(180, 22);
            editPeséeToolStripMenuItem.Text = "Edit Pesée";
            editPeséeToolStripMenuItem.Click += editPeséeToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1671, 687);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Gestcom";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichiersToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem articlesToolStripMenuItem;
        private ToolStripMenuItem tarifsToolStripMenuItem;
        private ToolStripMenuItem lieuxDeLivraisonToolStripMenuItem;
        private ToolStripMenuItem fromageriesToolStripMenuItem;
        private ToolStripMenuItem lotsToolStripMenuItem;
        private ToolStripMenuItem entréeToolStripMenuItem;
        private ToolStripMenuItem classementToolStripMenuItem;
        private ToolStripMenuItem imprimantesToolStripMenuItem;
        private ToolStripMenuItem editPeséeToolStripMenuItem;
    }
}