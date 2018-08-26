using System;

namespace VideoLogic.Utils
{
    public class VideoDtoSearch
    {
		public int ID { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public double BorrowingRate { get; set; }
		public int ReleaseYear { get; set; }
		public int RunningTime { get; set; }
		public int Rated { get; set; }
		public string Borrower { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
