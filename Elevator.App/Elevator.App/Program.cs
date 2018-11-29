using Elevator.App.Infrastructor;
using Elevator.App.Validations;
using log4net;
using log4net.Config;
using System;
using System.Reflection;

namespace Elevator.App
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static ITaskPerformer _taskPerformer;
        private static IValidator _validator;

        static void Main(string[] args)
        {
            // Register all dependecies of the applications
            Startup.Initialize();
            XmlConfigurator.Configure();

            #region Retreive Instance

            _validator = DependencyInjector.Retrieve<IValidator>();
            _taskPerformer = DependencyInjector.Retrieve<ITaskPerformer>();

            #endregion

            Console.WriteLine("Welcome to Elevator constructed by XYZ Company");
            _log.Info("Starting Application Successfully");

            do
            {
                string selectedOperations = PerformOperations();
                var parsedInputResult = _validator.CanParseInput(selectedOperations);
                if (parsedInputResult.Item2)
                {
                    if (_taskPerformer.PerformTask(parsedInputResult.Item1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully reached to Destination !!!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry!! Please select the appropriate floor");
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Press valid inputs");
                }

                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadLine().ToLower() != "Y" || Console.ReadLine().ToLower() != "yes");

            Console.WriteLine("Thansk for using the Elevator, Hope to see you soon !!! :)");
            Console.ReadLine();
        }

        private static string PerformOperations()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Select the Operations you want to Perform !!!");
            Console.WriteLine("1. to go Up(^^)");
            Console.WriteLine("2. button to go down (vv)");

            return Console.ReadLine();
        }


    }
}
