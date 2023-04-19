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
            StreamWriter sw1 = new StreamWriter("BigramsResult.txt");
            int i = 0;
            while(i < 1000)
            {
                string ch = gen1.getSym();
                i += ch.Length;

                sw1.Write(ch + " ");
            }
            sw1.Close();

            GeneratorBasedWord gen2 = new GeneratorBasedWord();
            StreamWriter sw2 = new StreamWriter("WordResult.txt");
            i = 0;
            while (i < 1000)
            {
                string ch = gen2.getSym();
                i += ch.Length;

                sw2.Write(ch + " ");
            }
            sw2.Close();

            GeneratorOnPairsOfWords gen3 = new GeneratorOnPairsOfWords();
            StreamWriter sw3 = new StreamWriter("PairsOfWordsResult.txt");
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
