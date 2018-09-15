using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VideoDialog.Loan;
using VideoDialog.Search;
using VideoLogic;
using VideoLogic.Utils;

namespace VideoDialog
{
    internal partial class CDialogMain : Form, IDialog
    {
        #region fields
        private VideoDtoSearch _videoSearch;
        private VideoDtoLoan _videoLoan;
        private VideoDtoLoan _videoLoanExisting;
        private ILogic _logic;


        private bool exists;
        #endregion

        #region properties
        internal VideoDtoSearch VideoSearch { get { return _videoSearch; } }
        internal VideoDtoLoan VideoLoan { get { return _videoLoan; } }
        internal CDialogSearch DialogSearch { get; set; }
        internal CDialogSearchResult DialogSearchResult { get; set; }
        internal CDialogLoanInsert DialogLoanInsert { get; set; }
        internal CDialogLoanUpdate DialogLoanUpdate { get; set; }
        internal CDialogLoanDelete DialogLoanDelete { get; set; }
        #endregion

        #region ctor
        internal CDialogMain(ILogic logic)
        {
            InitializeComponent();
            _logic = logic;
            _videoSearch = new VideoDtoSearch();
            _videoLoan = new VideoDtoLoan();
            _videoLoanExisting = new VideoDtoLoan();
        }
        #endregion

        #region Eventhandler
        private void SuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Fenster wird nach erfogreicher Suche erneut angezeigt
                while (true)
                {
                    // Zeigt Fenster zum Suchen
                    DialogResult dialogResult = DialogSearch.ShowDialog();

                    // wenn Button Bestätigen bei der Suche gedrückt
                    if (dialogResult == DialogResult.OK)
                    {
                        _videoSearch = DialogSearch.VideoDtoSearch;
                        // wird Suchen ausgeführt
                        _logic.Search.ReadVideos(_videoSearch, out DataTable dataTable);
                        // und das Ergebnis in DialogSearchView dargestellen
                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();
                    }
                    // wenn Button Abbrechen gedrückt, wird das Fenster geschlossen ohne eine Aktion auszuführen
                    else
                    {
                        return;
                    }
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Abbruch Suchen",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Abbruch Suchen",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NeueAusleiheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Insert
            try
            {
                // erstellen einer Datentabelle
                DataTable dataTable = new DataTable();

                // Fenster wird nach erfogreichem Insert erneut angezeigt
                while (true)
                {
                    // Öffnen des Insert-Fensters
                    DialogResult dialogResult = DialogLoanInsert.ShowDialog();

                    // Wenn Button bestätigen gedrückt
                    if (dialogResult == DialogResult.OK)
                    {
                        // werden die Einträge aus den Feldern übernommen
                        //_videoLoanExisting zum Überprüfen der Werte mit denen aus der DB
                        _videoLoan = DialogLoanInsert.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = "";

                        // Wenn keine ID eingetragen wurde..
                        if (_videoLoan.ID == 0)
                        {
                            // Wenn keine freies Video mit dem Titel mehr vorhanden ist
                            if (!_logic.Search.FreeTitles(_videoLoanExisting))
                            {
                                MessageBox.Show("Kein Film mit dem Titel " + _videoLoan.Title + " zur Ausleihe verfügbar", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        // wenn ID angegeben ist..
                        else
                        {
                            // Suche nach Einträgen in der DB
                            _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);
                            //.. und das Result leer ist..
                            if (dataTable.Rows.Count == 0)
                            {
                                //..zeige die Messagebox
                                MessageBox.Show("Titel und ID stimmen nicht überein oder existieren nicht", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                // Wenn ein Film bereits ausgeliehen ist
                                string borrower = dataTable.Rows[0]["Borrower"].ToString();
                                DateTime returnDate = Util.ParseDate(dataTable.Rows[0]["ReturnDate"].ToString(), DateTime.Now);
                                if ((borrower != "") && (returnDate != Util.ParseDate("01.01.2001", DateTime.Now)))
                                {
                                    MessageBox.Show("Film ist bereits ausgeliehen.", "Hinweis: Neue Ausleihe",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                        }

                        // Daten werden in die DB eingetragen und die geänderten Einräge als Result zurückgegeben
                        _logic.Loan.InsertVideoTable(_videoLoan);
                            _logic.Search.ReadVideo(_videoLoan, out dataTable);
                            DialogSearchResult.ResultTable = dataTable;
                            dialogResult = DialogSearchResult.ShowDialog();
                        }
                        else
                        {
                            // Schließen des Fensters
                            return;
                        }
                    }
                }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Fehler bei neuer Ausleihe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Fehler bei neuer Ausleihe",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AusleiheVerlängernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update
            try
            {
                DataTable dataTable = new DataTable();

                // Fenster wird nach erfogreichem Update erneut angezeigt
                while (true)
                {
                    DialogResult dialogResult = DialogLoanUpdate.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        // Einträge aus den Feldern werden übernommen
                        //_videoLoanExisting zum Überprüfen der Werte mit denen aus der DB
                        _videoLoan = DialogLoanUpdate.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = _videoLoan.Borrower;

                        // Suche nach Einträgen in der DB
                        _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);

                        // Result ist leer
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Angaben stimmen nicht überein oder existieren nicht", "Hinweis: Neue Ausleihe",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            // Für den angegeben Film gibt es keine Ausleihe
                            string borrower = dataTable.Rows[0]["Borrower"].ToString();
                            DateTime returnDate = Util.ParseDate(dataTable.Rows[0]["ReturnDate"].ToString(), DateTime.Now);
                            if ((_videoLoan.ID != 0) && (borrower == "") && (returnDate == Util.ParseDate("01.01.2001", DateTime.Now)))
                            {
                                MessageBox.Show("Film ist nicht ausgeliehen.", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        // Daten werden in die DB eingetragen und die geänderten Einräge als Result zurückgegeben
                        _videoLoan = DialogLoanUpdate.VideoDtoLoan;
                        _logic.Loan.UpdateVideoTable(_videoLoan);
                        _logic.Search.ReadVideo(_videoLoan, out dataTable);
                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();
                    }
                    else
                    {
                        // Schließen des Fensters
                        return;
                    }
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Fehler beim Ändern der Ausleihe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Fehler beim Ändern der Ausleihe",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RückgabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delete
            try
            {
                DataTable dataTable = new DataTable();
                // Fenster wird nach erfogreichem Delete erneut angezeigt
                while (true)
                {
                    DialogResult dialogResult = DialogLoanDelete.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        // Einträge aus den Feldern werden übernommen
                        //_videoLoanExisting zum Überprüfen der Werte mit denen aus der DB
                        _videoLoan = DialogLoanDelete.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = _videoLoan.Borrower;

                        // Suche nach Einträgen in der DB
                        _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);

                        // Result ist leer
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Keine passenden Einträge gefunden.", "Hinweis: Neue Ausleihe",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        // Die Daten die geändert werden, werden als Result angezeigt und danach überarbeitet
                        _videoLoan = DialogLoanDelete.VideoDtoLoan;
                        _logic.Search.ReadVideo(_videoLoan, out dataTable);
                        _logic.Loan.DeleteVideoTable(_videoLoan);
                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();

                    }
                    else
                    {
                        // Schließen des Fensters
                        return;
                    }
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Fehler bei der Rückgabe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Fehler bei der Rückgabe",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
