using System;
using System.Threading.Tasks;
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
            operationManager.MakePistons().GetAwaiter().GetResult();
        }
    }
}
