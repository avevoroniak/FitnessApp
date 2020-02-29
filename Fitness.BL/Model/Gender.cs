using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    ///  Gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Gender name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="name">gender name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender name can not be null or empty");
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

}
