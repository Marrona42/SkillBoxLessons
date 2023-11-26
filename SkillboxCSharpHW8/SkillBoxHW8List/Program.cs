using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SkillBoxHW8List
{
    internal class Program
    {
        static void Main()
        {
            var list = CreateList();
            Console.WriteLine("Лист состоящий из случайных чисел: ");
            ReadList(list);
            RemoveFromList(list);
            Console.WriteLine("Лист состоящий из отобранных чисел: ");
            ReadList(list);
        }

        static List<int> CreateList()
        {
            List<int> list = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                list.Add(rnd.Next(0, 101));
            }
            return list;
        }

        static void ReadList(List<int> list)
        {
            Console.WriteLine("Количество элементов Листа: " + list.Count);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static List<int> RemoveFromList(List<int> list)
        {
            list.RemoveAll(item => !(item < 25 || item > 50));
            Console.WriteLine();
            return list;
        }
    }
}
