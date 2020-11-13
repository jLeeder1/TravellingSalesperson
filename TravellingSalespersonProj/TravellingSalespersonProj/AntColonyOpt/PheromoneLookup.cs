using System;
using System.Collections;
using System.Collections.Generic;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class PheromoneLookup
    {
        // NOTE in this dictionary nodes are always stored [lowerIntValue, higherIntValue] for the key
        private Dictionary<EdgeStructure, double> pheronomoneValues;

        public PheromoneLookup()
        {
            pheronomoneValues = new Dictionary<EdgeStructure, double>();
        }

        public double GetPheromoneLevelForEdge(int[] edges)
        {
            edges = FormatUndirectionalEdges(edges);
            EdgeStructure edgeStructure = new EdgeStructure(edges[0], edges[1]);
            
            if (pheronomoneValues.ContainsKey(edgeStructure))
            {
                return pheronomoneValues[edgeStructure];
            }

            return double.MaxValue;
        }

        public void DecayAllPheromones()
        {
            Dictionary<EdgeStructure, double> newPheronomoneValues = new Dictionary<EdgeStructure, double>();

            foreach (KeyValuePair<EdgeStructure, double> entry in pheronomoneValues)
            {
                newPheronomoneValues[entry.Key] = entry.Value * ACOConstants.RHO_PHEROMONE_DECAY;
            }

            pheronomoneValues = newPheronomoneValues;
        }

        public void UpdatePheromoneForSingleRoute(int[] route)
        {
            double pheremoneIncrease = ACOConstants.Q_PHEROMONE_Deposition / route.Length;

            for (int index = 1; index < route.Length - 2; index++)
            {
                int[] edges = FormatUndirectionalEdges(new int[] { route[index], route[index + 1] });
                UpdatePheromone(new EdgeStructure(edges[0], edges[1]), pheremoneIncrease);
            }
        }

        public void InitialisePheremoneOnAllEdges(int numberOfCities)
        {
            for (int outerIndex = 1; outerIndex <= numberOfCities - 1; outerIndex++)
            {
                for (int innerIndex = outerIndex + 1; innerIndex <= numberOfCities; innerIndex++)
                {
                    UpdatePheromone(new EdgeStructure(outerIndex, innerIndex), ACOConstants.INITIAL_PHEROMONE_LEVEL);
                    //Console.WriteLine($"The value at [{outerIndex}, {innerIndex}] is {pheronomoneValues[new int[] { outerIndex, innerIndex }]}");
                }
            }
        }

        private void UpdatePheromone(EdgeStructure key, double newPheronmoneLevel)
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
