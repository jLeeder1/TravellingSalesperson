using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class WheelSegment
    {
        public Route Route { get; set; }
        public float LowerBound { get; set; }

        public WheelSegment(Route route, float lowerBound)
        {
            Route = route;
            LowerBound = lowerBound;
        }
    }
}
