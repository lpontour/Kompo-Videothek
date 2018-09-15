using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic.Utils;

namespace VideoLogic
{
    public interface IDataLoan
	{
		//Das Leihen Interface
		int InsertLoan(Loan loan);
		int UpdateLoan(Loan loan);
		int DeleteLoan(Loan loan);
		int InsertVideoTable(VideoDtoLoan videoLoan);
		int UpdateVideoTable(VideoDtoLoan videoLoan, DateTime returnDate);
		int DeleteVideoTable(VideoDtoLoan videoLoan, string borrower, DateTime returnDate);
	}
}
