using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using VideoLogic.Utils;
namespace VideoData.Access
{
    internal class CDataSearch : ADataSearch
    {
        #region ctor
        internal CDataSearch(AData data): base(data)
        {
        }
        #endregion
    }
}