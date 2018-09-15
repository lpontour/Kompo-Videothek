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

        #region properties
        internal VideoDtoLoan VideoDtoLoan { get; set; }
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
            // Prüfen erlaubter Eingabekombinationen
            // Prüfen, ob Ausleihender als Pflichtfeld ausgefüllt ist
            if (textBoxBorrower.Text == "")
            {
                MessageBox.Show("Ausleihender muss angegeben werden.", "Hinweis: Rückgabe",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // wenn Eingabe in Ordnung, wird diese weitrgegeben
            else
            {
                VideoDtoLoan videoLoan = _dialogMain.VideoLoan;
                videoLoan.ID = Util.ParseInt(textBoxID.Text, 0); ;
                videoLoan.Title = textBoxTitle.Text;
                videoLoan.Borrower = textBoxBorrower.Text;
                videoLoan.ReturnDate = Util.ParseDate(textBoxReturnDate.Text, DateTime.MinValue);
                this.VideoDtoLoan = videoLoan;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Schließen des Fensters und leeren der Felder
            textBoxID.Text = "";
            textBoxTitle.Text = "";
            textBoxBorrower.Text = "";
            textBoxReturnDate.Text = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
