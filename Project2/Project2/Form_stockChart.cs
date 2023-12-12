using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Project2
{
	public partial class Form_stockChart : Form
	{
		private DateTime startDate;
		private DateTime endDate;
		readonly string chartTitle;

		//	stores all candlesticks for the given csv file/stock.
		private List<SmartCandlestick> all_smartCandlesticks = new List<SmartCandlestick>(1024);

		//	stores updated candlesticks in line with the start and end dates.
		private List<SmartCandlestick> temp_smartCandlesticks = new List<SmartCandlestick>(1024);

		//	stores all patternIndices
		private List<List<int>> all_patternIndices = new List<List<int>>(1024);

		// stores list of recognizers
		private List<Recognizer> Lr= new List<Recognizer>(32);






		/******************************************************************************************************** 
		 * Loads an individal chart for each of the chosen stocks/tickers from Form_startUp.
		 * Converts the candlesticks from Form_startUp into smartcandlesticks(adding higher level values).
		 * Will display start date, end date, candlestick chart, volume chart, pattern selection, update button, clear button.
		 * Can view candlesticks based on if candlestick matches a selected pattern like bullish, bearish, doji, etc.
		 * Changing the dates will automatically clear the chart of any made annotations.
		 * Selecting a pattern will add annotation to the chart.
		 * Multiple patterns/annotations can be viewed on the chart.
		 * Annotations will remain on the chart until a new date is selected or the button "Clear Patterns" is selected.
		 * 
		 * *******************************************************************************************************/
		public Form_stockChart(List<Candlestick> all_candlesticks, List<Candlestick> temp_candlesticks, DateTime startDate, DateTime endDate, string title)
		{
			this.startDate = startDate;
			this.endDate = endDate;
			this.chartTitle = title;

			//	convert candlestick into smartcandestick
			foreach (var candlestick in all_candlesticks) { all_smartCandlesticks.Add(new SmartCandlestick(candlestick));}
			foreach (var candlestick in temp_candlesticks) { temp_smartCandlesticks.Add(new SmartCandlestick(candlestick)); }

			InitializeComponent();
			
			//	make the initial shown values match the designated values from Form_startUp.
			dateTimePicker_startDate.Value = this.startDate;
			dateTimePicker_endDate.Value = this.endDate;

			//	chart title
			this.chart_stock.Titles.Add(chartTitle);

			// initialize list of recognizers/patterns
			Lr = InitializeRecognizers();
			// set properties of recognizers, fill combobox
			foreach (Recognizer r in Lr)
			{
				//set properties
				r.SetRecognizerProperties(r.PatternName, r.PatternSize);

				// generate combobox
				comboBox_pattern.Items.Add(r.PatternName);

			}

		}




		/********************************************************************************************************
		 * Responsible for first setting the combobox to display "None".
		 * Loads the initial chart values from temp_candlesticks, which contained the passed start and end dates
		 * from Form_startUp for that stock.
		 * 
		 * ******************************************************************************************************/
		private void Form_chart_Load(object sender, EventArgs e)
		{
			//	set first pattern to "None".
			comboBox_pattern.SelectedIndex = 0;
			LoadChart(temp_smartCandlesticks);
		}






		/**********************************************************************************************************
		 * When the "Update" button is clicked onthe form it will alter the chart to match the start, end date,
		 * and add annotations for the slected patterns to the chart.
		 * If the start date or end date was changed then the patterns/annotations are cleared.
		 * Initializes all the different patterns available.
		 * Based on temp_candlesticks, for the selected pattern, it will recognize which smartcandlesticks meet the criteria
		 * and add those annotations to the chart.
		 * ***********************************************************************************************************/
		private void button_updateChart_Click(object sender, EventArgs e)
		{
			//	if start date or end date changes the clear the patterns/annotations.
			if (dateTimePicker_startDate.Value != startDate)
			{
				ClearChartPatterns();
				startDate = dateTimePicker_startDate.Value;
				comboBox_pattern.SelectedIndex = 0;
			}
			if (dateTimePicker_endDate.Value != endDate)
			{
				ClearChartPatterns();
				endDate = dateTimePicker_endDate.Value;
				comboBox_pattern.SelectedIndex = 0;
			}

			UpdateCandlesticks(temp_smartCandlesticks);


			
			all_patternIndices.Clear();
			// add indicies of all recognizers to big list of them
			foreach (Recognizer r in Lr)
			{
				List<int> pI = r.Recognize(temp_smartCandlesticks);
				all_patternIndices.Add(pI);
			}

			// get indicies at pattern's index and add annotation for those indices on chart.
			int comboBox_index = comboBox_pattern.SelectedIndex;
			List<int> patternIndices = all_patternIndices[comboBox_index];
			Recognizer recognizer = Lr[comboBox_index];
			//AddAnnotation(temp_smartCandlesticks, recognizer.GetName, patternIndices);
			AddAnnotation(temp_smartCandlesticks, recognizer.GetName, patternIndices, recognizer.PatternSize);

		}







		/*********************************************************************
		 * Calls on ClearChartPatterns() which will simply clear the chart
		 * of all exisitng annotations (shown as arrows).
		 * Labeled as "Clear Patterns" on the chart/form.
		 * *******************************************************************/
		private void button_clearAnnotations_Click(object sender, EventArgs e)
		{
			ClearChartPatterns();
		}








		/*====================================================================
		 * Initializes the recongnizers used to recognize the patterns in the 
		 * data.
		 * Stores recognizers in a list and returns that list to where it was called.
		 * Patterns are single, 2, and 3 candlestick patterns.
		 * PatternName and PatternSize are initialized here as well.
		 * ==================================================================*/
		public List<Recognizer> InitializeRecognizers()
		{
			List<Recognizer> recognizers = new List<Recognizer>(32);

			// used at index 0 as a 'pattern' for combobox. will show nothing.
			recognizers.Add(new NoneRecognizer { PatternName = "None", PatternSize = 0 });
			// list of acutal patterns start at 1...

			//single candlesticks
			recognizers.Add(new DojiRecognizer { PatternName = "Doji", PatternSize = 1 });
			recognizers.Add(new BullishRecognizer { PatternName = "Bullish", PatternSize = 1 });
			recognizers.Add(new BearishRecognizer { PatternName = "Bearish", PatternSize = 1 });
			recognizers.Add(new NeutralRecognizer { PatternName = "Neutral", PatternSize = 1 });
			recognizers.Add(new MarubozuRecognizer { PatternName = "Marubozu", PatternSize = 1 });
			recognizers.Add(new DragonFlyDojiRecognizer { PatternName = "DragonFlyDoji", PatternSize = 1 });
			recognizers.Add(new GravestoneDojiRecognizer { PatternName = "GravestoneDoji", PatternSize = 1 });
			recognizers.Add(new HammerRecognizer { PatternName = "Hammer", PatternSize = 1 });
			recognizers.Add(new InvertedHammerRecognizer { PatternName = "InvertedHammer", PatternSize = 1 });

			//2 candlesticks
			recognizers.Add(new EngulfingRecognizer { PatternName = "Engulfing", PatternSize = 2 });
			recognizers.Add(new BullishEngulfingRecognizer { PatternName = "BullishEngulfing", PatternSize = 2 });
			recognizers.Add(new BearishEngulfingRecognizer { PatternName = "BearishEngulfing", PatternSize = 2 });
			recognizers.Add(new BullishHaramiRecognizer { PatternName = "BullishHarami", PatternSize = 2 });
			recognizers.Add(new BearishHaramiRecognizer { PatternName = "BearishHarami", PatternSize = 2 });

			// 3 candlesticks
			recognizers.Add(new PeakRecognizer { PatternName = "Peak", PatternSize = 3 });
			recognizers.Add(new ValleyRecognizer { PatternName = "Valley", PatternSize = 3 });

			return recognizers;

        }




		/*****************************************************************
		 * Will update temp_candlesticks list.
		 * rewrites the values stored for start and end date.
		 * clears the existing temp_smartcandlesticks list.
		 * filters smart candlesticks from the cumulative list of all 
		 * candlesticks that was loaded and rewrites temp_smartcandlesticks
		 * so it matches the smart and end date.
		 * Calls LoadChart() which will update the view of the chart.
		 * ***************************************************************/
		private void UpdateCandlesticks(List<SmartCandlestick> targetList)
		{

			startDate = dateTimePicker_startDate.Value;
			endDate = dateTimePicker_endDate.Value;

			temp_smartCandlesticks.Clear();
			temp_smartCandlesticks = FilterCandlesticksByDate(all_smartCandlesticks, startDate, endDate);

			LoadChart(temp_smartCandlesticks);
		}



		/************************************************************************************************************************************
		 * Filters candlesticks so it only shows the range of start to end date.
		 * *********************************************************************************************************************************/
		private List<SmartCandlestick> FilterCandlesticksByDate(List<SmartCandlestick> smartCandlesticks, DateTime startDate, DateTime endDate)
		{
			return smartCandlesticks.Where(data => data.Date >= startDate && data.Date <= endDate).ToList();
		}



		/**************************************************************************
		 * Clears the existing chart's values.
		 * Will have two charts: candlestick and volume.
		 * Responsible for formatting the chart area. This includues the arrow legends,
		 * chart legends, chart area for candlestick, chart area for volume, the series.
		 * Called by UpdateCandelsticks() to show the data based on the range specified.
		 * ************************************************************************/
		private void LoadChart(List<SmartCandlestick> targetList)
		{
			//  clear the charts and its series
			chart_stock.Series.Clear();
			chart_stock.ChartAreas.Clear();
			chart_stock.Legends.Clear();

			//  make new chart for candlesticks
			ChartArea ChartArea_hloc = new ChartArea("ChartArea_hloc");
			chart_stock.ChartAreas.Add(ChartArea_hloc);
			//  set to two decimals.
			ChartArea_hloc.AxisY.LabelStyle.Format = "0.00";
			ChartArea_hloc.AxisY.Title = "Price $USD";
			ChartArea_hloc.AxisX.MajorGrid.LineColor = Color.Gray; // Set to your preferred color.
			ChartArea_hloc.AxisY.MajorGrid.LineColor = Color.Gray; // Set to your preferred color.

			//  changing min and max of candlestick chart so can better see the values.
			if (targetList.Count > 0)
			{
				//  make buffer as a percentage of the data range.
				//  buffer used so the min and max isn't the exact min max values
				//    of the selected stocks.
				double bufferPercentage = 5;
				decimal minLow = targetList.Min(data => data.Low);
				decimal maxHigh = targetList.Max(data => data.High);
				double buffer = (double)(Math.Abs(maxHigh - minLow) * (decimal)(bufferPercentage / 100.0));

				//  setting the yaxis min and max
				ChartArea_hloc.AxisY.Minimum = (double)minLow - buffer;
				ChartArea_hloc.AxisY.Maximum = (double)maxHigh + buffer;
			}
			//  case where stockData is empty. 
			else
			{
				//	setting default min and max.
				ChartArea_hloc.AxisY.Minimum = 0;
				ChartArea_hloc.AxisY.Maximum = 100;
			}

			//  make series for candlestick chart.
			//  will show high, low, open, close.
			Series Series_hloc = new Series("Series_hloc");
			Series_hloc.ChartArea = "ChartArea_hloc";
			Series_hloc.ChartType = SeriesChartType.Candlestick;
			Series_hloc.XValueMember = "Date";
			Series_hloc.YValueMembers = "High,Low,Open,Close";
			Series_hloc.XValueType = ChartValueType.Date;
			Series_hloc.CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
			Series_hloc["ShowOpenClose"] = "Both";
			//  change wick size and color so the wick is more easily seen.
			Series_hloc.BorderWidth = 3;
			Series_hloc.Color = Color.Black;

			//  add candlestick series to the chart
			chart_stock.Series.Add(Series_hloc);

			// make a chart area for volume
			ChartArea ChartArea_volume = new ChartArea("ChartArea_volume");
			chart_stock.ChartAreas.Add(ChartArea_volume);
			ChartArea_volume.AxisY.Title = "Volume";
			ChartArea_volume.AxisX.MajorGrid.LineColor = Color.Gray; // Set to your preferred color.
			ChartArea_volume.AxisY.MajorGrid.LineColor = Color.Gray; // Set to your preferred color.

			//  make new series for volume
			Series Series_volume = new Series("Series_volume");
			Series_volume.ChartArea = "ChartArea_volume";
			Series_volume.ChartType = SeriesChartType.Column;
			Series_volume.XValueMember = "Date";
			Series_volume.YValueMembers = "Volume";
			Series_volume.XValueType = ChartValueType.Date;

			//  add volume series to the chart
			chart_stock.Series.Add(Series_volume);

			//	controls legend for the hlock and volume series
			Legend seriesLegend = new Legend("SeriesLegend");
			seriesLegend.Docking = Docking.Right;
			seriesLegend.Title = "Series";
			chart_stock.Legends.Add(seriesLegend);


			// Create a new legend for the patterns
			Legend patternsLegend = new Legend("PatternsLegend");
			patternsLegend.Docking = Docking.Bottom;
			patternsLegend.Title = "Pattern (# candlesticks per pattern)";

			//single patterns--------------------------------------------------------
			AddLegendItem(patternsLegend, "Doji (1)", Color.Orchid);
			AddLegendItem(patternsLegend, "Bullish (1)", Color.Green);
			AddLegendItem(patternsLegend, "Bearish (1)", Color.Red);
			AddLegendItem(patternsLegend, "Neutral (1)", Color.Olive);
			AddLegendItem(patternsLegend, "Marubozu (1)", Color.DarkCyan);
			AddLegendItem(patternsLegend, "DragonFlyDoji (1)", Color.PaleVioletRed);
			AddLegendItem(patternsLegend, "GravestoneDoji (1)", Color.Brown);
			AddLegendItem(patternsLegend, "Hammer (1)", Color.BlueViolet);
			AddLegendItem(patternsLegend, "InvertedHammer (1)", Color.Orange);

			// 2 patterns---------------------------------------------------------
			AddLegendItem(patternsLegend, "Engulfing (2)", Color.DarkGoldenrod);
			AddLegendItem(patternsLegend, "BullishEngulfing (2)", Color.SpringGreen);
			AddLegendItem(patternsLegend, "BearishEngulfing (2)", Color.MediumVioletRed);
			AddLegendItem(patternsLegend, "BullishHarami (2)", Color.MidnightBlue);
			AddLegendItem(patternsLegend, "BearishHarami (2)", Color.Brown);

			// 3 patterns--------------------------------------------------------
			AddLegendItem(patternsLegend, "Peak (3)", Color.Chocolate);
			AddLegendItem(patternsLegend, "Valley (3)", Color.Pink);


			// Add the legend to the chart's Legends collection
			chart_stock.Legends.Add(patternsLegend);

			chart_stock.DataSource = targetList;
			chart_stock.DataBind();
		}


		/*************************************************************************
		 * Used in LoadChart() to add a new legend series for each of the patterns.
		 * **********************************************************************/
		private void AddLegendItem(Legend legend, string patternName, Color color)
		{
			Series legendSeries = new Series(patternName);
			legendSeries.Points.Add(1); // You need to add a point to the series

			legend.CustomItems.Add(color, patternName);
		}





		/*****************************************************************************************************************
		 * Takes the selected pattern name and will call on MakeAnnoationArrow() to add arrow for that pattern on the
		 * chart.
		 * **************************************************************************************************************/
		public void AddAnnotation(List<SmartCandlestick> targetList, Func<string> getPatternName, List<int> patternIndices, int patternSize)
		{
			string patternName = getPatternName();
			foreach (int index in patternIndices)
			{
				MakeAnnotationArrow(targetList[index], patternName);
			}
		}


		/**************************************************************************************
		 * Responsible for formatting of arrow annotation used to show patterns on the chart. 
		 * Each pattern/arrowannoation has its unique color to distinguish.
		 * Be aware, the arrows will just overlap each other if the candlestick is multiple patterns.
		 * ************************************************************************************/
		public void MakeAnnotationArrow(SmartCandlestick targetCandlestick, string patternName)
		{
			ArrowAnnotation arrowAnnotation = new ArrowAnnotation();

			//pointing left
			arrowAnnotation.Width = 2;
			// make negative to point down
			arrowAnnotation.Height = -1;
			arrowAnnotation.LineWidth = 2; // Set the line width
			//arrowAnnotation.LineColor = Color.Blue; // Set the line color
			arrowAnnotation.Alignment = ContentAlignment.TopCenter;



			// set color of the arrow annotation
			int selectedPattern = comboBox_pattern.SelectedIndex;
			switch (selectedPattern)
			{
				// none
				case 0:
					break;

				// 1 candle ----------------------------------------------------

				// doji
				case 1:
					arrowAnnotation.LineColor = Color.Orchid;
					break;
				// bullish
				case 2:
					arrowAnnotation.LineColor = Color.Green;
					break;
				// bearish
				case 3:
					arrowAnnotation.LineColor = Color.Red;
					break;
				// neutral
				case 4:
					arrowAnnotation.LineColor = Color.Olive;
					break;
				// marubozu
				case 5:
					arrowAnnotation.LineColor = Color.DarkCyan;
					break;
				// dragonflydoji
				case 6:
					arrowAnnotation.LineColor = Color.PaleVioletRed;
					break;
				// gravestonedoji
				case 7:
					arrowAnnotation.LineColor = Color.Brown;
					break;
				// hammer
				case 8:
					arrowAnnotation.LineColor = Color.BlueViolet;
					break;
				// inverted hammer
				case 9:
					arrowAnnotation.LineColor = Color.Orange;
					break;

				// 2 candles ----------------------------------------------------------

				// engulfing
				case 10:
					arrowAnnotation.LineColor = Color.DarkGoldenrod;
					break;
				// bullish engulf
				case 11:
					arrowAnnotation.LineColor = Color.SpringGreen;
					break;
				// bearish engulf
				case 12:
					arrowAnnotation.LineColor = Color.MediumVioletRed;
					break;
				// bull harami
				case 13:
					arrowAnnotation.LineColor = Color.MidnightBlue;
					break;
				// bear harami
				case 14:
					arrowAnnotation.LineColor = Color.Brown;
					break;

				// 3 candles ---------------------------------------------------

				// peak
				case 15:
					arrowAnnotation.LineColor = Color.Chocolate;
					break;
				//valley
				case 16:
					arrowAnnotation.LineColor = Color.Pink;
					break;


				default:
					break;
			}

			// find data point that is matched with the candlestick
			DataPoint anchorDataPoint = chart_stock.Series[0].Points.FindByValue(targetCandlestick.Date.ToOADate(), "X");
			if (anchorDataPoint != null)
			{
				arrowAnnotation.AnchorDataPoint = anchorDataPoint;
				arrowAnnotation.AnchorOffsetY = 0; 
				arrowAnnotation.Font = new Font("Arial", 10);
				arrowAnnotation.ForeColor = Color.Yellow;
				chart_stock.Annotations.Add(arrowAnnotation);
			}
		}
	



		/************************************
		 * Will clear all made annotations 
		 * on the chart.
		 * **********************************/
		private void ClearChartPatterns()
		{
			var annotationCopy = chart_stock.Annotations.ToList();

			// Clear all annotations from the chart
			foreach (var annotation in annotationCopy)
			{
				chart_stock.Annotations.Remove(annotation);
			}
		}








		//	autogenerated and unused. . . . . . . .. . . .. . . . .. . . . . . .. 
		private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
		{
		}
		private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
		{
		}
		private void comboBox_pattern_SelectedIndexChanged(object sender, EventArgs e)
		{
		}







		//	text- testing
		/*
		public void MakeAnnotation(SmartCandlestick targetCandlestick, string patternName)
		{
			TextAnnotation annotation = new TextAnnotation();
			annotation.Text = patternName;
			annotation.ForeColor = Color.Violet;
			annotation.Font = new Font("Arial", 10);
			annotation.AxisX = chart_stock.ChartAreas[0].AxisX;
			annotation.AxisY = chart_stock.ChartAreas[0].AxisY;
			


			// Adjust the Y position of the annotation
			DataPoint anchorDataPoint = chart_stock.Series[0].Points.FindByValue(targetCandlestick.Date.ToOADate(), "X");
			double yOffset = 2; // Adjust this value as needed to control the distance above the data point
			annotation.AnchorDataPoint = anchorDataPoint;
			annotation.AnchorAlignment = ContentAlignment.TopCenter;
			annotation.Y = anchorDataPoint.YValues[0] + yOffset;

			chart_stock.Annotations.Add(annotation);
		}*/







	}//	end class Form_stockChart
}//	end namespace Project2
