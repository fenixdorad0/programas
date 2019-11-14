namespace Cripto_Clasics
{
    partial class Afin
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
            this.textBox_Desplazamiento = new System.Windows.Forms.TextBox();
            this.textBox_texto_cifrado = new System.Windows.Forms.TextBox();
            this.textBox_texto_claro = new System.Windows.Forms.TextBox();
            this.button_Descifrar = new System.Windows.Forms.Button();
            this.button_Cifrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_decimacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desplazamiento";
            // 
            // textBox_Desplazamiento
            // 
            this.textBox_Desplazamiento.Location = new System.Drawing.Point(424, 46);
            this.textBox_Desplazamiento.Name = "textBox_Desplazamiento";
            this.textBox_Desplazamiento.Size = new System.Drawing.Size(100, 20);
            this.textBox_Desplazamiento.TabIndex = 10;
            // 
            // textBox_texto_cifrado
            // 
            this.textBox_texto_cifrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_texto_cifrado.Location = new System.Drawing.Point(12, 229);
            this.textBox_texto_cifrado.Multiline = true;
            this.textBox_texto_cifrado.Name = "textBox_texto_cifrado";
            this.textBox_texto_cifrado.Size = new System.Drawing.Size(703, 132);
            this.textBox_texto_cifrado.TabIndex = 9;
            // 
            // textBox_texto_claro
            // 
            this.textBox_texto_claro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_texto_claro.Location = new System.Drawing.Point(12, 88);
            this.textBox_texto_claro.Multiline = true;
            this.textBox_texto_claro.Name = "textBox_texto_claro";
            this.textBox_texto_claro.Size = new System.Drawing.Size(703, 135);
            this.textBox_texto_claro.TabIndex = 8;
            // 
            // button_Descifrar
            // 
            this.button_Descifrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Descifrar.Location = new System.Drawing.Point(304, 36);
            this.button_Descifrar.Name = "button_Descifrar";
            this.button_Descifrar.Size = new System.Drawing.Size(114, 32);
            this.button_Descifrar.TabIndex = 7;
            this.button_Descifrar.Text = "Descifrar";
            this.button_Descifrar.UseVisualStyleBackColor = true;
            this.button_Descifrar.Click += new System.EventHandler(this.button_Descifrar_Click);
            // 
            // button_Cifrar
            // 
            this.button_Cifrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cifrar.Location = new System.Drawing.Point(184, 36);
            this.button_Cifrar.Name = "button_Cifrar";
            this.button_Cifrar.Size = new System.Drawing.Size(114, 32);
            this.button_Cifrar.TabIndex = 6;
            this.button_Cifrar.Text = "Cifrar";
            this.button_Cifrar.UseVisualStyleBackColor = true;
            this.button_Cifrar.Click += new System.EventHandler(this.button_Cifrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Decimación";
            // 
            // textBox_decimacion
            // 
            this.textBox_decimacion.Location = new System.Drawing.Point(530, 46);
            this.textBox_decimacion.Name = "textBox_decimacion";
            this.textBox_decimacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_decimacion.TabIndex = 12;
            // 
            // Afin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_decimacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Desplazamiento);
            this.Controls.Add(this.textBox_texto_cifrado);
            this.Controls.Add(this.textBox_texto_claro);
            this.Controls.Add(this.button_Descifrar);
            this.Controls.Add(this.button_Cifrar);
            this.Name = "Afin";
            this.Text = "Afin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Desplazamiento;
        private System.Windows.Forms.TextBox textBox_texto_cifrado;
        private System.Windows.Forms.TextBox textBox_texto_claro;
        private System.Windows.Forms.Button button_Descifrar;
        private System.Windows.Forms.Button button_Cifrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_decimacion;
    }
}