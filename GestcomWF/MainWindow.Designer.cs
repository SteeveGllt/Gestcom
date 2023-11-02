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
            éditionToolStripMenuItem = new ToolStripMenuItem();
            saisiePeséesToolStripMenuItem = new ToolStripMenuItem();
            outilsToolStripMenuItem = new ToolStripMenuItem();
            calculatriceToolStripMenuItem = new ToolStripMenuItem();
            saisieRappelToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichiersToolStripMenuItem, éditionToolStripMenuItem, outilsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1910, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            fichiersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientsToolStripMenuItem, articlesToolStripMenuItem, tarifsToolStripMenuItem, lieuxDeLivraisonToolStripMenuItem, fromageriesToolStripMenuItem, lotsToolStripMenuItem, imprimantesToolStripMenuItem, saisieAcompteToolStripMenuItem, saisieRappelToolStripMenuItem });
            fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            fichiersToolStripMenuItem.Size = new Size(72, 24);
            fichiersToolStripMenuItem.Text = "Fichiers";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(224, 26);
            clientsToolStripMenuItem.Text = "Clients";
            // 
            // articlesToolStripMenuItem
            // 
            articlesToolStripMenuItem.Name = "articlesToolStripMenuItem";
            articlesToolStripMenuItem.Size = new Size(224, 26);
            articlesToolStripMenuItem.Text = "Articles";
            // 
            // tarifsToolStripMenuItem
            // 
            tarifsToolStripMenuItem.Name = "tarifsToolStripMenuItem";
            tarifsToolStripMenuItem.Size = new Size(224, 26);
            tarifsToolStripMenuItem.Text = "Tarifs";
            // 
            // lieuxDeLivraisonToolStripMenuItem
            // 
            lieuxDeLivraisonToolStripMenuItem.Name = "lieuxDeLivraisonToolStripMenuItem";
            lieuxDeLivraisonToolStripMenuItem.Size = new Size(224, 26);
            lieuxDeLivraisonToolStripMenuItem.Text = "Lieux de Livraison";
            // 
            // fromageriesToolStripMenuItem
            // 
            fromageriesToolStripMenuItem.Name = "fromageriesToolStripMenuItem";
            fromageriesToolStripMenuItem.Size = new Size(224, 26);
            fromageriesToolStripMenuItem.Text = "Fromageries";
            // 
            // lotsToolStripMenuItem
            // 
            lotsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entréeToolStripMenuItem, classementToolStripMenuItem });
            lotsToolStripMenuItem.Name = "lotsToolStripMenuItem";
            lotsToolStripMenuItem.Size = new Size(224, 26);
            lotsToolStripMenuItem.Text = "Lots";
            // 
            // entréeToolStripMenuItem
            // 
            entréeToolStripMenuItem.Name = "entréeToolStripMenuItem";
            entréeToolStripMenuItem.Size = new Size(167, 26);
            entréeToolStripMenuItem.Text = "Entrée";
            entréeToolStripMenuItem.Click += entréeToolStripMenuItem_Click;
            // 
            // classementToolStripMenuItem
            // 
            classementToolStripMenuItem.Name = "classementToolStripMenuItem";
            classementToolStripMenuItem.Size = new Size(167, 26);
            classementToolStripMenuItem.Text = "Classement";
            classementToolStripMenuItem.Click += classementToolStripMenuItem_Click;
            // 
            // imprimantesToolStripMenuItem
            // 
            imprimantesToolStripMenuItem.Name = "imprimantesToolStripMenuItem";
            imprimantesToolStripMenuItem.Size = new Size(224, 26);
            imprimantesToolStripMenuItem.Text = "Imprimantes";
            imprimantesToolStripMenuItem.Click += imprimantesToolStripMenuItem_Click;
            // 
            // saisieAcompteToolStripMenuItem
            // 
            saisieAcompteToolStripMenuItem.Name = "saisieAcompteToolStripMenuItem";
            saisieAcompteToolStripMenuItem.Size = new Size(224, 26);
            saisieAcompteToolStripMenuItem.Text = "Saisie Acompte";
            saisieAcompteToolStripMenuItem.Click += saisieAcompteToolStripMenuItem_Click;
            // 
            // éditionToolStripMenuItem
            // 
            éditionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saisiePeséesToolStripMenuItem });
            éditionToolStripMenuItem.Name = "éditionToolStripMenuItem";
            éditionToolStripMenuItem.Size = new Size(70, 24);
            éditionToolStripMenuItem.Text = "Édition";
            // 
            // saisiePeséesToolStripMenuItem
            // 
            saisiePeséesToolStripMenuItem.Name = "saisiePeséesToolStripMenuItem";
            saisiePeséesToolStripMenuItem.Size = new Size(179, 26);
            saisiePeséesToolStripMenuItem.Text = "Saisie pesées";
            saisiePeséesToolStripMenuItem.Click += saisiePeséesToolStripMenuItem_Click;
            // 
            // outilsToolStripMenuItem
            // 
            outilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculatriceToolStripMenuItem });
            outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            outilsToolStripMenuItem.Size = new Size(61, 24);
            outilsToolStripMenuItem.Text = "Outils";
            // 
            // calculatriceToolStripMenuItem
            // 
            calculatriceToolStripMenuItem.Name = "calculatriceToolStripMenuItem";
            calculatriceToolStripMenuItem.Size = new Size(169, 26);
            calculatriceToolStripMenuItem.Text = "Calculatrice";
            calculatriceToolStripMenuItem.Click += calculatriceToolStripMenuItem_Click;
            // 
            // saisieRappelToolStripMenuItem
            // 
            saisieRappelToolStripMenuItem.Name = "saisieRappelToolStripMenuItem";
            saisieRappelToolStripMenuItem.Size = new Size(224, 26);
            saisieRappelToolStripMenuItem.Text = "Saisie Rappel";
            saisieRappelToolStripMenuItem.Click += saisieRappelToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1910, 916);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
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
    }
}