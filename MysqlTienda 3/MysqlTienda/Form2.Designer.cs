﻿namespace MysqlTienda
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextboxApartado = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.Button = new Bunifu.Framework.UI.BunifuFlatButton();
            this.TextboxCredito = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.TextboxEfectivo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.TextboxDatafono = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.labelPagoCon = new System.Windows.Forms.Label();
            this.labelPago = new System.Windows.Forms.Label();
            this.TextboxPago = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ButtonEfectivo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonDatafono = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonApartado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonCredito = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelFactura2 = new System.Windows.Forms.Label();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxCambio = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.panel1);
            this.bunifuGradientPanel1.Controls.Add(this.panel2);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Empty;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(111)))), ((int)(((byte)(182)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(166)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1276, 475);
            this.bunifuGradientPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.TextboxApartado);
            this.panel1.Controls.Add(this.Button);
            this.panel1.Controls.Add(this.TextboxCredito);
            this.panel1.Controls.Add(this.TextboxEfectivo);
            this.panel1.Controls.Add(this.TextboxDatafono);
            this.panel1.Controls.Add(this.labelPagoCon);
            this.panel1.Controls.Add(this.labelPago);
            this.panel1.Controls.Add(this.TextboxPago);
            this.panel1.Controls.Add(this.ButtonEfectivo);
            this.panel1.Controls.Add(this.ButtonDatafono);
            this.panel1.Controls.Add(this.ButtonApartado);
            this.panel1.Controls.Add(this.ButtonCredito);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 459);
            this.panel1.TabIndex = 0;
            // 
            // TextboxApartado
            // 
            this.TextboxApartado.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxApartado.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxApartado.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxApartado.BorderThickness = 3;
            this.TextboxApartado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxApartado.Enabled = false;
            this.TextboxApartado.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextboxApartado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxApartado.isPassword = false;
            this.TextboxApartado.Location = new System.Drawing.Point(182, 211);
            this.TextboxApartado.Margin = new System.Windows.Forms.Padding(4);
            this.TextboxApartado.Name = "TextboxApartado";
            this.TextboxApartado.Size = new System.Drawing.Size(237, 48);
            this.TextboxApartado.TabIndex = 11;
            this.TextboxApartado.Text = "0";
            this.TextboxApartado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxApartado.Visible = false;
            this.TextboxApartado.OnValueChanged += new System.EventHandler(this.TextboxApartado_OnValueChanged);
            // 
            // Button
            // 
            this.Button.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.Button.BackColor = System.Drawing.Color.DodgerBlue;
            this.Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button.BorderRadius = 0;
            this.Button.ButtonText = "COTIZACION";
            this.Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button.DisabledColor = System.Drawing.Color.Gray;
            this.Button.Iconcolor = System.Drawing.Color.Transparent;
            this.Button.Iconimage = ((System.Drawing.Image)(resources.GetObject("Button.Iconimage")));
            this.Button.Iconimage_right = null;
            this.Button.Iconimage_right_Selected = null;
            this.Button.Iconimage_Selected = null;
            this.Button.IconMarginLeft = 0;
            this.Button.IconMarginRight = 0;
            this.Button.IconRightVisible = true;
            this.Button.IconRightZoom = 0D;
            this.Button.IconVisible = true;
            this.Button.IconZoom = 90D;
            this.Button.IsTab = false;
            this.Button.Location = new System.Drawing.Point(13, 267);
            this.Button.Margin = new System.Windows.Forms.Padding(4);
            this.Button.Name = "Button";
            this.Button.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.Button.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.Button.OnHoverTextColor = System.Drawing.Color.White;
            this.Button.selected = false;
            this.Button.Size = new System.Drawing.Size(153, 48);
            this.Button.TabIndex = 13;
            this.Button.Text = "COTIZACION";
            this.Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button.Textcolor = System.Drawing.Color.White;
            this.Button.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // TextboxCredito
            // 
            this.TextboxCredito.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxCredito.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxCredito.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxCredito.BorderThickness = 3;
            this.TextboxCredito.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxCredito.Enabled = false;
            this.TextboxCredito.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextboxCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxCredito.isPassword = false;
            this.TextboxCredito.Location = new System.Drawing.Point(178, 155);
            this.TextboxCredito.Margin = new System.Windows.Forms.Padding(4);
            this.TextboxCredito.Name = "TextboxCredito";
            this.TextboxCredito.Size = new System.Drawing.Size(237, 48);
            this.TextboxCredito.TabIndex = 7;
            this.TextboxCredito.Text = "0";
            this.TextboxCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxCredito.Visible = false;
            this.TextboxCredito.OnValueChanged += new System.EventHandler(this.TextboxCredito_OnValueChanged);
            // 
            // TextboxEfectivo
            // 
            this.TextboxEfectivo.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxEfectivo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxEfectivo.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxEfectivo.BorderThickness = 3;
            this.TextboxEfectivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxEfectivo.Enabled = false;
            this.TextboxEfectivo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextboxEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxEfectivo.isPassword = false;
            this.TextboxEfectivo.Location = new System.Drawing.Point(178, 47);
            this.TextboxEfectivo.Margin = new System.Windows.Forms.Padding(4);
            this.TextboxEfectivo.Name = "TextboxEfectivo";
            this.TextboxEfectivo.Size = new System.Drawing.Size(237, 48);
            this.TextboxEfectivo.TabIndex = 3;
            this.TextboxEfectivo.Text = "0";
            this.TextboxEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxEfectivo.Visible = false;
            this.TextboxEfectivo.OnValueChanged += new System.EventHandler(this.TextboxEfectivo_OnValueChanged);
            // 
            // TextboxDatafono
            // 
            this.TextboxDatafono.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxDatafono.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxDatafono.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxDatafono.BorderThickness = 3;
            this.TextboxDatafono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxDatafono.Enabled = false;
            this.TextboxDatafono.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextboxDatafono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxDatafono.isPassword = false;
            this.TextboxDatafono.Location = new System.Drawing.Point(178, 99);
            this.TextboxDatafono.Margin = new System.Windows.Forms.Padding(4);
            this.TextboxDatafono.Name = "TextboxDatafono";
            this.TextboxDatafono.Size = new System.Drawing.Size(237, 48);
            this.TextboxDatafono.TabIndex = 5;
            this.TextboxDatafono.Text = "0";
            this.TextboxDatafono.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxDatafono.Visible = false;
            this.TextboxDatafono.OnValueChanged += new System.EventHandler(this.TextboxDatafono_OnValueChanged);
            // 
            // labelPagoCon
            // 
            this.labelPagoCon.AutoSize = true;
            this.labelPagoCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPagoCon.Location = new System.Drawing.Point(21, 426);
            this.labelPagoCon.Name = "labelPagoCon";
            this.labelPagoCon.Size = new System.Drawing.Size(72, 24);
            this.labelPagoCon.TabIndex = 7;
            this.labelPagoCon.Text = "TOTAL";
            // 
            // labelPago
            // 
            this.labelPago.AutoSize = true;
            this.labelPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPago.Location = new System.Drawing.Point(21, 10);
            this.labelPago.Name = "labelPago";
            this.labelPago.Size = new System.Drawing.Size(149, 24);
            this.labelPago.TabIndex = 1;
            this.labelPago.Text = "Método de pago";
            // 
            // TextboxPago
            // 
            this.TextboxPago.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxPago.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxPago.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxPago.BorderThickness = 3;
            this.TextboxPago.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxPago.Enabled = false;
            this.TextboxPago.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxPago.isPassword = false;
            this.TextboxPago.Location = new System.Drawing.Point(179, 406);
            this.TextboxPago.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.TextboxPago.Name = "TextboxPago";
            this.TextboxPago.Size = new System.Drawing.Size(236, 48);
            this.TextboxPago.TabIndex = 84;
            this.TextboxPago.Text = "0";
            this.TextboxPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxPago.OnValueChanged += new System.EventHandler(this.TextboxPago_OnValueChanged);
            // 
            // ButtonEfectivo
            // 
            this.ButtonEfectivo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonEfectivo.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonEfectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonEfectivo.BorderRadius = 0;
            this.ButtonEfectivo.ButtonText = "EFECTIVO";
            this.ButtonEfectivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEfectivo.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonEfectivo.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonEfectivo.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonEfectivo.Iconimage")));
            this.ButtonEfectivo.Iconimage_right = null;
            this.ButtonEfectivo.Iconimage_right_Selected = null;
            this.ButtonEfectivo.Iconimage_Selected = null;
            this.ButtonEfectivo.IconMarginLeft = 0;
            this.ButtonEfectivo.IconMarginRight = 0;
            this.ButtonEfectivo.IconRightVisible = true;
            this.ButtonEfectivo.IconRightZoom = 0D;
            this.ButtonEfectivo.IconVisible = true;
            this.ButtonEfectivo.IconZoom = 90D;
            this.ButtonEfectivo.IsTab = false;
            this.ButtonEfectivo.Location = new System.Drawing.Point(17, 47);
            this.ButtonEfectivo.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonEfectivo.Name = "ButtonEfectivo";
            this.ButtonEfectivo.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.ButtonEfectivo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ButtonEfectivo.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonEfectivo.selected = false;
            this.ButtonEfectivo.Size = new System.Drawing.Size(153, 48);
            this.ButtonEfectivo.TabIndex = 2;
            this.ButtonEfectivo.Text = "EFECTIVO";
            this.ButtonEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEfectivo.Textcolor = System.Drawing.Color.White;
            this.ButtonEfectivo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEfectivo.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // ButtonDatafono
            // 
            this.ButtonDatafono.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonDatafono.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonDatafono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDatafono.BorderRadius = 0;
            this.ButtonDatafono.ButtonText = "DATAFONO";
            this.ButtonDatafono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDatafono.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonDatafono.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonDatafono.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonDatafono.Iconimage")));
            this.ButtonDatafono.Iconimage_right = null;
            this.ButtonDatafono.Iconimage_right_Selected = null;
            this.ButtonDatafono.Iconimage_Selected = null;
            this.ButtonDatafono.IconMarginLeft = 0;
            this.ButtonDatafono.IconMarginRight = 0;
            this.ButtonDatafono.IconRightVisible = true;
            this.ButtonDatafono.IconRightZoom = 0D;
            this.ButtonDatafono.IconVisible = true;
            this.ButtonDatafono.IconZoom = 90D;
            this.ButtonDatafono.IsTab = false;
            this.ButtonDatafono.Location = new System.Drawing.Point(17, 99);
            this.ButtonDatafono.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDatafono.Name = "ButtonDatafono";
            this.ButtonDatafono.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.ButtonDatafono.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ButtonDatafono.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonDatafono.selected = false;
            this.ButtonDatafono.Size = new System.Drawing.Size(153, 48);
            this.ButtonDatafono.TabIndex = 4;
            this.ButtonDatafono.Text = "DATAFONO";
            this.ButtonDatafono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDatafono.Textcolor = System.Drawing.Color.White;
            this.ButtonDatafono.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDatafono.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // ButtonApartado
            // 
            this.ButtonApartado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonApartado.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonApartado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonApartado.BorderRadius = 0;
            this.ButtonApartado.ButtonText = "APARTADO";
            this.ButtonApartado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonApartado.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonApartado.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonApartado.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonApartado.Iconimage")));
            this.ButtonApartado.Iconimage_right = null;
            this.ButtonApartado.Iconimage_right_Selected = null;
            this.ButtonApartado.Iconimage_Selected = null;
            this.ButtonApartado.IconMarginLeft = 0;
            this.ButtonApartado.IconMarginRight = 0;
            this.ButtonApartado.IconRightVisible = true;
            this.ButtonApartado.IconRightZoom = 0D;
            this.ButtonApartado.IconVisible = true;
            this.ButtonApartado.IconZoom = 90D;
            this.ButtonApartado.IsTab = false;
            this.ButtonApartado.Location = new System.Drawing.Point(13, 211);
            this.ButtonApartado.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonApartado.Name = "ButtonApartado";
            this.ButtonApartado.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.ButtonApartado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ButtonApartado.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonApartado.selected = false;
            this.ButtonApartado.Size = new System.Drawing.Size(153, 48);
            this.ButtonApartado.TabIndex = 10;
            this.ButtonApartado.Text = "APARTADO";
            this.ButtonApartado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonApartado.Textcolor = System.Drawing.Color.White;
            this.ButtonApartado.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonApartado.Click += new System.EventHandler(this.bunifuFlatButton4_Click);
            // 
            // ButtonCredito
            // 
            this.ButtonCredito.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonCredito.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonCredito.BorderRadius = 0;
            this.ButtonCredito.ButtonText = "CREDITO";
            this.ButtonCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCredito.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonCredito.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonCredito.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonCredito.Iconimage")));
            this.ButtonCredito.Iconimage_right = null;
            this.ButtonCredito.Iconimage_right_Selected = null;
            this.ButtonCredito.Iconimage_Selected = null;
            this.ButtonCredito.IconMarginLeft = 0;
            this.ButtonCredito.IconMarginRight = 0;
            this.ButtonCredito.IconRightVisible = true;
            this.ButtonCredito.IconRightZoom = 0D;
            this.ButtonCredito.IconVisible = true;
            this.ButtonCredito.IconZoom = 90D;
            this.ButtonCredito.IsTab = false;
            this.ButtonCredito.Location = new System.Drawing.Point(17, 155);
            this.ButtonCredito.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonCredito.Name = "ButtonCredito";
            this.ButtonCredito.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.ButtonCredito.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ButtonCredito.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonCredito.selected = false;
            this.ButtonCredito.Size = new System.Drawing.Size(153, 48);
            this.ButtonCredito.TabIndex = 6;
            this.ButtonCredito.Text = "CREDITO";
            this.ButtonCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCredito.Textcolor = System.Drawing.Color.White;
            this.ButtonCredito.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCredito.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.bunifuFlatButton2);
            this.panel2.Controls.Add(this.labelCiudad);
            this.panel2.Controls.Add(this.labelFactura2);
            this.panel2.Controls.Add(this.bunifuThinButton21);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TextboxCambio);
            this.panel2.Controls.Add(this.labelTotal);
            this.panel2.Location = new System.Drawing.Point(424, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 455);
            this.panel2.TabIndex = 6;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.DodgerBlue;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "ACEPTAR";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(691, 402);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.DodgerBlue;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(153, 48);
            this.bunifuFlatButton2.TabIndex = 91;
            this.bunifuFlatButton2.Text = "ACEPTAR";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click_1);
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCiudad.Location = new System.Drawing.Point(6, 422);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(90, 29);
            this.labelCiudad.TabIndex = 90;
            this.labelCiudad.Text = "Ciudad";
            // 
            // labelFactura2
            // 
            this.labelFactura2.AutoSize = true;
            this.labelFactura2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFactura2.Location = new System.Drawing.Point(3, 9);
            this.labelFactura2.Name = "labelFactura2";
            this.labelFactura2.Size = new System.Drawing.Size(93, 29);
            this.labelFactura2.TabIndex = 89;
            this.labelFactura2.Text = "Factura";
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.Color.White;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "ACEPTAR";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.Location = new System.Drawing.Point(891, 358);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(106, 41);
            this.bunifuThinButton21.TabIndex = 31;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 87;
            this.label2.Text = "Su cambio es";
            // 
            // TextboxCambio
            // 
            this.TextboxCambio.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextboxCambio.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxCambio.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextboxCambio.BorderThickness = 3;
            this.TextboxCambio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextboxCambio.Enabled = false;
            this.TextboxCambio.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextboxCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextboxCambio.isPassword = false;
            this.TextboxCambio.Location = new System.Drawing.Point(6, 172);
            this.TextboxCambio.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.TextboxCambio.Name = "TextboxCambio";
            this.TextboxCambio.Size = new System.Drawing.Size(838, 150);
            this.TextboxCambio.TabIndex = 86;
            this.TextboxCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextboxCambio.OnValueChanged += new System.EventHandler(this.TextboxCambio_OnValueChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(348, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(114, 55);
            this.labelTotal.TabIndex = 85;
            this.labelTotal.Text = "total";
            this.labelTotal.Click += new System.EventHandler(this.labelTotal_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 493);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "Form2";
            this.Text = "metodo de pago";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonEfectivo;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonDatafono;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonApartado;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonCredito;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.Label labelPago;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelPagoCon;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxPago;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxCambio;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxCredito;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxEfectivo;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxDatafono;
        private Bunifu.Framework.UI.BunifuMetroTextbox TextboxApartado;
        private Bunifu.Framework.UI.BunifuFlatButton Button;
        public System.Windows.Forms.Label labelFactura2;
        public System.Windows.Forms.Label labelCiudad;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
    }
}