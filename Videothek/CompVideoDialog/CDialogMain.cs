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
        // Felder aus der DB fehlen noch
        private VideoDtoSearch _videoSearch;
        private VideoDtoLoan _videoLoan;
        private ILogic _logic;
        private object[] _id;
        private object[] _arrayTitle;
        private object[] _arrayGenre;
        private object[] _borrowingRate;
        private object[] _releaseYear;
        private object[] _runningTime;
        private object[] _rated;
        private object[] _borrower;
        private object[] _returnDate;

        #endregion

        #region properties
        internal object[] ID { get { return _id; } }
        internal object[] Titel { get { return _arrayTitle; } }
        internal object[] Genre { get { return _arrayGenre; } }
        internal object[] BorrowingRate { get { return _borrowingRate; } }
        internal object[] ReleaseYear { get { return _releaseYear; } }
        internal object[] RunningTime { get { return _runningTime; } }
        internal object[] Rated { get { return _rated; } }
        internal object[] Borrower { get { return _borrower; } }
        internal object[] ReturnDate { get { return _returnDate; } }

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
        }
        #endregion

        #region Eventhandler
        private void SuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                while (true)
                {
                    DialogResult dialogResult = DialogSearch.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        // Suchen ausführen
                        _logic.Search.ReadVideos(_videoSearch, out DataTable dataTable);
                        // Ergebnis in DialogSearchView darstellen
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
                DialogResult dialogResult = DialogLoanInsert.ShowDialog();
                DataTable dataTable = new DataTable();
                if (dialogResult == DialogResult.OK)
                {
                    _logic.Loan.InsertVideoTable(_videoLoan);
                    _logic.Search.ReadVideo(_videoLoan, out dataTable);
                    DialogSearchResult.ResultTable = dataTable;
                    dialogResult = DialogSearchResult.ShowDialog();
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Abbruch Verkaufen: neues Auto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Abbruch Verkaufen: neues Auto",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AusleiheVerlängernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update
            try
            {
                DialogResult dialogResult = DialogLoanUpdate.ShowDialog();
                DataTable dataTable = new DataTable();
                if (dialogResult == DialogResult.OK)
                {
                    _logic.Loan.UpdateVideoTable(_videoLoan);
                    _logic.Search.ReadVideo(_videoLoan, out dataTable);
                    DialogSearchResult.ResultTable = dataTable;
                    dialogResult = DialogSearchResult.ShowDialog();
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Abbruch Verkaufen: Auto ändern",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Abbruch Verkaufen: Auto ändern",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RückgabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delete
            try
            {
                DialogResult dialogResult = DialogLoanDelete.ShowDialog();
                DataTable dataTable = new DataTable();
                if (dialogResult == DialogResult.OK)
                {
                    _logic.Loan.DeleteVideoTable(_videoLoan);
                    _logic.Search.ReadVideo(_videoLoan, out dataTable);
                    DialogSearchResult.ResultTable = dataTable;
                    dialogResult = DialogSearchResult.ShowDialog();
                }
            }
            catch (DataException dataException)
            {
                MessageBox.Show(dataException.Message, "Abbruch Verkaufen: Auto löschen",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Abbruch Verkaufen: Auto löschen",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
