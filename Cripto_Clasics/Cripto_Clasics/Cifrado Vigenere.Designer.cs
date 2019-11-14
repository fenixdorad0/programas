namespace Cripto_Clasics
{
    partial class Cifrado_Vigenere
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_clave = new System.Windows.Forms.TextBox();
            this.textBox_texto_cifrado = new System.Windows.Forms.TextBox();
            this.textBox_texto_claro = new System.Windows.Forms.TextBox();
            this.button_Cifrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Clave";
            // 
            // textBox_clave
            // 
            this.textBox_clave.Location = new System.Drawing.Point(416, 46);
            this.textBox_clave.Name = "textBox_clave";
            this.textBox_clave.Size = new System.Drawing.Size(100, 20);
            this.textBox_clave.TabIndex = 18;
            // 
            // textBox_texto_cifrado
            // 
            this.textBox_texto_cifrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_texto_cifrado.Location = new System.Drawing.Point(12, 229);
            this.textBox_texto_cifrado.Multiline = true;
            this.textBox_texto_cifrado.Name = "textBox_texto_cifrado";
            this.textBox_texto_cifrado.Size = new System.Drawing.Size(703, 132);
            this.textBox_texto_cifrado.TabIndex = 17;
            // 
            // textBox_texto_claro
            // 
            this.textBox_texto_claro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_texto_claro.Location = new System.Drawing.Point(12, 88);
            this.textBox_texto_claro.Multiline = true;
            this.textBox_texto_claro.Name = "textBox_texto_claro";
            this.textBox_texto_claro.Size = new System.Drawing.Size(703, 135);
            this.textBox_texto_claro.TabIndex = 16;
            // 
            // button_Cifrar
            // 
            this.button_Cifrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cifrar.Location = new System.Drawing.Point(274, 36);
            this.button_Cifrar.Name = "button_Cifrar";
            this.button_Cifrar.Size = new System.Drawing.Size(114, 32);
            this.button_Cifrar.TabIndex = 14;
            this.button_Cifrar.Text = "Cifrar";
            this.button_Cifrar.UseVisualStyleBackColor = true;
            this.button_Cifrar.Click += new System.EventHandler(this.button_Cifrar_Click);
            // 
            // Cifrado_Vigenere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 388);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_clave);
            this.Controls.Add(this.textBox_texto_cifrado);
            this.Controls.Add(this.textBox_texto_claro);
            this.Controls.Add(this.button_Cifrar);
            this.Name = "Cifrado_Vigenere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_clave;
        private System.Windows.Forms.TextBox textBox_texto_cifrado;
        private System.Windows.Forms.TextBox textBox_texto_claro;
        private System.Windows.Forms.Button button_Cifrar;
    }
}