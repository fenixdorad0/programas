namespace Ping_LoL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.metodo = new System.Windows.Forms.ComboBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.textTop1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.texto = new System.Windows.Forms.RichTextBox();
            this.bunifuVTrackbar1 = new Bunifu.Framework.UI.BunifuVTrackbar();
            this.doubleBitmapControl1 = new BunifuAnimatorNS.DoubleBitmapControl();
            this.bunifuRange1 = new Bunifu.Framework.UI.BunifuRange();
            this.textBox1 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.textCreditos = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnComenzar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuWebClient1 = new Bunifu.Framework.UI.BunifuWebClient(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.textTop2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox2 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.textTop3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox3 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Crimson;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(943, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(25, 27);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 8;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 20;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.InitialImage = global::Ping_LoL.Properties.Resources.LOGO__1;
            this.bunifuImageButton2.Location = new System.Drawing.Point(19, 12);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(137, 157);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 9;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 8;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("36 days ago Thick BRK", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.AliceBlue;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(225, 56);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(600, 64);
            this.bunifuCustomLabel6.TabIndex = 10;
            this.bunifuCustomLabel6.Text = "Programa de redes";
            // 
            // metodo
            // 
            this.metodo.FormattingEnabled = true;
            this.metodo.Items.AddRange(new object[] {
            "agregar vlan",
            "borrar vlan",
            "modo access",
            "modo trunk",
            "estatica",
            "rip"});
            this.metodo.Location = new System.Drawing.Point(289, 180);
            this.metodo.Name = "metodo";
            this.metodo.Size = new System.Drawing.Size(119, 21);
            this.metodo.TabIndex = 12;
            this.metodo.SelectedValueChanged += new System.EventHandler(this.metodo_SelectedValueChanged);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.richTextBox1);
            this.bunifuGradientPanel1.Controls.Add(this.textTop3);
            this.bunifuGradientPanel1.Controls.Add(this.textBox3);
            this.bunifuGradientPanel1.Controls.Add(this.textTop2);
            this.bunifuGradientPanel1.Controls.Add(this.textBox2);
            this.bunifuGradientPanel1.Controls.Add(this.textTop1);
            this.bunifuGradientPanel1.Controls.Add(this.texto);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuVTrackbar1);
            this.bunifuGradientPanel1.Controls.Add(this.doubleBitmapControl1);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuRange1);
            this.bunifuGradientPanel1.Controls.Add(this.textBox1);
            this.bunifuGradientPanel1.Controls.Add(this.textCreditos);
            this.bunifuGradientPanel1.Controls.Add(this.btnComenzar);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuImageButton2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel6);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuImageButton1);
            this.bunifuGradientPanel1.Controls.Add(this.metodo);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.ForestGreen;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Navy;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Turquoise;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 7);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(976, 562);
            this.bunifuGradientPanel1.TabIndex = 13;
            this.bunifuGradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseMove);
            // 
            // textTop1
            // 
            this.textTop1.AutoSize = true;
            this.textTop1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textTop1.Location = new System.Drawing.Point(419, 165);
            this.textTop1.Name = "textTop1";
            this.textTop1.Size = new System.Drawing.Size(13, 13);
            this.textTop1.TabIndex = 22;
            this.textTop1.Text = "?";
            // 
            // texto
            // 
            this.texto.Location = new System.Drawing.Point(134, 206);
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(397, 254);
            this.texto.TabIndex = 21;
            this.texto.Text = "";
            // 
            // bunifuVTrackbar1
            // 
            this.bunifuVTrackbar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuVTrackbar1.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuVTrackbar1.BorderRadius = 0;
            this.bunifuVTrackbar1.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.bunifuVTrackbar1.Location = new System.Drawing.Point(-15, -22);
            this.bunifuVTrackbar1.MaximumValue = 100;
            this.bunifuVTrackbar1.Name = "bunifuVTrackbar1";
            this.bunifuVTrackbar1.Size = new System.Drawing.Size(28, 415);
            this.bunifuVTrackbar1.SliderRadius = 0;
            this.bunifuVTrackbar1.TabIndex = 20;
            this.bunifuVTrackbar1.Value = 0;
            // 
            // doubleBitmapControl1
            // 
            this.doubleBitmapControl1.Location = new System.Drawing.Point(-15, -22);
            this.doubleBitmapControl1.Name = "doubleBitmapControl1";
            this.doubleBitmapControl1.Size = new System.Drawing.Size(75, 23);
            this.doubleBitmapControl1.TabIndex = 19;
            this.doubleBitmapControl1.Text = "doubleBitmapControl1";
            this.doubleBitmapControl1.Visible = false;
            // 
            // bunifuRange1
            // 
            this.bunifuRange1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuRange1.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuRange1.BorderRadius = 0;
            this.bunifuRange1.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.bunifuRange1.Location = new System.Drawing.Point(-15, -22);
            this.bunifuRange1.MaximumRange = 100;
            this.bunifuRange1.Name = "bunifuRange1";
            this.bunifuRange1.RangeMax = 49;
            this.bunifuRange1.RangeMin = 0;
            this.bunifuRange1.Size = new System.Drawing.Size(415, 28);
            this.bunifuRange1.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.SeaGreen;
            this.textBox1.Location = new System.Drawing.Point(419, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textCreditos
            // 
            this.textCreditos.AutoSize = true;
            this.textCreditos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textCreditos.Location = new System.Drawing.Point(785, 545);
            this.textCreditos.Name = "textCreditos";
            this.textCreditos.Size = new System.Drawing.Size(184, 13);
            this.textCreditos.TabIndex = 15;
            this.textCreditos.Text = "Yeferson Quevedo Universidad Piloto";
            // 
            // btnComenzar
            // 
            this.btnComenzar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnComenzar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnComenzar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComenzar.BorderRadius = 0;
            this.btnComenzar.ButtonText = "Comenzar";
            this.btnComenzar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComenzar.DisabledColor = System.Drawing.Color.Gray;
            this.btnComenzar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnComenzar.Iconimage = null;
            this.btnComenzar.Iconimage_right = null;
            this.btnComenzar.Iconimage_right_Selected = null;
            this.btnComenzar.Iconimage_Selected = null;
            this.btnComenzar.IconMarginLeft = 0;
            this.btnComenzar.IconMarginRight = 0;
            this.btnComenzar.IconRightVisible = true;
            this.btnComenzar.IconRightZoom = 0D;
            this.btnComenzar.IconVisible = true;
            this.btnComenzar.IconZoom = 90D;
            this.btnComenzar.IsTab = false;
            this.btnComenzar.Location = new System.Drawing.Point(373, 499);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnComenzar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnComenzar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnComenzar.selected = false;
            this.btnComenzar.Size = new System.Drawing.Size(234, 46);
            this.btnComenzar.TabIndex = 14;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComenzar.Textcolor = System.Drawing.Color.White;
            this.btnComenzar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzar.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // bunifuWebClient1
            // 
            this.bunifuWebClient1.AllowReadStreamBuffering = false;
            this.bunifuWebClient1.AllowWriteStreamBuffering = false;
            this.bunifuWebClient1.BaseAddress = "";
            this.bunifuWebClient1.CachePolicy = null;
            this.bunifuWebClient1.Credentials = null;
            this.bunifuWebClient1.Encoding = ((System.Text.Encoding)(resources.GetObject("bunifuWebClient1.Encoding")));
            this.bunifuWebClient1.Headers = ((System.Net.WebHeaderCollection)(resources.GetObject("bunifuWebClient1.Headers")));
            this.bunifuWebClient1.QueryString = ((System.Collections.Specialized.NameValueCollection)(resources.GetObject("bunifuWebClient1.QueryString")));
            this.bunifuWebClient1.UseDefaultCredentials = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // textTop2
            // 
            this.textTop2.AutoSize = true;
            this.textTop2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textTop2.Location = new System.Drawing.Point(519, 165);
            this.textTop2.Name = "textTop2";
            this.textTop2.Size = new System.Drawing.Size(13, 13);
            this.textTop2.TabIndex = 24;
            this.textTop2.Text = "?";
            // 
            // textBox2
            // 
            this.textBox2.BorderColor = System.Drawing.Color.SeaGreen;
            this.textBox2.Location = new System.Drawing.Point(519, 180);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 23;
            // 
            // textTop3
            // 
            this.textTop3.AutoSize = true;
            this.textTop3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textTop3.Location = new System.Drawing.Point(619, 165);
            this.textTop3.Name = "textTop3";
            this.textTop3.Size = new System.Drawing.Size(13, 13);
            this.textTop3.TabIndex = 26;
            this.textTop3.Text = "?";
            // 
            // textBox3
            // 
            this.textBox3.BorderColor = System.Drawing.Color.SeaGreen;
            this.textBox3.Location = new System.Drawing.Point(619, 180);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 25;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(537, 206);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(397, 254);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(976, 577);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private System.Windows.Forms.ComboBox metodo;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnComenzar;
        private Bunifu.Framework.UI.BunifuCustomLabel textCreditos;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox textBox1;
        private System.Windows.Forms.RichTextBox texto;
        private Bunifu.Framework.UI.BunifuVTrackbar bunifuVTrackbar1;
        private BunifuAnimatorNS.DoubleBitmapControl doubleBitmapControl1;
        private Bunifu.Framework.UI.BunifuRange bunifuRange1;
        private Bunifu.Framework.UI.BunifuWebClient bunifuWebClient1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel textTop1;
        private Bunifu.Framework.UI.BunifuCustomLabel textTop2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel textTop3;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox textBox3;
    }
}

