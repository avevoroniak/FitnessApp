using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories per 100 grams of product 
        /// </summary>
        public double Calories { get; }
        public Food(string name):this(name, 0, 0, 0, 0) { }
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100;
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
            // TODO : check input parameters

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
