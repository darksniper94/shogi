namespace Shogi
{
    partial class BenutzernameAendern
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
            this.txtBenutzer = new System.Windows.Forms.TextBox();
            this.txtPasswort = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenutzername.Location = new System.Drawing.Point(24, 26);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(151, 20);
            this.lblBenutzername.TabIndex = 0;
            this.lblBenutzername.Text = "Neuer Benutzername";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswort.Location = new System.Drawing.Point(27, 58);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(70, 20);
            this.lblPasswort.TabIndex = 1;
            this.lblPasswort.Text = "Passwort";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBenutzer.Location = new System.Drawing.Point(205, 24);
            this.txtBenutzer.Name = "txtBenutzer";
            this.txtBenutzer.Size = new System.Drawing.Size(234, 24);
            this.txtBenutzer.TabIndex = 2;
            // 
            // txtPasswort
            // 
            this.txtPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswort.Location = new System.Drawing.Point(205, 58);
            this.txtPasswort.Name = "txtPasswort";
            this.txtPasswort.PasswordChar = '*';
            this.txtPasswort.Size = new System.Drawing.Size(234, 24);
            this.txtPasswort.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(113, 107);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BenutzernameAendern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 155);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPasswort);
            this.Controls.Add(this.txtBenutzer);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzername);
            this.Name = "BenutzernameAendern";
            this.Text = "Benutzername Ändern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.TextBox txtBenutzer;
        private System.Windows.Forms.TextBox txtPasswort;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}