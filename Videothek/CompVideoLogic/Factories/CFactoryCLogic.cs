using VideoLogic.Factories;

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
