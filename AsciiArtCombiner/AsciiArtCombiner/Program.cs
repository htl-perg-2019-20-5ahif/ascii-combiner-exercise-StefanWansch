using ClassLibraryCombiner;
using System;
using System.Collections.Generic;
using System.IO;

namespace AsciiArtCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile(args);

        }
        public static void ReadFile(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    List<string[]> list = new List<string[]>();
                    for (int i = 0; i < args.Length; i++)
                    {
                        var splittedFile = ReadFiles(args[i]);
                        list.Add((string[])splittedFile);
                    }
                    Combine(list);
                }
                else
                {
                    Console.WriteLine("Geben Sie mindestens 2 Dateien an");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Fehler beim einlesen der Textdatei");
            }
        }

        public static void Combine(List<string[]> list)
        {
            Combiner c = new Combiner(list);
            c.combineFiles();
        }

        public static IEnumerable<string> ReadFiles(string filename)
        {
            var file = System.IO.File.ReadAllText(filename);
            var splittedFile = file.Split('\n');
            return splittedFile;
        }



    }
}
