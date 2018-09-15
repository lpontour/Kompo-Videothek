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

        private bool AllFree()
        {
            // Überprüft, ob alle Texte aller Comboboxen sind ist und gibt entsprechenden Bool-Wert zurück
            if (comboBoxID.Text == "" && comboBoxTitle.Text == "" && comboBoxBorrowingRate.Text == "" && comboBoxRated.Text == "" && comboBoxReleaseYear.Text == "" && 
                comboBoxGenre.Text == "" && comboBoxRunningTime.Text == "" && comboBoxReturnDate.Text == "" && comboBoxBorrower.Text == "")
            {
                // Alle Comboboxen leer
                return true;
            }
            else
            {
                // Mindestens eine Combobox ist nicht leer
                return false;
            }
        }

        private void ResetAll()
        {
            // Setzt Index der Combobox auf kein vorhandenes Element
            if (comboBoxID.SelectedIndex == -1)
            {
                // Leeren der Comcobox-Einträge
                comboBoxID.Items.Clear();
                // Leeren Eintrag einfügen, um alle Einträge zu erhalten
                comboBoxID.Items.Add("");
                // Alle in der DB gefunden IDs in der comboBoxID anzeigen
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
                comboBoxGenre.Items.Add("");
                comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(""));
                if (comboBoxGenre.Items.Count > 0)
                {
                    comboBoxGenre.Text = comboBoxGenre.Items[0].ToString();
                }
            }

            // Auswahl Preis
            if (comboBoxBorrowingRate.SelectedIndex == -1)
            {
                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.Add("");
                comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(""));
                if (comboBoxBorrowingRate.Items.Count > 0)
                {
                    comboBoxBorrowingRate.Text = comboBoxBorrowingRate.Items[0].ToString();
                }
            }

            // Auswahl Erscheinungsjahr
            if (comboBoxReleaseYear.SelectedIndex == -1)
            {
                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.Add("");
                comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(""));
                if (comboBoxReleaseYear.Items.Count > 0)
                {
                    comboBoxReleaseYear.Text = comboBoxReleaseYear.Items[0].ToString();
                }
            }

            // Auswahl Laufzeit
            if (comboBoxRunningTime.SelectedIndex == -1)
            {
                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.Add("");
                comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(""));
                if (comboBoxRunningTime.Items.Count > 0)
                {
                    comboBoxRunningTime.Text = comboBoxRunningTime.Items[0].ToString();
                }
            }

            // Auswahl FSK
            if (comboBoxRated.SelectedIndex == -1)
            {
                comboBoxRated.Items.Clear();
                comboBoxRated.Items.Add("");
                comboBoxRated.Items.AddRange(_logicSearch.ReadRated(""));
                if (comboBoxRated.Items.Count > 0)
                {
                    comboBoxRated.Text = comboBoxRated.Items[0].ToString();
                }
            }

            // Auswahl Ausleihender
            if (comboBoxBorrower.SelectedIndex == -1)
            {
                comboBoxBorrower.Items.Clear();
                comboBoxBorrower.Items.Add("");
                comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(""));
                if (comboBoxBorrower.Items.Count > 0)
                {
                    comboBoxBorrower.Text = comboBoxBorrower.Items[0].ToString();
                }
            }

            // Auswahl Rückgabedatum
            if (comboBoxReturnDate.SelectedIndex == -1)
            {
                comboBoxReturnDate.Items.Clear();
                comboBoxReturnDate.Items.Add("");
                comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(""));
                if (comboBoxReturnDate.Items.Count > 0)
                {
                    comboBoxReturnDate.Text = comboBoxReturnDate.Items[0].ToString();
                }
            }
        }

        private void FillUnselectedBoxes()
        {
            // Überprüfen, ob Combobox ID leer ist
            if (comboBoxID.Text == "")
            {
                // Löschen der Itemliste und hinzufügen des leeren Eintrages
                comboBoxID.Items.Clear();
                comboBoxID.Items.Add("");
            }
            else
            {
                _videoSearch.ID = Util.ParseInt(comboBoxID.Text, 0);
            }

            // Überprüfen, ob Combobox Titel leer ist
            if (comboBoxTitle.Text == "")
            {
                comboBoxTitle.Items.Clear();
                comboBoxTitle.Items.Add("");
            }
            else
            {
                // Übergeben des ausgewählten Textes
                _videoSearch.Title = comboBoxTitle.Text;
            }

            // Überprüfen, ob Combobox Genre leer ist
            if (comboBoxGenre.Text == "")
            {
                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.Add("");
            }
            else
            {
                _videoSearch.Genre = comboBoxGenre.Text;
            }

            // Überprüfen, ob Combobox Preis leer ist
            if (comboBoxBorrowingRate.Text == "")
            {
                comboBoxBorrowingRate.Items.Clear();
                comboBoxBorrowingRate.Items.Add("");
            }
            else
            {
                _videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, 0.0);
            }

            // Überprüfen, ob Combobox Erscheinungsjahr leer ist
            if (comboBoxReleaseYear.Text == "")
            {
                comboBoxReleaseYear.Items.Clear();
                comboBoxReleaseYear.Items.Add("");
            }
            else
            {
                _videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, 0);
            }

            // Überprüfen, ob Combobox Laufzeit leer ist
            if (comboBoxRunningTime.Text == "")
            {
                comboBoxRunningTime.Items.Clear();
                comboBoxRunningTime.Items.Add("");
            }
            else
            {
                _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
            }

            // Überprüfen, ob Combobox FSK leer ist
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

            // Überprüfen, ob Combobox Ausleihender leer ist
            if (comboBoxBorrower.Text == "")
            {
                comboBoxBorrower.Items.Clear();
                comboBoxBorrower.Items.Add("");
            }
            else
            {
                _videoSearch.Borrower = comboBoxBorrowingRate.Text;
            }

            // Überprüfen, ob Combobox Rückgabedatum leer ist
            if (comboBoxReturnDate.Text == "")
            {
                comboBoxReturnDate.Items.Clear();
                comboBoxReturnDate.Items.Add("");
            }
            else
            {
                _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
            }

            // Suche in der Datenbank mit den vorher bestimmten Werten der Comboboxen
            _logicSearch.ReadVideos(_videoSearch, out DataTable dataTable);

            // Gehe alle Reihen der zurückkomenden Datentabelle durch
            foreach (DataRow row in dataTable.Rows)
            {
                // Fülle die Attribute mit den Werten der Datentabellenreihe
                string id = row["ID"].ToString();
                string title = row["Title"].ToString();
                string genre = row["Genre"].ToString();
                string runningTime = row["RunningTime"].ToString();
                string rated = row["Rated"].ToString();
                string releaseYear = row["ReleaseYear"].ToString();
                string borrower = row["Borrower"].ToString();
                string borrowRate = row["BorrowingRate"].ToString();
                string returnDate = row["ReturnDate"].ToString();

                // Wenn ID leer ist, wird der gefundene Wert aus der DB als Item hinzugefügt
                if (comboBoxID.Text == "")
                {
                    comboBoxID.Items.Add(id);
                }

                // Wenn Titel leer ist, wird der gefundene Wert aus der DB als Item hinzugefügt
                // überprüft, ob noch kein Item mit dem Wert vorhanden ist
                if (comboBoxTitle.Text == "" && comboBoxTitle.FindStringExact(title) == -1)
                {
                    comboBoxTitle.Items.Add(title);
                }

                // Überprüft, ob Genre leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxGenre.Text == "" && comboBoxGenre.FindStringExact(genre) == -1)
                {
                    comboBoxGenre.Items.Add(genre);
                }

                // Überprüft, ob Preis leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxBorrowingRate.Text == "" && comboBoxBorrowingRate.FindStringExact(borrowRate) == -1)
                {
                    comboBoxBorrowingRate.Items.Add(borrowRate);
                }

                // Überprüft, ob Erscheinungsjahr leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxReleaseYear.Text == "" && comboBoxReleaseYear.FindStringExact(releaseYear) == -1)
                {
                    comboBoxReleaseYear.Items.Add(releaseYear);
                }

                // Überprüft, ob Laufzeit leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxRunningTime.Text == "" && comboBoxRunningTime.FindStringExact(runningTime) == -1)
                {
                    comboBoxRunningTime.Items.Add(runningTime);
                }

                // Überprüft, ob FSK leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxRated.Text == "" && comboBoxRated.FindStringExact(rated) == -1)
                {
                    comboBoxRated.Items.Add(rated);
                }

                // Überprüft, ob Ausleihender leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxBorrower.Text == "" && comboBoxBorrower.FindStringExact(borrower) == -1)
                {
                    comboBoxBorrower.Items.Add(borrower);
                }

                // Überprüft, ob Rückgabedatum leer und noch kein Item mit dem Namen vorhanden
                if (comboBoxReturnDate.Text == "" && comboBoxReturnDate.FindStringExact(returnDate) == -1)
                {
                    comboBoxReturnDate.Items.Add(returnDate);
                }
            }

        }


        #endregion


        #region Eventhandler

        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            comboBoxID.Text = "";
            comboBoxTitle.Text = "";
            comboBoxGenre.Text = "";
            comboBoxBorrowingRate.Text = "";
            comboBoxReleaseYear.Text = "";
            comboBoxRunningTime.Text = "";
            comboBoxRated.Text = "";
            comboBoxBorrower.Text = "";
            comboBoxReturnDate.Text = "";

            // Füllen aller Comboboxen mit Items aus der DB
            ResetAll();

        }

        private void comboBoxID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Wenn Wert für Id geändert, wird überprüft, ob dieser leer ist
            if(comboBoxID.Text == "")
            {
                if (AllFree())
                {
                    // Wenn ja und alle anderen Boxen auf leer sind, sollen alle neu gefüllt werden
                    ResetAll();
                }
                else
                {
                    // wenn mindestens eine andere Combobox gefüllt, sollen nur alle leeren gefüllt werden
                    FillUnselectedBoxes();
                }
            }
            else
            {
                // Wenn ID einen Wert hat, sollen die Items aller anderen Comboboxen die passenden Einträge zur ID erhalten
                FillUnselectedBoxes();
            }

        }

        private void comboBoxTitle_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            // Wenn Wert für Titel geändert, wird überprüft, ob dieser leer ist
            if (comboBoxTitle.Text == "")
            {
                // Wenn ja wird der leere Eintrag weitergegeben
                _videoSearch.Title = "";
                if (AllFree())
                {
                    // Wenn alle anderen Comboboxen auch leer sind, sollen alle neu gefüllt werden
                    ResetAll();
                }
                else
                {
                    // wenn mindestens eine andere Combobox gefüllt, sollen nur alle leeren gefüllt werden
                    FillUnselectedBoxes();
                }
            }
            else
            {
                // wenn Titel Wert hat, sollen alle leeren Comboboxen gefüllt werden
                FillUnselectedBoxes();
            }
        }

        private void comboBoxGenre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Genre auf Wert
            if (comboBoxGenre.Text == "")
            {
                _videoSearch.Genre = "";
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }
        
        private void comboBoxBorrowingRate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Preis auf Wert
            if (comboBoxBorrowingRate.Text == "")
            {
                _videoSearch.BorrowingRate = 0.0;
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void comboBoxReleaseYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Erscheinungsjahr auf Wert
            if (comboBoxReleaseYear.Text == "")
            {
                _videoSearch.ReleaseYear = 0;
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void comboBoxRunningTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Laufzeit auf Wert
            if (comboBoxRunningTime.Text == "")
            {
                _videoSearch.RunningTime = 0;
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void comboBoxRated_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft FSK auf Wert
            if (comboBoxRated.Text == "")
            {
                _videoSearch.Rated = 1;
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void comboBoxBorrower_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Ausleihenden auf Wert
            if (comboBoxBorrower.Text == "")
            {
                _videoSearch.Borrower = "";
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void comboBoxReturnDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Überprüft Rückgabedatum auf Wert
            if (comboBoxReturnDate.Text == "")
            {
                _videoSearch.ReturnDate = DateTime.MinValue;
                if (AllFree())
                {
                    ResetAll();
                }
                else
                {
                    FillUnselectedBoxes();
                }
            }
            else
            {
                FillUnselectedBoxes();
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            // Übernehmen der Werte aus den Comboboxen
            VideoDtoSearch videoSearch = _dialogMain.VideoSearch;
            videoSearch.ID = Util.ParseInt(comboBoxID.Text, _videoSearch.ID);
            videoSearch.Title = comboBoxTitle.Text;
            videoSearch.Genre = comboBoxGenre.Text;
            videoSearch.BorrowingRate = Util.ParseDouble(comboBoxBorrowingRate.Text, _videoSearch.BorrowingRate);
            videoSearch.ReleaseYear = Util.ParseInt(comboBoxReleaseYear.Text, _videoSearch.ReleaseYear);
            videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, _videoSearch.RunningTime);
            videoSearch.Rated = Util.ParseInt(comboBoxRated.Text, 1);
            videoSearch.Borrower = comboBoxBorrower.Text;
            videoSearch.ReturnDate = Util.ParseDate(comboBoxReturnDate.Text, videoSearch.ReturnDate);

            // Weitergeben der Daten und schließen des Fensters
            this.VideoDtoSearch = videoSearch;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Schließen des Fensters
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion


    }
}
