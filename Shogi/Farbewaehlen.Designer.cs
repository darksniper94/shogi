namespace Shogi
{
    partial class Farbewaehlen
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.rBtnStandard = new System.Windows.Forms.RadioButton();
            this.rBtnHellblau = new System.Windows.Forms.RadioButton();
            this.rBtnHellgruen = new System.Windows.Forms.RadioButton();
            this.rBtnWeiss = new System.Windows.Forms.RadioButton();
            this.rBtnGrau = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(62, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(176, 213);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(100, 30);
            this.btnAbbrechen.TabIndex = 1;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            // 
            // rBtnStandard
            // 
            this.rBtnStandard.AutoSize = true;
            this.rBtnStandard.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnStandard.Location = new System.Drawing.Point(62, 32);
            this.rBtnStandard.Name = "rBtnStandard";
            this.rBtnStandard.Size = new System.Drawing.Size(89, 24);
            this.rBtnStandard.TabIndex = 2;
            this.rBtnStandard.TabStop = true;
            this.rBtnStandard.Text = "Standard";
            this.rBtnStandard.UseVisualStyleBackColor = true;
            // 
            // rBtnHellblau
            // 
            this.rBtnHellblau.AutoSize = true;
            this.rBtnHellblau.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnHellblau.Location = new System.Drawing.Point(62, 65);
            this.rBtnHellblau.Name = "rBtnHellblau";
            this.rBtnHellblau.Size = new System.Drawing.Size(83, 24);
            this.rBtnHellblau.TabIndex = 3;
            this.rBtnHellblau.TabStop = true;
            this.rBtnHellblau.Text = "Hellblau";
            this.rBtnHellblau.UseVisualStyleBackColor = true;
            // 
            // rBtnHellgruen
            // 
            this.rBtnHellgruen.AutoSize = true;
            this.rBtnHellgruen.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnHellgruen.Location = new System.Drawing.Point(62, 102);
            this.rBtnHellgruen.Name = "rBtnHellgruen";
            this.rBtnHellgruen.Size = new System.Drawing.Size(86, 24);
            this.rBtnHellgruen.TabIndex = 4;
            this.rBtnHellgruen.TabStop = true;
            this.rBtnHellgruen.Text = "Hellgrün";
            this.rBtnHellgruen.UseVisualStyleBackColor = true;
            // 
            // rBtnWeiss
            // 
            this.rBtnWeiss.AutoSize = true;
            this.rBtnWeiss.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnWeiss.Location = new System.Drawing.Point(62, 139);
            this.rBtnWeiss.Name = "rBtnWeiss";
            this.rBtnWeiss.Size = new System.Drawing.Size(61, 24);
            this.rBtnWeiss.TabIndex = 5;
            this.rBtnWeiss.TabStop = true;
            this.rBtnWeiss.Text = "Weiß";
            this.rBtnWeiss.UseVisualStyleBackColor = true;
            // 
            // rBtnGrau
            // 
            this.rBtnGrau.AutoSize = true;
            this.rBtnGrau.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnGrau.Location = new System.Drawing.Point(62, 174);
            this.rBtnGrau.Name = "rBtnGrau";
            this.rBtnGrau.Size = new System.Drawing.Size(61, 24);
            this.rBtnGrau.TabIndex = 6;
            this.rBtnGrau.TabStop = true;
            this.rBtnGrau.Text = "Grau";
            this.rBtnGrau.UseVisualStyleBackColor = true;
            // 
            // Farbewählen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 261);
            this.Controls.Add(this.rBtnGrau);
            this.Controls.Add(this.rBtnWeiss);
            this.Controls.Add(this.rBtnHellgruen);
            this.Controls.Add(this.rBtnHellblau);
            this.Controls.Add(this.rBtnStandard);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnOK);
            this.Name = "Farbewählen";
            this.Text = "Farbewählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.RadioButton rBtnStandard;
        private System.Windows.Forms.RadioButton rBtnHellblau;
        private System.Windows.Forms.RadioButton rBtnHellgruen;
        private System.Windows.Forms.RadioButton rBtnWeiss;
        private System.Windows.Forms.RadioButton rBtnGrau;
    }
}