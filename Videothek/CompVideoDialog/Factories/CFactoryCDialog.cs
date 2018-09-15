using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoLogic;
using VideoLogic.Factories;

namespace VideoDialog.Factories
{
    public class CFactoryCDialog  : IFactoryIDialog
    {
        // Erstellen der CDialogMain
        public IDialog Create (ILogic ilogic)
        {
            return new CDialogMain(ilogic);
        }
    }
}
