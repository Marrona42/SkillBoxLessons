using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Генератор Массива");

        Console.WriteLine("Введите ширину Массива");
        int x = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите высоту Массива");
        int y = int.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("МАССИВ 1\n");

        int[,] matrix = new int[x, y];  //создаем матрицу
        int sum = 0;
        Random r = new Random();

        for (int a = 0; a < x; a++)
        {
            for (int b = 0; b < y; b++)
            {
                matrix[a, b] = r.Next(-9, 10);
                Console.Write($"{matrix[a, b]} ");
                sum = sum + matrix[a, b];
            }
            Console.WriteLine();
        }
        Console.Write("Сумма элементов массива равна: " + sum + "\n");
        Console.ReadKey();
    }
}