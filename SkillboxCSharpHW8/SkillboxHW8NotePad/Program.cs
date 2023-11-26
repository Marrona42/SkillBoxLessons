using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillboxHW8NotePad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programWork = true;
            while (programWork)
            {
                Console.Write("Ввод для продолжения, Выход - закрыть программу: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "ввод":
                        Insertion();
                        break;
                    case "выход":
                        programWork = false;
                        break;
                    default:
                        Console.WriteLine("Непрвильный ввод");
                        break;
                }
            }
        }

        static void Insertion()
        {
            Console.Write("Введите Имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите Улицу: ");
            string street = Console.ReadLine();
            Console.Write("Введите номер дома: ");
            string houseNumber = Console.ReadLine();
            Console.Write("Введите номер квартиры: ");
            string flatNumber = Console.ReadLine();
            Console.Write("Введите номер сотового: ");
            string mobilePhone = Console.ReadLine();
            Console.Write("Введите домашний номер: ");
            string flatPhone = Console.ReadLine();

            XElement myName = new XElement("Person");

            XElement myADRESS = new XElement("ADRESS");
            XElement myPHONES = new XElement("PHONES");

            XElement mySTREET = new XElement("STREET");
            XElement myHOUSENUMBER = new XElement("HOUSENUMBER");
            XElement myFLATNUMBER = new XElement("FLATNUMBER");
            XElement myMOBILEPHONE = new XElement("MOBILEPHONE");
            XElement myFLATPHONE = new XElement("FLATPHONE");

            XAttribute xAttributeStreet = new XAttribute("Street", street);
            XAttribute xAttributeHouseNumber = new XAttribute("HouseNumbers", houseNumber);
            XAttribute xAttributeFlatNumber = new XAttribute("FlatNumbers", flatNumber);
            XAttribute xAttributeMobilePhone = new XAttribute("MobilePhone", mobilePhone);
            XAttribute xAttributeFlatPhone = new XAttribute("FlatPhone", flatPhone);

            mySTREET.Add(xAttributeStreet);
            myHOUSENUMBER.Add(xAttributeHouseNumber);
            myFLATNUMBER.Add(xAttributeFlatNumber);
            myMOBILEPHONE.Add(xAttributeMobilePhone);
            myFLATPHONE.Add(xAttributeFlatPhone);

            myADRESS.Add(mySTREET, myHOUSENUMBER, myFLATNUMBER);
            myPHONES.Add(myMOBILEPHONE, myFLATPHONE);

            XAttribute xAttributeName = new XAttribute("имя", name);
            myName.Add(myADRESS, myPHONES, xAttributeName);

            myName.Save($"_person {name} {street} {houseNumber} {flatNumber}.xml");
            Console.WriteLine("Пользователь сохранен");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
