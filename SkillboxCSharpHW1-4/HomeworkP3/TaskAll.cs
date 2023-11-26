using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
        //Главное Меню
        #region MainMenu
        Repeat: //ЯКОРЬ для перемещения в главное меню
            Console.Clear(); //Для красоты очистки меню
            Console.WriteLine(@"На ваш выбор представляет 5 программ. Выберету одну из них
            Цифра 1 - Определение чет/нечет
            Цифра 2 - Игра ДВАДЦАТЬ ОДНО!
            Цифра 3 - Проверка простого числа
            Цифра 4 - Наименьший элемент в последовательности
            Цифра 5 - Игра «Угадай число»
            Цифра 6 - Выход"); //Для красотые выводится с помощью 
            int numberProgram = int.Parse(Console.ReadLine()); //Объявление новой переменной для будущего выбора одной из программ
            if (numberProgram == 1) //Цикл, позволяющий выбрать одну из программ или ругающая за неверный выбор
            {
                Console.Clear();
                goto chetNechet; //перенаправляет в блок определения четного нечетного числа
            }
            else if (numberProgram == 2)
            {
                Console.Clear();
                goto twentyOne; //отправляет в блок игра 21
            }
            else if (numberProgram == 3)
            {
                Console.Clear();
                goto prostoe; //отправляет в блок проверка простого числа
            }
            else if (numberProgram == 4)
            {
                Console.Clear();
                goto naimensh; //отправляет в блок Наименьший элемент в последовательности
            }
            else if (numberProgram == 5)
            {
                Console.Clear();
                goto ugadai; //отправляет в блок игры Угадай число
            }
            else if (numberProgram == 6)
            {
                Console.Clear();
                goto konec; //Отправляет в конец для вывода финального сообщения и окончания всей программы
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Не умеешь считать до 6? Повтори!");
                Console.ReadKey();
                goto Repeat; //Возвращает в меню
            }
        #endregion
        //Главное Меню

        //ЧетНечет
        #region ЧетНечет
        chetNechet: //ЯКОРЬ
            Console.WriteLine("Определите четность числа! Введите целое число:");
            int evenOdd = int.Parse(Console.ReadLine()); //Ввод строки и конвертация её в значения типа Интежер
            if (evenOdd%2 == 0) //Цикл, позволяющий определеить есть ли остаток от деления
            {
                Console.WriteLine($"Число {evenOdd} четное");
            }
            else
            {
                Console.WriteLine($"Число {evenOdd} нечетное");
            }


            //Интерактив с возвратом в меню или выходом
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nЕсли хотите попробовать другую программу, введите Yes");
            Console.WriteLine("\nЕсли хотите повторить, введите Repeat");
            Console.WriteLine("\nДля выхода введите любое значение или нажмите любую кнопку");
            string repCN = Console.ReadLine();
            if (repCN == "Yes") //Цикл позволяет определить, хотите ли вы продолжить или направляет в конец программы
            {
                Console.Clear();
                goto Repeat;
            }
            else if (repCN == "Repeat")
            {
                Console.Clear();
                goto chetNechet;
            }
            else
            {
                Console.Clear();
                goto konec;
            }
        #endregion
        //ЧетНечет

        //Двадцать одно
        #region Двадцать Одно
        twentyOne: //ЯКОРЬ

            Console.WriteLine("Вас приветствует 21! Введите количество карт на руке:");
            int cardInHand = int.Parse(Console.ReadLine()); // количетсво карт в руке
            Console.Clear();

            Console.WriteLine(@"Введите ваши карты!
Это могут быть карты от 2 до 10
или J - Валет, Q - дамма, K - король, T - туз");
            int hCV = 0; //рука Номинал карт
            for (int i = 1; i <= cardInHand; i++)
            {
                int motion = cardInHand - i + 1;
                Console.WriteLine("Осталось ввести карт: " + motion);
                string cardValue = Console.ReadLine();
                switch (cardValue) //Цикл сверяет каждое введеное значение с мастями карт и присваивает определенное цифровое значение
                {
                    case "2": hCV += 2; break;
                    case "3": hCV += 3; break;
                    case "4": hCV += 4; break;
                    case "5": hCV += 5; break;
                    case "6": hCV += 6; break;
                    case "7": hCV += 7; break;
                    case "8": hCV += 8; break;
                    case "9": hCV += 9; break;
                    case "10": hCV += 10; break;
                    case "J": hCV += 10; break;
                    case "Q": hCV += 10; break;
                    case "K": hCV += 10; break;
                    case "T": hCV += 10; break;
                    default:
                        {
                            Console.WriteLine("Введено неверное значение, попрубуйте еще раз");
                            i--;
                            break;
                        }
                }
            }
            Console.Clear();
            Console.WriteLine("Сумма карт:" + hCV);

            //Интерактив с возвратом в меню или выходом
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nЕсли хотите попробовать другую программу, введите Yes");
            Console.WriteLine("\nЕсли хотите повторить, введите Repeat");
            Console.WriteLine("\nДля выхода введите любое значение или нажмите любую кнопку");
            string repTO = Console.ReadLine();
            if (repTO == "Yes") 
            {
                Console.Clear();
                goto Repeat;
            }
            else if(repTO == "Repeat")
            {
                Console.Clear();
                goto twentyOne;
            }
            else
            {
                Console.Clear();
                goto konec;
            }
        #endregion
        //Двадцать Одно

        //Простое число
        #region Простое Число
        prostoe: //ЯКОРЬ

            Console.WriteLine("Введите число, чтобы опредилить, простое ли оно!");
            bool prostoe = true;
            int countProst = int.Parse(Console.ReadLine());
            int stepProst = 2;

            while (stepProst <= countProst / 2)
            {
                if (countProst % stepProst == 0)
                {
                    prostoe = false;
                    break;
                }
                stepProst++;
            }

            if (prostoe)
                {
                    Console.WriteLine($"Число {countProst} простое");
                }
            else
                {
                    Console.WriteLine($"Число {countProst} не простое");
                }

            //Интерактив с возвратом в меню или выходом
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nЕсли хотите попробовать другую программу, введите Yes");
            Console.WriteLine("\nЕсли хотите повторить, введите Repeat");
            Console.WriteLine("\nДля выхода введите любое значение или нажмите любую кнопку");
            string repPC = Console.ReadLine();
            if (repPC == "Yes")
        {
            Console.Clear();
            goto Repeat;
        }
            else if(repPC == "Repeat")
            {
                Console.Clear();
                goto prostoe;
            }
            else
        {
            Console.Clear();
            goto konec;
        }
        #endregion
        //Простое число

        //Наименьший элемент в последовательности
        #region Наименьший элемент в последовательности
        naimensh: //ЯКОРЬ
            Console.WriteLine("Вас приветствует программа по определению наименьшего элемента в последовательности");
            Console.WriteLine("Введите длинну последовательности: ");
            int countSequence = int.Parse(Console.ReadLine()); // длинна последовательности
            Console.WriteLine("Введите элементы последовательности:");
            int firstCount = int.Parse(Console.ReadLine());
            int newSequnce = countSequence - 1;
            while (newSequnce != 0)
            {
                int newCount = int.Parse(Console.ReadLine());
                if (newCount < firstCount)
                    firstCount = newCount;
                newSequnce--;
            } 

            Console.WriteLine("Наименьшее число последовательности: " + firstCount);

            //Интерактив с возвратом в меню или выходом
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nЕсли хотите попробовать другую программу, введите Yes");
            Console.WriteLine("\nЕсли хотите повторить, введите Repeat");
            Console.WriteLine("\nДля выхода введите любое значение или нажмите любую кнопку");
            string repNEP = Console.ReadLine();
            if (repNEP == "Yes")
            {
                Console.Clear();
                goto Repeat;
            }
            else if (repNEP == "Repeat")
            {
                Console.Clear();
                goto naimensh;
            }
            else
            {
                Console.Clear();
                goto konec;
            }
        #endregion
        //Наименьший элемент в последовательности

        //Угадай число
        #region Игра «Угадай число»
        ugadai: //ЯКОРЬ!!!

            Console.WriteLine(@"Вас приветствует игра УГАДАЙ ЧИСЛО!!
Правила просты. Компьютер загадывает число,
а вы должны его угадать!
Введите максимальное значение для отгадывания:");
               
            Random rand = new Random();
            int userMaxNumber = Convert.ToInt32(Console.ReadLine());
            int randomBool = rand.Next(1, userMaxNumber + 1);
            int numberCount = 0;
            int userNumber;
            while (true)
            {
                Console.Write("\nВведите число: ");
                numberCount++;
                userNumber = Convert.ToInt32(Console.ReadLine());
                if (userNumber < randomBool)
                {
                    Console.WriteLine("Введенное число меньше загаданного");
                }
                else if (userNumber > randomBool)
                {
                    Console.WriteLine("Введенное число больше загаданного");
                }
                else
                {
                    Console.WriteLine($"Вы угадали число!");
                    Console.WriteLine($"Это было: {randomBool}");
                    Console.WriteLine($"Число попыток: {numberCount}");
                    break;
                }
            }

            //Интерактив с возвратом в менюили выходом
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nЕсли хотите попробовать другую программу, введите Yes");
            Console.WriteLine("\nЕсли хотите повторить, введите Repeat");
            Console.WriteLine("\nДля выхода введите любое значение или нажмите любую кнопку");
            string repUC = Console.ReadLine();
            if (repUC == "Yes")
            {
                Console.Clear();
                goto Repeat;
            }
            else if (repUC == "Repeat")
            {
                Console.Clear();
                goto ugadai;
            }
            else
            {
                Console.Clear();
                goto konec;
            }
        #endregion
        //Угадай число

        //Концовка
        #region Конец
        konec:
            Console.WriteLine("До встречи!");
            Console.ReadKey();
            #endregion
        //Концовка
        }
    }
}