using System;
using System.Collections.Generic;
using System.Data;
using VideoLogic.Utils;

namespace VideoLogic
{
    public interface IDataSearch
    {
		void ReadID(string ID, out IList<int> ListID);
		void ReadTitle(string Title, out IList<string> ListTitle);
		void ReadGenre(string Genre, out IList<string> ListGenre);
		void ReadBorrowingRate(string BorrowingRate, out IList<double> ListBorrowingRate);
		void ReadReleaseYear(string ReleaseYear, out IList<int> ListReleaseYear);
		void ReadRunningTime(string RunningTime, out IList<int> ListRunningTime);
		void ReadRated(string Rated, out IList<int> ListRated);
		void ReadBorrower(string Borrower, out IList<string> ListBorrower);
		void ReadReturnDate(string ReturnDate, out IList<DateTime> ListReturnDate);
		void ReadVideos(VideoDtoSearch VideoDtoSelected, out IList<Loan> Videos);
		void ReadVideos(VideoDtoSearch VideoDtoSelected, out DataTable dTableVideos);
    }
}
