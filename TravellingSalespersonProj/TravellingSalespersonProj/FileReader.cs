using System;
using System.IO;

namespace TravellingSalespersonProj
{
    public class FileReader
    {
        public void ReadFileOfTypeCSV(Graph graph)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("C:\\Users\\joshu\\Documents\\repos\\TravelingSalesperson\\TravellingSalespersonProj\\TravellingSalespersonProj\\Resources\\ulysses.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] values = sr.ReadLine().Split(',');

                        if(IsRowWithCorrectStartingData(values))
                        {
                            float[] coordinates = { float.Parse(values[1]), float.Parse(values[2]) };
                            graph.AddNodeToGraph(int.Parse(values[0]), coordinates);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
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
