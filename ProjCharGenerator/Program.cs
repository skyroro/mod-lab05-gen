using System;
using System.IO;
using System.Buffers.Text;
using System.Collections.Generic;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratorBasedOnBigrams gen1 = new GeneratorBasedOnBigrams();
            string fileName = Path.Combine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\..\\"), "BigramsResult.txt");
            StreamWriter sw1 = new StreamWriter(fileName);
            int i = 0;
            while(i < 1000)
            {
                string ch = gen1.getSym();
                i += ch.Length;

                sw1.Write(ch + " ");
            }
            sw1.Close();

            GeneratorBasedWord gen2 = new GeneratorBasedWord();
            fileName = Path.Combine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\..\\"), "WordResult.txt");
            StreamWriter sw2 = new StreamWriter(fileName);
            i = 0;
            while (i < 1000)
            {
                string ch = gen2.getSym();
                i += ch.Length;

                sw2.Write(ch + " ");
            }
            sw2.Close();

            GeneratorOnPairsOfWords gen3 = new GeneratorOnPairsOfWords();
            fileName = Path.Combine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\\..\\..\\"), "PairsOfWordsResult.txt");
            StreamWriter sw3 = new StreamWriter(fileName);
            i = 0;
            while (i < 1000)
            {
                string ch = gen3.getSym();
                i += ch.Length;

                sw3.Write(ch + " ");
            }
            sw3.Close();
        }
    }
}
