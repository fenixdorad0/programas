namespace PracticandoconTuring
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1a = new System.Windows.Forms.Button();
            this.button1b = new System.Windows.Forms.Button();
            this.button1c = new System.Windows.Forms.Button();
            this.textLong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1a
            // 
            this.button1a.Location = new System.Drawing.Point(53, 103);
            this.button1a.Name = "button1a";
            this.button1a.Size = new System.Drawing.Size(75, 23);
            this.button1a.TabIndex = 0;
            this.button1a.Text = "1a";
            this.button1a.UseVisualStyleBackColor = true;
            this.button1a.Click += new System.EventHandler(this.button1a_Click);
            // 
            // button1b
            // 
            this.button1b.Location = new System.Drawing.Point(148, 103);
            this.button1b.Name = "button1b";
            this.button1b.Size = new System.Drawing.Size(75, 23);
            this.button1b.TabIndex = 1;
            this.button1b.Text = "1b";
            this.button1b.UseVisualStyleBackColor = true;
            this.button1b.Click += new System.EventHandler(this.button1b_Click);
            // 
            // button1c
            // 
            this.button1c.Location = new System.Drawing.Point(251, 103);
            this.button1c.Name = "button1c";
            this.button1c.Size = new System.Drawing.Size(75, 23);
            this.button1c.TabIndex = 2;
            this.button1c.Text = "1c";
            this.button1c.UseVisualStyleBackColor = true;
            this.button1c.Click += new System.EventHandler(this.button1c_Click);
            // 
            // textLong
            // 
            this.textLong.Location = new System.Drawing.Point(136, 60);
            this.textLong.Name = "textLong";
            this.textLong.Size = new System.Drawing.Size(75, 20);
            this.textLong.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "longitud";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLong);
            this.Controls.Add(this.button1c);
            this.Controls.Add(this.button1b);
            this.Controls.Add(this.button1a);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1a;
        private System.Windows.Forms.Button button1b;
        private System.Windows.Forms.Button button1c;
        private System.Windows.Forms.TextBox textLong;
        private System.Windows.Forms.Label label1;
    }
}

