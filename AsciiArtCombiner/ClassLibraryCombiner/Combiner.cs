

using System;
using System.Collections.Generic;

namespace ClassLibraryCombiner
{
    public class Combiner
    {
        List<string[]> list;

        public Combiner(List<string[]> list)
        {
            this.list = list;
        }

        public void combineFiles()
        {
            

            if (checkRequirements())
            {
                String[] result = list[0];
                foreach (var file in list)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        var fileCharArray = file[i].Replace('\r', ' ').ToCharArray();
                        var resultCharArray = result[i].Replace('\r', ' ').ToCharArray();
                        for (int j = 0; j < resultCharArray.Length; j++)
                        {
                            if (resultCharArray[j] == ' ' && fileCharArray[j] != ' ')
                            {
                                resultCharArray[j] = fileCharArray[j];
                            }
                        }
                        result[i] = new String(resultCharArray);
                    }
                }
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
            else
            {
                Console.WriteLine("Dateien stimmen in der Größe nicht überein!");
            }

            
        }
        public Boolean checkRequirements()
        {
            foreach (var file in list)
            {
                if (file.Length != list[0].Length || file[0].Length != list[0][0].Length)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
