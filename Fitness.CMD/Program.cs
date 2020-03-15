using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultreInfo = CultureInfo.CreateSpecificCulture("en-us");
            ResourceManager resourseManager = new ResourceManager("Fitness.CMD.Languages.Messeges",typeof(Program).Assembly);
            Console.WriteLine(resourseManager.GetString("Hello"),cultreInfo);
            Console.WriteLine(resourseManager.GetString("EnterName"),cultreInfo);
            var name = Console.ReadLine();
            UserController uc = new UserController(name);
            EatingController eatingController = new EatingController(uc.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(uc.CurrentUser);
            if (uc.IsNewUser)
            {
                Console.WriteLine("Write gender ");
                string gender = Console.ReadLine();
                DateTime birthDate;
                birthDate = ParseDate("dd.mm.yyy");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");
                uc.SetNewUserData(gender, birthDate, weight, height);


            }
            Console.WriteLine(uc.CurrentUser.ToString());
            Console.WriteLine("What are you going to do ?");
            Console.WriteLine("E - input food eating");
            Console.WriteLine("R - input add some activity");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);
                    foreach (var food in eatingController.Eating.Foods)
                    {
                        Console.WriteLine(food);
                    }
                    break;
                case ConsoleKey.R:
                    var activity = EnterActivity();
                    exerciseController.Add(activity.activity, activity.start, activity.finish);
                    foreach(var exercise in exerciseController.Exercises)
                    {
                        Console.WriteLine(exercise.ToString());
                    }
                    break;
                default:
                    break;
            }
         
        }

        private static (Activity activity, DateTime start, DateTime finish) EnterActivity()
        {
            Console.WriteLine("Input the name of activity: ");
            string activityName = Console.ReadLine();
            Console.WriteLine("Input Calories per minute: ");
            double caloriesPerMinute = ParseDouble("Calories per minute");
            Console.WriteLine("Input exercise starts time: ");
            DateTime dateBegin = ParseDate("dd/mm/yyyy hh:mm:ss");
            Console.WriteLine("Input exercise ends time: ");
            DateTime dateEnd = ParseDate("dd/mm/yyyy hh:mm:ss");
            return (activity: new Activity(activityName, caloriesPerMinute),start : dateBegin, finish: dateEnd);


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

        private static DateTime ParseDate(string dateType)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Write  ({dateType}) ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect date");
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
                    Console.WriteLine($"Incorrect {name}");
                }
            }
        }
    }
}
