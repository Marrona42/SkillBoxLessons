using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxHW8PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();
            bool programIsOn = true;

            while (programIsOn)
            {
                Console.WriteLine("Ввод - ввод в базу, Вывод - вывод из базы по номеру, Выход - закрыть программу");

                switch (Console.ReadLine().ToLower())
                {
                    case "ввод":
                        InsertionData(phoneBook);
                        break;

                    case "вывод":
                        OutterData(phoneBook);
                        break;

                    case "выход":
                        programIsOn= false;
                        break;

                    default:
                        Console.WriteLine("Неверный запрос");
                        break;
                }
                Console.Clear();
            }
        }

        static void InsertionData(Dictionary<string,string> phoneBook)
        {
            Console.Clear();
            string number = InsertionText("Номер телефона");

            if (phoneBook.ContainsKey(number))
            {
                Console.WriteLine("Такой номер уже есть в базе");
            }
            else
            {
                string name = InsertionText("ФИО");
                phoneBook.Add(number, name);
                Console.WriteLine("Номер добавлен в базу");
            }
            Console.ReadKey();
        }

        static void OutterData(Dictionary<string, string> phoneBook)
        {
            Console.Clear();
            Console.WriteLine("Введите Номер");
            string request = Console.ReadLine();
            if (phoneBook.ContainsKey(request))
                Console.WriteLine(phoneBook[request]);
            else
                Console.WriteLine("Такого номера нет в базе");
            Console.ReadKey();
        }

        static string InsertionText(string insert)
        {
            Console.WriteLine($"Введиет {insert}");
            string outter = Console.ReadLine();
            return outter;
        }
    }
}
