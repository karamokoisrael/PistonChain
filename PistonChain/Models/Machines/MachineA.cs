using System.Threading.Tasks;
using PistonChain.Models.Time;

namespace PistonChain.Models.Machines
{
    public class MachineA : IUsinageMachine
    {
        private readonly TimeManager _timeManager = new();
        public string PieceName { get; set; }
        public double UsinageDuration { get; set; }
        public int UsageCount { get; set; }

        public MachineA(TimeManager timeManager)
        {
            _timeManager = timeManager;
            PieceName = Piston.Piston.Axe;
            UsinageDuration = 2.5;
            UsageCount = 1;
        }

        public async Task<double> Usiner()
        {
            if (MachineManager.IsBroken(UsageCount))
            {
                await Repair();
            }
            var timeSpent = await _timeManager.Wait(UsinageDuration);
            UsageCount += 1;
            return timeSpent;
        }

        public async Task<double> Repair()
        {
            return await _timeManager.Wait(TimeManager.GenerateReparationTime());
        }
    }
}
