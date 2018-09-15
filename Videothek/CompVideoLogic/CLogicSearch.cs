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

		public object[] ReadID(VideoDtoSearch value)
		{
			List<int> listID = new List<int>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string id = row["ID"].ToString();
				listID.Add(Util.ParseInt(id, 0));
				listID.Sort();
			}
			if (listID == null)
				throw new CDataException("ID-Liste ist leer");
			return Util.ToArray(listID);
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
		public object[] ReadTitle(VideoDtoSearch value)
		{
			List<string> listTitle = new List<string>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string title = row["Title"].ToString();
				if (!listTitle.Contains(title))
				{
					listTitle.Add(title);
					listTitle.Sort();
				}
			}
			if (listTitle == null)
				throw new CDataException("Titelliste ist leer");
			return Util.ToArray(listTitle);
		}


		public object[] ReadTitle(string value)
		{
			IList<string> listTitle = null;
			_dataSearch.ReadTitle(value, out listTitle);
			if (listTitle == null)
				throw new CDataException("Titelliste ist leer");
			return Util.ToArray(listTitle);
		}

		//Liest alle Genre aus
		public object[] ReadGenre(VideoDtoSearch value)
		{
			List<string> listGenre = new List<string>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string genre = row["Genre"].ToString();
				if (!listGenre.Contains(genre))
				{
					listGenre.Add(genre);
					listGenre.Sort();
				}
			}
			if (listGenre == null)
				throw new CDataException("Genreliste ist leer");
			return Util.ToArray(listGenre);
		}


		public object[] ReadGenre(string value)
		{
			IList<string> listGenre = null;
			_dataSearch.ReadGenre(value, out listGenre);
			if (listGenre == null)
				throw new CDataException("Genreliste ist leer");
			return Util.ToArray(listGenre);
		}

		//Liest alle Preise aus
		public object[] ReadBorrowingRate(VideoDtoSearch value)
		{
			List<double> listBorrowingRate = new List<double>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string borrowingRate = row["BorrowingRate"].ToString();
				if (!listBorrowingRate.Contains(Util.ParseDouble(borrowingRate, 0.0)))
				{
					listBorrowingRate.Add(Util.ParseDouble(borrowingRate, 0.0));
					listBorrowingRate.Sort();
				}
			}
			if (listBorrowingRate == null)
				throw new CDataException("Preisiste-Liste ist leer");
			return Util.ToArray(listBorrowingRate);
		}


		public object[] ReadBorrowingRate(string value)
		{
			IList<double> listBorrowingRate = null;
			_dataSearch.ReadBorrowingRate(value, out listBorrowingRate);
			if (listBorrowingRate == null)
				throw new CDataException("Preisiste ist leer");
			return Util.ToArray(listBorrowingRate);
		}

		//Liest alle Release Daten aus
		public object[] ReadReleaseYear(VideoDtoSearch value)
		{
			List<int> listReleaseYear = new List<int>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string releaseYear = row["ReleaseYear"].ToString();
				if (!listReleaseYear.Contains(Util.ParseInt(releaseYear, 0)))
				{
					listReleaseYear.Add(Util.ParseInt(releaseYear, 0));
					listReleaseYear.Sort();
				}
			}
			if (listReleaseYear == null)
				throw new CDataException("Erscheinungsjahrliste ist leer");
			return Util.ToArray(listReleaseYear);
		}


		public object[] ReadReleaseYear(string value)
		{
			IList<int> listReleaseYear = null;
			_dataSearch.ReadReleaseYear(value, out listReleaseYear);
			if (listReleaseYear == null)
				throw new CDataException("Erscheinungsjahrliste ist leer");
			return Util.ToArray(listReleaseYear);
		}

		//Liest alle Laufzeiten aus
		public object[] ReadRunningTime(VideoDtoSearch value)
		{
			List<int> listRunningTime = new List<int>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string runningTime = row["RunningTime"].ToString();
				if (!listRunningTime.Contains(Util.ParseInt(runningTime, 0)))
				{
					listRunningTime.Add(Util.ParseInt(runningTime, 0));
					listRunningTime.Sort();
				}
			}
			if (listRunningTime == null)
				throw new CDataException("Laufzeitliste-Liste ist leer");
			return Util.ToArray(listRunningTime);
		}


		public object[] ReadRunningTime(string value)
		{
			IList<int> listRunningTime = null;
			_dataSearch.ReadRunningTime(value, out listRunningTime);
			if (listRunningTime == null)
				throw new CDataException("Laufzeitliste ist leer");
			return Util.ToArray(listRunningTime);
		}

		//Liest die FSK aus
		public object[] ReadRated(VideoDtoSearch value)
		{
			List<int> listRated = new List<int>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string rated = row["Rated"].ToString();
				if (!listRated.Contains(Util.ParseInt(rated, 1)))
				{
					listRated.Add(Util.ParseInt(rated, 1));
					listRated.Sort();
				}
			}
			if (listRated == null)
				throw new CDataException("FSK-Liste ist leer");
			return Util.ToArray(listRated);
		}


		public object[] ReadRated(string value)
		{
			IList<int> listRated = null;
			_dataSearch.ReadRated(value, out listRated);
			if (listRated == null)
				throw new CDataException("FSK-Liste ist leer");
			return Util.ToArray(listRated);
		}

		//Gibt alle Ausleihenden aus
		public object[] ReadBorrower(VideoDtoSearch value)
		{
			List<string> listBorrower = new List<string>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string borrower = row["Borrower"].ToString();
				if (!listBorrower.Contains(borrower))
				{
					listBorrower.Add(borrower);
					listBorrower.Sort();
				}
			}
			if (listBorrower == null)
				throw new CDataException("Borrower-Liste ist leer");
			return Util.ToArray(listBorrower);
		}


		public object[] ReadBorrower(string value)
		{
			IList<string> listBorrower = null;
			_dataSearch.ReadBorrower(value, out listBorrower);
			return Util.ToArray(listBorrower);
		}

		//Gibt das Rückgabedatum zurück
		public object[] ReadReturnDate(VideoDtoSearch value)
		{
			List<DateTime> listReturnDate = new List<DateTime>();
			ReadVideos(value, out DataTable dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string returnDate = row["ReturnDate"].ToString();
				if (!listReturnDate.Contains(Util.ParseDate(returnDate, DateTime.MinValue)) && (Util.ParseDate("1.1.2001", DateTime.MinValue) != Util.ParseDate(returnDate, DateTime.MinValue)))
				{
					listReturnDate.Add(Util.ParseDate(returnDate, DateTime.MinValue));
					listReturnDate.Sort();
				}
			}
			if (listReturnDate == null)
				throw new CDataException("ReturnDate-Liste ist leer");
			return Util.ToArray(listReturnDate);
		}


		public object[] ReadReturnDate(string value)
		{
			IList<DateTime> listReturnDate = null;
			_dataSearch.ReadReturnDate(value, out listReturnDate);
			return Util.ToArray(listReturnDate);
		}

		#endregion
	}
}