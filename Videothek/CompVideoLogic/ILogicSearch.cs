using System;
using System.Data;
using System.Threading.Tasks;
using VideoLogic.Utils;

namespace VideoLogic
{
    public interface ILogicSearch
    {
		//Das Suchen Interface
		object[] ReadID(string ID);
		object[] ReadTitle(string Title);
		object[] ReadGenre(string Genre);
		object[] ReadBorrowingRate(string BorrowingRate);
		object[] ReadReleaseYear(string ReleaseYear);
		object[] ReadRunningTime(string RunningTime);
		object[] ReadRated(string Rated);
		object[] ReadBorrower(string Borrower);
		object[] ReadReturnDate(string ReturnDate);
		// Lese alle Daten der Tabelle
		void ReadVideos(VideoDtoSearch videoSearch, out DataTable dataTable);
		// Lese nur geänderte Einträge der Tabelle
		void ReadVideo(VideoDtoLoan videoLoan, out DataTable dataTable);
	}
}
