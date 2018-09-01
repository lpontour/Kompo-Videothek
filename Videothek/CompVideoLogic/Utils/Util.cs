using System;
using System.Collections.Generic;

namespace VideoLogic.Utils
{
    public class Util
	{
		public static double ParseDouble(string s, double defaultValue) 
		{
			double value;
			s = s.Replace(".", "");

			if(!double.TryParse(s, out value)) 
			{
				value = defaultValue;
			}

			return value;
		}

		public static int ParseInt(string s, int defaultValue) 
		{
			int value;
			s = s.Replace(".", "");

			if(!int.TryParse(s, out value)) 
			{
				value = defaultValue;
			}

			return value;
		}

		public static DateTime ParseDate(string s, DateTime defaultValue)
		{
			DateTime value;
			s = s.Replace(".", ",");

			if (!DateTime.TryParse(s, out value))
			{
				value = defaultValue;
			}

			return value;
		}

		public static object[] ToArray(IList<string> list) 
		{
			object[] arrayFromList = new object[list.Count];
			for(int i = 0; i < list.Count; i++)
			{
				arrayFromList[i] = list[i] as object;
			}

			return arrayFromList;
		}
		public static object[] ToArray(IList<int> list)
		{
			object[] arrayFromList = new object[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				arrayFromList[i] = list[i] as object;
			}

			return arrayFromList;
		}
		public static object[] ToArray(IList<double> list)
		{
			object[] arrayFromList = new object[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				arrayFromList[i] = list[i] as object;
			}

			return arrayFromList;
		}
		public static object[] ToArray(IList<DateTime> list)
		{
			object[] arrayFromList = new object[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				arrayFromList[i] = list[i] as object;
			}

			return arrayFromList;
		}
	}
}
