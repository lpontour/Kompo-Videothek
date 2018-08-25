using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLogic;
using VideoLogic.Utils;
namespace VideoData
{
    class ADataSearch : IDataSearch
    {
        #region fields
        protected AData _data;
        protected DbProviderFactory _dbProviderFactory;
        protected DbConnection _dbConnection;
        protected DbCommand _dbCommand;
        #endregion
        #region ctor
        internal ADataSearch(AData data)
        {
            _data = data;
        }
        #endregion
        #region interface ISearch methods
        public void Init(DbProviderFactory dbProviderFactory,
           DbConnection dbConnection, DbCommand dbCommand)
        {
            _dbProviderFactory = dbProviderFactory;
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
        }
        public void ReadGenre(string video, out IList<string> genre)
        {
            genre = new List<string>();
            AData.Open(_dbConnection);
            this.SqlGetGenre(video, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    genre.Add(dbDataReader[0].ToString());
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }
        public void ReadVideos(VideoDtoSearch videoSearch, out IList<Video> videos)
        {
            videos = new List<Video>();
            AData.Open(_dbConnection);
            this.SqlSelectVideo(videoSearch, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                int nColumns = dbDataReader.FieldCount;
                while (dbDataReader.Read())
                {
                    Video video = new Video(dbDataReader.GetInt32(0))
                    {
                        Title = dbDataReader.GetString(1),
                        Genre = dbDataReader.GetString(2),
                        BorrowingRate = dbDataReader.GetDouble(3),
                        ReleaseYear = dbDataReader.GetInt32(4),
                        RunningTime = dbDataReader.GetInt32(5),
                        Rated = dbDataReader.GetInt32(6),
                        Borrower = dbDataReader.GetString(6),
                        ReturnDate = dbDataReader.GetDateTime(6)
                    };
                    videos.Add(video);
                }
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }
        public void ReadVideos(VideoDtoSearch videoSearch, out DataTable dataTableVideos)
        {
            dataTableVideos = new DataTable("Videos");
            DbDataAdapter dbDataAdapter = _dbProviderFactory.CreateDataAdapter();
            this.SqlSelectVideo(videoSearch, _dbCommand);
            dbDataAdapter.SelectCommand = _dbCommand;
            int records = dbDataAdapter.Fill(dataTableVideos);
        }
        #endregion
        #region virtual methods      
        protected virtual void SqlGetGenre(string video, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT Genre FROM VideoTable WHERE Title = @Video ORDER BY Genre";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@Video", video);
        }
        protected virtual void SqlSelectVideo(VideoDtoSearch videoSearch, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM VideoTable";
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