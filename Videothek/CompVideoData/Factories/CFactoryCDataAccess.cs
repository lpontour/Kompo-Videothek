using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLogic;
using VideoLogic.Factories;
using VideoData;
using VideoData.Access;
namespace VideoData.Factories
{
    public class CFactoryCDataAccess : IFactoryIData
    {
        //Erstellt ein CData Objekt der IData Klasee und gibt diesen zurück.
        //Benötigt einen Connection String
        public IData Create(string connection)
        {
            return new CData(connection);

        }
    }
}