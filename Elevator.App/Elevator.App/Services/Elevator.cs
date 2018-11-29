using Elevator.App.Constants;
using Elevator.App.Validations;
using log4net;
using System;
using System.Reflection;

namespace Elevator.App.Services
{
    public class Elevator : IElevator
    {
        private IValidator _validator;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static int currentFloorLocationTracker = 0;

        public Elevator(IValidator validator)
        {
            _validator = validator;
        }

        public int MaxFloors
        {
            get
            {
                return ApplicationConstants.MaxFloorValue;
            }
            // Can be extended if needs to change the limit 
            private set { }
        }

        public Tuple<int, bool> MoveDown(int currentFloor, int requestFloor)
        {
            bool isMovingDown = false;

            if (_validator.CanGoDown(currentFloor, requestFloor))
            {
                currentFloorLocationTracker = requestFloor;
                isMovingDown = true;
                _log.Info($"Moved to {requestFloor} successfully");
            }
            else
            {
                currentFloorLocationTracker = currentFloor;
            }

            return Tuple.Create(currentFloorLocationTracker, isMovingDown);

        }

        public Tuple<int, bool> MoveUp(int currentFloor, int requestFloor)
        {
            bool isMovingUp = false;

            if (_validator.CanGoUp(currentFloor, requestFloor))
            {
                currentFloorLocationTracker = requestFloor;
                isMovingUp = true;
                _log.Info($"Moved to {requestFloor} successfully");
            }
            else
            {
                currentFloorLocationTracker = currentFloor;
            }

            return Tuple.Create(currentFloorLocationTracker, isMovingUp);
        }
    }
}
