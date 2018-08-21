using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic;
using VideoDialog.Search;

namespace VideoDialog.Factories
{
    public abstract class AFactoryDialogSearch
    {
        public static void SearchCreate(ILogicSearch logicSearch, IDialog dialogMain)
        {
            if(dialogMain is CDialogMain)
            {
                (dialogMain as CDialogMain).DialogSearch = new CDialogSearch(logicSearch, dialogMain);
            }
        }

        public static void SearchResultCreate(IDialog dialogMain)
        {
            if (dialogMain is CDialogMain)
            {
                (dialogMain as CDialogMain).DialogSearchResult = new CDialogSearchResult(dialogMain);
            }
        }
    }
}
