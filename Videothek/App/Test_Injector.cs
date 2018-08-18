using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

using VideoDialog.Factories;
using VideoLogic;
using VideoLogic.Factories;
using VideoData.Factories;


namespace App
{
    class Test_Injector
    {

        private IDialog _dialogMain;


        public void Run()
        {

            Application.Run(_dialogMain as Form);

        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Test_Injector().Run();
        }
    }
}
