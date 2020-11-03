using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class ACOController
    {
        private readonly PheromoneLookup pheromoneLookup;

        public ACOController()
        {
            pheromoneLookup = new PheromoneLookup();
        }
    }
}
