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
            // setzen der FSk auf 1, stellvertretend für den leeren Eintrag
            _videoSearch.Rated = 1;

            // Überprüfen, ob Combobox ID leer ist
            if (comboBoxID.Text == "")
            {
                // Löschen der Itemliste und hinzufügen des leeren Eintrages
                comboBoxID.Items.Clear();
                comboBoxID.Items.Add("");
                // 0 stellvertretend für den leeren Eintrag
                _videoSearch.ID = 0;
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
                _videoSearch.Title = "";
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
                _videoSearch.Genre = "";
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
                // 0.0 stellvertretend für den leeren Eintrag
                _videoSearch.BorrowingRate = 0.0;
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
                // 0 stellvertretend für den leeren Eintrag
                _videoSearch.ReleaseYear = 0;
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
                // 0 stellvertretend für den leeren Eintrag
                _videoSearch.RunningTime = 0;
            }
            else
            {
                _videoSearch.RunningTime = Util.ParseInt(comboBoxRunningTime.Text, 0);
            }

            // Überprüfen, ob Combobox FSK leer ist
            if (comboBoxRated.Text == "")
            {
                comboBoxRated.Items.Clear();
                comboBoxRated.Items.Add("");
                // 1 stellvertretend für den leeren Eintrag
                _videoSearch.Rated = 1;
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
                _videoSearch.Borrower = "";
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
                // DateTime.MinValue(1.1.2001) stellvertretend für den leeren Eintrag
                _videoSearch.ReturnDate = DateTime.MinValue;
            }
            else
            {
                _videoSearch.ReturnDate = Util.ParseDate(comboBoxBorrowingRate.Text, DateTime.MinValue);
            }

            // Wenn ID leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxID.Text == "")
            {
                comboBoxID.Items.AddRange(_logicSearch.ReadID(_videoSearch));
            }
            // Wenn Titel leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxTitle.Text == "")
            {
                comboBoxTitle.Items.AddRange(_logicSearch.ReadTitle(_videoSearch));
            }
            // Wenn Genre leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxGenre.Text == "")
            {
                comboBoxGenre.Items.AddRange(_logicSearch.ReadGenre(_videoSearch));
            }
            // Wenn Preis leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxBorrowingRate.Text == "")
            {
                comboBoxBorrowingRate.Items.AddRange(_logicSearch.ReadBorrowingRate(_videoSearch));
            }
            // Wenn Erscheinungsjahr leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxReleaseYear.Text == "")
            {
                comboBoxReleaseYear.Items.AddRange(_logicSearch.ReadReleaseYear(_videoSearch));
            }
            // Wenn Laufzeit leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxRunningTime.Text == "")
            {
                comboBoxRunningTime.Items.AddRange(_logicSearch.ReadRunningTime(_videoSearch));
            }
            // Wenn FSK leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxRated.Text == "")
            {
                comboBoxRated.Items.AddRange(_logicSearch.ReadRated(_videoSearch));
            }
            // Wenn Ausleihender leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxBorrower.Text == "")
            {
                comboBoxBorrower.Items.AddRange(_logicSearch.ReadBorrower(_videoSearch));
            }
            // Wenn Rückgabedatum leer, dann füllen der Combobox-Items mit Werten aus der Datenbank
            if (comboBoxReturnDate.Text == "")
            {
                comboBoxReturnDate.Items.AddRange(_logicSearch.ReadReturnDate(_videoSearch));
            }
        }

        #endregion


        #region Eventhandler

        private void CDialogSearch_Load(object sender, EventArgs e)
        {
            // leeren aller Comboboxen zu beginn
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
            // Zurücksetzen aller Combobox-Items, wenn Ergebnis erhalten
            ResetAll();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Zurücksetzen der Combobox-Items wenn Fenster geschlossen wird
            ResetAll();
            // Schließen des Fensters
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion


    }
}
