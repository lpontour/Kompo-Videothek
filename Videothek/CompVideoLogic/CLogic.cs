using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		 // Anzahl Autos in der DB ermitteln(=nCars)    
		// Liste der Hersteller (=makers) ermitteln, als object Array
		public void InitApp(ref int nVideos, out object[] arrayMakers) 
		{
			_data.InitApp(ref nVideos, out IList<string> makers);

			if(makers == null)
			{
				throw new CDataException("Produzentenliste ist leer");
			}
            
			arrayMakers = Util.ToArray(makers);
		}      
		#endregion
    }
}
