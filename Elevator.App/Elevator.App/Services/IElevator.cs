using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.App.Services
{
    public interface IElevator
    {
        int MaxFloors { get; }

        Tuple<int, bool> MoveDown(int currentFloor, int requestFloor);

        Tuple<int, bool> MoveUp(int currentFloor, int requestFloor);
    };

}
