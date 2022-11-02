using System;
using System.Threading.Tasks;
using PistonChain.Models.Machines;
using PistonChain.Models.Piston;
using PistonChain.Models.Time;

namespace PistonChain.Models.Operation
{
    public class OperationManager
    {
        private readonly TimeManager _timeManager;
        private readonly MachineP _machineP;
        private readonly MachineT _machineT;
        private readonly MachineJ _machineJ;
        private readonly MachineA _machineA;

        public OperationManager(TimeManager timeManager)
        {
            _timeManager = timeManager;
            _machineP = new MachineP(timeManager);
            _machineT = new MachineT(timeManager);
            _machineJ = new MachineJ(timeManager);
            _machineA = new MachineA(timeManager);
            
        }

        public async Task<double> MakePiston()
        {
            // Get Pieces
            var box = new Box();
            var pieces = box.GetPieces();
            IUsinageMachine usinageMachine;

            //Choose piece to work with
            foreach (string piece in pieces)
            {
                usinageMachine = piece switch
                {
                    "tête" => _machineT,
                    "jupe" => _machineJ,
                    "axe" => _machineA,
                    _ => _machineT,
                };

                //Usinage for each piece
                await usinageMachine.Usiner();
            }

            //assemble pieces
            await _machineP.AssemblePieces();
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
