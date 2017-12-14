using System.Threading.Tasks;
using ProjektISK.Models;

namespace ProjektISK
{
    public partial class SimulatorWindow
    {
        private readonly Simulator _simulator;

        public SimulatorWindow(Simulator simulator)
        {
            DataContext = simulator;
            InitializeComponent();
            _simulator = simulator;

            Start();
        }

        private async void Start()
        {
            await Task.Run(() => _simulator.Simulate());
        }
    }
}
