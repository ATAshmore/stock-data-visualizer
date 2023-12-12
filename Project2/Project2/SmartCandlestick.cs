using System;

namespace Project2
{
	public class SmartCandlestick : Candlestick
	{

		//	smartcandlestick properties
		public decimal RealBody { get; }
		public decimal Range { get; }
		public decimal TopPrice { get; }
		public decimal BottomPrice { get; }
		public decimal TopTail { get; }
		public decimal BottomTail { get; }


		/*===============================================================================================================================
		 * Takes candlestick as base and adds higher level properties that are used by the pattern identifiers.
		 * ===========================================================================================================================*/
		public SmartCandlestick(Candlestick candlestick): base(candlestick.Ticker, candlestick.Period, candlestick.Date, candlestick.Open, 
															   candlestick.High, candlestick.Low, candlestick.Close, candlestick.Volume)
		{
			TopPrice = Math.Max(High, Low);
			BottomPrice = Math.Min(High, Low);
			RealBody = Math.Abs(Open - Close);
			Range = High - Low;

			// used for calculating top tail and bottom tail
			// gets the open/close thats highest. depending if bull or bear
			decimal top_open_close = Math.Max(Open, Close);
			// get the lowest
			decimal bottom_open_close = Math.Min(Open, Close);

            TopTail = Math.Abs(High - top_open_close);
			BottomTail = Math.Abs(Low - bottom_open_close);
		}











	}//	end SmartCandlestick
}//	end Project2
