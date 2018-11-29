using Elevator.App.Services;
using Elevator.App.Validations;
using System;

namespace Elevator.App
{
    public class TaskPerformer : ITaskPerformer
    {
        private IElevator _elevator;
        private IValidator _validator;


        // Just to set the starting point
        private static int currentFloor = 0;

        public TaskPerformer(IElevator elevator, IValidator validator)
        {
            _elevator = elevator;
            _validator = validator;
        }
        
        public bool PerformTask(int option)
        {
            bool isSuccess = false;

            switch(option)
            {
                case 1: // Moving Up
                    Console.WriteLine("Please enter the floor you want to move");
                    string inputToGoUp = Console.ReadLine();
                    var moveUpResult = _elevator.MoveUp(currentFloor, _validator.CanParseInput(inputToGoUp).Item1);
                    if(moveUpResult.Item2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successully Reached to {moveUpResult.Item1} Floor !!!");
                        currentFloor = moveUpResult.Item1;
                        isSuccess = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry you can not move to {moveUpResult.Item1} Floor !!!");
                    }

                        break;
                case 2: // MOving Down
                    Console.WriteLine("Please enter the floor you want to move");
                    string inputToGoDown = Console.ReadLine();
                    var moveDownResult = _elevator.MoveDown(currentFloor, _validator.CanParseInput(inputToGoDown).Item1);
                    if (moveDownResult.Item2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successully Reached to {moveDownResult.Item1} Floor !!!");
                        currentFloor = moveDownResult.Item1;
                        isSuccess = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry you can not move to {moveDownResult.Item1} Floor !!!");
                    }
                    break;
                default: Console.WriteLine("Please press the button to move !!!");
                    break;
            }

            return isSuccess;
        }
    }
}
