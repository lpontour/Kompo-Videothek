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
        #region interface IDataLoan
        //Initialisiert eine Verbindung
        public void Init(DbProviderFactory dbProviderFactory,DbConnection dbConnection, DbCommand dbCommand)
        {
            _dbProviderFactory = dbProviderFactory;
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
            _dbDataAdapterVideoTable = AData.CreateDbDataAdapter(_dbProviderFactory, _dbConnection,
              "SELECT * FROM VideoTable;");
        }
        //Legt einen neuen Eintrag in die Datenbank an
        public int InsertLoan(Loan video)
        {
            
            this.SqlInsertVideo(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        //Verändert ein vorhandenes Video in der Datenbank
        public int UpdateLoan(Loan video)
        {
            this.SqlUpdateVideo(video, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        //Entfernt eine Ausleihe in dem ein eintrag verändert wird
        public int DeleteLoan(Loan loan)
        {
            this.SqlReturnVideoLoan(loan, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        //Legt eine Neue Ausleihe an in dem ein eintrag verändert wird
        public int InsertVideoTable(VideoDtoLoan videoLoan)
        {
           
                this.SqlNewVideoLoan(videoLoan, _dbCommand);
                AData.Open(_dbConnection);
                int nRecords = _dbCommand.ExecuteNonQuery();
                AData.Close(_dbConnection);
                return nRecords;
        }
        //Verändert eine Ausleihe
        public int UpdateVideoTable(VideoDtoLoan videoLoan, DateTime returnDate)
        {
            videoLoan.ReturnDate = returnDate;


            this.SqlUptadeVideoLoan(videoLoan, _dbCommand);
            AData.Open(_dbConnection);
            int nRecords = _dbCommand.ExecuteNonQuery();
            AData.Close(_dbConnection);
            return nRecords;
        }
        //Ruft die Methode DeleteLoan auf
        public int DeleteVideoTable(VideoDtoLoan videoLoan, string borrower, DateTime returnDate)
        {
            return this.DeleteLoan(videoLoan);
        }
        #endregion
        #region virtual methods      
        //Erstellt den SQL Befehl für das Hinzufügen eines neus Eintrages und setzt ihn in DbCommand command ein
        protected virtual void SqlInsertVideo(Loan video, DbCommand dbCommand)
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
        //Erstellt den SQL Befehl für das Anpassen eines Eintrages und setzt ihn in DbCommand command ein
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
        //Erstellt den SQL Befehl für das Erstellen einer neuen Ausleihe und setzt ihn in DbCommand command ein
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
        //Erstellt den SQL Befehl für das zurückgeben einer Ausleihe und setzt ihn in DbCommand command ein
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
                dbCommand.CommandType = CommandType.Text;
                dbCommand.Parameters.Clear();
                dbCommand.CommandText = @"UPDATE VideoTable ";
                dbCommand.CommandText += "SET ";
                dbCommand.CommandText += "Borrower = @NewBorrower, ";
                AData.AddParameter(dbCommand, "@NewBorrower", "");
                dbCommand.CommandText += "ReturnDate = @newReturnDate ";
                AData.AddParameter(dbCommand, "@newReturnDate", DateTime.MinValue);
                if (video.Title != "" && video.Title != null)
                {
                    dbCommand.CommandText += $"WHERE Title = @Title";
                    AData.AddParameter(dbCommand, "@Title", video.Title);
                    dbCommand.CommandText += $" And Borrower = @OldBorrower";
                    AData.AddParameter(dbCommand, "@OldBorrower", video.Borrower);
                }
                else
                {
                    dbCommand.CommandText += $"WHERE Borrower = @OldBorrower";
                    AData.AddParameter(dbCommand, "@OldBorrower", video.Borrower);
                }
                if (video.ReturnDate != DateTime.MinValue)
                {
                    dbCommand.CommandText += $" AND ReturnDate >= @DateNow";
                    AData.AddParameter(dbCommand, "@DateNow", DateTime.MinValue.ToString("G"));
                    dbCommand.CommandText += $" AND ReturnDate <= @TillReturnDate;";
                    AData.AddParameter(dbCommand, "@TillReturnDate", video.ReturnDate.ToString("G"));
                }
            }       
        }
        //Erstellt den SQL Befehl für das anpassen eines Eintrages und setzt ihn in DbCommand command ein
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
        #endregion

    }
}