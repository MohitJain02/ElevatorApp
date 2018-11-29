using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Elevator.App.Infrastructor;
using Elevator.App.Services;

namespace Elevator.App.Tests
{
    [TestClass]
    public class ElevatorTests
    {
        private static IElevator _elevator;
                      
        [TestInitialize]
        public void InitializeTestComponents()
        {
            Startup.Initialize();
            _elevator = DependencyInjector.Retrieve<IElevator>();
        }


        [TestMethod]
        public void ShouldMoveDown_When_CurrentFloor_GreaterThen_GroundFloor()
        {
            var result = _elevator.MoveDown(2, 0);

            result.Item2.Should().Be(true);
            result.Item1.Should().Be(0);
        }

        [TestMethod]
        public void ShouldMoveUp_When_CurrentFloor_IsNot_MaxFloor()
        {
            var result = _elevator.MoveUp(2, 5);

            result.Item2.Should().Be(true);
            result.Item1.Should().Be(5);

        }

        [TestMethod]
        public void ShouldNot_MoveUp_WhenCurrentFloor_Is_MaxFloor()
        {
            var result = _elevator.MoveUp(5, 5);

            result.Item2.Should().Be(false);
            result.Item1.Should().Be(5);
        }

        [TestMethod]
        public void ShouldNot_MoveDown_When_CurrentFloor_Is_GroundFloor()
        {
            var result = _elevator.MoveDown(0, 0);

            result.Item2.Should().Be(false);
            result.Item1.Should().Be(0);
        }
    }
}
