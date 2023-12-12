using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class EngulfingRecognizer: Recognizer
    {


		//	0.1%
		//static decimal LEEWAY = 0.001M;

		/*========================================================
		 * Overrides base class Recognizer's RecognizePattern
		 * Takes in a List of candlesticks.
		 * Since single candlestick, the list is only one.
		 * Returns true or false based on pattern's logic.
		 *========================================================*/
		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			// 2 candlestick
			SmartCandlestick s0 = lscs[0];
			SmartCandlestick s1 = lscs[1];

            // rightmost on graph is considered lscs[0].
            // 3, 2, 1, 0

            bool isBullishEngulfing = s1.Close < s1.Open // first candle is bear
								   && s0.Close > s0.Open // second candle is bull
								   && s1.RealBody < s0.RealBody
								   && s1.Range < s0.Range
								   && s1.TopPrice < s0.TopPrice
								   && s1.BottomPrice > s0.BottomPrice;

            bool isBearishEngulfing = s1.Close > s1.Open // first candle is bull
								   && s0.Close < s0.Open // second candle is bear
								   && s1.RealBody < s0.RealBody
								   && s1.Range < s0.Range
								   && s1.TopPrice < s0.TopPrice
								   && s1.BottomPrice > s0.BottomPrice;




			return isBearishEngulfing || isBullishEngulfing;
		}











	}
}
