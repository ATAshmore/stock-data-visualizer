using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class ValleyRecognizer : Recognizer
    {


        /*========================================================
		* Overrides base class Recognizer's RecognizePattern
		* Takes in a List of candlesticks.
		* Since single candlestick, the list is only one.
		* Returns true or false based on pattern's logic.
		*========================================================*/
        public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			// 3 candlestick
			SmartCandlestick s0 = lscs[0];
			SmartCandlestick s1 = lscs[1];
			SmartCandlestick s2 = lscs[2];

			// the middle candlestick's low, s1, is lowers than s0 and s2 lows.
			return (s0.Low > s1.Low) && (s1.Low < s2.Low);
		}





	}
}
