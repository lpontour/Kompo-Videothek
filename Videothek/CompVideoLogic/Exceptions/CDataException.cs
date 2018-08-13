using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLogic.Exceptions
{
    public class CDataException : Exception
    {
		public CDataException( string message ) : base( message )  {}
    }
}
