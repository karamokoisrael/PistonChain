using System.Threading.Tasks;

namespace PistonChain.Models.Machines
{
    public interface IUsinageMachine
    {
        string PieceName { get; set; }
        double UsinageDuration { get; set; }
        int UsageCount { get; set; }
        Task<double> Usiner();
        Task<double> Repair();
    }
}
