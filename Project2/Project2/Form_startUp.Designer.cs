namespace Project2
{
	partial class Form_startUp
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
			this.button_loadStockChart = new System.Windows.Forms.Button();
			this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
			this.label_startDate = new System.Windows.Forms.Label();
			this.label_endDate = new System.Windows.Forms.Label();
			this.openFileDialog_selectStock = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// button_loadStockChart
			// 
			this.button_loadStockChart.Location = new System.Drawing.Point(261, 68);
			this.button_loadStockChart.Name = "button_loadStockChart";
			this.button_loadStockChart.Size = new System.Drawing.Size(75, 23);
			this.button_loadStockChart.TabIndex = 0;
			this.button_loadStockChart.Text = "Load Stock";
			this.button_loadStockChart.UseVisualStyleBackColor = true;
			this.button_loadStockChart.Click += new System.EventHandler(this.button_loadStockChart_Click);
			// 
			// dateTimePicker_startDate
			// 
			this.dateTimePicker_startDate.Location = new System.Drawing.Point(55, 71);
			this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
			this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker_startDate.TabIndex = 1;
			this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
			// 
			// dateTimePicker_endDate
			// 
			this.dateTimePicker_endDate.Location = new System.Drawing.Point(342, 71);
			this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
			this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker_endDate.TabIndex = 2;
			this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.dateTimePicker_endDate_ValueChanged);
			// 
			// label_startDate
			// 
			this.label_startDate.AutoSize = true;
			this.label_startDate.Location = new System.Drawing.Point(52, 55);
			this.label_startDate.Name = "label_startDate";
			this.label_startDate.Size = new System.Drawing.Size(55, 13);
			this.label_startDate.TabIndex = 3;
			this.label_startDate.Text = "Start Date";
			// 
			// label_endDate
			// 
			this.label_endDate.AutoSize = true;
			this.label_endDate.Location = new System.Drawing.Point(490, 55);
			this.label_endDate.Name = "label_endDate";
			this.label_endDate.Size = new System.Drawing.Size(52, 13);
			this.label_endDate.TabIndex = 4;
			this.label_endDate.Text = "End Date";
			// 
			// openFileDialog_selectStock
			// 
			this.openFileDialog_selectStock.FileName = "openFileDialog1";
			// 
			// Form_startUp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(607, 155);
			this.Controls.Add(this.label_endDate);
			this.Controls.Add(this.label_startDate);
			this.Controls.Add(this.dateTimePicker_endDate);
			this.Controls.Add(this.dateTimePicker_startDate);
			this.Controls.Add(this.button_loadStockChart);
			this.Name = "Form_startUp";
			this.Text = "Stock Selector";
			this.Load += new System.EventHandler(this.Form_startUp_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_loadStockChart;
		private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
		private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
		private System.Windows.Forms.Label label_startDate;
		private System.Windows.Forms.Label label_endDate;
		private System.Windows.Forms.OpenFileDialog openFileDialog_selectStock;
	}
}

