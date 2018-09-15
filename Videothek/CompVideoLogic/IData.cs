using System.Collections.Generic;

namespace VideoLogic
{
    public interface IData
    {
		//Data Interface
		IDataSearch Search {get;}
		IDataLoan Loan {get;}
		void Init();
    }
}
