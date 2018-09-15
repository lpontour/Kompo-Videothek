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
        bool exists;

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
                DataTable dataTable = new DataTable();

                while (true)
                {
                    DialogResult dialogResult = DialogLoanInsert.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        _videoLoan = DialogLoanInsert.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = "";

                        if (_videoLoan.ID == 0)
                        {
                            _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Kein Film mit dem Titel " + _videoLoan.Title + " zur Ausleihe verfügbar", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            exists = false;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                int id = Util.ParseInt(row["ID"].ToString(), 0);
                                string title = row["Title"].ToString();
                                string borrower = row["Borrower"].ToString();
                                DateTime returnDate = Util.ParseDate(row["ReturnDate"].ToString(), DateTime.Now);
                                if (borrower == "" && returnDate == Util.ParseDate("01.01.2001", DateTime.Now))
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (exists == false)
                            {
                                MessageBox.Show("Kein Film mit den Namen " + _videoLoan.Title + " zur Ausleihe verfügbar", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {
                            _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Titel und ID stimmen nicht überein oder existieren nicht", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
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
                        _logic.Loan.InsertVideoTable(_videoLoan);
                        _logic.Search.ReadVideo(_videoLoan, out dataTable);
                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();
                    }
                    else
                    {
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

                while (true)
                {
                    DialogResult dialogResult = DialogLoanUpdate.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        _videoLoan = DialogLoanUpdate.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = _videoLoan.Borrower;

                        _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Angaben stimmen nicht überein oder existieren nicht", "Hinweis: Neue Ausleihe",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            string borrower = dataTable.Rows[0]["Borrower"].ToString();
                            DateTime returnDate = Util.ParseDate(dataTable.Rows[0]["ReturnDate"].ToString(), DateTime.Now);
                            if ((_videoLoan.ID != 0) && (borrower == "") && (returnDate == Util.ParseDate("01.01.2001", DateTime.Now)))
                            {
                                MessageBox.Show("Film ist nicht ausgeliehen.", "Hinweis: Neue Ausleihe",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }

                        _videoLoan = DialogLoanUpdate.VideoDtoLoan;
                        _logic.Loan.UpdateVideoTable(_videoLoan);
                        _logic.Search.ReadVideo(_videoLoan, out dataTable);
                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();
                    }
                    else
                    {
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

                while (true)
                {
                    DialogResult dialogResult = DialogLoanDelete.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        _videoLoan = DialogLoanDelete.VideoDtoLoan;
                        _videoLoanExisting.ID = _videoLoan.ID;
                        _videoLoanExisting.Title = _videoLoan.Title;
                        _videoLoanExisting.Borrower = _videoLoan.Borrower;

                        _logic.Search.ReadVideo(_videoLoanExisting, out dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Keine passenden Einträge gefunden.", "Hinweis: Neue Ausleihe",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        _videoLoan = DialogLoanDelete.VideoDtoLoan;

                        _logic.Search.ReadVideo(_videoLoan, out dataTable);
                        _logic.Loan.DeleteVideoTable(_videoLoan);

                        DialogSearchResult.ResultTable = dataTable;
                        dialogResult = DialogSearchResult.ShowDialog();

                    }
                    else
                    {
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
