using System;
using System.Collections.Generic;


namespace Project2
{
	public class DojiRecognizer: Recognizer
	{
		//	10%
		//static decimal LEEWAY = 0.1M;

		/*========================================================
		 * Overrides base class Recognizer's RecognizePattern
		 * Takes in a List of candlesticks.
		 * Since single candlestick, the list is only one.
		 * Returns true or false based on pattern's logic.
		 *========================================================*/
		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			//	if its neutral its a doji
			NeutralRecognizer neutralRecognizer = new NeutralRecognizer();
			bool isDoji = neutralRecognizer.RecognizePattern(lscs);
			return isDoji;
		}



	}//	end DojiRecognizer
}//	end Project2
