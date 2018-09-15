using VideoLogic.Factories;

namespace VideoLogic.Factories
{
    public class CFactoryCLogic : IFactoryILogic
    {
		//Erstellt eine neue der Factory eintsprechende Klasse
		public ILogic Create(IData data) 
		{
			return new CLogic(data);
		}
    }
}
