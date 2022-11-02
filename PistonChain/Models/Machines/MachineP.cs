using System.Threading.Tasks;
using PistonChain.Models.Time;

namespace PistonChain.Models.Machines
{
    public class MachineP
    {
        private readonly TimeManager _timeManager = new();
        public readonly double OperationDuration = 1;
        public int UsageCount = 1;
        public MachineP(TimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        public async Task<double> AssemblePieces()
        {
            if (MachineManager.IsBroken(UsageCount))
            {
                await Repair();
            }
            var time = await _timeManager.Wait(OperationDuration);
            UsageCount += 1;
            return time;
        }

        public async Task<double> Repair()
        {
            return await _timeManager.Wait(TimeManager.GenerateReparationTime());
        }
    }
}
