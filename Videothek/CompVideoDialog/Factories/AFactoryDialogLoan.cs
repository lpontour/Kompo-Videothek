using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic;
using VideoDialog.Loan;

namespace VideoDialog.Factories
{
    public abstract class AFactoryDialogLoan
    {
        public static void LoanInsertCreate(ILogic logic, IDialog dialogMain)
        {
            if (dialogMain is CDialogMain)
            {
                (dialogMain as CDialogMain).DialogLoanInsert = new CDialogLoanInsert(logic, dialogMain);
            }
        }
        public static void LoanUpdateCreate(ILogic logic, IDialog dialogMain)
        {
            if (dialogMain is CDialogMain)
            {
                (dialogMain as CDialogMain).DialogLoanUpdate = new CDialogLoanUpdate(logic, dialogMain);
            }
        }
        public static void LoanDeleteCreate(ILogic logic, IDialog dialogMain)
        {
            if (dialogMain is CDialogMain)
            {
                (dialogMain as CDialogMain).DialogLoanDelete = new CDialogLoanDelete(logic, dialogMain);
            }
        }
    }
}
