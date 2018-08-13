using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic.Factories
{
    public abstract class AFactoryLogicSearch
    {
		public static void Create(ILogic logic, IDataSearch dataSearch) 
		{
			if(logic is CLogic)
			{
				(logic as CLogic).Search = new CLogicSearch(dataSearch);
			}      
		} 
	}
}
