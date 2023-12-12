using System;

namespace Project2
{
	public class Candlestick
	{
		public string Ticker { get; set; }
		public string Period { get; set; }
		public DateTime Date { get; set; }
		public decimal Open { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public decimal Close { get; set; }
		public int Volume { get; set; }

		/*==============================
		 * constructor for candlestick
		 * ===========================*/
		public Candlestick() { }

		/*================================================================================================================================
		 * Can set individual values or make your own candlestick for testing.
		 * ==============================================================================================================================*/
		public Candlestick(string ticker, string period, DateTime date, decimal open, decimal high, decimal low, decimal close, int volume)
		{
			Ticker = ticker;
			Period = period;
			Date = date;
			Open = open;
			High = high;
			Low = low;
			Close = close;
			Volume = volume;
		}   



	}
}
