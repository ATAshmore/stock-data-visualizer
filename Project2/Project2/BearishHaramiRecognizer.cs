using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class BearishHaramiRecognizer : Recognizer
    {


        /*========================================================
         * Overrides base class Recognizer's RecognizePattern
         * Takes in a List of candlesticks.
         * Since single candlestick, the list is only one.
         * Returns true or false based on pattern's logic.
         *========================================================*/
        public override bool RecognizePattern(List<SmartCandlestick> lscs)
        {
            // rightmost on graph is considered lscs[0].
            // 3, 2, 1, 0
            SmartCandlestick s0 = lscs[0];
            SmartCandlestick s1 = lscs[1];

            // large bullish candle on first candle, then smaller bearish or bullish candle on day two
            // smaller candle should be within the real body of the first candle
            return s1.Close > s1.Open
                && s1.RealBody > s0.Range
                && s1.Open < s0.BottomPrice
                && s1.Close > s0.TopPrice;
        }








    }
}
