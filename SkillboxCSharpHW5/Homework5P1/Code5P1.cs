using System;
using System.Threading;

class Homework
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст");
        string firstText = Console.ReadLine();
        string[] splitText;
        Split(firstText, out splitText);
        Print(splitText);
        Console.ReadKey();
    }

    /// <summary>
    /// Разделение текста на отдельные элементы массива
    /// </summary>
    /// <param name="firstText"></param>
    /// <param name="splitText"></param>
    static void Split(string firstText, out string[] splitText)
    {
        splitText = firstText.Split(' ');
    }

    /// <summary>
    /// Вывод каждого элемента массива
    /// </summary>
    /// <param name="splitText"></param>
    static void Print(string[] splitText)
    {
        Console.WriteLine("Массив: ");
        for (int i = 0; i < splitText.Length; i++)
        {
            Console.WriteLine($"Элемент массива {i}: " + splitText[i]);
        }
    }
}