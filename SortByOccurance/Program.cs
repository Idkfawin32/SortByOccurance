using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SortByOccurance
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();

            if(args.Length > 0)
            {
                string fn = args[0];
                string ofn = args[0] + ".byoccurrance.txt";
                using(StreamReader sr = new StreamReader(fn))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        if (line != "")
                        {
                            if (table.ContainsKey(line))
                            {
                                table[line] += 1;
                            }
                            else
                            {
                                table.Add(line, 1);
                            }
                        }
                    }
                }

                var ordered = table.OrderByDescending(x => x.Value);

                using(StreamWriter sr = new StreamWriter(ofn))
                {
                    foreach (KeyValuePair<string, int> kvp in ordered)
                    {
                        sr.WriteLine(kvp.Key + " - " + kvp.Value);
                    }
                }
            }
        }
    }
}
