using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Application controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Application user.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// New user creating.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName,DateTime birthDay, double weight, double height )
        {
            //if (user == null)
            //{
            //    throw new ArgumentNullException("User can not be null",nameof(user));
            //}
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
          
        }
        /// <summary>
        /// Save users data.
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Retrieve user data.
        /// </summary>
        /// <returns>Application user.</returns>
        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: What we are going to do if we do not read user ?
            }
        }
    }
}
