using System.Threading.Tasks;
using VideoLogic.Utils;

namespace VideoLogic
{
    public interface ILogicSearch
    {
		object[] ReadGenre(string maker);
		void ReadVideos(VideoDtoSearch VideoSearch, out DataTable dataTable);
    }
}
