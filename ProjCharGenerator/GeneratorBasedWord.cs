using System;
using System.Drawing;

namespace generator
{
	public class GeneratorBasedWord
    {
        private string[] data;
        int[] weights;
        private int size;

        private Random random = new Random();

        int[] np;
        int summa = 0;

        public GeneratorBasedWord()
		{
            size = 100;
            data = new string[size];
            weights = new int[size];

            try
            {
                using (StreamReader sr = new StreamReader("Words.txt")) //считывание из файла
                {
                    int i = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] numbers = line.Split(' ');
                        data[i] = numbers[0];
                        weights[i] = int.Parse(numbers[1]);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < size; i++)
                summa += weights[i];

            np = new int[size];
            int s2 = 0;
            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }

        public string getSym()
        {
            int m = random.Next(0, summa);
            int j;
            for (j = 0; j < size; j++)
            {
                if (m < np[j])
                    break;
            }
            return data[j];
        }
    }
}