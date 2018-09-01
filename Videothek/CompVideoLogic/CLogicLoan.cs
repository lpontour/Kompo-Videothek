using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic.Utils;

namespace VideoLogic
{
    internal class CLogicLoan : ILogicLoan
    {
		#region  fields
		private IDataLoan _dataLoan;
		#endregion

		#region ctor
		internal CLogicLoan(IDataLoan dataLoan)
		{
			_dataLoan = dataLoan;
		}
		#endregion

		#region interface ILogicOffer methods
		public int InsertVideoTable(VideoDtoLoan videoLoan)
		{
			return _dataLoan.InsertVideoTable(videoLoan);
		}

		public int UpdateVideoTable(VideoDtoLoan videoLoan)
		{
			return _dataLoan.UpdateVideoTable(videoLoan, videoLoan.ReturnDate);
		}
		public int DeleteVideoTable(VideoDtoLoan videoLoan)
		{
			return _dataLoan.DeleteVideoTable(videoLoan, videoLoan.Borrower, videoLoan.ReturnDate);
		}
		#endregion

	}
}
