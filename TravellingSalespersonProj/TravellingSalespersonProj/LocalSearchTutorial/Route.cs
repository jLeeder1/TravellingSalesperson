using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.LocalSearchTutorial
{
    public class Route
    {
        public int[] RouteIds { get; set; }
        public float RouteCost { get; set; }

        public Route(int[] routeIds, float routeCost)
        {
            RouteIds = routeIds;
            RouteCost = routeCost;
        }
    }
}
