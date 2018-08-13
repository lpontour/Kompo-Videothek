using System.Collections.Generic;

namespace VideoLogic.Utils
{
    public class Util
    {
		/// <summary>
		/// Erzeugen eines 8-Byte Schlüssels
		/// </summary>
		/// <returns></returns>
		public static string CreateGUID() 
		{
			// 16 Byte Schlüssel
			System.Guid gUID = System.Guid.NewGuid();
			string strgUID = gUID.ToString();
			byte[] bUID = gUID.ToByteArray();

			// die ersten 8 Bytes werden verwendet
			long lUID = 0;
			lUID = lUID | (long) bUID[0];
			int shift = 8;

			for(int i = 1; i < 8; i++) 
			{
				lUID = lUID | (long) bUID[i] << shift;
				shift = shift + 8;
			}

			return string.Format("{0:d}", lUID);
		}

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

		public static object[] ToArray(IList<string> list) 
		{
			object[] arrayFromList = new object[list.Count];
			for(int i = 0; i < list.Count; i++)
			{
				arrayFromList[i] = list[i] as object;
			}

			return arrayFromList;
		}
    }
}
