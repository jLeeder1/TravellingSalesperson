using System;
using System.IO;
using System.Reflection;

namespace TravellingSalespersonProj
{
    public class FileReader
    {
        public void ReadFileOfTypeCSV(Graph graph)
        {
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                //string resourceName = "TravellingSalespersonProj.Resources.ulysses.csv";
                string resourceName = "TravellingSalespersonProj.Resources.test.csv";

                try
                {
                    using Stream stream = assembly.GetManifestResourceStream(resourceName);
                    using StreamReader reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        string[] values = reader.ReadLine().Split(',');

                        if (IsRowWithCorrectStartingData(values))
                        {
                            double[] coordinates = { double.Parse(values[1]), double.Parse(values[2])};
                            graph.AddNodeToGraph(int.Parse(values[0]), coordinates);
                        }
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private bool IsRowWithCorrectStartingData(string[] row)
        {
            int result = 0;
            if (int.TryParse(row[0], out result) && row[0] != string.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
