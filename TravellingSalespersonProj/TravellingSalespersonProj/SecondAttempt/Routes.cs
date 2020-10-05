using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.SecondAttempt
{

    public class Routes
    {
        // Don't think this will check the contents of hte arrays, just if it's the same object
        public HashSet<int[]> AllRoutes { get; set; }

        public void AddSingleRoute(int[] route)
        {
            AllRoutes.Add(route);
        }
    }
}
