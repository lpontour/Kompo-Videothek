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
        #endregion
    }
}
