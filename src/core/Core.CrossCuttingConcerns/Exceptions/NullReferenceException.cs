using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class NullReferenceException : Exception
    {
        public NullReferenceException(string message) : base(message)
        {
            
        }
    }
}
