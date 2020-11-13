using System;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public struct EdgeStructure
    {
        public int EgdeComponentOne { get; }
        public int EgdeComponentTwo { get; }


        public EdgeStructure(int egdeComponentOne, int egdeComponentTwo)
        {
            EgdeComponentOne = egdeComponentOne;
            EgdeComponentTwo = egdeComponentTwo;
        }

    }
}
