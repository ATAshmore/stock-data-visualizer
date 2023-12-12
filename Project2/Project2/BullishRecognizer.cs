using System;
using System.Collections.Generic;

namespace Project2
{
	public class BullishRecognizer: Recognizer
	{
		//	0.1 % 
		//static decimal LEEWAY = 0.001M;

		/*========================================================
		 * Overrides base class Recognizer's RecognizePattern
		 * Takes in a List of candlesticks.
		 * Since single candlestick, the list is only one.
		 * Returns true or false based on pattern's logic.
		 *========================================================*/
		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			// if not neutral then its bear or bull. 
			NeutralRecognizer neturalRecognizer = new NeutralRecognizer();
			bool isNotNeutral = !neturalRecognizer.RecognizePattern(lscs);

			// one candlestick
			SmartCandlestick s0 = lscs[0];

			//	if close > open then bull
			bool isBullish = s0.Close > s0.Open && isNotNeutral;

			return isBullish;
		}



	}
}
