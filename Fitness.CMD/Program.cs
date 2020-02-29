using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am happy to see you in me application");
            Console.WriteLine("Please, write user name");
            var name = Console.ReadLine();
            UserController uc = new UserController(name);
            if (uc.IsNewUser)
            {
                Console.WriteLine("Write gender ");
                string gender = Console.ReadLine();
                DateTime birthDate;
                birthDate = ParseDate();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");
                uc.SetNewUserData(gender, birthDate, weight, height);


            }
            Console.WriteLine(uc.CurrentUser.ToString());
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Write your  (dd.mm.yyyy) ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Uncorrect date");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Write your {name} ");

                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Uncorrect {name}");
                }
            }
        }
    }
}
