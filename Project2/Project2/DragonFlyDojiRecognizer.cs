using System;
using System.Collections.Generic;

namespace Project2
{
	public class DragonFlyDojiRecognizer: Recognizer
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

			//	needs to be doji then make sure its a dragonfly
			DojiRecognizer dojiRecognizer = new DojiRecognizer();
			bool isDoji = dojiRecognizer.RecognizePattern(lscs);
			decimal tolerance = s0.Range * LEEWAY;


			//	toptail needs to be nonexistant. but for our purposes just small in comparison of the rnage.
			bool isDragonFlyDoji = isDoji && s0.TopTail <= tolerance;

			return isDragonFlyDoji;
		}



	}
}
