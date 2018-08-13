using System.Collections.Generic;
using System.Data;
using VideoLogic.Utils;
using VideoLogic.Exceptions;

namespace VideoLogic
{
    internal class CLogicSearch : ILogicSearch
    {
		#region fields
		private IDataSearch _dataSearch;
		#endregion

		#region ctor
		internal CLogicSearch(IDataSearch dataSearch) 
		{
			_dataSearch = dataSearch;
		}
		#endregion

		#region interface ILogicSearch methods
		public object[] ReadModels(string maker) 
		{
			IList<string> genre = null;
			_dataSearch.ReadGenre(maker, out genre);

			if(genre == null)
			{
				throw new CDataException("Genre ist leer");
			}

			return Util.ToArray(genre);
		}

		public void ReadVideos(VideoDtoSearch VideoSearch, out DataTable datatable) 
		{
			_dataSearch.ReadVideos(VideoSearch, out datatable);
		}
		#endregion
    }
}
