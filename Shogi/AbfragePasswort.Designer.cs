namespace Shogi
{
    partial class frmPasswortAbfrage
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
            this.txtPasswort = new System.Windows.Forms.TextBox();
            this.lblMeldung = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bAbbrechen = new System.Windows.Forms.Button();
            this.lblrueckMeldung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPasswort
            // 
            this.txtPasswort.Location = new System.Drawing.Point(191, 57);
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(203, 20);
            this.txtPasswort.TabIndex = 0;
            // 
            // lblMeldung
            // 
            this.lblMeldung.AutoSize = true;
            this.lblMeldung.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldung.Location = new System.Drawing.Point(12, 9);
            this.lblMeldung.Name = "lblMeldung";
            this.lblMeldung.Size = new System.Drawing.Size(475, 20);
            this.lblMeldung.TabIndex = 1;
            this.lblMeldung.Text = "Bitte geben Sie ihr Passwort ein, wenn Sie Ihr Konto löschen möchten.";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswort.Location = new System.Drawing.Point(58, 57);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(80, 20);
            this.lblPasswort.TabIndex = 2;
            this.lblPasswort.Text = "Passswort:";
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(129, 113);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 30);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bAbbrechen
            // 
            this.bAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bAbbrechen.Location = new System.Drawing.Point(260, 113);
            this.bAbbrechen.Name = "bAbbrechen";
            this.bAbbrechen.Size = new System.Drawing.Size(100, 30);
            this.bAbbrechen.TabIndex = 4;
            this.bAbbrechen.Text = "Abbrechen";
            this.bAbbrechen.UseVisualStyleBackColor = true;
            this.bAbbrechen.Click += new System.EventHandler(this.bAbbrechen_Click);
            // 
            // lblrueckMeldung
            // 
            this.lblrueckMeldung.AutoSize = true;
            this.lblrueckMeldung.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrueckMeldung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblrueckMeldung.Location = new System.Drawing.Point(166, 86);
            this.lblrueckMeldung.Name = "lblrueckMeldung";
            this.lblrueckMeldung.Size = new System.Drawing.Size(157, 18);
            this.lblrueckMeldung.TabIndex = 5;
            this.lblrueckMeldung.Text = "Passwort nicht korrekt.";
            this.lblrueckMeldung.Visible = false;
            // 
            // frmPasswortAbfrage
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bAbbrechen;
            this.ClientSize = new System.Drawing.Size(492, 156);
            this.Controls.Add(this.lblrueckMeldung);
            this.Controls.Add(this.bAbbrechen);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblMeldung);
            this.Controls.Add(this.txtPasswort);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasswortAbfrage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konto löschen";
            this.Load += new System.EventHandler(this.frmPasswortAbfrage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswort;
        private System.Windows.Forms.Label lblMeldung;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bAbbrechen;
        private System.Windows.Forms.Label lblrueckMeldung;
    }
}