using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using VideoLogic;
using VideoLogic.Exceptions;
namespace VideoData
{
    internal abstract class AData : IData
    {
        #region fields      
        protected string _connection;
        protected string _provider;
        protected ADataSearch _dataSearch;
        protected ADataLoan _dataLoan;
        protected DbProviderFactory _dbProviderFactory;
        protected DbConnection _dbConnection;
        protected DbCommand _dbCommand;
        #endregion
        #region interface IData properties
        public IDataSearch Search { get { return _dataSearch; } }
        public IDataLoan Loan { get { return _dataLoan; } }
        #endregion
        #region ctor
        internal AData(string connection)
        {
            if (string.IsNullOrEmpty(connection))
                throw new CDataException("InitDb() Connection String ist leer");
            _connection = connection;
        }
        #endregion
        #region interface IData methods
        public void Init()
        {
            // Create Provider Factory 
            _dbProviderFactory = DbProviderFactories.GetFactory(_provider);
            if (_dbProviderFactory == null)
                throw new CDataException("InitDb() konnte DbProviderFactory nicht erzeugen");
            // Create DbConnection - Factory Method CreateConnection()
            _dbConnection = _dbProviderFactory.CreateConnection();
            if (_dbConnection == null)
                throw new CDataException("InitDb() konnte DbConnection nicht erzeugen");
            // set the connectionString
            _dbConnection.ConnectionString = _connection;
            // Setup DbCommand objects
            _dbCommand = _dbProviderFactory.CreateCommand();
            _dbCommand.Connection = _dbConnection; // Dependency Injection via Setter
            _dbCommand.CommandType = CommandType.Text;
            _dataSearch.Init(_dbProviderFactory, _dbConnection, _dbCommand);
            _dataLoan.Init(_dbProviderFactory, _dbConnection, _dbCommand);
        }
        public void InitApp(ref int nVideos, out IList<string> genres)
        {
            AData.Open(_dbConnection);
            _dbCommand.CommandText = "SELECT COUNT(*) FROM VideoTable;";
            _dbCommand.CommandType = CommandType.Text;
            nVideos = (int)_dbCommand.ExecuteScalar();
            AData.Close(_dbConnection);
            AData.Open(_dbConnection);
            genres = new List<string>();
            _dbCommand.CommandText = "SELECT DISTINCT Genre FROM VideoTable ORDER BY Genre;";
            _dbCommand.CommandType = CommandType.Text;
            DbDataReader dbDataReader = _dbCommand.ExecuteReader();
            if (dbDataReader != null)
            {
                while (dbDataReader.Read())
                    genres.Add(dbDataReader[0].ToString());
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(_dbConnection);
        }
        #endregion
        #region static methods
        public static void Open(DbConnection dbConnection)
        {
            if (dbConnection.State == ConnectionState.Open) return;
            dbConnection.Open();
            if (dbConnection.State != ConnectionState.Open)
            {
                var connection = dbConnection.ConnectionString;
                throw new CDataException($"Open() Datenbank läßt sich nicht öffnen\n{connection}");
            }
        }
        public static void Close(DbConnection dbConnection)
        {
            if (dbConnection.State != ConnectionState.Open) return;
            dbConnection.Close();
            if (dbConnection.State != ConnectionState.Closed)
            {
                var connection = dbConnection.ConnectionString;
                throw new CDataException($"Close() Datenbank läßt sich nicht schließen\n{connection}");
            }
        }
        public static void AddParameter(DbCommand dbCommand, string name, object value)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }
        public static DbDataAdapter CreateDbDataAdapter(
          DbProviderFactory dbProviderFactory, DbConnection dbConnection, string sql)
        {
            DbCommand dbSelectCommand = dbProviderFactory.CreateCommand();
            dbSelectCommand.Connection = dbConnection;
            dbSelectCommand.CommandText = sql;
            DbDataAdapter dbDataAdapter = dbProviderFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = dbSelectCommand;
            DbCommandBuilder dbCommandBuilder = dbProviderFactory.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            return dbDataAdapter;
        }
        public static int Fill(DataTable dataTable, DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dataTable == null)
                throw new DataException(" ADatabase.Fill() dataTable is null");
            if (dbDataAdapter == null)
                throw new DataException(" ADatabase.Fill() dbDataAdapter is null");
            int nRows = dbDataAdapter.Fill(dataTable);
            return nRows;
        }
        public static int Update(DataTable dataTable, DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dataTable == null)
                throw new DataException(" ADatabase.Update() dataTable is null");
            if (dbDataAdapter == null)
                throw new DataException(" ADatabase.Update() dbDataAdapter is null");
            int nRows = dbDataAdapter.Update(dataTable);
            // post condition is nRows == 0 zulässig?
            return nRows;
        }
        public static DataTable GetSchema(DbDataAdapter dbDataAdapter)
        {
            // preconditions
            if (dbDataAdapter == null)
                throw new DataException(" ADatabase.GetSchema() dbDataAdapter is null");
            DataTable dataTable = new DataTable();
            dataTable = dbDataAdapter.FillSchema(dataTable, SchemaType.Source);
            return dataTable;
        }
        public static void SetRowStateAdded(DataRow dataRow)
        {
            dataRow.SetAdded();
        }
        #endregion
        #region protected virtual methods
        // SQL-Injection bezeichnet das Ausnutzen einer Sicherheitslücke in SQL-Datenbanken, 
        // die durch mangelnde Maskierung oder Überprüfung von Metazeichen in Benutzereingaben 
        // entsteht.
        // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel'";
        // CommandText = "SELECT DISTINCT Model FROM CarTable WHERE Make='Opel';DELETE ...; ";
        // -----------------------------------------------------------------------------            
        // Create a Stored Procedure            
        public static void CreatedStoredProcedure(string sql, DbCommand dbCommand)
        {
            dbCommand.CommandText =
                @"CREATE PROCEDURE Video_SelectModelbyMake (pMake TEXT) as
                          SELECT DISTINCT Title FROM VideoTable WHERE Genre = [pMake] ORDER BY Title";
            dbCommand.CommandType = CommandType.Text;
            AData.Open(dbCommand.Connection);
            int result = dbCommand.ExecuteNonQuery();
            AData.Close(dbCommand.Connection);
        }
        // Used a Stored Procedure
        public static void UseStoredProcedure(string maker, IList<string> models, DbCommand dbCommand)
        {
            dbCommand.CommandText = "VideoTable_SelectModelbyMake";
            dbCommand.CommandType = CommandType.StoredProcedure;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "pMake";
            dbParameter.Value = maker;
            dbCommand.Parameters.Clear();
            dbCommand.Parameters.Add(dbParameter);
            models = new List<string>();
            AData.Open(dbCommand.Connection);
            DbDataReader dbDataReader = dbCommand.ExecuteReader();
            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                {
                    models.Add(dbDataReader[0].ToString());
                }
            }
            if (!dbDataReader.IsClosed) dbDataReader.Close();
            AData.Close(dbCommand.Connection);
            dbCommand.Parameters.Clear();
        }
        // Dynamic SQL Statement - User input via Parameter
        public static void DbCommandGetModel(string genre, DbCommand dbCommand)
        {
            dbCommand.CommandText =
               @"SELECT DISTINCT Title FROM VideoTable WHERE Maker = [pGenre] "
               + "ORDER BY Title";
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "pGenre";
            dbParameter.Value = genre;
            dbCommand.Parameters.Add(dbParameter);
        }
        public static DbDataAdapter CreateDataAdapter(string sql,
          DbProviderFactory dbProviderFactory, DbConnection dbConnection)
        {
            DbCommand dbSelectCommand = dbProviderFactory.CreateCommand();
            dbSelectCommand.Connection = dbConnection;
            dbSelectCommand.CommandText = sql;
            DbDataAdapter dbDataAdapter = dbProviderFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = dbSelectCommand;
            DbCommandBuilder dbCommandBuilder = dbProviderFactory.CreateCommandBuilder();
            dbCommandBuilder.DataAdapter = dbDataAdapter;
            dbDataAdapter.InsertCommand = dbCommandBuilder.GetInsertCommand();
            dbDataAdapter.UpdateCommand = dbCommandBuilder.GetUpdateCommand();
            dbDataAdapter.DeleteCommand = dbCommandBuilder.GetDeleteCommand();
            return dbDataAdapter;
        }
        #endregion
    }
}