using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using VideoLogic;
using VideoLogic.Utils;
namespace VideoData
{
    class ADataLoan : IDataLoan
    {
        #region fields
        // Komoposition 
        private AData _data;
        // namespace System.Data.Common
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
        public int InsertCar(Video video)
        {
            this.SqlInsertVido(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int UpdateVideo(Video video, string borrower, DateTime returnDate)
        {
            video.Borrower = borrower;
            video.ReturnDate = returnDate;
            this.SqlUpdateVideo(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        public int DeleteVideo(int ID)
        {
            this.SqlDeleteVideo(ID, _dbCommand);
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
        public int UpdateCarTable(VideoDtoLoan videoLoan, string Borrower, DateTime returnDate)
        {
            // videoLoan.Borrower = Borrower;
            // videoLoan.ReturnDate = returnDate;
            DataTable dataTable = AData.GetSchema(_dbDataAdapterCarTable);
            // videoLoan.AddNewDataRow(dataTable);
            int nRecords = AData.Update(dataTable, _dbDataAdapterCarTable);
            return nRecords;
        }
        #endregion
        #region virtual methods      
        protected virtual void SqlInsertVido(Video video, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = $"INSERT INTO VideoTable" +
               $" (  Title, Genre, BorrowingRate, ReleaseYear, RunningTime, Rated,Borrower,ReturnDate )" +
               $" VALUES " +
               $" ( @title, @genre, @borrowingRate, @releaseYear, @runningTime, @rated, @borrower, @returnDate);";
            dbCommand.Parameters.Clear();
            AData.AddParameter(dbCommand, "@title", video.Title);
            AData.AddParameter(dbCommand, "@genre", video.Genre);
            AData.AddParameter(dbCommand, "@borrowingRate", video.BorrowingRate);
            AData.AddParameter(dbCommand, "@releaseYear", video.ReleaseYear);
            AData.AddParameter(dbCommand, "@runningTime", video.RunningTime);
            AData.AddParameter(dbCommand, "@rated", video.Rated);
            AData.AddParameter(dbCommand, "@borrower", video.Borrower);
            AData.AddParameter(dbCommand, "@returnDate", video.ReturnDate);
        }
        void SqlUpdateVideo(Video video, DbCommand dbCommand)
        {
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = $"UPDATE VideoTable " +
               $"SET " +
               $"Borrower = ?, ReturnDate = ? " +
               $"WHERE pkGUID = ?;";
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