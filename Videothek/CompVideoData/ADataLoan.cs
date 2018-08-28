using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using VideoLogic;
using VideoLogic.Utils;
using System;

namespace VideoData
{
    internal abstract class ADataLoan : IDataLoan
    {
        #region fields
        private AData _data;
        private DbProviderFactory _dbProviderFactory;
        private DbConnection _dbConnection;
        private DbCommand _dbCommand;
        private DbDataAdapter _dbDataAdapterCarTable;
        #endregion
        #region ctor
        internal ADataLoan(AData data)
        {
            _data = data;
        }
        #endregion
        #region interface IDataLoan
        public void Init(DbProviderFactory dbProviderFactory,
           DbConnection dbConnection, DbCommand dbCommand)
        {
            _dbProviderFactory = dbProviderFactory;
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
            _dbDataAdapterCarTable = AData.CreateDbDataAdapter(_dbProviderFactory, _dbConnection,
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
            this.SqlDeleteVideo(loan.ID, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int InsertVideoTable(VideoDtoLoan videoLoan)
        {
            DataTable dataTable = AData.GetSchema(_dbDataAdapterCarTable);
            //videoLoan.AddNewDataRow(dataTable);
            int nRecords = AData.Update(dataTable, _dbDataAdapterCarTable);
            return nRecords;
        }
        public int UpdateVideoTable(VideoDtoLoan videoLoan, DateTime returnDate)
        {
            videoLoan.ReturnDate = returnDate;
            DataTable dataTable = AData.GetSchema(_dbDataAdapterCarTable);
            int nRecords = AData.Update(dataTable, _dbDataAdapterCarTable);
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
        void SqlUpdateVideo(Loan video, DbCommand dbCommand)
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