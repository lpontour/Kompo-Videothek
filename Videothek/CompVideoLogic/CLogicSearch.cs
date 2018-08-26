using System.Collections.Generic;
using System.Data;
using VideoLogic.Utils;
using VideoLogic.Exceptions;
using System;

namespace VideoLogic
{
    internal class CLogicSearch : ILogicSearch
    {
		#region fields
		private IDataSearch _dataSearch;
		#endregion

		#region ctor
		internal CLogicSearch(IDataSearch dataSearch) 
		{
			_dataSearch = dataSearch;
		}
		#endregion

		#region interface ILogicSearch methods

		public void ReadVideos(VideoDtoSearch videoSearch, out DataTable datatable) 
		{
			_dataSearch.ReadVideos(videoSearch, out datatable);
		}

		public void ReadVideo(VideoDtoLoan videoLoan, out DataTable dataTable)
		{
			VideoDtoSearch videoSearch = new VideoDtoSearch()
			{
				ID = videoLoan.ID,
				Title = videoLoan.Title,
				Borrower = videoLoan.Borrower,
				ReturnDate = videoLoan.ReturnDate,
			};
			_dataSearch.ReadVideos(videoSearch, out dataTable);

		}

		public object[] ReadID(int ID)
		{
			IList<int> listID = null;
			_dataSearch.ReadID(ID, out listID);
			if (listID == null)
				throw new CDataException("ID-Liste ist leer");
			return Util.ToArray(listID);
		}

		public object[] ReadTitle(string Title)
		{
			IList<string> listTitle = null;
			_dataSearch.ReadTitle(Title, out listTitle);
			if (listTitle == null)
				throw new CDataException("Titelliste ist leer");
			return Util.ToArray(listTitle);
		}

		public object[] ReadGenre(string Genre)
		{
			IList<string> listGenre = null;
			_dataSearch.ReadGenre(Genre, out listGenre);
			if (listGenre == null)
				throw new CDataException("Genreliste ist leer");
			return Util.ToArray(listGenre);
		}

		public object[] ReadBorrowingrate(double BorrowingRate)
		{
			IList<double> listBorrowingRate = null;
			_dataSearch.ReadBorrowingRate(BorrowingRate, out listBorrowingRate);
			if (listBorrowingRate == null)
				throw new CDataException("Preisiste ist leer");
			return Util.ToArray(listBorrowingRate);
		}

		public object[] ReadReleaseYear(int ReleaseYear)
		{
			IList<int> listReleaseYear = null;
			_dataSearch.ReadReleaseYear(ReleaseYear, out listReleaseYear);
			if (listReleaseYear == null)
				throw new CDataException("Erscheinungsjahrliste ist leer");
			return Util.ToArray(listReleaseYear);
		}

		public object[] ReadRunningTime(int RunningTime)
		{
			IList<int> listRunningTime = null;
			_dataSearch.ReadRunningTime(RunningTime, out listRunningTime);
			if (listRunningTime == null)
				throw new CDataException("Laufzeitliste ist leer");
			return Util.ToArray(listRunningTime);
		}

		public object[] ReadRated(int Rated)
		{
			IList<int> listRated = null;
			_dataSearch.ReadRated(Rated, out listRated);
			if (listRated == null)
				throw new CDataException("FSK-Liste ist leer");
			return Util.ToArray(listRated);
		}

		public object[] ReadBorrower(string Borrower)
		{
			IList<string> listBorrower = null;
			_dataSearch.ReadBorrower(Borrower, out listBorrower);
			if (listBorrower == null)
				throw new CDataException("Ausleiherliste ist leer");
			return Util.ToArray(listBorrower);
		}

		public object[] ReadReturnDate(DateTime ReturnDate)
		{
			IList<DateTime> listReturnDate = null;
			_dataSearch.ReadReturnDate(ReturnDate, out listReturnDate);
			if (listReturnDate == null)
				throw new CDataException("Rückgabedatumliste ist leer");
			return Util.ToArray(listReturnDate);
		}

		#endregion
	}
}
