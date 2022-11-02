using System;
namespace PistonChain.Models.Machines
{
    public class MachineManager
    {
        public MachineManager()
        {
        }

        public static bool IsBroken(int UsageCount, int pistonToMake = 100)
        {
            int breakProbability = 25;
            return UsageCount % (pistonToMake / breakProbability) == 0;
        }
    }
}
