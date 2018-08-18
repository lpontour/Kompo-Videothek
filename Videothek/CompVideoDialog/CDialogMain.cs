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
        #endregion

        #region properties
        // Properties für DB fehlen noch 
        internal VideoDtoSearch VideoSearch { get { return _videoSearch; } }
        internal VideoDtoLoan VideoLoan { get { return _videoLoan; } }
        internal CDialogSearch DialogSearch { get; set; }
        internal CDialogSearchResult DialogSearchResult { get; set; }
        internal CDialogLoanInsert DialogLoanInsert { get; set; }
        internal CDialogLoanUpdate DialogLoanUpdate { get; set; }
        internal CDialogLoanDelete DialogLoanDelete  { get; set; }
        #endregion

        #region ctor
        internal CDialogMain(Ilogic logic)
        {
            InitializeComponent();
            _logic = logic;
            _videoSearch = new VideoDtoSearch();
            _videoLoan = new VideoDtoLoan();
            this.Text = ("Videothek");
        }
        #endregion

        #region Eventhandler
        #endregion

    }
}
