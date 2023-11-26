using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_631_IntroFiles
{
    class Program
    {

        static void Anket()
        {
            Console.Clear();
            Console.WriteLine("Заполните Анкету");
            int numberLine = 0;
            foreach (string line in File.ReadAllLines(@"DataBank.txt"))
            {
                numberLine++;
            }

            using (StreamWriter bank = new StreamWriter("DataBank.txt", true, Encoding.Unicode))
            {
                char key = 'д';

                do
                {
                    string note = string.Empty;
                    numberLine++;
                    //ID
                    //Цикл подсчета строк в файла, добавление к значение 1 и внесение в файл
                    note += $"{numberLine}" + '#';

                    //Дату и время добавления записи
                    string now = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
                    note += $"{now}" + '#';

                    //Ф.И.О.
                    Console.WriteLine("Введите ФИО:");
                    note += $"{Console.ReadLine()}" + '#';

                    //Рост
                    Console.WriteLine("Введите Рост:");
                    note += $"{Console.ReadLine()}" + '#';

                    //Дату рождения
                        DateTime dob; // date of birth
                        string input;
                        do
                        {
                            Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                            input = Console.ReadLine();
                        }
                        while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));
                    note += $"{dob}" + '#';

                    //Возраст
                    DateTime nowx = new DateTime();
                    nowx = DateTime.Today;
                    TimeSpan cute = nowx.Subtract(dob);     
                    int abc = Convert.ToInt32(cute.TotalDays);
                    abc = abc / 365;
                    note += $"{abc}" + '#';

                    //Место рождения
                    Console.WriteLine("Введите место рождения:");
                    note += $"{Console.ReadLine()}" + '#';

                    Console.Write("Продолжить н/д");

                    bank.WriteLine(note);

                    key = Console.ReadKey(true).KeyChar;

                    bank.Flush();
                    Console.Clear();

                } while (char.ToLower(key) == 'д');
                System.Environment.Exit(0);

            }
        }

        static void Outter()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader("DataBank.txt", Encoding.Unicode))
            {
                string line;
               
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dope = line.Split('#');
                    Console.WriteLine($"№{dope[0]} " +
                        $"Дата:{dope[1]} " +
                        $"ФИО:{dope[2]} " +
                        $"Рост:{dope[3]} " +
                        $"Д.Рождения:{dope[4]} " +
                        $"Возраст:{dope[5]} " +
                        $"Место Рождения:{dope[6]} ");
                }
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            DateTime data = new DateTime();                             //Обозначаем переменную Дата
            data = DateTime.Now;                                        //Присваиваем ей значение текущей даты
            Console.WriteLine("Дата на текущий момент:" + data);        //Тест Даты;

            using (StreamWriter bank = new StreamWriter("DataBank.txt", true, Encoding.Unicode))
            {
                Console.WriteLine("Проверка целостости файла");
                Console.WriteLine("Файл в порядке");
                System.Threading.Thread.Sleep(1000);
                bank.Flush();
                Console.Clear();
            }
            Console.WriteLine("Вы хотите Внести данные или Вывести?");
            Console.WriteLine("1 - Ввод, 2 - Вывод, 3 - Выход");

            for (int i = 0; i < 1000; i++)
            {
                int argument = Convert.ToInt32(Console.ReadLine());
                                
                switch (argument)
                {
                    case 1: Anket(); break;
                        case 2: Outter(); break;
                    case 3: System.Environment.Exit(0); break;
                        default:
                        {
                            Console.Clear();
                            Console.WriteLine("НЕПРАВИЛЬНЫЙ ВВОД! 1 - Ввод, 2 - Вывод, 3 - Выход");
                            break;
                        }

                }
                
            }

        }
    }
}