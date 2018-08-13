using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic.Factories
{
    public class CFactoryCLogic : IFactoryILogic
    {
		public ILogic Create(IData data) 
		{
			return new CLogic(data);
		}
    }
}
