﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public static class ACOConstants
    {
        public static readonly double INITIAL_PHEROMONE_LEVEL = 0.005d;
        public static readonly double RHO_PHEROMONE_DECAY = 0.6d;
        public static readonly double Q_PHEROMONE_Deposition = 150d;
        public static readonly double ALPHA_PHEROMONE_IMPORTANCE = 1.5d;
        public static readonly double BETA_EDGE_IMPORTANCE = 2.5d;

        public static readonly int DEFAULT_ANT_POPULATION = 100;
        public static readonly int DEFAULT_ANT_GENERATIONS = 100;
    }
}
