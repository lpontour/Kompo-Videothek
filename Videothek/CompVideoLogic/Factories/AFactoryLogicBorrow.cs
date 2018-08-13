using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic.Factories
{
    public abstract class AFactoryLogicBorrow
    {
		public static void Create(ILogic logic, IDataLoan dataLoan) 
		{
			if(logic is CLogic)
			{
				(logic as CLogic).Loan = new CLogicSearch(dataLoan);
			}      
		} 
    }
}
