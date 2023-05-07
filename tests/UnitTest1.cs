using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;

namespace tests;

[TestClass]
public class UnitTest1
{
    [TestMethod] //количество символов в биграммах
    public void TestMethod1()
    {
        GeneratorBasedOnBigrams gen = new GeneratorBasedOnBigrams();
        string text = "";
        int i = 0;
        while (i < 1000)
        {
            string ch = gen.getSym();//вызываем метод класса генерации
            i += ch.Length;
            text += ch;
        }
        double result = text.Length;
        double expected = 1000;
        Assert.AreEqual(expected, result);
    }

    [TestMethod] //недопустимые слоги в биграммах
    public void TestMethod2()
    {
        GeneratorBasedOnBigrams gen = new GeneratorBasedOnBigrams();
        string text = "";
        string[] invalidСombinations = { "бб", "зж", "кд", "зй", "пг", "жч", "йь", "кы", "эа", "ьы" };
        bool invalid = false;
        int i = 0;
        while (i < 1000)
        {
            string ch = gen.getSym();
            i += ch.Length;
            text += ch;

            for (int k = 0; k < invalidСombinations.Length; k++)
            {
                if (ch == invalidСombinations[k]) invalid = true;
            }
        }
        Assert.AreEqual(invalid, false);
    }

    [TestMethod] //проверка вероятности в известном тексте биграммы
    public void TestMethod3()
    {
        GeneratorBasedOnBigrams gen = new GeneratorBasedOnBigrams();
        SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
        string text;
        using (StreamReader sr = new StreamReader("BigramsResult.txt"))
        {
            text = sr.ReadToEnd();
        }
        string[] data = text.Split(' ');
        for (int i = 0; i < data.Length; i++)
        {
            string ch = data[i];
            if (stat.ContainsKey(ch))
                stat[ch]++;
            else
                stat.Add(ch, 1);    
        }
        double result = stat["го"];
        double expected = 13;
        Assert.AreEqual(expected, result);
    }

    [TestMethod] //слова кол-во символов
    public void TestMethod4()
    {
        GeneratorBasedWord gen = new GeneratorBasedWord();
        bool Bad = false;
        string text = "";
        int i = 0;
        while (i < 1000)
        {
            string ch = gen.getSym();//вызываем метод класса генерации
            i += ch.Length;
            text += ch;
        }
        if (text.Length < 1000) Bad = true;
        Assert.AreEqual(Bad, false);
    }

    [TestMethod] //вероятность в словах
    public void TestMethod5() 
    {
        GeneratorBasedWord gen = new GeneratorBasedWord();
        SortedDictionary<string, int> stat = new SortedDictionary<string, int>(); //создаем словарь
        string text;
        using (StreamReader sr = new StreamReader("WordResult.txt"))
        {
            text = sr.ReadToEnd();
        }
        string[] data = text.Split(' ');
        for (int i = 0; i < data.Length; i++)
        {
            string ch = data[i];
            if (stat.ContainsKey(ch))
                stat[ch]++;
            else
                stat.Add(ch, 1);
        }
        double result = stat["в"];
        double expected = 42;
        Assert.AreEqual(expected, result);
    }

    [TestMethod] //пары слов кол-во символов
    public void TestMethod6()
    {
        GeneratorOnPairsOfWords gen = new GeneratorOnPairsOfWords();
        bool Bad = false;
        string text = "";
        int i = 0;
        while (i < 1000)
        {
            string ch = gen.getSym();//вызываем метод класса генерации
            i += ch.Length;
            text += ch;
        }
        if (text.Length < 1000) Bad = true;
        Assert.AreEqual(Bad, false);
    }

    [TestMethod] //вероятность в парах словах
    public void TestMethod7()
    {
        GeneratorOnPairsOfWords gen = new GeneratorOnPairsOfWords();
        SortedDictionary<string, int> stat = new SortedDictionary<string, int>(); //создаем словарь
        string text;
        using (StreamReader sr = new StreamReader("PairsOfWordsResult.txt"))
        {
            text = sr.ReadToEnd();
        }
        string[] data = text.Split(' ');
        for (int i = 0; i < data.Length-1; i+=2)
        {
            string ch = data[i] + " " + data[i+1];
            if (stat.ContainsKey(ch))
                stat[ch]++;
            else
                stat.Add(ch, 1);
        }
        double result = stat["и в"];
        double expected = 9;
        Assert.AreEqual(expected, result);
    }
}
