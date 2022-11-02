using System;
using System.Threading.Tasks;
using PistonChain.Models.Machines;
using PistonChain.Models.Piston;
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

        public async Task<double> MakePiston()
        {
            // Get Pieces
            var box = new Box();
            var pieces = box.GetPieces();
            var machineP = new MachineP(_timeManager);
            IUsinageMachine usinageMachine;
            //Choose piece to work with
            foreach (string piece in pieces)
            {
                usinageMachine = piece switch
                {
                    "tête" => new MachineT(_timeManager),
                    "jupe" => new MachineJ(_timeManager),
                    "axe" => new MachineA(_timeManager),
                    _ => new MachineT(_timeManager),
                };

                //Usinage for each piece
                await usinageMachine.Usiner();
            }

            //assemble pieces
            await machineP.AssemblePieces();
            return _timeManager.GetElapsedTime();
        }

        public async Task<double> MakePistons(int total=100)
        {
            for (int i = 0; i < total; i++)
            {
                await MakePiston();
            }
            var elapsedTime = _timeManager.GetElapsedTime();
            Console.WriteLine($"Elapsed time: {elapsedTime} minutes");
            return elapsedTime;
        }
    }
}
