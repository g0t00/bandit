namespace Bandit
{
    partial class Form1
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
            this.Start = new System.Windows.Forms.Button();
            this.Stopp1 = new System.Windows.Forms.Button();
            this.Stopp2 = new System.Windows.Forms.Button();
            this.Stopp3 = new System.Windows.Forms.Button();
            this.Anzeige = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(131, 461);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(233, 79);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stopp1
            // 
            this.Stopp1.Location = new System.Drawing.Point(31, 358);
            this.Stopp1.Name = "Stopp1";
            this.Stopp1.Size = new System.Drawing.Size(70, 70);
            this.Stopp1.TabIndex = 2;
            this.Stopp1.Text = "Stopp";
            this.Stopp1.UseVisualStyleBackColor = true;
            this.Stopp1.Click += new System.EventHandler(this.Stopp1_Click);
            // 
            // Stopp2
            // 
            this.Stopp2.Location = new System.Drawing.Point(208, 358);
            this.Stopp2.Name = "Stopp2";
            this.Stopp2.Size = new System.Drawing.Size(70, 70);
            this.Stopp2.TabIndex = 3;
            this.Stopp2.Text = "Stopp";
            this.Stopp2.UseVisualStyleBackColor = true;
            this.Stopp2.Click += new System.EventHandler(this.Stopp2_Click);
            // 
            // Stopp3
            // 
            this.Stopp3.Location = new System.Drawing.Point(396, 358);
            this.Stopp3.Name = "Stopp3";
            this.Stopp3.Size = new System.Drawing.Size(70, 70);
            this.Stopp3.TabIndex = 4;
            this.Stopp3.Text = "Stopp";
            this.Stopp3.UseVisualStyleBackColor = true;
            this.Stopp3.Click += new System.EventHandler(this.Stopp3_Click);
            // 
            // Anzeige
            // 
            this.Anzeige.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Anzeige.ForeColor = System.Drawing.Color.Red;
            this.Anzeige.Location = new System.Drawing.Point(2, 588);
            this.Anzeige.Name = "Anzeige";
            this.Anzeige.Size = new System.Drawing.Size(526, 191);
            this.Anzeige.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 823);
            this.Controls.Add(this.Anzeige);
            this.Controls.Add(this.Stopp3);
            this.Controls.Add(this.Stopp2);
            this.Controls.Add(this.Stopp1);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Einarmiger Bandit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stopp1;
        private System.Windows.Forms.Button Stopp2;
        private System.Windows.Forms.Button Stopp3;
        private System.Windows.Forms.Label Anzeige;
    }
}

