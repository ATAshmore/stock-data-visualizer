namespace Project2
{
	partial class Form_stockChart
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
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_stockChart));
			this.chart_stock = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label_endDate = new System.Windows.Forms.Label();
			this.label_startDate = new System.Windows.Forms.Label();
			this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
			this.comboBox_pattern = new System.Windows.Forms.ComboBox();
			this.label_pattern = new System.Windows.Forms.Label();
			this.button_updateChart = new System.Windows.Forms.Button();
			this.button_clearAnnotations = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.label_annotationNote = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart_stock)).BeginInit();
			this.SuspendLayout();
			// 
			// chart_stock
			// 
			chartArea1.Name = "ChartArea1";
			this.chart_stock.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart_stock.Legends.Add(legend1);
			this.chart_stock.Location = new System.Drawing.Point(12, 12);
			this.chart_stock.Name = "chart_stock";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart_stock.Series.Add(series1);
			this.chart_stock.Size = new System.Drawing.Size(1080, 555);
			this.chart_stock.TabIndex = 0;
			this.chart_stock.Text = "chart1";
			title1.Name = "Title1";
			this.chart_stock.Titles.Add(title1);
			// 
			// label_endDate
			// 
			this.label_endDate.AutoSize = true;
			this.label_endDate.Location = new System.Drawing.Point(215, 590);
			this.label_endDate.Name = "label_endDate";
			this.label_endDate.Size = new System.Drawing.Size(52, 13);
			this.label_endDate.TabIndex = 9;
			this.label_endDate.Text = "End Date";
			// 
			// label_startDate
			// 
			this.label_startDate.AutoSize = true;
			this.label_startDate.Location = new System.Drawing.Point(9, 590);
			this.label_startDate.Name = "label_startDate";
			this.label_startDate.Size = new System.Drawing.Size(55, 13);
			this.label_startDate.TabIndex = 8;
			this.label_startDate.Text = "Start Date";
			// 
			// dateTimePicker_endDate
			// 
			this.dateTimePicker_endDate.Location = new System.Drawing.Point(218, 606);
			this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
			this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker_endDate.TabIndex = 7;
			this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.dateTimePicker_endDate_ValueChanged);
			// 
			// dateTimePicker_startDate
			// 
			this.dateTimePicker_startDate.Location = new System.Drawing.Point(12, 606);
			this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
			this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker_startDate.TabIndex = 6;
			this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
			// 
			// comboBox_pattern
			// 
			this.comboBox_pattern.FormattingEnabled = true;
			this.comboBox_pattern.Location = new System.Drawing.Point(424, 605);
			this.comboBox_pattern.Name = "comboBox_pattern";
			this.comboBox_pattern.Size = new System.Drawing.Size(149, 21);
			this.comboBox_pattern.TabIndex = 11;
			this.comboBox_pattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_pattern_SelectedIndexChanged);
			// 
			// label_pattern
			// 
			this.label_pattern.AutoSize = true;
			this.label_pattern.Location = new System.Drawing.Point(421, 589);
			this.label_pattern.Name = "label_pattern";
			this.label_pattern.Size = new System.Drawing.Size(72, 13);
			this.label_pattern.TabIndex = 12;
			this.label_pattern.Text = "Stock Pattern";
			// 
			// button_updateChart
			// 
			this.button_updateChart.Location = new System.Drawing.Point(579, 603);
			this.button_updateChart.Name = "button_updateChart";
			this.button_updateChart.Size = new System.Drawing.Size(75, 23);
			this.button_updateChart.TabIndex = 13;
			this.button_updateChart.Text = "Update";
			this.button_updateChart.UseVisualStyleBackColor = true;
			this.button_updateChart.Click += new System.EventHandler(this.button_updateChart_Click);
			// 
			// button_clearAnnotations
			// 
			this.button_clearAnnotations.Location = new System.Drawing.Point(660, 603);
			this.button_clearAnnotations.Name = "button_clearAnnotations";
			this.button_clearAnnotations.Size = new System.Drawing.Size(105, 23);
			this.button_clearAnnotations.TabIndex = 14;
			this.button_clearAnnotations.Text = "Clear Patterns";
			this.button_clearAnnotations.UseVisualStyleBackColor = true;
			this.button_clearAnnotations.Click += new System.EventHandler(this.button_clearAnnotations_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// label_annotationNote
			// 
			this.label_annotationNote.AutoSize = true;
			this.label_annotationNote.ForeColor = System.Drawing.Color.Firebrick;
			this.label_annotationNote.Location = new System.Drawing.Point(771, 570);
			this.label_annotationNote.Name = "label_annotationNote";
			this.label_annotationNote.Size = new System.Drawing.Size(311, 65);
			this.label_annotationNote.TabIndex = 15;
			this.label_annotationNote.Text = resources.GetString("label_annotationNote.Text");
			// 
			// Form_stockChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1104, 650);
			this.Controls.Add(this.label_annotationNote);
			this.Controls.Add(this.button_clearAnnotations);
			this.Controls.Add(this.button_updateChart);
			this.Controls.Add(this.label_pattern);
			this.Controls.Add(this.comboBox_pattern);
			this.Controls.Add(this.label_endDate);
			this.Controls.Add(this.label_startDate);
			this.Controls.Add(this.dateTimePicker_endDate);
			this.Controls.Add(this.dateTimePicker_startDate);
			this.Controls.Add(this.chart_stock);
			this.Name = "Form_stockChart";
			this.Text = "Candlestick Chart";
			this.Load += new System.EventHandler(this.Form_chart_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart_stock)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart_stock;
		private System.Windows.Forms.Label label_endDate;
		private System.Windows.Forms.Label label_startDate;
		private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
		private System.Windows.Forms.ComboBox comboBox_pattern;
		private System.Windows.Forms.Label label_pattern;
		public System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
		private System.Windows.Forms.Button button_updateChart;
		private System.Windows.Forms.Button button_clearAnnotations;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label label_annotationNote;
	}
}