﻿namespace Shogi
{
    partial class ShogiSpielfeld
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benutzernamenÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwortÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontoLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spielBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.statisikToolStripMenuItem,
            this.toolStripMenuItem3,
            this.spielSpeichernToolStripMenuItem,
            this.spielLadenToolStripMenuItem,
            this.spielBeendenToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.benutzernamenÄndernToolStripMenuItem,
            this.passwortÄndernToolStripMenuItem,
            this.kontoLöschenToolStripMenuItem});
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // benutzernamenÄndernToolStripMenuItem
            // 
            this.benutzernamenÄndernToolStripMenuItem.Name = "benutzernamenÄndernToolStripMenuItem";
            this.benutzernamenÄndernToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.benutzernamenÄndernToolStripMenuItem.Text = "Benutzernamen ändern";
            this.benutzernamenÄndernToolStripMenuItem.Click += new System.EventHandler(this.benutzernamenÄndernToolStripMenuItem_Click);
            // 
            // passwortÄndernToolStripMenuItem
            // 
            this.passwortÄndernToolStripMenuItem.Name = "passwortÄndernToolStripMenuItem";
            this.passwortÄndernToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.passwortÄndernToolStripMenuItem.Text = "Passwort ändern";
            this.passwortÄndernToolStripMenuItem.Click += new System.EventHandler(this.passwortÄndernToolStripMenuItem_Click);
            // 
            // kontoLöschenToolStripMenuItem
            // 
            this.kontoLöschenToolStripMenuItem.Name = "kontoLöschenToolStripMenuItem";
            this.kontoLöschenToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.kontoLöschenToolStripMenuItem.Text = "Konto löschen";
            this.kontoLöschenToolStripMenuItem.Click += new System.EventHandler(this.kontoLöschenToolStripMenuItem_Click);
            // 
            // statisikToolStripMenuItem
            // 
            this.statisikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansehenToolStripMenuItem,
            this.zurücksetzenToolStripMenuItem});
            this.statisikToolStripMenuItem.Name = "statisikToolStripMenuItem";
            this.statisikToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.statisikToolStripMenuItem.Text = "Statisik";
            // 
            // ansehenToolStripMenuItem
            // 
            this.ansehenToolStripMenuItem.Name = "ansehenToolStripMenuItem";
            this.ansehenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ansehenToolStripMenuItem.Text = "ansehen";
            this.ansehenToolStripMenuItem.Click += new System.EventHandler(this.ansehenToolStripMenuItem_Click);
            // 
            // zurücksetzenToolStripMenuItem
            // 
            this.zurücksetzenToolStripMenuItem.Name = "zurücksetzenToolStripMenuItem";
            this.zurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zurücksetzenToolStripMenuItem.Text = "zurücksetzen";
            this.zurücksetzenToolStripMenuItem.Click += new System.EventHandler(this.zurücksetzenToolStripMenuItem_Click);
            // 
            // spielSpeichernToolStripMenuItem
            // 
            this.spielSpeichernToolStripMenuItem.Name = "spielSpeichernToolStripMenuItem";
            this.spielSpeichernToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.spielSpeichernToolStripMenuItem.Text = "Spiel speichern";
            this.spielSpeichernToolStripMenuItem.Click += new System.EventHandler(this.spielSpeichernToolStripMenuItem_Click);
            // 
            // spielLadenToolStripMenuItem
            // 
            this.spielLadenToolStripMenuItem.Name = "spielLadenToolStripMenuItem";
            this.spielLadenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.spielLadenToolStripMenuItem.Text = "Spiel laden";
            this.spielLadenToolStripMenuItem.Click += new System.EventHandler(this.spielLadenToolStripMenuItem_Click);
            // 
            // spielBeendenToolStripMenuItem
            // 
            this.spielBeendenToolStripMenuItem.Name = "spielBeendenToolStripMenuItem";
            this.spielBeendenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.spielBeendenToolStripMenuItem.Text = "Spiel beenden";
            this.spielBeendenToolStripMenuItem.Click += new System.EventHandler(this.spielBeendenToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.hilfeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hilfeToolStripMenuItem.Text = "Regelwerk";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(150, 6);
            // 
            // ShogiSpielfeld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShogiSpielfeld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panda Shogi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShogiSpielfeld_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShogiSpielfeld_FormClosed);
            this.Load += new System.EventHandler(this.ShogiSpielfeld_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benutzernamenÄndernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwortÄndernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontoLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansehenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zurücksetzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielSpeichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spielBeendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;


    }

}