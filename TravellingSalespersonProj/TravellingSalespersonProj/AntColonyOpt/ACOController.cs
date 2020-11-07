namespace TravellingSalespersonProj.AntColonyOpt
{
    public class ACOController
    {
        private readonly PheromoneLookup pheromoneLookup;
        private readonly RouteEvaluator routeEvaluator;

        public ACOController()
        {
            pheromoneLookup = new PheromoneLookup();
            routeEvaluator = new RouteEvaluator();
        }
    }
}
