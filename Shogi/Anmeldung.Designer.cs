namespace Shogi
{
    partial class FormAnmeldung
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.bAnmelden = new System.Windows.Forms.Button();
            this.bAbbrechen = new System.Windows.Forms.Button();
            this.txtBenutzername = new System.Windows.Forms.TextBox();
            this.txtPasswort = new System.Windows.Forms.TextBox();
            this.lblBenutzername = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.bRegistrieren = new System.Windows.Forms.Button();
            this.lblMeldung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bAnmelden
            // 
            this.bAnmelden.Location = new System.Drawing.Point(68, 157);
            this.bAnmelden.Name = "bAnmelden";
            this.bAnmelden.Size = new System.Drawing.Size(100, 30);
            this.bAnmelden.TabIndex = 3;
            this.bAnmelden.Text = "Anmelden";
            this.bAnmelden.UseVisualStyleBackColor = true;
            this.bAnmelden.Click += new System.EventHandler(this.bAnmelden_Click);
            // 
            // bAbbrechen
            // 
            this.bAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bAbbrechen.Location = new System.Drawing.Point(280, 157);
            this.bAbbrechen.Name = "bAbbrechen";
            this.bAbbrechen.Size = new System.Drawing.Size(100, 30);
            this.bAbbrechen.TabIndex = 5;
            this.bAbbrechen.Text = "Abbrechen";
            this.bAbbrechen.UseVisualStyleBackColor = true;
            this.bAbbrechen.Click += new System.EventHandler(this.bAbbrechen_Click);
            // 
            // txtBenutzername
            // 
            this.txtBenutzername.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBenutzername.Location = new System.Drawing.Point(165, 41);
            this.txtBenutzername.MaxLength = 30;
            this.txtBenutzername.Name = "txtBenutzername";
            this.txtBenutzername.Size = new System.Drawing.Size(233, 24);
            this.txtBenutzername.TabIndex = 1;
            // 
            // txtPasswort
            // 
            this.txtPasswort.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswort.Location = new System.Drawing.Point(165, 82);
            this.txtPasswort.MaxLength = 30;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(233, 24);
            this.txtPasswort.TabIndex = 2;
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenutzername.Location = new System.Drawing.Point(39, 41);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(110, 20);
            this.lblBenutzername.TabIndex = 4;
            this.lblBenutzername.Text = "Benutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswort.Location = new System.Drawing.Point(39, 82);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(74, 20);
            this.lblPasswort.TabIndex = 5;
            this.lblPasswort.Text = "Passwort:";
            // 
            // bRegistrieren
            // 
            this.bRegistrieren.Location = new System.Drawing.Point(174, 157);
            this.bRegistrieren.Name = "bRegistrieren";
            this.bRegistrieren.Size = new System.Drawing.Size(100, 30);
            this.bRegistrieren.TabIndex = 4;
            this.bRegistrieren.Text = "Registrieren";
            this.bRegistrieren.UseVisualStyleBackColor = true;
            this.bRegistrieren.Click += new System.EventHandler(this.bRegistrieren_Click);
            // 
            // lblMeldung
            // 
            this.lblMeldung.AutoSize = true;
            this.lblMeldung.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMeldung.Location = new System.Drawing.Point(89, 125);
            this.lblMeldung.Name = "lblMeldung";
            this.lblMeldung.Size = new System.Drawing.Size(258, 18);
            this.lblMeldung.TabIndex = 7;
            this.lblMeldung.Text = "Benutzername oder Passwort ist falsch.";
            this.lblMeldung.Visible = false;
            // 
            // FormAnmeldung
            // 
            this.AcceptButton = this.bAnmelden;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.bAbbrechen;
            this.ClientSize = new System.Drawing.Size(453, 208);
            this.Controls.Add(this.lblMeldung);
            this.Controls.Add(this.bRegistrieren);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzername);
            this.Controls.Add(this.txtPasswort);
            this.Controls.Add(this.txtBenutzername);
            this.Controls.Add(this.bAbbrechen);
            this.Controls.Add(this.bAnmelden);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAnmeldung";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Anmeldung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAnmelden;
        private System.Windows.Forms.Button bAbbrechen;
        private System.Windows.Forms.TextBox txtBenutzername; 
        private System.Windows.Forms.TextBox txtPasswort;
        private System.Windows.Forms.Label lblBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Button bRegistrieren;
        private System.Windows.Forms.Label lblMeldung;
        
        /// <summary>
        /// Property für die SpielerID 
        /// </summary>
        public int spielerID { get; set; }
        
        /// <summary>
        /// "Getter" für den Benutzernamen
        /// </summary>
        /// <returns> String mit dem eingegebenen Benutzernamen</returns>
        public string getBenutzername()
        {
            return txtBenutzername.Text;
        }
    }
}

