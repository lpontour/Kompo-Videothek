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
using VideoLogic.Utils;

namespace VideoDialog.Loan
{
    internal partial class CDialogLoanDelete : Form
    {
        #region fields
        private ILogic _logic;
        private CDialogMain _dialogMain;
        #endregion

        #region ctor
        internal CDialogLoanDelete(ILogic logic, IDialog dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain as CDialogMain;
            _logic = logic;
        }
        #endregion

        #region Eventhandler
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            VideoDtoLoan videoLoan = _dialogMain.VideoLoan;
            videoLoan.Id = Util.CreateGUID();
            videoLoan.Title = textBoxTitle.Text();
            videoLoan.Borrower = textBoxBorrower.Text();
            videoLoan.ReleaseDate = Util.ParseDate(this.textBoxReturnDate, 0);

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
