using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLogic;
using VideoLogic.Factories;
using VideoData;
using VideoData.Access;
namespace VideoData.Factories
{
    class CFactoryCDataAccess : IFactoryIData
    {

        public IData Create(string connection)
        {
            return new CData(connection);

        }
    }
}