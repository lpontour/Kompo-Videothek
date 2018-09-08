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
            }
            _logicSearch = logicSearch;
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
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxID.Items.Add("");
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
                comboBoxTitle.Items.AddRange(_dialogMain.Titel);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxTitle.Items.Add("");
                if (comboBoxTitle.Items.Count > 0)
                {
                    comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
                }
            }

            // Auswahl Genre
            if (comboBoxGenre.SelectedIndex == -1)
            {
                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.AddRange(_dialogMain.Genre);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxGenre.Items.Add("");
                if (comboBoxGenre.Items.Count > 0)
                {
                    comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
                }
            }

            // Auswahl Preis
            if (comboBoxBorrowingRate.SelectedIndex == -1)
            {
                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.AddRange(_dialogMain.BorrowingRate);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxBorrowingRate.Items.Add("");
                if (comboBoxBorrowingRate.Items.Count > 0)
                {
                    comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
                }
            }

            // Auswahl Erscheinungsjahr
            if (comboBoxReleaseYear.SelectedIndex == -1)
            {
                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.AddRange(_dialogMain.ReleaseYear);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxReleaseYear.Items.Add("");
                if (comboBoxReleaseYear.Items.Count > 0)
                {
                    comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
                }
            }

            // Auswahl Laufzeit
            if (comboBoxRunningTime.SelectedIndex == -1)
            {
                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.AddRange(_dialogMain.RunningTime);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxRunningTime.Items.Add("");
                if (comboBoxRunningTime.Items.Count > 0)
                {
                    comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
                }
            }

            // Auswahl FSK
            if (comboBoxRated.SelectedIndex == -1)
            {
                comboBoxRated.Items.Clear();
                comboBoxRated.Items.AddRange(_dialogMain.Rated);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxRated.Items.Add("");
                if (comboBoxRated.Items.Count > 0)
                {
                    comboBoxRated.Text = comboBoxRated.Items[0].ToString();
                }
            }

            // Auswahl Ausleihender
            if (comboBoxBorrower.SelectedIndex == -1)
            {
                comboBoxBorrower.Items.Clear();
                comboBoxBorrower.Items.AddRange(_dialogMain.Borrower);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxBorrower.Items.Add("");
                if (comboBoxBorrower.Items.Count > 0)
                {
                    comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
                }
            }

            // Auswahl Rückgabedatum
            if (comboBoxReturnDate.SelectedIndex == -1)
            {
                comboBoxReturnDate.Items.Clear();
                comboBoxReturnDate.Items.AddRange(_dialogMain.ReturnDate);
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxReturnDate.Items.Add("");
                if (comboBoxReturnDate.Items.Count > 0)
                {
                    comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
                }
            }

        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl ID
            string id = comboBoxID.Text;

            // Den Titel des Films der ID aus der Datenbank lesen und in der 
            // comboBoxTitel anzeigen 
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(id));
            // Leeren Eintrag einfügen, um alle Einträge zu erhalten
            comboBoxTitle.Items.Add("");
            // ComboBox Text auf das erste Element setzen
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Das Genre zur ID auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(id));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Den Preis zur ID auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(id));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Das Erscheinungsjahr zur ID auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(id));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }

            // Die Laufzeit zur ID auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(id));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }


            // Das FSK zur ID auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(id));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Den Ausleihenden zur ID auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(id));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Das Rückgabedatum zur ID auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(id));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }

        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Titel
            string title = comboBoxTitle.Text;

            // Die IDs zum Titel auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(title));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Das Genre zum Titel auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(title));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Den Preis zum Titel auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(title));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Das Erscheinungsjahr zum Titel auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(title));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }

            // Die Laufzeit zum Titel auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(title));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }


            // Das FSK zum Titel auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(title));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zum Titel auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(title));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zum Title auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(title));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Genre
            string genre = comboBoxGenre.Text;

            // Die IDs zum Genre auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(genre));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zum Genre auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(genre));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Preise zum Genre auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(genre));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Erscheinungsjahre zum Genre auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(genre));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }

            // Die Laufzeiten zum Genre auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(genre));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }


            // Die FSKs zum Genre auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(genre));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zum Genre auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(genre));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zum Genre auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(genre));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxBorrowingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Preis
            string borrowingRate = comboBoxBorrowingRate.Text;

            // Die IDs zum Preis auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(borrowingRate));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zum Preis auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(borrowingRate));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zum Preis auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(borrowingRate));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Erscheinungsjahre zum Preis auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(borrowingRate));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }

            // Die Laufzeiten zum Preis auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(borrowingRate));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }


            // Die FSKs zum Preis auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(borrowingRate));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zum Preis auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(borrowingRate));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zum Preis auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(borrowingRate));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxReleaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Erscheinungsjahr
            string releaseYear = comboBoxReleaseYear.Text;

            // Die IDs zum Erscheinungsjahr auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(releaseYear));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zum Erscheinungsjahr auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(releaseYear));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zum Erscheinungsjahr auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(releaseYear));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Preise zum Erscheinungsjahr auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(releaseYear));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Laufzeiten zum Erscheinungsjahr auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(releaseYear));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }


            // Die FSKs zum Preis auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(releaseYear));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zum Preis auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(releaseYear));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zum Preis auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(releaseYear));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxRunningTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Laufzeit
            string runningTime = comboBoxRunningTime.Text;

            // Die IDs zur Laufzeit auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(runningTime));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zur Laufzeit auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(runningTime));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zur Laufzeit auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(runningTime));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Preise zur Laufzeit auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(runningTime));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Erscheinungsjahre zur Laufzeit auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(runningTime));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }


            // Die FSKs zur Laufzeit auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(runningTime));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zur Laufzeit auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(runningTime));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zur Laufzeit auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(runningTime));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxRated_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl FSK
            string rated = comboBoxRated.Text;

            // Die IDs zur FSK auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(rated));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zur FSK auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(rated));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zur FSK auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(rated));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Preise zur FSK auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(rated));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Erscheinungsjahre zur FSK auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(rated));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }


            // Die Laufzeiten zur FSK auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(rated));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }

            // Die Ausleihenden zur FSK auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(rated));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
            }

            // Die Rückgabedaten zur FSK auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(rated));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxBorrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Ausleihender
            string borrower = comboBoxBorrower.Text;

            // Die IDs zum Ausleihenden auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(borrower));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zum Ausleihenden auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(borrower));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zum Ausleihenden auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(borrower));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Preise zum Ausleihenden auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(borrower));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Erscheinungsjahre zum Ausleihenden auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(borrower));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }


            // Die Laufzeiten zum Ausleihenden auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(borrower));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }

            // Die FSKs zum Ausleihenden auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(borrower));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Rückgabedaten zum Ausleihenden auslesen
            comboBoxReturnDate.Items.Clear();
            comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(borrower));
            comboBoxReturnDate.Items.Add("");
            if (comboBoxReturnDate.Items.Count > 0)
            {
                comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
            }
        }

        private void comboBoxReturnDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl Rückgabedatum
            string returnDate = comboBoxReturnDate.Text;

            // Die IDs zum Rückgabedatum auslesen
            comboBoxID.Items.Clear();
            comboBoxID.Items.AddRange(_logicSearch.ReadID(returnDate));
            comboBoxID.Items.Add("");
            if (comboBoxID.Items.Count > 0)
            {
                comboBoxID.Text = comboBoxID.Items[0].ToString();
            }

            // Die Titel zum Rückgabedatum auslesen
            comboBoxTitle.Items.Clear();
            comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(returnDate));
            comboBoxTitle.Items.Add("");
            if (comboBoxTitle.Items.Count > 0)
            {
                comboBoxTitle.Text = comboBoxTitle.Items[0].ToString();
            }

            // Die Genre zum Rückgabedatum auslesen
            comboBoxGenre.Items.Clear();
            comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(returnDate));
            comboBoxGenre.Items.Add("");
            if (comboBoxGenre.Items.Count > 0)
            {
                comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
            }

            // Die Preise zum Rückgabedatum auslesen
            comboBoxBorrowingRate.Items.Clear();
            comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(returnDate));
            comboBoxBorrowingRate.Items.Add("");
            if (comboBoxBorrowingRate.Items.Count > 0)
            {
                comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
            }

            // Die Erscheinungsjahre zum Rückgabedatum auslesen
            comboBoxReleaseYear.Items.Clear();
            comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(returnDate));
            comboBoxReleaseYear.Items.Add("");
            if (comboBoxReleaseYear.Items.Count > 0)
            {
                comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
            }


            // Die Laufzeiten zum Rückgabedatum auslesen
            comboBoxRunningTime.Items.Clear();
            comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(returnDate));
            comboBoxRunningTime.Items.Add("");
            if (comboBoxRunningTime.Items.Count > 0)
            {
                comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
            }

            // Die FSKs zum Rückgabedatum auslesen
            comboBoxRated.Items.Clear();
            comboBoxRated.Items.AddRange(_logicSearch.ReadRated(returnDate));
            comboBoxRated.Items.Add("");
            if (comboBoxRated.Items.Count > 0)
            {
                comboBoxRated.Text = comboBoxRated.Items[0].ToString();
            }

            // Die Ausleihenden zum Rückgabedatum auslesen
            comboBoxBorrower.Items.Clear();
            comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(returnDate));
            comboBoxBorrower.Items.Add("");
            if (comboBoxBorrower.Items.Count > 0)
            {
                comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
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
