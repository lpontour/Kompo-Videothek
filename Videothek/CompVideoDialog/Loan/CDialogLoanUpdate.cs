﻿using System;
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
    internal partial class CDialogLoanUpdate : Form
    {
        #region fields
        private ILogic _logic;
        private CDialogMain _dialogMain;
        #endregion

        #region properties
        internal VideoDtoLoan VideoDtoLoan { get; set; } 
        #endregion

        #region ctor
        internal CDialogLoanUpdate(ILogic logic, IDialog dialogMain)
        {
            InitializeComponent();
            _dialogMain = dialogMain as CDialogMain;
            _logic = logic;
        }
        #endregion

        #region Eventhandler
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxReturnDate.Text == "")
            {
                MessageBox.Show("Das Rückgabedatum muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBoxID.Text == "" && textBoxTitle.Text == "" && textBoxBorrower.Text == "")
            {
                MessageBox.Show("ID, Titel oder Ausleihender muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBoxID.Text == "" && textBoxBorrower.Text == "" && !(textBoxTitle.Text == "") && !(textBoxReturnDate.Text == ""))
            {
                MessageBox.Show("ID oder Ausleihender muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                VideoDtoLoan videoLoan = _dialogMain.VideoLoan;
                videoLoan.ID = Util.ParseInt(textBoxID.Text, 0); ;
                videoLoan.Title = textBoxTitle.Text;
                videoLoan.Borrower = textBoxBorrower.Text;
                videoLoan.ReturnDate = Util.ParseDate(textBoxReturnDate.Text, DateTime.Now);
                this.VideoDtoLoan = videoLoan;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

    }
}
