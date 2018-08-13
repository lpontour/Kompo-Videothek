using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic
{
    public interface IData
    {
		IDataSearch Search {get;}
		IDataLoan  Loan  {get;}
		void Init();
		void InitApp(ref int nVideos, out IList<string> makers);
    }
}
