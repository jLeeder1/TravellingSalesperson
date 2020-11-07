using System.Collections.Generic;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class PheromoneLookup
    {
        // NOTE in this dictionary nodes are always stored [lowerIntValue, higherIntValue] for the key
        private Dictionary<int[], double> pheronomoneValues;

        public PheromoneLookup()
        {
            pheronomoneValues = new Dictionary<int[], double>();
        }

        public double GetPheromoneLevelForEdge(int[] edges)
        {
            edges = FormatUndirectionalEdges(edges);

            if (pheronomoneValues.ContainsKey(edges))
            {
                return pheronomoneValues[edges];
            }

            return double.MaxValue;
        }

        public void DecayAllPheromones()
        {
            foreach(KeyValuePair<int[], double> entry in pheronomoneValues)
            {
                UpdatePheromone(entry.Key, entry.Value * ACOConstants.RHO_PHEROMONE_DECAY);
            }
        }

        public void UpdatePheromoneForSingleRoute(int[] route)
        {
            double pheremoneIncrease = ACOConstants.Q_PHEROMONE_Deposition / route.Length;

            for (int index = 0; index < route.Length - 2; index++)
            {
                int[] edges = FormatUndirectionalEdges(new int[] { route[index], route[index + 1] });
                UpdatePheromone(edges, pheremoneIncrease);
            }
        }

        private void UpdatePheromone(int[] key, double newPheronmoneLevel)
        {
            pheronomoneValues[key] = newPheronmoneLevel;
        }

        /*
         * This makes it always format the undirectrional value into a directional one
         * This saves having to store duplicate values like 0 to 1 and 1 to 0
         * Intead we take in [0,1] and get the value at [0,1] or we get [1,0] and convert it to to [0,1] to get value at [0,1]
         */
        private int[] FormatUndirectionalEdges(int[] egdes)
        {
            if (egdes[0] > egdes[1])
            {
                return new int[]
                {
                    egdes[1],
                    egdes[0]
                };
            }

            return egdes;
        }
    }
}
