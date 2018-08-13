using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic
{
    public interface ILogic
    {
		ILogicSearch Search {get;}
		ILogicLoan Loan {get;}
		void InitApp(ref int _nVideos, out object[] _arrayMakers);
    }
}
