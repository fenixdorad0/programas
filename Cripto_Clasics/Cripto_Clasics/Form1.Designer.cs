namespace Cripto_Clasics
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
            this.button_cesar = new System.Windows.Forms.Button();
            this.button_Afin = new System.Windows.Forms.Button();
            this.button_vigenere = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_cesar
            // 
            this.button_cesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cesar.Location = new System.Drawing.Point(12, 12);
            this.button_cesar.Name = "button_cesar";
            this.button_cesar.Size = new System.Drawing.Size(172, 70);
            this.button_cesar.TabIndex = 0;
            this.button_cesar.Text = " Cesar";
            this.button_cesar.UseVisualStyleBackColor = true;
            this.button_cesar.Click += new System.EventHandler(this.button_cesar_Click);
            // 
            // button_Afin
            // 
            this.button_Afin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Afin.Location = new System.Drawing.Point(192, 12);
            this.button_Afin.Name = "button_Afin";
            this.button_Afin.Size = new System.Drawing.Size(172, 70);
            this.button_Afin.TabIndex = 1;
            this.button_Afin.Text = " Afín";
            this.button_Afin.UseVisualStyleBackColor = true;
            this.button_Afin.Click += new System.EventHandler(this.button_Afin_Click);
            // 
            // button_vigenere
            // 
            this.button_vigenere.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vigenere.Location = new System.Drawing.Point(12, 88);
            this.button_vigenere.Name = "button_vigenere";
            this.button_vigenere.Size = new System.Drawing.Size(172, 70);
            this.button_vigenere.TabIndex = 2;
            this.button_vigenere.Text = "Vigenere";
            this.button_vigenere.UseVisualStyleBackColor = true;
            this.button_vigenere.Click += new System.EventHandler(this.button_vigenere_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(192, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 70);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 173);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_vigenere);
            this.Controls.Add(this.button_Afin);
            this.Controls.Add(this.button_cesar);
            this.Name = "Form1";
            this.Text = "Metodos de criptografía";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_cesar;
        private System.Windows.Forms.Button button_Afin;
        private System.Windows.Forms.Button button_vigenere;
        private System.Windows.Forms.Button button1;
    }
}

