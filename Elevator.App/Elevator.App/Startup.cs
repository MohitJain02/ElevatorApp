using Elevator.App.Infrastructor;
using Elevator.App.Services;
using Elevator.App.Validations;
using ElevatorImplementation = Elevator.App.Services.Elevator;

namespace Elevator.App
{
    public static class Startup
    {
        public static void Initialize()
        {
            DependencyInjector.Register<IElevator, ElevatorImplementation>();

            DependencyInjector.Register<IValidator, Validator>();

            DependencyInjector.Register<ITaskPerformer, TaskPerformer>();

        }
    }
}
