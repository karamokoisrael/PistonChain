using System;
using System.Threading.Tasks;

namespace PistonChain.Models.Time
{
    public class TimeManager
    {
        private double _time = 0;
        public TimeManager()
        {
        }

        public static double GenerateReparationTime(double minimum = 5, double maximum = 10)
        {
            Random random = new();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public async Task<double> Wait(double time)
        {
            // Not required for this test but I think waiting should be async
            var currentTime = await Task.Run(() => _time += time);
            return currentTime;
        }

        public double GetElapsedTime()
        {
            return _time;
        }
    }
}
