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
            saisieAcompteToolStripMenuItem = new ToolStripMenuItem();
            saisieRappelToolStripMenuItem = new ToolStripMenuItem();
            éditionToolStripMenuItem = new ToolStripMenuItem();
            saisiePeséesToolStripMenuItem = new ToolStripMenuItem();
            outilsToolStripMenuItem = new ToolStripMenuItem();
            calculatriceToolStripMenuItem = new ToolStripMenuItem();
            testVBNetToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichiersToolStripMenuItem, éditionToolStripMenuItem, outilsToolStripMenuItem, testVBNetToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1671, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            fichiersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, articlesToolStripMenuItem, tarifsToolStripMenuItem, lieuxDeLivraisonToolStripMenuItem, fromageriesToolStripMenuItem, lotsToolStripMenuItem, imprimantesToolStripMenuItem, saisieAcompteToolStripMenuItem, saisieRappelToolStripMenuItem });
            fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            fichiersToolStripMenuItem.Size = new Size(59, 20);
            fichiersToolStripMenuItem.Text = "Fichiers";
            fichiersToolStripMenuItem.Click += fichiersToolStripMenuItem_Click;
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(180, 22);
            clientsToolStripMenuItem.Text = "Clients";
            clientsToolStripMenuItem.Click += clientsToolStripMenuItem_Click;
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
            fromageriesToolStripMenuItem.Click += fromageriesToolStripMenuItem_Click;
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
            classementToolStripMenuItem.Click += classementToolStripMenuItem_Click;
            // 
            // imprimantesToolStripMenuItem
            // 
            imprimantesToolStripMenuItem.Name = "imprimantesToolStripMenuItem";
            imprimantesToolStripMenuItem.Size = new Size(180, 22);
            imprimantesToolStripMenuItem.Text = "Imprimantes";
            imprimantesToolStripMenuItem.Click += imprimantesToolStripMenuItem_Click;
            // 
            // saisieAcompteToolStripMenuItem
            // 
            saisieAcompteToolStripMenuItem.Name = "saisieAcompteToolStripMenuItem";
            saisieAcompteToolStripMenuItem.Size = new Size(180, 22);
            saisieAcompteToolStripMenuItem.Text = "Saisie Acompte";
            saisieAcompteToolStripMenuItem.Click += saisieAcompteToolStripMenuItem_Click;
            // 
            // saisieRappelToolStripMenuItem
            // 
            saisieRappelToolStripMenuItem.Name = "saisieRappelToolStripMenuItem";
            saisieRappelToolStripMenuItem.Size = new Size(180, 22);
            saisieRappelToolStripMenuItem.Text = "Saisie Rappel";
            saisieRappelToolStripMenuItem.Click += saisieRappelToolStripMenuItem_Click;
            // 
            // éditionToolStripMenuItem
            // 
            éditionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saisiePeséesToolStripMenuItem });
            éditionToolStripMenuItem.Name = "éditionToolStripMenuItem";
            éditionToolStripMenuItem.Size = new Size(56, 20);
            éditionToolStripMenuItem.Text = "Édition";
            // 
            // saisiePeséesToolStripMenuItem
            // 
            saisiePeséesToolStripMenuItem.Name = "saisiePeséesToolStripMenuItem";
            saisiePeséesToolStripMenuItem.Size = new Size(141, 22);
            saisiePeséesToolStripMenuItem.Text = "Saisie pesées";
            saisiePeséesToolStripMenuItem.Click += saisiePeséesToolStripMenuItem_Click;
            // 
            // outilsToolStripMenuItem
            // 
            outilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculatriceToolStripMenuItem });
            outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            outilsToolStripMenuItem.Size = new Size(50, 20);
            outilsToolStripMenuItem.Text = "Outils";
            // 
            // calculatriceToolStripMenuItem
            // 
            calculatriceToolStripMenuItem.Name = "calculatriceToolStripMenuItem";
            calculatriceToolStripMenuItem.Size = new Size(136, 22);
            calculatriceToolStripMenuItem.Text = "Calculatrice";
            calculatriceToolStripMenuItem.Click += calculatriceToolStripMenuItem_Click;
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
        private ToolStripMenuItem éditionToolStripMenuItem;
        private ToolStripMenuItem saisiePeséesToolStripMenuItem;
        private ToolStripMenuItem outilsToolStripMenuItem;
        private ToolStripMenuItem calculatriceToolStripMenuItem;
        private ToolStripMenuItem saisieAcompteToolStripMenuItem;
        private ToolStripMenuItem saisieRappelToolStripMenuItem;
        private ToolStripMenuItem testVBNetToolStripMenuItem;
    }
}