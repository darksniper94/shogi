namespace Shogi
{
    partial class FormRegistrierung
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
            this.lblBenutzername = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.lblPasswortWdh = new System.Windows.Forms.Label();
            this.lblMeldung = new System.Windows.Forms.Label();
            this.txtBenutzername = new System.Windows.Forms.TextBox();
            this.txtPasswort = new System.Windows.Forms.TextBox();
            this.txtPasswortWdh = new System.Windows.Forms.TextBox();
            this.bAbbrechen = new System.Windows.Forms.Button();
            this.bRegistrieren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenutzername.Location = new System.Drawing.Point(32, 32);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(110, 20);
            this.lblBenutzername.TabIndex = 0;
            this.lblBenutzername.Text = "Benutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswort.Location = new System.Drawing.Point(32, 73);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(74, 20);
            this.lblPasswort.TabIndex = 1;
            this.lblPasswort.Text = "Passwort:";
            // 
            // lblPasswortWdh
            // 
            this.lblPasswortWdh.AutoSize = true;
            this.lblPasswortWdh.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswortWdh.Location = new System.Drawing.Point(32, 112);
            this.lblPasswortWdh.Name = "lblPasswortWdh";
            this.lblPasswortWdh.Size = new System.Drawing.Size(161, 20);
            this.lblPasswortWdh.TabIndex = 2;
            this.lblPasswortWdh.Text = "Passwort wiederholen:";
            // 
            // lblMeldung
            // 
            this.lblMeldung.AutoSize = true;
            this.lblMeldung.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMeldung.Location = new System.Drawing.Point(34, 155);
            this.lblMeldung.Name = "lblMeldung";
            this.lblMeldung.Size = new System.Drawing.Size(517, 18);
            this.lblMeldung.TabIndex = 3;
            this.lblMeldung.Text = "Der Benutzername darf nur Buchstaben und Ziffern zwischen 0 und 9 enthalten.";
            // 
            // txtBenutzername
            // 
            this.txtBenutzername.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBenutzername.Location = new System.Drawing.Point(206, 28);
            this.txtBenutzername.MaxLength = 30;
            this.txtBenutzername.Name = "txtBenutzername";
            this.txtBenutzername.Size = new System.Drawing.Size(233, 24);
            this.txtBenutzername.TabIndex = 4;
            // 
            // txtPasswort
            // 
            this.txtPasswort.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswort.Location = new System.Drawing.Point(206, 69);
            this.txtPasswort.MaxLength = 30;
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(233, 24);
            this.txtPasswort.TabIndex = 5;
            // 
            // txtPasswortWdh
            // 
            this.txtPasswortWdh.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswortWdh.Location = new System.Drawing.Point(206, 108);
            this.txtPasswortWdh.MaxLength = 30;
            this.txtPasswortWdh.Name = "txtPasswortWdh";
            this.txtPasswortWdh.PasswordChar = '*';
            this.txtPasswortWdh.Size = new System.Drawing.Size(233, 24);
            this.txtPasswortWdh.TabIndex = 6;
            // 
            // bAbbrechen
            // 
            this.bAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bAbbrechen.Location = new System.Drawing.Point(301, 193);
            this.bAbbrechen.Name = "bAbbrechen";
            this.bAbbrechen.Size = new System.Drawing.Size(100, 30);
            this.bAbbrechen.TabIndex = 8;
            this.bAbbrechen.Text = "Abbrechen";
            this.bAbbrechen.UseVisualStyleBackColor = true;
            this.bAbbrechen.Click += new System.EventHandler(this.bAbbrechen_Click);
            // 
            // bRegistrieren
            // 
            this.bRegistrieren.Location = new System.Drawing.Point(153, 193);
            this.bRegistrieren.Name = "bRegistrieren";
            this.bRegistrieren.Size = new System.Drawing.Size(100, 30);
            this.bRegistrieren.TabIndex = 7;
            this.bRegistrieren.Text = "Registrieren";
            this.bRegistrieren.UseVisualStyleBackColor = true;
            this.bRegistrieren.Click += new System.EventHandler(this.bRegistrieren_Click);
            // 
            // FormRegistrierung
            // 
            this.AcceptButton = this.bRegistrieren;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bAbbrechen;
            this.ClientSize = new System.Drawing.Size(580, 238);
            this.Controls.Add(this.bAbbrechen);
            this.Controls.Add(this.bRegistrieren);
            this.Controls.Add(this.txtPasswortWdh);
            this.Controls.Add(this.txtPasswort);
            this.Controls.Add(this.txtBenutzername);
            this.Controls.Add(this.lblMeldung);
            this.Controls.Add(this.lblPasswortWdh);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzername);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRegistrierung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrierung";
            this.Load += new System.EventHandler(this.formRegistrierung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Label lblPasswortWdh;
        private System.Windows.Forms.Label lblMeldung;
        private System.Windows.Forms.TextBox txtBenutzername;
        private System.Windows.Forms.TextBox txtPasswort;
        private System.Windows.Forms.TextBox txtPasswortWdh;
        private System.Windows.Forms.Button bRegistrieren;
        private System.Windows.Forms.Button bAbbrechen;
    }
}