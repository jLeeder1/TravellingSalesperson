using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class WheelSegment
    {
        public Route Route { get; set; }
        public double UpperBound { get; set; }

        public WheelSegment(Route route, double upperBound)
        {
            Route = route;
            UpperBound = upperBound;
        }
    }
}
