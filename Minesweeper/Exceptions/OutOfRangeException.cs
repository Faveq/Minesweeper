using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Exceptions
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException() { }

        public OutOfRangeException(string? message) : base(message)
        {
        }

        public OutOfRangeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
