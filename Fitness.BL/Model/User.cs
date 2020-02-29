using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{/// <summary>
/// User
/// </summary>
   [Serializable]
   public class User
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Date of Birthday.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthDate"> Date of Birthday. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight,
                    double height)
        {
            #region checking the conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be null or empty.", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Gender can not be null or empty.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birthday.");
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight can not be less or equal than zero.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException("Height can not be less or equal than zero.", nameof(height));

            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be null or empty.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}  {Age}";
        }
    }
}
