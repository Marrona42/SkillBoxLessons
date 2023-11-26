using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxHW8HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();

            bool programWork = true;

            while (programWork)
            {
                    Console.Write($"Элементs коллекции: ");
                foreach (int i in set)
                {
                    Console.Write($" {i}");
                }
                Console.WriteLine();
                int input = Convert.ToInt32(Console.ReadLine());
                if (set.Contains(input))
                {
                    Console.WriteLine($"Элемент {input} есть в коллекции");
                    Console.ReadKey();
                }
                else
                {
                    set.Add(input);
                    Console.WriteLine($"Элемент {input} добавлен в коллекцию");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}
