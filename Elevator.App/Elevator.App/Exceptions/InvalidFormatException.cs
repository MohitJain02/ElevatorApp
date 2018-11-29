using System;

namespace Elevator.App.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message)
           : base(message)
        {
        }
    }
}
