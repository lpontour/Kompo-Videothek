using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VideoLogic;
using VideoLogic.Exceptions;
using VideoLogic.Utils;


namespace VideoDialog.Search
{
    internal partial class CDialogSearch : Form
    {
        #region fields
        private CDialogMain _dialogMain;
        private ILogicSearch _logicSearch;
        private VideoDtoSearch _videoSearch;
        #endregion

        #region properties
        internal VideoDtoSearch VideoDtoSearch { get; set; }
        #endregion

        #region ctor
        internal CDialogSearch(ILogicSearch logicSearch, IDialog dialog)
        {
            InitializeComponent();
            if (dialog is CDialogMain)
            {
                _dialogMain = dialog as CDialogMain;
            }
            else
            {
                CErrorHandling.ShowAndStop("Fehler beim Initialisieren von CDialogSearch", "Programmabbruch");
            }
            _logicSearch = logicSearch;
            _videoSearch = new VideoDtoSearch();
        }

        #endregion

        #region methods
        private void ResetAll()
        {
            // Auswahl ID, nur beim ersten Aufruf
            if (comboBoxID.SelectedIndex == -1)
            {
                // Leeren der Comcobox-Einträge
                comboBoxID.Items.Clear();
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxID.Items.Add("");
                // Alle in der DB gefunden IDs in der comboBoxID anzeigen
                comboBoxID.Items.AddRange(_dialogMain.ID);
                comboBoxID.Items.AddRange(_logicSearch.ReadID(""));
                // ComboBoxID.Text auf das erste Element setzen
                if (comboBoxID.Items.Count > 0)
                {
                    comboBoxID.Text = comboBoxID.Items[0].ToString();
                }
            }

            // Auswahl Titel
            if (comboBoxTitle.SelectedIndex == -1)
            {
                comboBoxTitle.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(""));
                if (comboBoxTitle.Items.Count > 0)
                {
                    comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
                }
            }

            // Auswahl Genre
            if (comboBoxGenre.SelectedIndex == -1)
            {
                comboBoxGenre.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadGenre(""));
                if (comboBoxGenre.Items.Count > 0)
                {
                    comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
                }
            }

