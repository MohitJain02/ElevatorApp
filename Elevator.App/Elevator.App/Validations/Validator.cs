using Elevator.App.Constants;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Validations
{
    public class Validator : IValidator
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Validator()
        {
        }

        public bool CanGoDown(int currentFloor, int requestedFloor)
        {
            bool canGoDown = false;

            if(!IsSameFloor(currentFloor, requestedFloor) && !IsGroundFloor(currentFloor))
            {
                canGoDown =  true;
            }

            return canGoDown;
        }

        public bool CanGoUp(int currentFloor, int requestedFloor)
        {
            bool canGoUp = false;

            if (!IsSameFloor(currentFloor, requestedFloor) && !IsMaxFloor(currentFloor))
            {
                canGoUp = true;
            }

            return canGoUp;
        }

        public Tuple<int, bool> CanParseInput(string inputValue)
        {
            bool isParsedCorrectly = false;

            if (int.TryParse(inputValue, out int parsedValue))
            {
                isParsedCorrectly = true;
            }

            return Tuple.Create(parsedValue, isParsedCorrectly);
        }

        private bool IsMaxFloor(int currentFloor)
        {
            return currentFloor > ApplicationConstants.MaxFloorValue;
        }

        private bool IsSameFloor(int currentFloor, int requestFloor)
        {
            return currentFloor == requestFloor;
        }

        private bool IsGroundFloor(int currentFloor)
        {
            return currentFloor == 0;
        }
    }
}
