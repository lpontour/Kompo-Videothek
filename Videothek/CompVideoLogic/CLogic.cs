using System.Collections.Generic;
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

		//Erstellt eine neue Dataschicht
		#region ctor
		internal CLogic(IData data) 
		{
			_data = data;
		}
		#endregion
    }
}
