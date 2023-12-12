using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace Project2
{
	public partial class Form_startUp : Form
	{

		public List<Candlestick> all_candlesticks = new List<Candlestick>(1024);
		public List<Candlestick> temp_candlesticks = new List<Candlestick>(1024);


		/*======================
		 * Constructor for Form_startUp
		 * ==========================*/
		public Form_startUp()
		{
			InitializeComponent();

			// set initial start and end date
			// only set up this way for graders.
			dateTimePicker_startDate.Value = new DateTime(2021, 1, 1);
			//dateTimePicker_endDate.Value = new DateTime(2021, 1, 7);
		}

	




		/*==================================================================
		 * Will open file dialog box so user can select stocks.
		 * Attached to the FileOk event.
		 * ===============================================================*/
		private void button_loadStockChart_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = CreateOpenFileDialog();

			// subscribe to the FileOk event
			ofd.FileOk += OpenFileDialog_FileOk;

			// Show the dialog
			ofd.ShowDialog();
		}




		/*====================================================================
		 * Allows for multiselect of files/stocks which will load their own
		 * unique candlesticks and theri own form for chart.
		 * stores all_candlesticks for all the values in the file and stores
		 * the range of start and enddate in temp_candlesticks.
		 * ===================================================================*/
		private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			OpenFileDialog ofd = (OpenFileDialog)sender;
			DateTime startDate = dateTimePicker_startDate.Value;
			DateTime endDate = dateTimePicker_endDate.Value;

			foreach (string selectedFilePath in ofd.FileNames)
			{
				string chartTitle = Path.GetFileNameWithoutExtension(selectedFilePath);

				//List<Candlestick> all_candlesticks = new List<Candlestick>();
				//List<Candlestick> temp_candlesticks = new List<Candlestick>();

				all_candlesticks.Clear();
				// Use CsvHelper to load the selected CSV file.
				LoadStockData(selectedFilePath, all_candlesticks);

				temp_candlesticks.Clear();
				temp_candlesticks = FilterCandlesticksByDate(all_candlesticks, startDate, endDate);

				Form_stockChart stockChartForm = new Form_stockChart(all_candlesticks, temp_candlesticks, startDate, endDate, chartTitle);
				stockChartForm.Show();
			}
		}



		/*==================================================================
		 * Responsible for logic of openfiledialog box.
		 * Can filter stock by their period: day, week, month.
		 * Allows multiselect for multiple files.
		 * Responsible for logic of opening Stock Data folder.
		 * ===============================================================*/
		private OpenFileDialog CreateOpenFileDialog()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Stock by Period (Day, Week, Month)";
			// Filter the files by only type .csv and then by their period of day, week, or month.
			ofd.Filter = "Day|*Day.csv|Week|*Week.csv|Month|*Month.csv";

			// Allow multiple file selections
			ofd.Multiselect = true;

			// Get the initial directory for stock data
			string executableDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string parentDirectory = executableDirectory;

			for (int i = 0; i < 4; i++)
			{
				parentDirectory = Directory.GetParent(parentDirectory).FullName;
			}

			string stockDataDirectory = Path.Combine(parentDirectory, "Stock Data");
			ofd.InitialDirectory = stockDataDirectory;

			return ofd;
		}



		/*============================================================================
		 * loads stock daata from csv file and returns list.
		 * Uses csvHelper to make data into collection of candlesticks
		 * ============================================================================*/
		
		private void LoadStockData(string filePath, List<Candlestick> targetedList)
		{
			//  read contents of csv file usinug streamreader and csv helper.
			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
			{
				//	map to stockdata objects then make a list
				var stockDataList = csv.GetRecords<Candlestick>().ToList();
				// Round values to 2 decimals.
				//RoundCandlestickValues(stockDataList);
				targetedList.AddRange(stockDataList);
			}
		}



		/*======================================================================================================================
		 * Filters candlesticks by their start and end date.
		 * Returns the updated list.
		 * Should be called on temp_candlesticks.
		 * =====================================================================================================================*/
		private List<Candlestick> FilterCandlesticksByDate(List<Candlestick> candlesticks, DateTime startDate, DateTime endDate)
		{
			return candlesticks.Where(data => data.Date >= startDate && data.Date <= endDate).ToList();
		}










		// autogenerated - empty - unused . . . . . . . . . . . . . . . . . . . . .
		private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
		{

		}

		private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
		{

		}

		private void Form_startUp_Load(object sender, EventArgs e)
		{

		}


	}//	end Form_startUp
}//	end namespace Project2
