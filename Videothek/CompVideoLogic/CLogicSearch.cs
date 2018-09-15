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
		//Sucht nach einem Video
		public void ReadVideos(VideoDtoSearch videoSearch, out DataTable datatable)
		{
			_dataSearch.ReadVideos(videoSearch, out datatable);
		}

		//Sucht mit Filtern nach einem Video
		public void ReadVideo(VideoDtoLoan videoLoan, out DataTable dataTable)
		{
			VideoDtoSearch videoSearch = new VideoDtoSearch()
			{
				ID = videoLoan.ID,
				Title = videoLoan.Title,
				Borrower = videoLoan.Borrower,
				ReturnDate = videoLoan.ReturnDate,
				Rated = 1,
			};
			_dataSearch.ReadVideos(videoSearch, out dataTable);

		}

		//Liest alle IDs aus
		public object[] ReadID(string value)
		{
			IList<int> listID = null;
			_dataSearch.ReadID(value, out listID);
			if (listID == null)
				throw new CDataException("ID-Liste ist leer");
			return Util.ToArray(listID);
		}


		//Liest alla Titel aus
		public object[] ReadTitle(string value)
		{
			IList<string> listTitle = null;
			_dataSearch.ReadTitle(value, out listTitle);
			if (listTitle == null)
				throw new CDataException("Titelliste ist leer");
			return Util.ToArray(listTitle);
		}

		//Liest alle Genre aus
		public object[] ReadGenre(string value)
		{
			IList<string> listGenre = null;
			_dataSearch.ReadGenre(value, out listGenre);
			if (listGenre == null)
				throw new CDataException("Genreliste ist leer");
			return Util.ToArray(listGenre);
		}

		//Liest alle Preise aus
		public object[] ReadBorrowingRate(string value)
		{
			IList<double> listBorrowingRate = null;
			_dataSearch.ReadBorrowingRate(value, out listBorrowingRate);
			if (listBorrowingRate == null)
				throw new CDataException("Preisiste ist leer");
			return Util.ToArray(listBorrowingRate);
		}

		//Liest alle Releas Daten aus
		public object[] ReadReleaseYear(string value)
		{
			IList<int> listReleaseYear = null;
			_dataSearch.ReadReleaseYear(value, out listReleaseYear);
			if (listReleaseYear == null)
				throw new CDataException("Erscheinungsjahrliste ist leer");
			return Util.ToArray(listReleaseYear);
		}

		//Liest alle Laufzeiten aus
		public object[] ReadRunningTime(string value)
		{
			IList<int> listRunningTime = null;
			_dataSearch.ReadRunningTime(value, out listRunningTime);
			if (listRunningTime == null)
				throw new CDataException("Laufzeitliste ist leer");
			return Util.ToArray(listRunningTime);
		}

		//Liest die FSK aus
		public object[] ReadRated(string value)
		{
			IList<int> listRated = null;
			_dataSearch.ReadRated(value, out listRated);
			if (listRated == null)
				throw new CDataException("FSK-Liste ist leer");
			return Util.ToArray(listRated);
		}

		//Gibt alle Ausleihenden aus
		public object[] ReadBorrower(string value)
		{
			IList<string> listBorrower = null;
			_dataSearch.ReadBorrower(value, out listBorrower);
			return Util.ToArray(listBorrower);
		}

		//Gibt das Rückgabedatum zurück
		public object[] ReadReturnDate(string value)
		{
			IList<DateTime> listReturnDate = null;
			_dataSearch.ReadReturnDate(value, out listReturnDate);
			return Util.ToArray(listReturnDate);
		}

		#endregion
	}
}