            // Auswahl Preis
            if (comboBoxBorrowingRate.SelectedIndex == -1)
            {
                comboBoxBorrowingRate.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadBorrowingRate(""));
                if (comboBoxBorrowingRate.Items.Count > 0)
                {
                    comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
                }
            }

            // Auswahl Erscheinungsjahr
            if (comboBoxReleaseYear.SelectedIndex == -1)
            {
                comboBoxReleaseYear.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadReleaseYear(""));
                if (comboBoxReleaseYear.Items.Count > 0)
                {
                    comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
                }
            }

            // Auswahl Laufzeit
            if (comboBoxRunningTime.SelectedIndex == -1)
            {
                comboBoxRunningTime.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadRunningTime(""));
                if (comboBoxRunningTime.Items.Count > 0)
                {
                    comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
                }
            }

            // Auswahl FSK
            if (comboBoxRated.SelectedIndex == -1)
            {
                comboBoxRated.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadRated(""));
                if (comboBoxRated.Items.Count > 0)
                {
                    comboBoxRated.Text = comboBoxRated.Items[0].ToString();
                }
            }

            // Auswahl Ausleihender
            if (comboBoxBorrower.SelectedIndex == -1)
            {
                comboBoxBorrower.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadBorrower(""));
                if (comboBoxBorrower.Items.Count > 0)
                {
                    comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
                }
            }

            // Auswahl Rückgabedatum
            if (comboBoxReturnDate.SelectedIndex == -1)
            {
                comboBoxReturnDate.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.AddRange(_logicSearch.ReadReturnDate(""));
                if (comboBoxReturnDate.Items.Count > 0)
                {
                    comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
                }
            }
        }
        #endregion


        #region Eventhandler

        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxID.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.ID = Util.ParseInt(comboBoxID.Text, 0);
                _videoSearch.Rated = 1;

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                comboBoxTitle.Items.Clear();
                comboBoxTitle.Items.Add("");
                comboBoxTitle.Items.Add(dataTable.Rows[0]["Title"].ToString());

                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.Add("");
                comboBoxGenre.Items.Add(dataTable.Rows[0]["Genre"].ToString());

                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.Add("");
                comboBoxBorrowingRate.Items.Add(dataTable.Rows[0]["BorrowingRate"].ToString());

                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.Add("");
                comboBoxReleaseYear.Items.Add(dataTable.Rows[0]["ReleaseYear"].ToString());

                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.Add("");
                comboBoxRunningTime.Items.Add(dataTable.Rows[0]["RunningTime"].ToString());

                comboBoxRated.Items.Clear();
                comboBoxRated.Items.Add("");
                comboBoxRated.Items.Add(dataTable.Rows[0]["Rated"].ToString());

                comboBoxBorrower.Items.Clear();
                comboBoxBorrower.Items.Add("");
                comboBoxBorrower.Items.Add(dataTable.Rows[0]["Borrower"].ToString());

                comboBoxReturnDate.Items.Clear();
                comboBoxReturnDate.Items.Add("");
                comboBoxReturnDate.Items.Add(dataTable.Rows[0]["ReturnDate"].ToString());
            }

        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTitle.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.Title = comboBoxTitle.Text;
                _videoSearch.Rated = 1;

                if (comboBoxBorrower.Text != "")
                {
                    _videoSearch.Borrower = comboBoxBorrower.Text;
                }

                if (comboBoxReturnDate.Text != "")
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.Add("");
                comboBoxGenre.Items.Add(dataTable.Rows[0]["Genre"].ToString());

                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.Add("");
                comboBoxBorrowingRate.Items.Add(dataTable.Rows[0]["BorrowingRate"].ToString());

                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.Add("");
                comboBoxReleaseYear.Items.Add(dataTable.Rows[0]["ReleaseYear"].ToString());

                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.Add("");
                comboBoxRunningTime.Items.Add(dataTable.Rows[0]["RunningTime"].ToString());

                comboBoxRated.Items.Clear();
                comboBoxRated.Items.Add("");
                comboBoxRated.Items.Add(dataTable.Rows[0]["Rated"].ToString());

                comboBoxID.Items.Clear();
                comboBoxBorrower.Items.Clear();
                comboBoxReturnDate.Items.Clear();

                comboBoxID.Items.Add("");
                comboBoxBorrower.Items.Add("");
                comboBoxReturnDate.Items.Add("");

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string returnDate = row["ReturnDate"].ToString();
                    comboBoxID.Items.Add(id);
                    comboBoxBorrower.Items.Add(borrower);
                    comboBoxReturnDate.Items.Add(returnDate);
                }
            }
        }

        private void comboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGenre.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.Genre = comboBoxGenre.Text;

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;
                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 0);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string rated = row["Rated"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string borrowRate = row["BorrowingRate"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowRate);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxBorrower.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxBorrowingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBorrowingRate.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;
                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 0);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string rated = row["Rated"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string genre = row["Genre"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxReleaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReleaseYear.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;
                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 0);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string rated = row["Rated"].ToString();
                    string borrowingRate = row["BorrowingRate"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string genre = row["Genre"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowingRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowingRate);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxRunningTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRunningTime.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;
                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 0);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string rated = row["Rated"].ToString();
                    string borrowingRate = row["BorrowingRate"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string genre = row["Genre"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowingRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowingRate);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxRated_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRated.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.Rated = Util.ParseInt(comboBoxRunningTime.Text, 0);

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string borrowingRate = row["BorrowingRate"].ToString();
                    string borrower = row["Borrower"].ToString();
                    string genre = row["Genre"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowingRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowingRate);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxBorrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBorrower.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.Borrower = comboBoxRunningTime.Text;

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;

                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 1);
                }

                if (comboBoxReturnDate.Text == "")
                {
                    comboBoxReturnDate.Items.Clear();
                    comboBoxReturnDate.Items.Add("");
                }
                else
                {
                    _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string borrowingRate = row["BorrowingRate"].ToString();
                    string rated = row["Rated"].ToString();
                    string genre = row["Genre"].ToString();
                    string returnDate = row["ReturnDate"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowingRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowingRate);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                    {
                        comboBoxReturnDate.Items.Add(returnDate);
                    }
                }
            }
        }

        private void comboBoxReturnDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReturnDate.Text == "")
            {
                ResetAll();
            }
            else
            {
                _videoSearch.ReturnDate = Util.ParseDate(comboBoxRunningTime.Text, DateTime.MinValue);

                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Clear();
                    comboBoxID.Items.Add("");
                }

                if (comboBoxTitle.Text == "")
                {
                    comboBoxTitle.Items.Clear();
                    comboBoxTitle.Items.Add("");
                }
                else
                {
                    _videoSearch.Title = comboBoxTitle.Text;
                }

                if (comboBoxGenre.Text == "")
                {
                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add("");
                }
                else
                {
                    _videoSearch.Genre = comboBoxGenre.Text;
                }

                if (comboBoxBorrowingRate.Text == "")
                {
                    comboBoxBorrowingRate.Items.Clear();
                    comboBoxBorrowingRate.Items.Add("");
                }
                else
                {
                    _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
                }

                if (comboBoxReleaseYear.Text == "")
                {
                    comboBoxReleaseYear.Items.Clear();
                    comboBoxReleaseYear.Items.Add("");
                }
                else
                {
                    _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
                }

                if (comboBoxRunningTime.Text == "")
                {
                    comboBoxRunningTime.Items.Clear();
                    comboBoxRunningTime.Items.Add("");
                }
                else
                {
                    _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
                }

                if (comboBoxRated.Text == "")
                {
                    _videoSearch.Rated = 1;
                    comboBoxRated.Items.Clear();
                    comboBoxRated.Items.Add("");
                }
                else
                {
                    _videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 1);
                }

                if (comboBoxBorrower.Text == "")
                {
                    comboBoxBorrower.Items.Clear();
                    comboBoxBorrower.Items.Add("");
                }
                else
                {
                    _videoSearch.Borrower = comboBoxBorrowingRate.Text;
                }

                _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row["ID"].ToString();
                    string title = row["Title"].ToString();
                    string releaseYear = row["ReleaseYear"].ToString();
                    string runningTime = row["RunningTime"].ToString();
                    string borrowingRate = row["BorrowingRate"].ToString();
                    string rated = row["Rated"].ToString();
                    string genre = row["Genre"].ToString();
                    string borrower = row["Borrower"].ToString();

                    if (comboBoxID.Text == "")
                    {
                        comboBoxID.Items.Add(id);
                    }

                    if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                    {
                        comboBoxTitle.Items.Add(title);
                    }

                    if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(genre);
                    }

                    if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowingRate) == -1)
                    {
                        comboBoxBorrowingRate.Items.Add(borrowingRate);
                    }

                    if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                    {
                        comboBoxReleaseYear.Items.Add(releaseYear);
                    }

                    if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                    {
                        comboBoxRunningTime.Items.Add(runningTime);
                    }

                    if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                    {
                        comboBoxRated.Items.Add(rated);
                    }

                    if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                    {
                        comboBoxBorrower.Items.Add(borrower);
                    }
                }
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            VideoDtoSearch videoSearch = _dialogMain.VideoSearch;
            videoSearch.ID = Util.ParseInt(comboBoxID.Text, videoSearch.ID);
            videoSearch.Title = comboBoxTitle.Text;
            videoSearch.Genre = comboBoxGenre.Text;
            videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, videoSearch.BorrowingRate);
            videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, videoSearch.ReleaseYear);
            videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, videoSearch.RunningTime);
            videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, videoSearch.Rated);
            videoSearch.Borrower = comboBoxBorrower.Text;
            videoSearch.ReturnDate = Util.ParseDate(comboBoxReturnDate.Text, videoSearch.ReturnDate);

            this.VideoDtoSearch = videoSearch;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion


    }
}
