using System;
using PistonChain.Models.Time;
using PistonChain.Models.Machines;
using Xunit;
using PistonChain.Models.Operation;

namespace PistonChain.UnitTests.OperationManagerTest
{
    public class OperationTest
    {
        [Fact]
        public async void MakePiston_ReturnsElapsedTimeGreaterThanZero()
        {
            //Arrange
            var timeManager = new TimeManager();
            var operationManager = new OperationManager(timeManager);


            //Act
            await operationManager.MakePiston();
            var time = timeManager.GetElapsedTime();

            //Assert
            Assert.True(time > 0);
        }


        [Fact]
        public async void MakePistons_ReturnsElapsedTimeGreaterThanZero()
        {
            //Arrange
            var timeManager = new TimeManager();
            var operationManager = new OperationManager(timeManager);


            //Act
            var time = await operationManager.MakePistons();

            //Assert
            Assert.True(time > 0);
        }
    }
}
