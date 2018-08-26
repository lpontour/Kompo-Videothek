using System;
using System.Data;
using System.Threading.Tasks;
using VideoLogic.Utils;

namespace VideoLogic
{
    public interface ILogicSearch
    {
		object[] ReadID(int ID);
		object[] ReadTitle(string Title);
		object[] ReadGenre(string Genre);
		object[] ReadBorrowingrate(double BorrowingRate);
		object[] ReadReleaseYear(int ReleaseYear);
		object[] ReadRunningTime(int RunningTime);
		object[] ReadRated(int Rated);
		object[] ReadBorrower(string Borrower);
		object[] ReadReturnDate(DateTime ReturnDate);
		// Lese alle Daten der Tabelle
		void ReadVideos(VideoDtoSearch videoSearch, out DataTable dataTable);
		// Lese nur geänderte Einträge der Tabelle
		void ReadVideo(VideoDtoLoan videoLoan, out DataTable dataTable);
	}
}
