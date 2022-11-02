using PistonChain.Models.Time;
using Xunit;

namespace PistonChain.UnitTests.TimeManagerTest
{
    public class TimeManagerTest
    {
        [Fact]
        public async void Wait_ReturnsFloatEqualToTotalWaitingTime()
        {
            //Arrange
            var timeManager = new TimeManager();
            float waitingTime = 5;
            float operationIteration = 10;

            //Act
            var time = await timeManager.Wait(waitingTime * operationIteration);

            //Assert
            Assert.Equal(time, waitingTime * operationIteration);
        }
    }
}
