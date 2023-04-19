using System;
using System.IO;
using System.Collections.Generic;
namespace generator
{
	public class GeneratorBasedOnBigrams
	{
        private string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        private char[] data;
        int[,] weights;
        private int size;

        private Random random = new Random();
        
        public GeneratorBasedOnBigrams()
	{
            size = syms.Length;
            data = syms.ToCharArray();
            weights = new int[size, size];
            try
            {
                using (StreamReader sr = new StreamReader("Bigrams.txt")) //считывание из файла
                {
                    int i = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] numbers = line.Split(' ');
                        for (int j = 0; j < size; j++)
                        {
                            weights[i, j] = int.Parse(numbers[j]);
                        }
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public string getSym()
        {
            int summa = 0;
            int index = random.Next(0, size);
            char temp = data[index];

            int[] letterWeights = new int[size];
            for (int i = 0; i < size; i++)
            {
                letterWeights[i] = weights[index, i];
                summa += letterWeights[i];
            }

            int[] np = new int[size];
            int s2 = 0;
            for (int i = 0; i < size; i++) 
            {
                s2 += letterWeights[i];
                np[i] = s2;
            }

            int m = random.Next(0, summa);
            int index2;
            
            for (index2 = 0; index2 < size; index2++)
            {
                if (m < np[index2])
                    break;
            }

            char temp2 = data[index2];

            char[] chars = { temp, temp2 };
            string s = new string(chars);
            return s;
        }
    }
}
