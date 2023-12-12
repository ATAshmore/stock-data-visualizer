using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	public class MarubozuRecognizer:Recognizer
	{
		static decimal LEEWAY = 0.95M;



		/*========================================================
		 * Overrides base class Recognizer's RecognizePattern
		 * Takes in a List of candlesticks.
		 * Since single candlestick, the list is only one.
		 * Returns true or false based on pattern's logic.
		 *========================================================*/
		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			// one candlestick
			SmartCandlestick s0 = lscs[0];

			// the realbody and range should be equal if true marubozu.
			//	but for our purposes its close.
			decimal tolerance = s0.Range * LEEWAY;
			bool IsMarubozu = s0.RealBody >= tolerance;
			return IsMarubozu;
		}




	}
}
