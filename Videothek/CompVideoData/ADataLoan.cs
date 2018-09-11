using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using VideoLogic;
using VideoLogic.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VideoData
{
    internal abstract class ADataLoan : IDataLoan
    {
        #region fields
        private AData _data;
        private DbProviderFactory _dbProviderFactory;
        private DbConnection _dbConnection;
        private DbCommand _dbCommand;
        private DbDataAdapter _dbDataAdapterVideoTable;
        #endregion
        #region ctor
        internal ADataLoan(AData data)
        {
            _data = data;
        }
        #endregion
        #region methods
        private bool VideoIdMissMach(VideoDtoLoan loan)
        {

            List<Loan> videos = new List<Loan>();
            AData.Open(_dbConnection);
            _dbCommand.CommandType = CommandType.Text;
            _dbCommand.Parameters.Clear();
            _dbCommand.CommandText = @"SELECT * FROM VideoTable";
            _dbCommand.CommandText += " WHERE ID = @ID";
            AData.AddParameter(_dbCommand, "@ID", loan.ID);
            _dbCommand.CommandText += " AND Title = @Title";
            AData.AddParameter(_dbCommand, "@Title", loan.Title);
            _dbCommand.CommandText += " ORDER BY BorrowingRate;";
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            
            if (dbDataReader.HasRows)
            {
                AData.Close(_dbConnection);
                return false;

            }
            else
            {
                AData.Close(_dbConnection);
                return true;
            }
        }
        private bool VideoNotLoaned(VideoDtoLoan loan)
        {
            List<Loan> videos = new List<Loan>();
            AData.Open(_dbConnection);
            _dbCommand.CommandType = CommandType.Text;
            _dbCommand.Parameters.Clear();
            _dbCommand.CommandText = @"SELECT * FROM VideoTable";
            _dbCommand.CommandText += " WHERE ID = @ID";
            AData.AddParameter(_dbCommand, "@ID", loan.ID);
            _dbCommand.CommandText += " AND Title = @Title";
            AData.AddParameter(_dbCommand, "@Title", loan.Title);

            _dbCommand.CommandText += " ORDER BY BorrowingRate;";
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
            else
            {
                AData.Close(_dbConnection);
                return false;
            }
            if(videos[0].Borrower==""&&videos[0].ReturnDate==DateTime.MinValue)
            {
                AData.Close(_dbConnection);
                return true;
            }
            AData.Close(_dbConnection);
            return false;
        }
        private bool BorrowerMissMach(VideoDtoLoan loan)
        {
            List<Loan> videos = new List<Loan>();
            AData.Open(_dbConnection);
            _dbCommand.CommandType = CommandType.Text;
            _dbCommand.Parameters.Clear();
            _dbCommand.CommandText = @"SELECT * FROM VideoTable";
            _dbCommand.CommandText += " WHERE ID = @ID";
            AData.AddParameter(_dbCommand, "@ID", loan.ID);
            _dbCommand.CommandText += " AND Title = @Title";
            AData.AddParameter(_dbCommand, "@Title", loan.Title);
            _dbCommand.CommandText += " ORDER BY BorrowingRate;";
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
                        Borrower = dbDataReader.GetString(8),
                        ReturnDate = dbDataReader.GetDateTime(9)
                    };
                    videos.Add(video);
                }
            }
            else
            {
                AData.Close(_dbConnection);
                return true;
            }
            if (videos[0].Borrower != loan.Borrower )
            {
                AData.Close(_dbConnection);
                return true;
            }
            AData.Close(_dbConnection);
            return false;
        }

        private Loan GetNextFreeVideo(VideoDtoLoan loan)
        {
            List<Loan> videos = new List<Loan>();
            AData.Open(_dbConnection);
            _dbCommand.CommandType = CommandType.Text;
            _dbCommand.Parameters.Clear();
            _dbCommand.CommandText = @"SELECT * FROM VideoTable";
            _dbCommand.CommandText += " WHERE Title = @Title";
            AData.AddParameter(_dbCommand, "@Title", loan.Title);
            _dbCommand.CommandText += " ORDER BY ID;";
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            AData.Close(_dbConnection);
            if (dbDataReader.HasRows)
            {
                int nColumns = dbDataReader.FieldCount;
                while (dbDataReader.Read())
                {
                    Loan video = new Loan()
                    {
                        ID = dbDataReader.GetInt32(0),
                        Title = dbDataReader.GetString(1),
                        Borrower = dbDataReader.GetString(8),
                        ReturnDate = dbDataReader.GetDateTime(9)
                    };
                    if (video.Borrower == "" && video.ReturnDate == DateTime.MinValue)
                    {
                        AData.Close(_dbConnection);
                        return video;
                    }
                }
            }
            else
            {
                AData.Close(_dbConnection);
                return null;
            }
            AData.Close(_dbConnection);
            return null;
        }

        #endregion
        #region interface IDataLoan
        public void Init(DbProviderFactory dbProviderFactory,
           DbConnection dbConnection, DbCommand dbCommand)
        {
            _dbProviderFactory = dbProviderFactory;
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
            _dbDataAdapterVideoTable = AData.CreateDbDataAdapter(_dbProviderFactory, _dbConnection,
              "SELECT * FROM VideoTable;");
        }
        public int InsertLoan(Loan video)
        {
            
            this.SqlInsertVido(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int UpdateLoan(Loan video)
        {
            this.SqlUpdateVideo(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int DeleteLoan(Loan loan)
        {
            this.SqlReturnVideoLoan(loan, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int InsertVideoTable(VideoDtoLoan videoLoan)
        {
           
                this.SqlNewVideoLoan(videoLoan, _dbCommand);
                AData.Open(_dbConnection);
                int nRecords = _dbCommand.ExecuteNonQuery();
                AData.Close(_dbConnection);
                return nRecords;
        }
        public int UpdateVideoTable(VideoDtoLoan videoLoan, DateTime returnDate)
        {
            videoLoan.ReturnDate = returnDate;


            this.SqlUptadeVideoLoan(videoLoan, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int DeleteVideoTable(VideoDtoLoan videoLoan, string borrower, DateTime returnDate)
        {
            return this.DeleteLoan(videoLoan);
        }
        #endregion
        #region virtual methods      
        protected virtual void SqlInsertVido(Loan video, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = $"INSERT INTO VideoTable" +
               $" (  Title, Genre, BorrowingRate, ReleaseYear, RunningTime, Rated,Borrower,ReturnDate )" +
               $" VALUES " +
               $" ( @title, @genre, @borrowingRate, @releaseYear, @runningTime, @rated, @borrower, @returnDate);";
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@title", video.Title);
            AData.AddParameter(dbCommand, "@borrower", video.Borrower);
            AData.AddParameter(dbCommand, "@returnDate", video.ReturnDate);
        }
        protected void SqlUpdateVideo(Loan video, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
                dbCommand.CommandText = $"UPDATE VideoTable " +
                   $"SET " +
                   $"Borrower = ?, ReturnDate = ? " +
                   $"WHERE ID = ?;";
                dbCommand.Parameters.Clear();
                AData.AddParameter(dbCommand, "Borrower", video.Borrower);
                AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                AData.AddParameter(dbCommand, "ID", video.ID);
  
        }
        protected void SqlNewVideoLoan(Loan video, DbCommand dbCommand)
        {
            if(video.ID!=0)
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandText = $"UPDATE VideoTable " +
                   $"SET " +
                   $"Borrower = ?, ReturnDate = ? " +
                   $"WHERE ID = ?;";
                dbCommand.Parameters.Clear();
                AData.AddParameter(dbCommand, "Borrower", video.Borrower);
                AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                AData.AddParameter(dbCommand, "ID", video.ID);
            }
            else
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandText = $"UPDATE VideoTable " +
                   $"SET " +
                   $"Borrower = ?, ReturnDate = ? " +
                   $"WHERE Title = ?"+
                   $"And Borrower =?";
                dbCommand.Parameters.Clear();
                AData.AddParameter(dbCommand, "Borrower", video.Borrower);
                AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                AData.AddParameter(dbCommand, "Title", video.Title);
                AData.AddParameter(dbCommand, "NewBorrower", "");

            }
        }
        protected void SqlReturnVideoLoan(Loan video, DbCommand dbCommand)
        {
            if (video.ID != 0)
            {
                video.Borrower = "";
                video.ReturnDate = DateTime.MinValue;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandText = $"UPDATE VideoTable " +
                   $"SET " +
                   $"Borrower = ?, ReturnDate = ? " +
                   $"WHERE ID = ?;";
                dbCommand.Parameters.Clear();
                AData.AddParameter(dbCommand, "Borrower", video.Borrower);
                AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                AData.AddParameter(dbCommand, "ID", video.ID);
            }
            else
            {
                if (video.ReturnDate == DateTime.MinValue)
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandText = $"UPDATE VideoTable " +
                       $"SET " +
                       $"Borrower = ?, ReturnDate = ? " +
                       $"WHERE Borrower = ?;";
                    dbCommand.Parameters.Clear();
                    AData.AddParameter(dbCommand, "Borrower", "");
                    AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                    AData.AddParameter(dbCommand, "Borrower", video.Borrower);
                }else
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandText = @"UPDATE VideoTable ";
                    dbCommand.CommandText += "SET ";
                    dbCommand.CommandText += "Borrower = @NewBorrower, ";
                    AData.AddParameter(dbCommand, "@NewBorrower", "");
                    dbCommand.CommandText += "ReturnDate = @newReturnDate ";
                    AData.AddParameter(dbCommand, "@newReturnDate", DateTime.MinValue);
                    dbCommand.CommandText += $"WHERE Borrower = @OldBorrower";
                    AData.AddParameter(dbCommand, "@OldBorrower", video.Borrower);
                    dbCommand.CommandText += $" AND ReturnDate >= @DateNow";
                    AData.AddParameter(dbCommand, "@DateNow", DateTime.MinValue.ToString("G"));
                    dbCommand.CommandText += $" AND ReturnDate <= @TillReturnDate;";
                    AData.AddParameter(dbCommand, "@TillReturnDate", video.ReturnDate.ToString("G"));
                }
            }       
        }
        protected void SqlUptadeVideoLoan(Loan video, DbCommand dbCommand)
        {
            if (video.ID != 0)
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandText = $"UPDATE VideoTable " +
                   $"SET " +
                   $"ReturnDate = ? " +
                   $"WHERE ID = ?;";
                dbCommand.Parameters.Clear();
                AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                AData.AddParameter(dbCommand, "ID", video.ID);
            }
            else
            {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandText = $"UPDATE VideoTable " +
                       $"SET " +
                       $"ReturnDate = ? " +
                       $"WHERE Borrower = ? ";
                    dbCommand.Parameters.Clear();
                    AData.AddParameter(dbCommand, "ReturnDate", video.ReturnDate);
                    AData.AddParameter(dbCommand, "Borrower", video.Borrower);
            }
        }
        void SqlDeleteVideo(int id, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = $"DELETE * FROM VideoTable WHERE ID = ?;";
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@ID", id);  
        }
        #endregion

    }
}