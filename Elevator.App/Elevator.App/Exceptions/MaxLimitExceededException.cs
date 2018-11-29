using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Exceptions
{
    class MaxLimitExceededException : Exception
    {
        public MaxLimitExceededException(string message, int maxLimit)
           : base(message)
        {
        }
    }
}
