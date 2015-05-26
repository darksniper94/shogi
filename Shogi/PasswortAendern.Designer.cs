namespace Shogi
{
    partial class PasswortAendern
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
            this.lblNeuesPasswort = new System.Windows.Forms.Label();
            this.lblNeuesPasswortwdh = new System.Windows.Forms.Label();
            this.lblAltesPasswort = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNeuesPasswort = new System.Windows.Forms.TextBox();
            this.txtNeuesPasswortwdh = new System.Windows.Forms.TextBox();
            this.txtAltesPasswort = new System.Windows.Forms.TextBox();
            this.lblMeldung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNeuesPasswort
            // 
            this.lblNeuesPasswort.AutoSize = true;
            this.lblNeuesPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeuesPasswort.Location = new System.Drawing.Point(37, 30);
            this.lblNeuesPasswort.Name = "lblNeuesPasswort";
            this.lblNeuesPasswort.Size = new System.Drawing.Size(115, 20);
            this.lblNeuesPasswort.TabIndex = 0;
            this.lblNeuesPasswort.Text = "Neues Passwort";
            // 
            // lblNeuesPasswortwdh
            // 
            this.lblNeuesPasswortwdh.AutoSize = true;
            this.lblNeuesPasswortwdh.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeuesPasswortwdh.Location = new System.Drawing.Point(36, 61);
            this.lblNeuesPasswortwdh.Name = "lblNeuesPasswortwdh";
            this.lblNeuesPasswortwdh.Size = new System.Drawing.Size(202, 20);
            this.lblNeuesPasswortwdh.TabIndex = 1;
            this.lblNeuesPasswortwdh.Text = "Neues Passwort wiederholen";
            // 
            // lblAltesPasswort
            // 
            this.lblAltesPasswort.AutoSize = true;
            this.lblAltesPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltesPasswort.Location = new System.Drawing.Point(34, 93);
            this.lblAltesPasswort.Name = "lblAltesPasswort";
            this.lblAltesPasswort.Size = new System.Drawing.Size(108, 20);
            this.lblAltesPasswort.TabIndex = 2;
            this.lblAltesPasswort.Text = "Altes Passwort";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(113, 156);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNeuesPasswort
            // 
            this.txtNeuesPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNeuesPasswort.Location = new System.Drawing.Point(249, 30);
            this.txtNeuesPasswort.Name = "txtNeuesPasswort";
            this.txtNeuesPasswort.PasswordChar = '*';
            this.txtNeuesPasswort.Size = new System.Drawing.Size(213, 24);
            this.txtNeuesPasswort.TabIndex = 5;
            // 
            // txtNeuesPasswortwdh
            // 
            this.txtNeuesPasswortwdh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNeuesPasswortwdh.Location = new System.Drawing.Point(249, 61);
            this.txtNeuesPasswortwdh.Name = "txtNeuesPasswortwdh";
            this.txtNeuesPasswortwdh.PasswordChar = '*';
            this.txtNeuesPasswortwdh.Size = new System.Drawing.Size(213, 24);
            this.txtNeuesPasswortwdh.TabIndex = 6;
            // 
            // txtAltesPasswort
            // 
            this.txtAltesPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltesPasswort.Location = new System.Drawing.Point(249, 92);
            this.txtAltesPasswort.Name = "txtAltesPasswort";
            this.txtAltesPasswort.PasswordChar = '*';
            this.txtAltesPasswort.Size = new System.Drawing.Size(213, 24);
            this.txtAltesPasswort.TabIndex = 7;
            // 
            // lblMeldung
            // 
            this.lblMeldung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeldung.AutoSize = true;
            this.lblMeldung.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMeldung.Location = new System.Drawing.Point(47, 127);
            this.lblMeldung.Name = "lblMeldung";
            this.lblMeldung.Size = new System.Drawing.Size(254, 18);
            this.lblMeldung.TabIndex = 8;
            this.lblMeldung.Text = "Die Passwörter stimmen nicht überein.";
            this.lblMeldung.Visible = false;
            // 
            // PasswortAendern
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 193);
            this.Controls.Add(this.lblMeldung);
            this.Controls.Add(this.txtAltesPasswort);
            this.Controls.Add(this.txtNeuesPasswortwdh);
            this.Controls.Add(this.txtNeuesPasswort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblAltesPasswort);
            this.Controls.Add(this.lblNeuesPasswortwdh);
            this.Controls.Add(this.lblNeuesPasswort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PasswortAendern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passwort Ändern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNeuesPasswort;
        private System.Windows.Forms.Label lblNeuesPasswortwdh;
        private System.Windows.Forms.Label lblAltesPasswort;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNeuesPasswort;
        private System.Windows.Forms.TextBox txtNeuesPasswortwdh;
        private System.Windows.Forms.TextBox txtAltesPasswort;
        private System.Windows.Forms.Label lblMeldung;
    }
}