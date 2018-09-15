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
        //Gibt das _dataSearch Objekt zurück
        public IDataSearch Search { get { return _dataSearch; } }
        //Gibt das _dataLoan Objekt zurück
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
        //Initialisiert die benötigten Objekte für die Datenbank auf
        public void Init()
        {
            _dbProviderFactory = DbProviderFactories.GetFactory(_provider);
            if (_dbProviderFactory == null)
                throw new CDataException("InitDb() konnte DbProviderFactory nicht erzeugen");
            _dbConnection = _dbProviderFactory.CreateConnection();
            if (_dbConnection == null)
                throw new CDataException("InitDb() konnte DbConnection nicht erzeugen");
            _dbConnection.ConnectionString = _connection;
            _dbCommand = _dbProviderFactory.CreateCommand();
            _dbCommand.Connection = _dbConnection;
            _dbCommand.CommandType = CommandType.Text;
            _dataSearch.Init(_dbProviderFactory, _dbConnection, _dbCommand);
            _dataLoan.Init(_dbProviderFactory, _dbConnection, _dbCommand);
        }
        #endregion
        #region static methods
        //Öffnet eine Verbindung zu der Datenbank
        //Benötigt die Datenbankverbindung
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
        //Schliest die Verbindung zu der Datenbank
        //Benötigt eine Datenbankverbindung
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
        //Knüpft einen Parameter den passenden Wert an
        //Benötigt eine Datenbankverbindung, den Parameternamen und den Parameterwert
        public static void AddParameter(DbCommand dbCommand, string name, object value)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }
        //Erzeugt einen DbDataAdapter für die Verbindung und den SQL-Befehl
        //Benötigt eine DbProviderFactory, Eine Verbindung und ein SQL-Befehl
        public static DbDataAdapter CreateDbDataAdapter( DbProviderFactory dbProviderFactory, DbConnection dbConnection, string sql)
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