using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	public class HammerRecognizer:Recognizer
	{
		//static decimal LEEWAY = 0.2M;

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

			bool IsHammer =
				s0.RealBody <= s0.Range * 0.40M && // The body is small
				s0.BottomTail >= s0.Range * 0.60M && // Long lower tail
				s0.TopTail <= s0.Range * 0.20M;     // Little to no upper tail
			return IsHammer;
		}



	}
}
