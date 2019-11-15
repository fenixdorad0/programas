namespace MysqlTienda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textFactura = new System.Windows.Forms.TextBox();
            this.labelFactura = new System.Windows.Forms.Label();
            this.modificar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textInsertarCodigo = new System.Windows.Forms.TextBox();
            this.insertar = new System.Windows.Forms.Button();
            this.textSumaTotal = new System.Windows.Forms.TextBox();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.buniRegistro = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.buniTextPass = new Bunifu.Framework.UI.BunifuTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.buniTextUsuario = new Bunifu.Framework.UI.BunifuTextbox();
            this.buniBtnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuGauge1 = new Bunifu.Framework.UI.BunifuGauge();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.buniCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.buniMaxMin = new Bunifu.Framework.UI.BunifuImageButton();
            this.buniBnFinalizar = new Bunifu.Framework.UI.BunifuTileButton();
            this.label9 = new System.Windows.Forms.Label();
            this.textReferencia = new System.Windows.Forms.TextBox();
            this.textTamano = new System.Windows.Forms.TextBox();
            this.textProducto = new System.Windows.Forms.TextBox();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.labelReferencia = new System.Windows.Forms.Label();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.labelProducto = new System.Windows.Forms.Label();
            this.labelTamaño = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buniActualizar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.textId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.bunifuEliminar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.bunifuGradientPanel2.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buniCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buniMaxMin)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFactura
            // 
            this.textFactura.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.textFactura, "textFactura");
            this.textFactura.Name = "textFactura";
            this.textFactura.ReadOnly = true;
            this.textFactura.TextChanged += new System.EventHandler(this.textFactura_TextChanged);
            // 
            // labelFactura
            // 
            resources.ApplyResources(this.labelFactura, "labelFactura");
            this.labelFactura.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelFactura.Name = "labelFactura";
            // 
            // modificar
            // 
            resources.ApplyResources(this.modificar, "modificar");
            this.modificar.Name = "modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // buscar
            // 
            resources.ApplyResources(this.buscar, "buscar");
            this.buscar.Name = "buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // textInsertarCodigo
            // 
            resources.ApplyResources(this.textInsertarCodigo, "textInsertarCodigo");
            this.textInsertarCodigo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textInsertarCodigo.Name = "textInsertarCodigo";
            this.textInsertarCodigo.TextChanged += new System.EventHandler(this.textCodigo_TextChanged_1);
            // 
            // insertar
            // 
            resources.ApplyResources(this.insertar, "insertar");
            this.insertar.Name = "insertar";
            this.insertar.UseVisualStyleBackColor = true;
            this.insertar.Click += new System.EventHandler(this.insertar_Click);
            // 
            // textSumaTotal
            // 
            resources.ApplyResources(this.textSumaTotal, "textSumaTotal");
            this.textSumaTotal.Name = "textSumaTotal";
            this.textSumaTotal.ReadOnly = true;
            this.textSumaTotal.TabStop = false;
            // 
            // bunifuCustomDataGrid1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.NullValue = null;
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.GridColor = System.Drawing.Color.Ivory;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.bunifuCustomDataGrid1, "bunifuCustomDataGrid1");
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellContentClick);
            this.bunifuCustomDataGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellContentClick);
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.bunifuGradientPanel2, "bunifuGradientPanel2");
            this.bunifuGradientPanel2.Controls.Add(this.buniRegistro);
            this.bunifuGradientPanel2.Controls.Add(this.bunifuProgressBar1);
            this.bunifuGradientPanel2.Controls.Add(this.buniTextPass);
            this.bunifuGradientPanel2.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel2.Controls.Add(this.buniTextUsuario);
            this.bunifuGradientPanel2.Controls.Add(this.buniBtnLogin);
            this.bunifuGradientPanel2.Controls.Add(this.bunifuGauge1);
            this.bunifuGradientPanel2.Controls.Add(this.label1);
            this.bunifuGradientPanel2.Controls.Add(this.textInsertarCodigo);
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.Gainsboro;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.WhiteSmoke;
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel2_Paint);
            // 
            // buniRegistro
            // 
            this.buniRegistro.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            resources.ApplyResources(this.buniRegistro, "buniRegistro");
            this.buniRegistro.BorderRadius = 0;
            this.buniRegistro.ButtonText = "Registrar";
            this.buniRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buniRegistro.DisabledColor = System.Drawing.Color.Gray;
            this.buniRegistro.Iconcolor = System.Drawing.Color.Transparent;
            this.buniRegistro.Iconimage = ((System.Drawing.Image)(resources.GetObject("buniRegistro.Iconimage")));
            this.buniRegistro.Iconimage_right = null;
            this.buniRegistro.Iconimage_right_Selected = null;
            this.buniRegistro.Iconimage_Selected = null;
            this.buniRegistro.IconMarginLeft = 0;
            this.buniRegistro.IconMarginRight = 0;
            this.buniRegistro.IconRightVisible = true;
            this.buniRegistro.IconRightZoom = 0D;
            this.buniRegistro.IconVisible = true;
            this.buniRegistro.IconZoom = 90D;
            this.buniRegistro.IsTab = false;
            this.buniRegistro.Name = "buniRegistro";
            this.buniRegistro.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniRegistro.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.buniRegistro.OnHoverTextColor = System.Drawing.Color.White;
            this.buniRegistro.selected = false;
            this.buniRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buniRegistro.Textcolor = System.Drawing.Color.White;
            this.buniRegistro.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
            this.bunifuProgressBar1.BorderRadius = 5;
            resources.ApplyResources(this.bunifuProgressBar1, "bunifuProgressBar1");
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
            this.bunifuProgressBar1.Value = 0;
            // 
            // buniTextPass
            // 
            this.buniTextPass.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buniTextPass, "buniTextPass");
            this.buniTextPass.ForeColor = System.Drawing.Color.Teal;
            this.buniTextPass.Icon = ((System.Drawing.Image)(resources.GetObject("buniTextPass.Icon")));
            this.buniTextPass.Name = "buniTextPass";
            this.buniTextPass.text = "Contraseña";
            // 
            // bunifuCustomLabel1
            // 
            resources.ApplyResources(this.bunifuCustomLabel1, "bunifuCustomLabel1");
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            // 
            // buniTextUsuario
            // 
            this.buniTextUsuario.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buniTextUsuario, "buniTextUsuario");
            this.buniTextUsuario.ForeColor = System.Drawing.Color.Teal;
            this.buniTextUsuario.Icon = ((System.Drawing.Image)(resources.GetObject("buniTextUsuario.Icon")));
            this.buniTextUsuario.Name = "buniTextUsuario";
            this.buniTextUsuario.text = "Usuario";
            // 
            // buniBtnLogin
            // 
            this.buniBtnLogin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniBtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            resources.ApplyResources(this.buniBtnLogin, "buniBtnLogin");
            this.buniBtnLogin.BorderRadius = 0;
            this.buniBtnLogin.ButtonText = "Login";
            this.buniBtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buniBtnLogin.DisabledColor = System.Drawing.Color.Gray;
            this.buniBtnLogin.Iconcolor = System.Drawing.Color.Transparent;
            this.buniBtnLogin.Iconimage = ((System.Drawing.Image)(resources.GetObject("buniBtnLogin.Iconimage")));
            this.buniBtnLogin.Iconimage_right = null;
            this.buniBtnLogin.Iconimage_right_Selected = null;
            this.buniBtnLogin.Iconimage_Selected = null;
            this.buniBtnLogin.IconMarginLeft = 0;
            this.buniBtnLogin.IconMarginRight = 0;
            this.buniBtnLogin.IconRightVisible = true;
            this.buniBtnLogin.IconRightZoom = 0D;
            this.buniBtnLogin.IconVisible = true;
            this.buniBtnLogin.IconZoom = 90D;
            this.buniBtnLogin.IsTab = false;
            this.buniBtnLogin.Name = "buniBtnLogin";
            this.buniBtnLogin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniBtnLogin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.buniBtnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.buniBtnLogin.selected = false;
            this.buniBtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buniBtnLogin.Textcolor = System.Drawing.Color.White;
            this.buniBtnLogin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buniBtnLogin.Click += new System.EventHandler(this.buniBtnLogin_Click);
            // 
            // bunifuGauge1
            // 
            resources.ApplyResources(this.bunifuGauge1, "bunifuGauge1");
            this.bunifuGauge1.Name = "bunifuGauge1";
            this.bunifuGauge1.ProgressBgColor = System.Drawing.Color.Gray;
            this.bunifuGauge1.ProgressColor1 = System.Drawing.Color.SeaGreen;
            this.bunifuGauge1.ProgressColor2 = System.Drawing.Color.Tomato;
            this.bunifuGauge1.Suffix = "";
            this.bunifuGauge1.Thickness = 30;
            this.bunifuGauge1.Value = 0;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(11)))), ((int)(((byte)(43)))));
            resources.ApplyResources(this.bunifuGradientPanel1, "bunifuGradientPanel1");
            this.bunifuGradientPanel1.Controls.Add(this.buniCerrar);
            this.bunifuGradientPanel1.Controls.Add(this.buniMaxMin);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.SeaGreen;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.SeaGreen;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.SeaGreen;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.SeaGreen;
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseDown);
            this.bunifuGradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseMove);
            this.bunifuGradientPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseUp);
            // 
            // buniCerrar
            // 
            resources.ApplyResources(this.buniCerrar, "buniCerrar");
            this.buniCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.buniCerrar.ImageActive = null;
            this.buniCerrar.Name = "buniCerrar";
            this.buniCerrar.TabStop = false;
            this.buniCerrar.Zoom = 10;
            this.buniCerrar.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // buniMaxMin
            // 
            resources.ApplyResources(this.buniMaxMin, "buniMaxMin");
            this.buniMaxMin.BackColor = System.Drawing.Color.SeaGreen;
            this.buniMaxMin.ImageActive = null;
            this.buniMaxMin.Name = "buniMaxMin";
            this.buniMaxMin.TabStop = false;
            this.buniMaxMin.Zoom = 10;
            this.buniMaxMin.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // buniBnFinalizar
            // 
            this.buniBnFinalizar.BackColor = System.Drawing.Color.SeaGreen;
            this.buniBnFinalizar.color = System.Drawing.Color.SeaGreen;
            this.buniBnFinalizar.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.buniBnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.buniBnFinalizar, "buniBnFinalizar");
            this.buniBnFinalizar.ForeColor = System.Drawing.Color.White;
            this.buniBnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("buniBnFinalizar.Image")));
            this.buniBnFinalizar.ImagePosition = 20;
            this.buniBnFinalizar.ImageZoom = 50;
            this.buniBnFinalizar.LabelPosition = 41;
            this.buniBnFinalizar.LabelText = "Finalizar";
            this.buniBnFinalizar.Name = "buniBnFinalizar";
            this.buniBnFinalizar.Click += new System.EventHandler(this.finalizar_Click_1);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Name = "label9";
            // 
            // textReferencia
            // 
            resources.ApplyResources(this.textReferencia, "textReferencia");
            this.textReferencia.Name = "textReferencia";
            this.textReferencia.ReadOnly = true;
            // 
            // textTamano
            // 
            resources.ApplyResources(this.textTamano, "textTamano");
            this.textTamano.Name = "textTamano";
            this.textTamano.ReadOnly = true;
            // 
            // textProducto
            // 
            resources.ApplyResources(this.textProducto, "textProducto");
            this.textProducto.Name = "textProducto";
            this.textProducto.ReadOnly = true;
            // 
            // textCantidad
            // 
            resources.ApplyResources(this.textCantidad, "textCantidad");
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.ReadOnly = true;
            // 
            // textPrecio
            // 
            resources.ApplyResources(this.textPrecio, "textPrecio");
            this.textPrecio.Name = "textPrecio";
            // 
            // labelReferencia
            // 
            resources.ApplyResources(this.labelReferencia, "labelReferencia");
            this.labelReferencia.BackColor = System.Drawing.Color.White;
            this.labelReferencia.ForeColor = System.Drawing.Color.Black;
            this.labelReferencia.Name = "labelReferencia";
            // 
            // labelCantidad
            // 
            resources.ApplyResources(this.labelCantidad, "labelCantidad");
            this.labelCantidad.BackColor = System.Drawing.Color.White;
            this.labelCantidad.ForeColor = System.Drawing.Color.Black;
            this.labelCantidad.Name = "labelCantidad";
            // 
            // labelProducto
            // 
            resources.ApplyResources(this.labelProducto, "labelProducto");
            this.labelProducto.BackColor = System.Drawing.Color.White;
            this.labelProducto.ForeColor = System.Drawing.Color.Black;
            this.labelProducto.Name = "labelProducto";
            // 
            // labelTamaño
            // 
            resources.ApplyResources(this.labelTamaño, "labelTamaño");
            this.labelTamaño.BackColor = System.Drawing.Color.White;
            this.labelTamaño.ForeColor = System.Drawing.Color.Black;
            this.labelTamaño.Name = "labelTamaño";
            // 
            // labelPrecio
            // 
            resources.ApplyResources(this.labelPrecio, "labelPrecio");
            this.labelPrecio.BackColor = System.Drawing.Color.White;
            this.labelPrecio.ForeColor = System.Drawing.Color.Black;
            this.labelPrecio.Name = "labelPrecio";
            // 
            // textTotal
            // 
            resources.ApplyResources(this.textTotal, "textTotal");
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            // 
            // labelTotal
            // 
            resources.ApplyResources(this.labelTotal, "labelTotal");
            this.labelTotal.BackColor = System.Drawing.Color.White;
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Name = "labelTotal";
            // 
            // buniActualizar
            // 
            this.buniActualizar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            resources.ApplyResources(this.buniActualizar, "buniActualizar");
            this.buniActualizar.BorderRadius = 0;
            this.buniActualizar.ButtonText = "Modificar dato";
            this.buniActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buniActualizar.DisabledColor = System.Drawing.Color.Gray;
            this.buniActualizar.Iconcolor = System.Drawing.Color.Transparent;
            this.buniActualizar.Iconimage = ((System.Drawing.Image)(resources.GetObject("buniActualizar.Iconimage")));
            this.buniActualizar.Iconimage_right = null;
            this.buniActualizar.Iconimage_right_Selected = null;
            this.buniActualizar.Iconimage_Selected = null;
            this.buniActualizar.IconMarginLeft = 0;
            this.buniActualizar.IconMarginRight = 0;
            this.buniActualizar.IconRightVisible = true;
            this.buniActualizar.IconRightZoom = 0D;
            this.buniActualizar.IconVisible = true;
            this.buniActualizar.IconZoom = 90D;
            this.buniActualizar.IsTab = false;
            this.buniActualizar.Name = "buniActualizar";
            this.buniActualizar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buniActualizar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.buniActualizar.OnHoverTextColor = System.Drawing.Color.White;
            this.buniActualizar.selected = false;
            this.buniActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buniActualizar.Textcolor = System.Drawing.Color.White;
            this.buniActualizar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buniActualizar.Click += new System.EventHandler(this.buniActualizar_Click);
            // 
            // textId
            // 
            resources.ApplyResources(this.textId, "textId");
            this.textId.Name = "textId";
            this.textId.TextChanged += new System.EventHandler(this.textCodigo_TextChanged_1);
            // 
            // labelId
            // 
            resources.ApplyResources(this.labelId, "labelId");
            this.labelId.BackColor = System.Drawing.Color.White;
            this.labelId.ForeColor = System.Drawing.Color.Black;
            this.labelId.Name = "labelId";
            // 
            // textCodigo
            // 
            resources.ApplyResources(this.textCodigo, "textCodigo");
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.ReadOnly = true;
            // 
            // labelCodigo
            // 
            resources.ApplyResources(this.labelCodigo, "labelCodigo");
            this.labelCodigo.BackColor = System.Drawing.Color.White;
            this.labelCodigo.ForeColor = System.Drawing.Color.Black;
            this.labelCodigo.Name = "labelCodigo";
            // 
            // bunifuEliminar
            // 
            this.bunifuEliminar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            resources.ApplyResources(this.bunifuEliminar, "bunifuEliminar");
            this.bunifuEliminar.BorderRadius = 0;
            this.bunifuEliminar.ButtonText = "Eliminar";
            this.bunifuEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuEliminar.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuEliminar.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuEliminar.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuEliminar.Iconimage")));
            this.bunifuEliminar.Iconimage_right = null;
            this.bunifuEliminar.Iconimage_right_Selected = null;
            this.bunifuEliminar.Iconimage_Selected = null;
            this.bunifuEliminar.IconMarginLeft = 0;
            this.bunifuEliminar.IconMarginRight = 0;
            this.bunifuEliminar.IconRightVisible = true;
            this.bunifuEliminar.IconRightZoom = 0D;
            this.bunifuEliminar.IconVisible = true;
            this.bunifuEliminar.IconZoom = 90D;
            this.bunifuEliminar.IsTab = false;
            this.bunifuEliminar.Name = "bunifuEliminar";
            this.bunifuEliminar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuEliminar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuEliminar.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuEliminar.selected = false;
            this.bunifuEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuEliminar.Textcolor = System.Drawing.Color.White;
            this.bunifuEliminar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuEliminar.Click += new System.EventHandler(this.bunifuEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuEliminar);
            this.panel1.Controls.Add(this.buniActualizar);
            this.panel1.Controls.Add(this.labelCodigo);
            this.panel1.Controls.Add(this.textSumaTotal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.modificar);
            this.panel1.Controls.Add(this.buniBnFinalizar);
            this.panel1.Controls.Add(this.buscar);
            this.panel1.Controls.Add(this.textId);
            this.panel1.Controls.Add(this.insertar);
            this.panel1.Controls.Add(this.textCodigo);
            this.panel1.Controls.Add(this.bunifuCustomDataGrid1);
            this.panel1.Controls.Add(this.textReferencia);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.textFactura);
            this.panel1.Controls.Add(this.textTamano);
            this.panel1.Controls.Add(this.labelFactura);
            this.panel1.Controls.Add(this.textProducto);
            this.panel1.Controls.Add(this.textCantidad);
            this.panel1.Controls.Add(this.textPrecio);
            this.panel1.Controls.Add(this.labelReferencia);
            this.panel1.Controls.Add(this.labelCantidad);
            this.panel1.Controls.Add(this.labelProducto);
            this.panel1.Controls.Add(this.labelTamaño);
            this.panel1.Controls.Add(this.labelPrecio);
            this.panel1.Controls.Add(this.textTotal);
            this.panel1.Controls.Add(this.labelTotal);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buniCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buniMaxMin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textFactura;
        private System.Windows.Forms.Label labelFactura;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textInsertarCodigo;
        private System.Windows.Forms.Button insertar;
        private System.Windows.Forms.TextBox textSumaTotal;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuTileButton buniBnFinalizar;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuGauge bunifuGauge1;
        private Bunifu.Framework.UI.BunifuFlatButton buniBtnLogin;
        private Bunifu.Framework.UI.BunifuTextbox buniTextPass;
        private Bunifu.Framework.UI.BunifuTextbox buniTextUsuario;
        private Bunifu.Framework.UI.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textReferencia;
        private System.Windows.Forms.TextBox textTamano;
        private System.Windows.Forms.TextBox textProducto;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.Label labelReferencia;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.Label labelProducto;
        private System.Windows.Forms.Label labelTamaño;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label labelTotal;
        private Bunifu.Framework.UI.BunifuFlatButton buniActualizar;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label labelCodigo;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuEliminar;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton buniMaxMin;
        private Bunifu.Framework.UI.BunifuImageButton buniCerrar;
        private Bunifu.Framework.UI.BunifuFlatButton buniRegistro;
    }
}

