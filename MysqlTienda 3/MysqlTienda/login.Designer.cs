namespace MysqlTienda
{
    partial class login
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
            this.components = new System.ComponentModel.Container();
            this.buttonVerificar = new Bunifu.Framework.UI.BunifuImageButton();
            this.label15 = new System.Windows.Forms.Label();
            this.buniTextPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.buniTextUsuario = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.labelCedula = new System.Windows.Forms.Label();
            this.labelOlvideContraseña = new System.Windows.Forms.Label();
            this.labelVendedor = new System.Windows.Forms.Label();
            this.LogoAlteza = new System.Windows.Forms.PictureBox();
            this.comboBoxCiudad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVerificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoAlteza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVerificar
            // 
            this.buttonVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(174)))), ((int)(((byte)(255)))));
            this.buttonVerificar.Image = global::MysqlTienda.Properties.Resources.botton;
            this.buttonVerificar.ImageActive = null;
            this.buttonVerificar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonVerificar.Location = new System.Drawing.Point(189, 472);
            this.buttonVerificar.Name = "buttonVerificar";
            this.buttonVerificar.Size = new System.Drawing.Size(163, 71);
            this.buttonVerificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonVerificar.TabIndex = 105;
            this.buttonVerificar.TabStop = false;
            this.buttonVerificar.Zoom = 10;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(196, 415);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 104;
            this.label15.Text = "Seleccionar almacén...";
            this.label15.Visible = false;
            // 
            // buniTextPass
            // 
            this.buniTextPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buniTextPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.buniTextPass.Font = new System.Drawing.Font("Averta Demo PE Cutted Demo", 9.749999F);
            this.buniTextPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buniTextPass.HintForeColor = System.Drawing.Color.Empty;
            this.buniTextPass.HintText = "";
            this.buniTextPass.isPassword = true;
            this.buniTextPass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buniTextPass.LineIdleColor = System.Drawing.Color.Gray;
            this.buniTextPass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buniTextPass.LineThickness = 3;
            this.buniTextPass.Location = new System.Drawing.Point(79, 361);
            this.buniTextPass.Margin = new System.Windows.Forms.Padding(4);
            this.buniTextPass.Name = "buniTextPass";
            this.buniTextPass.Size = new System.Drawing.Size(367, 33);
            this.buniTextPass.TabIndex = 103;
            this.buniTextPass.Text = "Contraseña";
            this.buniTextPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // buniTextUsuario
            // 
            this.buniTextUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buniTextUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.buniTextUsuario.Font = new System.Drawing.Font("Averta Demo PE Cutted Demo", 9.749999F);
            this.buniTextUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buniTextUsuario.HintForeColor = System.Drawing.Color.Empty;
            this.buniTextUsuario.HintText = "";
            this.buniTextUsuario.isPassword = false;
            this.buniTextUsuario.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buniTextUsuario.LineIdleColor = System.Drawing.Color.Gray;
            this.buniTextUsuario.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buniTextUsuario.LineThickness = 3;
            this.buniTextUsuario.Location = new System.Drawing.Point(79, 320);
            this.buniTextUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.buniTextUsuario.Name = "buniTextUsuario";
            this.buniTextUsuario.Size = new System.Drawing.Size(367, 33);
            this.buniTextUsuario.TabIndex = 102;
            this.buniTextUsuario.Text = "Usuario";
            this.buniTextUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelCedula
            // 
            this.labelCedula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCedula.AutoSize = true;
            this.labelCedula.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCedula.Location = new System.Drawing.Point(427, 588);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(40, 13);
            this.labelCedula.TabIndex = 100;
            this.labelCedula.Text = "Cédula";
            // 
            // labelOlvideContraseña
            // 
            this.labelOlvideContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOlvideContraseña.AutoSize = true;
            this.labelOlvideContraseña.BackColor = System.Drawing.Color.Transparent;
            this.labelOlvideContraseña.ForeColor = System.Drawing.Color.Black;
            this.labelOlvideContraseña.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelOlvideContraseña.Location = new System.Drawing.Point(208, 546);
            this.labelOlvideContraseña.Name = "labelOlvideContraseña";
            this.labelOlvideContraseña.Size = new System.Drawing.Size(130, 13);
            this.labelOlvideContraseña.TabIndex = 97;
            this.labelOlvideContraseña.Text = "¿Olvidaste la contraseña?";
            // 
            // labelVendedor
            // 
            this.labelVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVendedor.AutoSize = true;
            this.labelVendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVendedor.Location = new System.Drawing.Point(22, 588);
            this.labelVendedor.Name = "labelVendedor";
            this.labelVendedor.Size = new System.Drawing.Size(53, 13);
            this.labelVendedor.TabIndex = 99;
            this.labelVendedor.Text = "Vendedor";
            // 
            // LogoAlteza
            // 
            this.LogoAlteza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoAlteza.Image = global::MysqlTienda.Properties.Resources.Logo_tendidos_del_Tolima;
            this.LogoAlteza.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoAlteza.Location = new System.Drawing.Point(25, 14);
            this.LogoAlteza.Name = "LogoAlteza";
            this.LogoAlteza.Size = new System.Drawing.Size(487, 240);
            this.LogoAlteza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoAlteza.TabIndex = 101;
            this.LogoAlteza.TabStop = false;
            // 
            // comboBoxCiudad
            // 
            this.comboBoxCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCiudad.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBoxCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCiudad.FormattingEnabled = true;
            this.comboBoxCiudad.ItemHeight = 13;
            this.comboBoxCiudad.Location = new System.Drawing.Point(116, 431);
            this.comboBoxCiudad.Name = "comboBoxCiudad";
            this.comboBoxCiudad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxCiudad.Size = new System.Drawing.Size(303, 21);
            this.comboBoxCiudad.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Averta Demo PE Cutted Demo", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(225, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 28);
            this.label7.TabIndex = 96;
            this.label7.Text = "Cuenta";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton1.BackgroundImage = global::MysqlTienda.Properties.Resources.close;
            this.bunifuImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(514, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(21, 17);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 107;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 610);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.buttonVerificar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buniTextPass);
            this.Controls.Add(this.buniTextUsuario);
            this.Controls.Add(this.labelCedula);
            this.Controls.Add(this.labelOlvideContraseña);
            this.Controls.Add(this.labelVendedor);
            this.Controls.Add(this.LogoAlteza);
            this.Controls.Add(this.comboBoxCiudad);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.Text = "login";
            ((System.ComponentModel.ISupportInitialize)(this.buttonVerificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoAlteza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton buttonVerificar;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMaterialTextbox buniTextPass;
        private Bunifu.Framework.UI.BunifuMaterialTextbox buniTextUsuario;
        private System.Windows.Forms.Label labelCedula;
        private System.Windows.Forms.Label labelOlvideContraseña;
        private System.Windows.Forms.Label labelVendedor;
        private System.Windows.Forms.PictureBox LogoAlteza;
        private System.Windows.Forms.ComboBox comboBoxCiudad;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
    }
}