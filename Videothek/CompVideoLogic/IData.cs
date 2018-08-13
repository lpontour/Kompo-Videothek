using System.Collections.Generic;

namespace VideoLogic
{
    public interface IData
    {
		IDataSearch Search {get;}
		IDataLoan Loan {get;}
		void Init();
		void InitApp(ref int nVideos, out IList<string> makers);
    }
}
