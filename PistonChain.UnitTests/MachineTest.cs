using System;
using PistonChain.Models.Time;
using PistonChain.Models.Machines;
using Xunit;

namespace PistonChain.UnitTests.MachineTest
{
    public class MachineTest
    {
        [Fact]
        public async void UsinerMachineT_ReturnsTimeEqualToUsinageDuration()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineT(timeManager);
            

            //Act
            var time = await machine.Usiner();

            //Assert
            Assert.Equal(time, machine.UsinageDuration);
        }

        [Fact]
        public async void UsinerMachineJ_ReturnsTimeEqualToUsinageDuration()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineJ(timeManager);


            //Act
            var time = await machine.Usiner();

            //Assert
            Assert.Equal(time, machine.UsinageDuration);
        }

        [Fact]
        public async void UsinerMachineA_ReturnsTimeEqualToUsinageDuration()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineA(timeManager);


            //Act
            var time = await machine.Usiner();

            //Assert
            Assert.Equal(time, machine.UsinageDuration);
        }


        [Fact]
        public async void AssemblePiecesInMachineP_ReturnsTimeEqualToUsinageDuration()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineP(timeManager);


            //Act
            var time = await machine.AssemblePieces();

            //Assert
            Assert.Equal(time, machine.OperationDuration);
        }


        [Fact]
        public async void TestMachinePBreakin100Uses_Returns25()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineP(timeManager);
            int machineUsageCount = 0;
            int totalBreak = 0;


            //Act
            while (machineUsageCount <= 100)
            {
                if (MachineManager.IsBroken(machine.UsageCount)) totalBreak += 1;
                await machine.AssemblePieces();
                machineUsageCount++;
            }

            //Assert
            Assert.Equal(25, totalBreak);
        }

        [Fact]
        public async void TestMachineABreakin100Uses_Returns25()
        {
            //Arrange
            var timeManager = new TimeManager();
            var machine = new MachineA(timeManager);
            int machineUsageCount = 0;
            int totalBreak = 0;


            //Act
            while (machineUsageCount <= 100)
            {
                if (MachineManager.IsBroken(machine.UsageCount)) totalBreak += 1;
                await machine.Usiner();
                machineUsageCount++;
            }

            //Assert
            Assert.Equal(25, totalBreak);
        }
    }
}
