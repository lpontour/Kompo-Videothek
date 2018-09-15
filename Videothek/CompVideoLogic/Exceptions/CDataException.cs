using System;

namespace VideoLogic.Exceptions
{
    public class CDataException : Exception
    {
		//Stellt die Exceptions mit Text zur verfügung
		public CDataException(string message) : base(message) {}
    }
}
