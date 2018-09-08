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
    internal abstract class ADataSearch : IDataSearch
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

        public void ReadGenre(string genre, out IList<string> listGenre)
        {
            listGenre = new List<string>();
            AData.Open(_dbConnection);
            this.SqlGetGenre(genre, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    listGenre.Add(dbDataReader[0].ToString());
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadVideos(VideoDtoSearch videoSearch, out IList<Loan> videos)
        {
            videos = new List<Loan>();
            AData.Open(_dbConnection);
            this.SqlSelectVideo(videoSearch, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                int nColumns = dbDataReader.FieldCount;
                while (dbDataReader.Read())
                {
                    Loan video = new Loan()
                    {
                        ID = dbDataReader.GetInt32(0),
                        Title = dbDataReader.GetString(1),
                        Borrower = dbDataReader.GetString(2),
                        ReturnDate = dbDataReader.GetDateTime(3)
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
            AData.Open(_dbConnection);
            DbDataAdapter dbDataAdapter = _dbProviderFactory.CreateDataAdapter();
            this.SqlSelectVideo(videoSearch, _dbCommand);
            _dbCommand.Connection=_dbConnection;
            dbDataAdapter.SelectCommand = _dbCommand;
            int records = dbDataAdapter.Fill(dataTableVideos);
            AData.Close(_dbConnection);
        }

        public void ReadBorrower(string borrower, out IList<string> ListBorrower)
        {
            ListBorrower = new List<string>();
            AData.Open(_dbConnection);
            this.SqlGetBorrower(borrower, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListBorrower.Add(dbDataReader[0].ToString());
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadBorrowingRate(string BorrowingRate, out IList<double> ListBorrowingRate)
        {
            ListBorrowingRate = new List<double>();
            AData.Open(_dbConnection);
            double doubleBorrowingRate=0.0;
            double.TryParse(BorrowingRate, out doubleBorrowingRate);
            this.SqlGetBorrowingRate(doubleBorrowingRate, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListBorrowingRate.Add(dbDataReader.GetDouble(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadID(string ID, out IList<int> ListID)
        {
            ListID = new List<int>();
            AData.Open(_dbConnection);
            int intid = 0;
            Int32.TryParse(ID,out intid);
            this.SqlGetID(intid, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListID.Add(dbDataReader.GetInt32(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        //public void ReadID(int ID, out IList<int> ListID)
        //{
        //    ListID = new List<int>();
        //    AData.Open(_dbConnection);

        //    this.SqlGetID(ID, _dbCommand);
        //    DbDataReader dbDataReader = _dbCommand.ExecuteReader();
        //    if (dbDataReader.HasRows)
        //    {
        //        while (dbDataReader.Read())
        //            ListID.Add(dbDataReader.GetInt32(0));
        //    }
        //    if (!dbDataReader.IsClosed) dbDataReader.Close();
        //    AData.Close(_dbConnection);
        //}

        public void ReadRated(string Rated, out IList<int> ListRated)
        {
            ListRated = new List<int>();
            AData.Open(_dbConnection);
            int intrated = 0;
            Int32.TryParse(Rated, out intrated);
            this.SqlGetRated(intrated, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListRated.Add(dbDataReader.GetInt32(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadReleaseYear(string ReleaseYear, out IList<int> ListReleaseYear)
        {
            ListReleaseYear = new List<int>();
            AData.Open(_dbConnection);
            int intreleaseYear = 0;
            Int32.TryParse(ReleaseYear, out intreleaseYear);
            this.SqlGetReleaseYear(intreleaseYear, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListReleaseYear.Add(dbDataReader.GetInt32(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadReturnDate(string ReturnDate, out IList<DateTime> ListReturnDate)
        {
            ListReturnDate = new List<DateTime>();
            AData.Open(_dbConnection);

            DateTime dtRetunrDate=DateTime.MinValue;
            dtRetunrDate= Util.ParseDate(ReturnDate, DateTime.Now);
            this.SqlGetReturnDate(dtRetunrDate, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListReturnDate.Add(dbDataReader.GetDateTime(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadRunningTime(string RunningTime, out IList<int> ListRunningTime)
        {
            ListRunningTime = new List<int>();
            AData.Open(_dbConnection);
            int intrunningTime = 0;
            Int32.TryParse(RunningTime, out intrunningTime);
            this.SqlGetRunningTime(intrunningTime, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListRunningTime.Add(dbDataReader.GetInt32(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }

        public void ReadTitle(string Title, out IList<string> ListTitle)
        {
            ListTitle = new List<string>();
            AData.Open(_dbConnection);
            this.SqlGetTitle(Title, _dbCommand);
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                    ListTitle.Add(dbDataReader.GetString(0));
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
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

        protected virtual void SqlGetBorrower(string borrower, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT Borrower FROM VideoTable WHERE Borrower = @Borrower ORDER BY Borrower";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@Borrower", borrower);
        }

        protected virtual void SqlGetBorrowingRate(double borrowingRate, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT BorrowingRate FROM VideoTable WHERE BorrowingRate = @BorrowingRate ORDER BY BorrowingRate";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@BorrowingRate", borrowingRate);
        }

        protected virtual void SqlGetID(int ID, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT ID FROM VideoTable WHERE ID = @ID ORDER BY ID";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@ID", ID);
        }

        protected virtual void SqlGetRated(int rated, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT Rated FROM VideoTable WHERE Rated = @Rated ORDER BY Rated";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@Rated", rated);
        }

        protected virtual void SqlGetReleaseYear(int releaseYear, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT ReleaseYear FROM VideoTable WHERE ReleaseYear = @ReleaseYear ORDER BY ReleaseYear";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@ReleaseYear", releaseYear);
        }

        protected virtual void SqlGetReturnDate(DateTime returnDate, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT ReturnDate FROM VideoTable WHERE ReturnDate = @ReturnDate ORDER BY ReturnDate";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@ReturnDate", returnDate);
        }
        
        protected virtual void SqlGetRunningTime(int runningTime, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT RunningTime FROM VideoTable WHERE RunningTime = @RunningTime ORDER BY RunningTime";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@RunningTime", runningTime);
        }
        
        protected virtual void SqlGetTitle(string title, DbCommand dbCommand)
        {
            dbCommand.CommandText =
            @"SELECT DISTINCT Title FROM VideoTable WHERE Title = @Title ORDER BY Title";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@Title", title);
        }

        protected virtual void SqlSelectVideo(VideoDtoSearch videoSearch, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = @"SELECT * FROM VideoTable";
            dbCommand.CommandText += " WHERE ID = @ID";
            AData.AddParameter(dbCommand, "@ID", videoSearch.ID);

            dbCommand.CommandText += " AND Title = @Title";
            AData.AddParameter(dbCommand, "@Title", videoSearch.Title);
            if (videoSearch.Genre == null) 
            {

            }
            else{
                dbCommand.CommandText += " AND Genre = @Genre";
                AData.AddParameter(dbCommand, "@Genre", videoSearch.Genre);
            }

            if (videoSearch.BorrowingRate == 0)
            {
            }
            else
            {
                dbCommand.CommandText += " AND BorrowingRate = @BorrowingRate";
                AData.AddParameter(dbCommand, "@BorrowingRate", videoSearch.BorrowingRate);
            }
            if (videoSearch.ReleaseYear == 0)
            {

            }
            else
            {
                dbCommand.CommandText += " AND ReleaseYear = @ReleaseYear";
                AData.AddParameter(dbCommand, "@ReleaseYear", videoSearch.ReleaseYear);
            }
            if(videoSearch.RunningTime==0)
            {

            }
            else
            {
                dbCommand.CommandText += " AND RunningTime = @RunningTime";
                AData.AddParameter(dbCommand, "@RunningTime", videoSearch.RunningTime);
            }
           
            if(videoSearch.Rated==0)
            {

            }
            else
            {
                dbCommand.CommandText += " AND Rated = @Rated";
                AData.AddParameter(dbCommand, "@Rated", videoSearch.Rated);
            }

            dbCommand.CommandText += " AND Borrower = @Borrower";
            AData.AddParameter(dbCommand, "@Borrower", videoSearch.Borrower);

            dbCommand.CommandText += " AND ReturnDate = @ReturnDate";
            AData.AddParameter(dbCommand, "@ReturnDate", videoSearch.ReturnDate);

            dbCommand.CommandText += " ORDER BY BorrowingRate;";
        }

        #endregion

    }
}