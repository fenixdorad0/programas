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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartOrdenado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chartBusqeda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.text2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.text1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.valBuscado = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.textBox1 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.textCreditos = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnComenzar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrdenado)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBusqeda)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Crimson;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(1026, 0);
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
            this.bunifuImageButton2.Location = new System.Drawing.Point(187, 27);
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
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("36 days ago Thick BRK", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.AliceBlue;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(482, 27);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(128, 29);
            this.bunifuCustomLabel6.TabIndex = 10;
            this.bunifuCustomLabel6.Text = "heapsort";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.tabControl1);
            this.bunifuGradientPanel1.Controls.Add(this.text2);
            this.bunifuGradientPanel1.Controls.Add(this.text1);
            this.bunifuGradientPanel1.Controls.Add(this.valBuscado);
            this.bunifuGradientPanel1.Controls.Add(this.textBox1);
            this.bunifuGradientPanel1.Controls.Add(this.textCreditos);
            this.bunifuGradientPanel1.Controls.Add(this.btnComenzar);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuImageButton2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel6);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuImageButton1);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.ForestGreen;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Navy;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Turquoise;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1051, 586);
            this.bunifuGradientPanel1.TabIndex = 13;
            this.bunifuGradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(133, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 350);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartOrdenado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(770, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tiempoOrdenamiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartOrdenado
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOrdenado.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOrdenado.Legends.Add(legend1);
            this.chartOrdenado.Location = new System.Drawing.Point(6, 10);
            this.chartOrdenado.Name = "chartOrdenado";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "tiempos";
            this.chartOrdenado.Series.Add(series1);
            this.chartOrdenado.Size = new System.Drawing.Size(758, 300);
            this.chartOrdenado.TabIndex = 22;
            this.chartOrdenado.Text = "chart1";
            title1.Name = "tiempo (ms)";
            title1.Text = "tiempos(ms)";
            this.chartOrdenado.Titles.Add(title1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartBusqeda);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(770, 324);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tiempoBusqueda";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chartBusqeda
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBusqeda.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBusqeda.Legends.Add(legend2);
            this.chartBusqeda.Location = new System.Drawing.Point(6, 12);
            this.chartBusqeda.Name = "chartBusqeda";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "tiempos";
            this.chartBusqeda.Series.Add(series2);
            this.chartBusqeda.Size = new System.Drawing.Size(758, 300);
            this.chartBusqeda.TabIndex = 23;
            this.chartBusqeda.Text = "chart2";
            title2.Name = "tiempo (ms)";
            title2.Text = "tiempos(ms)";
            this.chartBusqeda.Titles.Add(title2);
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.BackColor = System.Drawing.Color.Transparent;
            this.text2.Font = new System.Drawing.Font("36 days ago Thick BRK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text2.ForeColor = System.Drawing.Color.AliceBlue;
            this.text2.Location = new System.Drawing.Point(550, 78);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(118, 19);
            this.text2.TabIndex = 20;
            this.text2.Text = "num buscado";
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.BackColor = System.Drawing.Color.Transparent;
            this.text1.Font = new System.Drawing.Font("36 days ago Thick BRK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text1.ForeColor = System.Drawing.Color.AliceBlue;
            this.text1.Location = new System.Drawing.Point(429, 78);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(113, 19);
            this.text1.TabIndex = 19;
            this.text1.Text = "long arreglo";
            // 
            // valBuscado
            // 
            this.valBuscado.BorderColor = System.Drawing.Color.SeaGreen;
            this.valBuscado.Location = new System.Drawing.Point(559, 100);
            this.valBuscado.Name = "valBuscado";
            this.valBuscado.Size = new System.Drawing.Size(100, 20);
            this.valBuscado.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.SeaGreen;
            this.textBox1.Location = new System.Drawing.Point(437, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textCreditos
            // 
            this.textCreditos.AutoSize = true;
            this.textCreditos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textCreditos.Location = new System.Drawing.Point(945, 558);
            this.textCreditos.Name = "textCreditos";
            this.textCreditos.Size = new System.Drawing.Size(92, 13);
            this.textCreditos.TabIndex = 15;
            this.textCreditos.Text = "Universidad Piloto";
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
            this.btnComenzar.Location = new System.Drawing.Point(354, 126);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnComenzar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnComenzar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnComenzar.selected = false;
            this.btnComenzar.Size = new System.Drawing.Size(391, 46);
            this.btnComenzar.TabIndex = 14;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnComenzar.Textcolor = System.Drawing.Color.White;
            this.btnComenzar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzar.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1074, 606);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartOrdenado)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBusqeda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuCustomLabel textCreditos;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox textBox1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox valBuscado;
        private Bunifu.Framework.UI.BunifuCustomLabel text1;
        private Bunifu.Framework.UI.BunifuFlatButton btnComenzar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOrdenado;
        private Bunifu.Framework.UI.BunifuCustomLabel text2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBusqeda;
    }
}

