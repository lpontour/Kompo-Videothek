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

namespace VideoDialog.Search
{
    internal partial class CDialogSearchResult : Form
    {
        #region fields
        private CDialogMain _dialogMain;
        #endregion

        #region properties
        internal DataTable ResultTable { get; set; }
        #endregion

        #region ctor
        internal CDialogSearchResult(IDialog dialogMain)
        {
            InitializeComponent();
            if (dialogMain is CDialogMain)
            {
                _dialogMain = dialogMain as CDialogMain;
            }
            else
            {
                CErrorHandling.ShowAndStop("Fehler beim Initialisieren von CDialogSearchResult", "Programmabbruch");
            }
        }
        #endregion

        #region Eventhandler

        private void CDialogSearchResult_Load(object sender, EventArgs e)
        {
            // Daten werden eingetragen
            this.dataGridViewVideoTable.DataSource = ResultTable;

            // Spaltenbreite wird automatisch ermittelt
            foreach (DataGridViewColumn dataGridViewColumn in this.dataGridViewVideoTable.Columns)
            {
                dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        #endregion
    }
}
