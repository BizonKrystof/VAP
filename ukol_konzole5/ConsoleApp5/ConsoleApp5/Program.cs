using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Nedostatečný počet argumentů");
                return;
            }



            string path = "soubor.txt";
            if (File.Exists("path"))
            {
                string filename = args[0];
                Dictionary<char, int> characterCounts;
                StreamReader reader = new StreamReader(path);
                using (StreamWriter writer = new StreamWriter(args[1], false))
                {
                    int lineCount = 0;
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine();
                        writer.WriteLine($"Znak{++lineCount}: {text}");
                    }
                }

                reader.Close();
            }
            Console.Read();
        }
    }
}