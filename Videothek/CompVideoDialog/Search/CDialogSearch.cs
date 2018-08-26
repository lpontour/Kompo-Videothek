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
                _logicSearch = logicSearch;
            }
        }

        #endregion

        #region Eventhandler

        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            // Auswahl ID, nur beim ersten Aufruf
            if (comboBoxID.SelectedIndex == -1)
            {
                // Alle in der DB gefunden IDs in der comboBoxID anzeigen
                comboBoxID.Items.Clear();
                comboBoxID.Items.AddRange(_dialogMain.ID);
                // ComboBoxID.Text auf das erste Element setzen
                if (comboBoxID.Items.Count > 0)
                    comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Auswahl Titel
            if (comboBoxTitle.SelectedIndex == -1)
            {
                comboBoxTitle.Items.Clear();
                comboBoxTitle.Items.AddRange(_dialogMain.Titel);
                if (comboBoxTitle.Items.Count > 0)
                    comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Auswahl Genre
            if (comboBoxGenre.SelectedIndex == -1)
            {
                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.AddRange(_dialogMain.Genre);
                if (comboBoxGenre.Items.Count > 0)
                    comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Auswahl Preis
            if (comboBoxBorrowingRate.SelectedIndex == -1)
            {
                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.AddRange(_dialogMain.BorrowingRate);
                if (comboBoxBorrowingRate.Items.Count > 0)
                    comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Auswahl Erscheinungsjahr
            if (comboBoxReleaseYear.SelectedIndex == -1)
            {
                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.AddRange(_dialogMain.ReleaseYear);
                if (comboBoxReleaseYear.Items.Count > 0)
                    comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }

            // Auswahl Laufzeit
            if (comboBoxRunningTime.SelectedIndex == -1)
            {
                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.AddRange(_dialogMain.RunningTime);
                if (comboBoxRunningTime.Items.Count > 0)
                    comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }

            // Auswahl FSK
            if (comboBoxRated.SelectedIndex == -1)
            {
                comboBoxRated.Items.Clear();
                comboBoxRated.Items.AddRange(_dialogMain.Rated);
                if (comboBoxRated.Items.Count > 0)
                    comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Auswahl Ausleihender
            if (comboBoxBorrower.SelectedIndex == -1)
            {
                comboBoxBorrower.Items.Clear();
                comboBoxBorrower.Items.AddRange(_dialogMain.Borrower);
                if (comboBoxBorrower.Items.Count > 0)
                    comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Auswahl Rückgabedatum
            if (comboBoxReturnDate.SelectedIndex == -1)
            {
                comboBoxReturnDate.Items.Clear();
                comboBoxReturnDate.Items.AddRange(_dialogMain.ReturnDate);
                if (comboBoxReturnDate.Items.Count > 0)
                    comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }

        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl ID
            string id = comboBoxID.Text;
            // Alle IDs der Filme aus der Datenbank lesen und in der 
            // comboBoxID anzeigen 
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(Util.ParseInt(id,0)));
            // ComboBox Text auf das erste Element setzen
            if (comboBoxID.Items.Count > 0)
                comboBoxID.Text = comboBoxID.Items[0].ToString();
        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Titel
            string titel = comboBoxTitle.Text;
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(titel));
            if (comboBoxTitle.Items.Count > 0)
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
        }

        private void comboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Genre
            string genre = comboBoxGenre.Text;
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(genre));
            if (comboBoxGenre.Items.Count > 0)
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
        }

        private void comboBoxBorrowingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Preis
            string borrowingRate = comboBoxBorrowingRate.Text;
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingrate(Util.ParseDouble(borrowingRate,10.0)));
            if (comboBoxBorrowingRate.Items.Count > 0)
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
        }

        private void comboBoxReleaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Erscheinungsjahr
            string releaseYear = comboBoxReleaseYear.Text;
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(Util.ParseInt(releaseYear,2000)));
            if (comboBoxReleaseYear.Items.Count > 0)
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
        }

        private void comboBoxRunningTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Laufzeit
            string runningTime = comboBoxRunningTime.Text;
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(Util.ParseInt(runningTime,120)));
            if (comboBoxRunningTime.Items.Count > 0)
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
        }

        private void comboBoxRated_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl FSK
            string rated = comboBoxRated.Text;
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(Util.ParseInt(rated, 0)));
            if (comboBoxRated.Items.Count > 0)
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
        }

        private void comboBoxBorrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Ausleihender
            string borrower = comboBoxBorrower.Text;
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(borrower));
            if (comboBoxBorrower.Items.Count > 0)
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
        }

        private void comboBoxReturnDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Rückgabedatum
            string returnDate = comboBoxReturnDate.Text;
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(Util.ParseDate(returnDate,DateTime.Now)));
            if (comboBoxReturnDate.Items.Count > 0)
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
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
