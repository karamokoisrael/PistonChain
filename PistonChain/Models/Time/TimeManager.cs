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

        public double WaitHandler(double time)
        {
            _time += time;
            return time;
        }

        public async Task<double> Wait(double time)
        {
            // Not required for this test but I think waiting should be async
            await Task.Run(() => WaitHandler(time));
            return _time;
        }

        public double GetElapsedTime()
        {
            return _time;
        }
    }
}
