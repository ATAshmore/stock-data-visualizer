using System;
using System.Collections.Generic;

namespace Project2
{
	public class GravestoneDojiRecognizer:Recognizer
	{

		//	15%
		static decimal LEEWAY = 0.15M;



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

			//	need to be doji
			DojiRecognizer dojiRecognizer = new DojiRecognizer();
			bool isDoji = dojiRecognizer.RecognizePattern(lscs);

			decimal tolerance = s0.Range * LEEWAY;
			//decimal tolerance2 = s0.Open
			bool IsGravestoneDoji = isDoji && s0.BottomTail <= tolerance;

			return IsGravestoneDoji;
		}





	}
}
