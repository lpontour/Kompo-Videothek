using System;
using System.Data;

namespace VideoLogic.Utils
{
    public class VideoDtoLoan : Loan
    {
		#region ctor
		public VideoDtoLoan(int id)
		{
			ID = id;
		}

		public VideoDtoLoan ()
		{

		}

		public VideoDtoLoan(DataRow dataRow)
		{
			ID = Convert.ToInt32(dataRow.ItemArray[1]);
			Title = Convert.ToString(dataRow.ItemArray[2]);
			Borrower = Convert.ToString(dataRow.ItemArray[3]);
			ReturnDate = Convert.ToDateTime(dataRow.ItemArray[4]);
		}
		#endregion

		// AddNewRow nicht benötigt --> keine neuen Einträge in DB

	}
}
