namespace Shogi
{
    partial class Steinwaehlen
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
            this.rBtnDE = new System.Windows.Forms.RadioButton();
            this.rBtnEN = new System.Windows.Forms.RadioButton();
            this.rBtnJA = new System.Windows.Forms.RadioButton();
            this.rBtnBewegung = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rBtnDE
            // 
            this.rBtnDE.AutoSize = true;
            this.rBtnDE.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnDE.Location = new System.Drawing.Point(35, 74);
            this.rBtnDE.Name = "rBtnDE";
            this.rBtnDE.Size = new System.Drawing.Size(82, 24);
            this.rBtnDE.TabIndex = 1;
            this.rBtnDE.TabStop = true;
            this.rBtnDE.Text = "Deutsch";
            this.rBtnDE.UseVisualStyleBackColor = true;
            // 
            // rBtnEN
            // 
            this.rBtnEN.AutoSize = true;
            this.rBtnEN.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnEN.Location = new System.Drawing.Point(35, 121);
            this.rBtnEN.Name = "rBtnEN";
            this.rBtnEN.Size = new System.Drawing.Size(83, 24);
            this.rBtnEN.TabIndex = 2;
            this.rBtnEN.TabStop = true;
            this.rBtnEN.Text = "Englisch";
            this.rBtnEN.UseVisualStyleBackColor = true;
            // 
            // rBtnJA
            // 
            this.rBtnJA.AutoSize = true;
            this.rBtnJA.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnJA.Location = new System.Drawing.Point(35, 171);
            this.rBtnJA.Name = "rBtnJA";
            this.rBtnJA.Size = new System.Drawing.Size(92, 24);
            this.rBtnJA.TabIndex = 3;
            this.rBtnJA.TabStop = true;
            this.rBtnJA.Text = "Japanisch";
            this.rBtnJA.UseVisualStyleBackColor = true;
            // 
            // rBtnBewegung
            // 
            this.rBtnBewegung.AutoSize = true;
            this.rBtnBewegung.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnBewegung.Location = new System.Drawing.Point(35, 30);
            this.rBtnBewegung.Name = "rBtnBewegung";
            this.rBtnBewegung.Size = new System.Drawing.Size(149, 24);
            this.rBtnBewegung.TabIndex = 0;
            this.rBtnBewegung.TabStop = true;
            this.rBtnBewegung.Text = "Bewegungsmuster";
            this.rBtnBewegung.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(49, 225);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(173, 226);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(100, 30);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // Steinwählen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 270);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rBtnJA);
            this.Controls.Add(this.rBtnEN);
            this.Controls.Add(this.rBtnDE);
            this.Controls.Add(this.rBtnBewegung);
            this.Name = "Steinwählen";
            this.Text = "Steinwählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rBtnBewegung;
        private System.Windows.Forms.RadioButton rBtnDE;
        private System.Windows.Forms.RadioButton rBtnEN;
        private System.Windows.Forms.RadioButton rBtnJA;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAbbrechen;
    }
}