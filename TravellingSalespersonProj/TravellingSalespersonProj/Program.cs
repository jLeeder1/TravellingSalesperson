using System;

namespace TravellingSalespersonProj
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultGraphGenerator defaultGraphGen = new DefaultGraphGenerator();
            defaultGraphGen.GenerateNodes();
        }

    }
}
