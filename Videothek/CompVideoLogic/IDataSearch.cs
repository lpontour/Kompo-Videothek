using System.Collections.Generic;
using System.Data;
using VideoLogic.Utils;

namespace VideoLogic
{
    public interface IDataSearch
    {
		void ReadGenre(string maker, out IList<string> Genre);
		void ReadVideos(VideoDtoSearch VideoDtoSelected, out IList<Video> Videos);
		void ReadVideos(VideoDtoSearch VideoDtoSelected, out DataTable dTableVideos);
    }
}
