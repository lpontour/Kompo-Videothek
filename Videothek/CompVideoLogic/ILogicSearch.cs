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
		object[] ReadID(VideoDtoSearch suche);
		object[] ReadTitle(string Title);
		object[] ReadTitle(VideoDtoSearch suche);
		object[] ReadGenre(string Genre);
		object[] ReadGenre(VideoDtoSearch suche);
		object[] ReadBorrowingRate(string BorrowingRate);
		object[] ReadBorrowingRate(VideoDtoSearch suche);
		object[] ReadReleaseYear(string ReleaseYear);
		object[] ReadReleaseYear(VideoDtoSearch suche);
		object[] ReadRunningTime(string RunningTime);
		object[] ReadRunningTime(VideoDtoSearch suche);
		object[] ReadRated(string Rated);
		object[] ReadRated(VideoDtoSearch suche);
		object[] ReadBorrower(string Borrower);
		object[] ReadBorrower(VideoDtoSearch suche);
		object[] ReadReturnDate(string ReturnDate);
		object[] ReadReturnDate(VideoDtoSearch suche);
		bool FreeTitles(VideoDtoLoan ausleihe);
		// Lese alle Daten der Tabelle
		void ReadVideos(VideoDtoSearch videoSearch, out DataTable dataTable);
		// Lese nur geänderte Einträge der Tabelle
		void ReadVideo(VideoDtoLoan videoLoan, out DataTable dataTable);
	}
}
