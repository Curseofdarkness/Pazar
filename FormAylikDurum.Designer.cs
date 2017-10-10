namespace hal_otomasyon_v1
{
    partial class FormAylikDurum
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.hal_otomasyonuDataSet = new hal_otomasyon_v1.hal_otomasyonuDataSet();
            this.urunlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urunlerTableAdapter = new hal_otomasyon_v1.hal_otomasyonuDataSetTableAdapters.urunlerTableAdapter();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hal_otomasyonuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // hal_otomasyonuDataSet
            // 
            this.hal_otomasyonuDataSet.DataSetName = "hal_otomasyonuDataSet";
            this.hal_otomasyonuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // urunlerBindingSource
            // 
            this.urunlerBindingSource.DataMember = "urunler";
            this.urunlerBindingSource.DataSource = this.hal_otomasyonuDataSet;
            // 
            // urunlerTableAdapter
            // 
            this.urunlerTableAdapter.ClearBeforeFill = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.urunlerBindingSource;
            legend1.Name = "Legend1";
            legend1.TextWrapThreshold = 0;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(22, 71);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.Legend = "Legend1";
            series1.Name = "Ocak";
            series1.XValueMember = "cins_adi";
            series1.YValueMembers = "kar_ocak";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "DrawingStyle=Cylinder";
            series2.LabelBorderWidth = 100;
            series2.Legend = "Legend1";
            series2.Name = "Şubat";
            series2.XValueMember = "cins_adi";
            series2.YValueMembers = "kar_subat";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "DrawingStyle=Cylinder";
            series3.LabelBorderWidth = 100;
            series3.Legend = "Legend1";
            series3.Name = "Mart";
            series3.XValueMember = "cins_adi";
            series3.YValueMembers = "kar_mart";
            series4.ChartArea = "ChartArea1";
            series4.CustomProperties = "DrawingStyle=Cylinder";
            series4.LabelBorderWidth = 100;
            series4.Legend = "Legend1";
            series4.Name = "Nisan";
            series4.XValueMember = "cins_adi";
            series4.YValueMembers = "kar_nisan";
            series5.ChartArea = "ChartArea1";
            series5.CustomProperties = "DrawingStyle=Cylinder";
            series5.LabelBorderWidth = 100;
            series5.Legend = "Legend1";
            series5.Name = "Mayıs";
            series5.XValueMember = "cins_adi";
            series5.YValueMembers = "kar_mayis";
            series6.ChartArea = "ChartArea1";
            series6.CustomProperties = "DrawingStyle=Cylinder";
            series6.LabelBorderWidth = 100;
            series6.Legend = "Legend1";
            series6.Name = "Haziran";
            series6.XValueMember = "cins_adi";
            series6.YValueMembers = "kar_haziran";
            series7.ChartArea = "ChartArea1";
            series7.CustomProperties = "DrawingStyle=Cylinder";
            series7.LabelBorderWidth = 100;
            series7.Legend = "Legend1";
            series7.Name = "Temmuz";
            series7.XValueMember = "cins_adi";
            series7.YValueMembers = "kar_temmuz";
            series8.ChartArea = "ChartArea1";
            series8.CustomProperties = "DrawingStyle=Cylinder";
            series8.LabelBorderWidth = 100;
            series8.Legend = "Legend1";
            series8.Name = "Ağustos";
            series8.XValueMember = "cins_adi";
            series8.YValueMembers = "kar_agustos";
            series9.ChartArea = "ChartArea1";
            series9.CustomProperties = "DrawingStyle=Cylinder";
            series9.LabelBorderWidth = 100;
            series9.Legend = "Legend1";
            series9.Name = "Eylül";
            series9.XValueMember = "cins_adi";
            series9.YValueMembers = "kar_eylul";
            series10.ChartArea = "ChartArea1";
            series10.CustomProperties = "DrawingStyle=Cylinder";
            series10.LabelBorderWidth = 100;
            series10.Legend = "Legend1";
            series10.Name = "Ekim";
            series10.XValueMember = "cins_adi";
            series10.YValueMembers = "kar_ekim";
            series11.ChartArea = "ChartArea1";
            series11.CustomProperties = "DrawingStyle=Cylinder";
            series11.LabelBorderWidth = 100;
            series11.Legend = "Legend1";
            series11.Name = "Kasım";
            series11.XValueMember = "cins_adi";
            series11.YValueMembers = "kar_kasim";
            series12.ChartArea = "ChartArea1";
            series12.CustomProperties = "DrawingStyle=Cylinder";
            series12.LabelBorderWidth = 100;
            series12.Legend = "Legend1";
            series12.Name = "Aralık";
            series12.XValueMember = "cins_adi";
            series12.YValueMembers = "kar_aralik";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(1564, 667);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Seçiniz:";
            // 
            // FormAylikDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 710);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.comboBox1);
            this.Name = "FormAylikDurum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aylık Durum Analizi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAylikDurum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hal_otomasyonuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private hal_otomasyonuDataSet hal_otomasyonuDataSet;
        private System.Windows.Forms.BindingSource urunlerBindingSource;
        private hal_otomasyonuDataSetTableAdapters.urunlerTableAdapter urunlerTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;

    }
}