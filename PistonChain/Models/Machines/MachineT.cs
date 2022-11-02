using System.Threading.Tasks;
using PistonChain.Models.Time;

namespace PistonChain.Models.Machines
{
    public class MachineT : IUsinageMachine
    {
        private readonly TimeManager _timeManager = new();
        public string PieceName { get; set; }
        public double UsinageDuration { get; set; }
        public int UsageCount { get; set; }

        public MachineT(TimeManager timeManager)
        {
            _timeManager = timeManager;
            PieceName = Piston.Piston.Tete;
            UsinageDuration = 2;
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
