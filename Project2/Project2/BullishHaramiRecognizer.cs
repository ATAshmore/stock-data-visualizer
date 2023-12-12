using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class BullishHaramiRecognizer : Recognizer
    {

		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			// rightmost on graph is considered lscs[0].
			// 3, 2, 1, 0
			SmartCandlestick s0 = lscs[0];
			SmartCandlestick s1 = lscs[1];

			// large bearsih candle on first candle, then smaller bearish or bullish candle on day two
			// smaller candle should be within the real body of the first candle
			return s1.Close < s1.Open
				&& s1.RealBody > s0.Range
				&& s1.Open > s0.TopPrice
				&& s1.Close < s0.BottomPrice;
		}


	}
}
