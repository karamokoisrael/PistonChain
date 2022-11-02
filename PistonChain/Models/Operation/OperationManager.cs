using System;
using System.Threading.Tasks;
using PistonChain.Models.Time;

namespace PistonChain.Models.Operation
{
    public class OperationManager
    {
        private readonly TimeManager _timeManager = new();
        public OperationManager(TimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        public async void MakePiston()
        {

        } 
    }
}
