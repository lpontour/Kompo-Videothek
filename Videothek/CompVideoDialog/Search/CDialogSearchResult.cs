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

        #endregion

        private void CDialogSearchResult_Load(object sender, EventArgs e)
        {
            // set datasource
            this.dataGridViewVideoTable.DataSource = ResultTable;

            // set primary key and foreign keys columns invisible
            foreach (DataGridViewColumn column in this.dataGridViewVideoTable.Columns)
            {
                if (column.Name.Substring(0, 2) == "pk" ||
                    column.Name.Substring(0, 2) == "fk")
                    column.Visible = false;
            }

            // column width auto
            foreach (DataGridViewColumn dataGridViewColumn in this.dataGridViewVideoTable.Columns)
            {
                dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
    }
}
