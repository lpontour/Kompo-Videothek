using System;
using System.Windows.Forms;

namespace VideoLogic.Exceptions
{
    public class CErrorHandling
    {

		public static void ShowAndStop( string message, string caption ) 
		{
			MessageBox.Show( message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error );
			CErrorHandling.StopExecution();
		}


		private static void StopExecution() 
		{
			// Windows Forms Anwendung (Event driven, MessageLoop)
			if( Application.MessageLoop ) 
{
				Application.Exit(); // Stop MessageLoop ... Dispose
			}
			 // Konsolenanwendung       
        else 
		{
            Environment.Exit(-1);
        }
      }

   }
}
