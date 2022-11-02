using System;
using PistonChain.Models.Operation;
using PistonChain.Models.Time;

namespace PistonChain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make Pistons
            var timeManager = new TimeManager();
            var operationManager = new OperationManager(timeManager);
            _ = operationManager.MakePistons();
        }
    }
}
