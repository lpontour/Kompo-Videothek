using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using VideoLogic.Utils;
namespace VideoData.Access
{
    class CDataSearch : ADataSearch
    {
        #region ctor
        internal CDataSearch(AData data)
           : base(data)
        {
        }
        #endregion
        #region protected methods override 
        protected override void SqlGetGenre(string titel, DbCommand dbCommand)
        {
            dbCommand.CommandText =
               @"SELECT DISTINCT Genre FROM VideoTable WHERE Video = [_Titel] ORDER BY Title";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(_dbCommand, "_Titel", titel);
        }
        protected override void SqlSelectVideo(VideoDtoSearch videoSearch, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM Video ";
            if ((videoSearch.Title == "ALLE") || (videoSearch.Title == "alle") || (videoSearch.Title == "Alle"))
            {
                videoSearch.Title = "*";
                dbCommand.CommandText = @"WHERE ";
            }
            else
            {
                dbCommand.CommandText += " WHERE Title = @Title";
                AData.AddParameter(dbCommand, "@Title", videoSearch.Title);
            }
            if (videoSearch.Genre != "Genre")
            {
                dbCommand.CommandText += " AND Genre = @Genre";
                AData.AddParameter(dbCommand, "@Genre", videoSearch.Genre);
            }
            dbCommand.CommandText += " AND BorrowingRate >= @BorrowingRateFrom";
            AData.AddParameter(dbCommand, "@BorrowingRateFrom", videoSearch.BorrowingRateFrom);
            dbCommand.CommandText += " AND BorrowingRate <= @BorrowingRateTo";
            AData.AddParameter(dbCommand, "@BorrowingRateTo", videoSearch.BorrowingRateTo);
            dbCommand.CommandText += " AND ReleaseYear = @ReleaseYear";
            AData.AddParameter(dbCommand, "@ReleaseYear", videoSearch.ReleaseYear);
            dbCommand.CommandText += " AND Rated = @Rated";
            AData.AddParameter(dbCommand, "@Rated", videoSearch.Rated);
            dbCommand.CommandText += " AND Borrower = @Borrower";
            AData.AddParameter(dbCommand, "@Borrower", videoSearch.Borrower);
            dbCommand.CommandText += " AND ReturnDate = @ReturnDate";
            AData.AddParameter(dbCommand, "@ReturnDate", videoSearch.ReturnDate);
            dbCommand.CommandText += " ORDER BY BorrowingRate;";
        }
        #endregion
    }
}