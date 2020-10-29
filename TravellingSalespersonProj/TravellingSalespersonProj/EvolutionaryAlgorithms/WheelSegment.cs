using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class WheelSegment
    {
        public Route Route { get; set; }
        public double LowerBound { get; set; }

        public WheelSegment(Route route, double lowerBound)
        {
            Route = route;
            LowerBound = lowerBound;
        }
    }
}
