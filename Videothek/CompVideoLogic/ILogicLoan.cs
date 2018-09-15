using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic.Utils;

namespace VideoLogic
{
    public interface ILogicLoan
    {
		//Das Leihen Interface
		int InsertVideoTable(VideoDtoLoan videoLoan);
		int UpdateVideoTable(VideoDtoLoan videoLoan);
		int DeleteVideoTable(VideoDtoLoan videoLoan);
	}
}
