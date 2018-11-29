using System;

namespace Elevator.App.Validations
{
    public interface IValidator
    {
        bool CanGoUp(int currentFloor, int requestedFloor);

        bool CanGoDown(int currentFloor, int requestedFloor);

        Tuple<int, bool> CanParseInput(string inputValue);
    }
}
