﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	public class NoneRecognizer: Recognizer
	{
		/*========================================================
		 * Used as placeholder for comboBox selection. 
		 * Does nothing. Returns false.
		 *========================================================*/
		public override bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			return false;
		}



	}
}
