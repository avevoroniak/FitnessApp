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
            Console.WriteLine("Write gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Write birthDay");
            var birthDay = DateTime.Parse(Console.ReadLine()); // TODO ReWrite
            Console.WriteLine("Write weight");
            var weight = Double.Parse(Console.ReadLine());
            Console.WriteLine("Write height");
            var heigth = Double.Parse(Console.ReadLine());
            UserController uc = new UserController(name,  gender, birthDay, weight, heigth);
            uc.Save();
        }
    }
}
