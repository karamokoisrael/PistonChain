using System;
using PistonChain.Models.Time;
using PistonChain.Models.Machines;
using Xunit;

namespace PistonChain.UnitTests.OperationManagerTest
{
    public class OperationTest
    {
        [Fact]
        public async void MakePiston_ReturnsElapsedTimeGreaterThanZero()
        {
            //Arrange
            var timeManager = new TimeManager();


            var machine = new MachineT(timeManager);
            

            //Act
            var time = await machine.Usiner();

            //Assert
            Assert.Equal(time, machine.UsinageDuration);
        }
    }
}
