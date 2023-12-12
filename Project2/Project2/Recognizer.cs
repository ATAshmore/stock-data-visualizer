using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	public abstract class Recognizer
	{
		//	Properties of every pattern
		public int PatternSize { get; set; }
		public string PatternName { get; set; }



		/*===========================
		 * Returns the pattern's name
		 * =========================*/
		public string GetName()
		{
			return PatternName;
		}


		/*=================================================
		 * Virtual function, will be overridden in inheriting
		 * classes' own functions.
		 * Will return true or false, if it is the pattern
		 * in question.
		 * Used by Recognize() to identify the candlesticks that
		 * are that pattern.
		 * ==============================================*/
		public virtual bool RecognizePattern(List<SmartCandlestick> lscs)
		{
			return false;
		}


		/*=================================================
		 * Used to set the pattern's name and size (if it is
		 * single candlestick type or multicandlestick type).
		 * ==============================================*/
		public void SetRecognizerProperties(string pn, int ps)
		{
			PatternName = pn;
			PatternSize = ps;
		}
/*
        public void SetRecognizerProperties(string pn, int ps): pn(PatternName),  ps(PatternSize)
		{ }*/




        /*====================================================================================================
		 * Responsible for identifying where in the list of candlesticks the patterns are.
		 * Returns indicies of these points. 
		 * Will call on RecognizePattern to check if it is that pattern or not. 
		 * Can recognize for single and multicandlestick patterns.
		 * =================================================================================================*/
        public List<int> Recognize(List<SmartCandlestick> lscs)
		{
			List<int> result = new List<int>(lscs.Count);
			for (int i = PatternSize - 1; i < lscs.Count; i++)
			{
				List<SmartCandlestick> subList = lscs.GetRange(i - PatternSize + 1, PatternSize);
				if(RecognizePattern(subList))
					result.Add(i);
			}
			return result;
		}







	}//end abstract Recognizer
}
