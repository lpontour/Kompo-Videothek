﻿using System.Collections.Generic;
using VideoLogic.Utils;
using VideoLogic.Exceptions;

namespace VideoLogic
{
    internal class CLogic : ILogic
    {
		#region fields
		private IData _data;
		#endregion

		#region interface properties         
		public ILogicSearch Search {get; internal set;}
		public ILogicLoan Loan {get; internal set;}
		#endregion

		#region ctor
		internal CLogic(IData data) 
		{
			_data = data;
		}
		#endregion

		#region interface ILogic methods
		// 2. Initialisierung der Anwendung
		// Anzahl Autos in der DB ermitteln(=nVideos)    
		// Liste der Titel (=titels) ermitteln, als object Array
		/*
		public void InitApp(ref int nVideos, out object[] arrayTitels) 
		{
			_data.InitApp(ref nVideos, out IList<string> titels);

			if(titels == null)
			{
				throw new CDataException("Titelliste ist leer");
			}
            
			arrayTitels = Util.ToArray(titels);
		} 
		*/
		#endregion
    }
}
