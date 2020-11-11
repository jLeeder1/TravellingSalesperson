using System.Collections.Generic;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public interface IRecombinationStrategy
    {
        List<Route> RunRecombination(Route parentOne, Route parentTwo);
    }
}