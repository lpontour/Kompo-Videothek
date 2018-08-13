using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
