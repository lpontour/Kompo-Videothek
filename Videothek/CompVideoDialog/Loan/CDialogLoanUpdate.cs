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
            // Prüfen erlaubter Eingabekombinationen
            // Prüfen, ob Rückgabedatum als Pflichtfeld gefüllt ist
            if (textBoxReturnDate.Text == "")
            {
                MessageBox.Show("Das Rückgabedatum muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Prüft, ob mehr als nur das Datum angegeben ist
            else if (textBoxID.Text == "" && textBoxTitle.Text == "" && textBoxBorrower.Text == "")
            {
                MessageBox.Show("ID, Titel oder Ausleihender muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Prüft, ob zum Datum und zum Titel zusätzlich noch ID oder Ausleihender eingetragen wurden
            else if (textBoxID.Text == "" && textBoxBorrower.Text == "" && !(textBoxTitle.Text == "") && !(textBoxReturnDate.Text == ""))
            {
                MessageBox.Show("ID oder Ausleihender muss angegeben werden.", "Hinweis: Ausleihe ändern",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Prüft, ob die ID richtig umgewandelt werden konnte
            else if (Util.ParseInt(textBoxID.Text, 0) == 0 && textBoxTitle.Text == "")
            {
                MessageBox.Show("Es wurde eine falsche ID angegeben.", "Hinweis: Neue Ausleihe",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // wenn Eingabe in Ordnung, wird diese weitrgegeben
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
