namespace Weather_Chart
{
    partial class Start
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.city_txt = new System.Windows.Forms.TextBox();
            this.area_radio = new System.Windows.Forms.RadioButton();
            this.line_radio = new System.Windows.Forms.RadioButton();
            this.step_radio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-4, -4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1215, 581);
            this.chart1.TabIndex = 0;
            this.chart1.TabStop = false;
            this.chart1.MouseHover += new System.EventHandler(this.chart1_MouseHover);
            // 
            // city_txt
            // 
            this.city_txt.BackColor = System.Drawing.SystemColors.Window;
            this.city_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.city_txt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.city_txt.Enabled = false;
            this.city_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city_txt.Location = new System.Drawing.Point(477, -4);
            this.city_txt.Multiline = true;
            this.city_txt.Name = "city_txt";
            this.city_txt.ReadOnly = true;
            this.city_txt.Size = new System.Drawing.Size(158, 36);
            this.city_txt.TabIndex = 1;
            // 
            // area_radio
            // 
            this.area_radio.AutoSize = true;
            this.area_radio.Location = new System.Drawing.Point(1117, 479);
            this.area_radio.Name = "area_radio";
            this.area_radio.Size = new System.Drawing.Size(47, 17);
            this.area_radio.TabIndex = 2;
            this.area_radio.TabStop = true;
            this.area_radio.Text = "Area";
            this.area_radio.UseVisualStyleBackColor = true;
            this.area_radio.CheckedChanged += new System.EventHandler(this.area_radio_CheckedChanged);
            // 
            // line_radio
            // 
            this.line_radio.AutoSize = true;
            this.line_radio.Location = new System.Drawing.Point(1117, 495);
            this.line_radio.Name = "line_radio";
            this.line_radio.Size = new System.Drawing.Size(45, 17);
            this.line_radio.TabIndex = 3;
            this.line_radio.TabStop = true;
            this.line_radio.Text = "Line";
            this.line_radio.UseVisualStyleBackColor = true;
            this.line_radio.CheckedChanged += new System.EventHandler(this.line_radio_CheckedChanged);
            // 
            // step_radio
            // 
            this.step_radio.AutoSize = true;
            this.step_radio.Location = new System.Drawing.Point(1117, 511);
            this.step_radio.Name = "step_radio";
            this.step_radio.Size = new System.Drawing.Size(70, 17);
            this.step_radio.TabIndex = 4;
            this.step_radio.TabStop = true;
            this.step_radio.Text = "Step Line";
            this.step_radio.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 570);
            this.Controls.Add(this.step_radio);
            this.Controls.Add(this.line_radio);
            this.Controls.Add(this.area_radio);
            this.Controls.Add(this.city_txt);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Start";
            this.Text = "Weather Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox city_txt;
        private System.Windows.Forms.RadioButton area_radio;
        private System.Windows.Forms.RadioButton line_radio;
        private System.Windows.Forms.RadioButton step_radio;
    }
}