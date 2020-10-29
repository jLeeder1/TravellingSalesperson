using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.LocalSearchTutorial
{
    public class Route
    {
        public int[] RouteIds { get; set; }
        public double RouteCost { get; set; }

        public Route(int[] routeIds, double routeCost)
        {
            RouteIds = routeIds;
            RouteCost = routeCost;
        }
    }
}
