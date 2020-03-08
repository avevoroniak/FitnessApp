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
            EatingController eatingController = new EatingController(uc.CurrentUser);
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
            Console.WriteLine("What are you going to do ?");
            Console.WriteLine("E - input food eating");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
              var foods =  EnterEating();
              eatingController.Add(foods.Food, foods.Weight);
              foreach(var food in eatingController.Eating.Foods)
              {
                    Console.WriteLine(food);
              }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Input the name of product: ");
            string foodName =  Console.ReadLine();
            Console.WriteLine("Input the weight of product: ");
            double weight = ParseDouble("weight");
            double calories = ParseDouble("Calories");
            double proteins = ParseDouble("Proteins");
            double fats = ParseDouble("fats");
            double carbohydrates = ParseDouble("carbohydrates");
            /* Calories = calories / 100;
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates 
             */
            return (Food : new Food(foodName, calories, proteins, fats, calories), Weight: weight);
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
                Console.WriteLine($"Write  {name} ");

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
