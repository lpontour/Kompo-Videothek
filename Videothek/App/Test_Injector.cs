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
using System.IO;

namespace App
{
    class Test_Injector
    {
        #region fields
        private IData _data;
        private ILogic _logic;
        private IDialog _dialogMain;
        #endregion
        #region methods
        void Run()
        {

            // Pfad zur Datenbank
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\VideoDatabase.accdb";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";

            // Objekterstellung passend zu den gewählten Factories
            IFactoryIData factoryData = new CFactoryCDataAccess();
            _data = factoryData.Create(connectionString);

            IFactoryILogic factoryLogic = new CFactoryCLogic();
            _logic = factoryLogic.Create(_data);
            AFactoryLogicSearch.Create(_logic, _data.Search);
            AFactoryLogicBorrow.Create(_logic, _data.Loan);

            IFactoryIDialog factoryDialog = new CFactoryCDialog();
            _dialogMain = factoryDialog.Create(_logic);
            AFactoryDialogSearch.SearchCreate(_logic.Search, _dialogMain);
            AFactoryDialogSearch.SearchResultCreate(_dialogMain);
            AFactoryDialogLoan.LoanInsertCreate(_logic, _dialogMain);
            AFactoryDialogLoan.LoanUpdateCreate(_logic, _dialogMain);
            AFactoryDialogLoan.LoanDeleteCreate(_logic, _dialogMain);
            _data.Init();


            // CDialogMain starten
            if (_dialogMain is Form)
            {
                Application.Run(_dialogMain as Form);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Einstellungen zum Stil der Anwendung
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Test_Injector().Run();
        }
        #endregion
    }
}