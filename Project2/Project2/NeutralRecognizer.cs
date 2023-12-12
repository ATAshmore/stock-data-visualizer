using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	public class NeutralRecognizer: Recognizer
	{
		//	0.1%
		static decimal LEEWAY = 0.001M;

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

			//	if neutral then the real body shouldn't be that far away from the open.
			decimal tolerance = LEEWAY * s0.Open;
			bool isNeutral = s0.RealBody <= tolerance;
			return isNeutral;
		}


	}
}
