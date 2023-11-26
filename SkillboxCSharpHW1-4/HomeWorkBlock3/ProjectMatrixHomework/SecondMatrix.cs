using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        #region Массив 1
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
            for(int b = 0; b < y; b++)
            {
                matrix[a, b] = r.Next(-9, 10);
                Console.Write($"{matrix[a, b]} ");
                sum = sum + matrix[a, b];
            }
            Console.WriteLine();
        }
        Console.Write("Сумма элементов массива равна: " + sum + "\n");
        Console.ReadKey();
        
        #endregion
       

        #region Массив 2
        Console.WriteLine("\nМАССИВ 2\n");

        int[,] neo = new int[x, y];  //создаем матрицу
        int newSum = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                neo[i, j] = r.Next(-9, 10);
                Console.Write($"{neo[i, j]} ");
                newSum = newSum + neo[i, j];
            }
            Console.WriteLine();
        }
        Console.Write("Сумма элементов массива равна: " + newSum + "\n");
        Console.ReadKey();
        #endregion

        #region Сложение массивов

        Console.WriteLine("\nСумма двух массивов\n");

        int[,] trinity = new int[x, y];
        int doubleSum = 0;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                trinity[i, j] = neo[i, j] + matrix[i, j];
                Console.Write($"{trinity[i, j]} ");
                doubleSum = doubleSum + trinity[i, j];
            }
            Console.WriteLine();
        }
        Console.WriteLine("Сумма элементов двойного массива равна: " + doubleSum);
        Console.ReadKey();

        #endregion
    }
}