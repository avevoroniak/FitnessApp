using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
       

        [TestMethod()]
        public void SaveTest()
        {
           // Assert.Fail();
            // Arrenge
            string userName = Guid.NewGuid().ToString();

            // Act
            UserController controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
           
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {

            // Arrenge
            string userName = Guid.NewGuid().ToString();
            string genderName = "Male";
            DateTime birthday = DateTime.Now.AddYears(-18);
            double weight = 90;
            double height = 200;
            
            // Act
            UserController controller = new UserController(userName);
            controller.SetNewUserData(genderName, birthday, weight, height);
            UserController controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(genderName, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthday, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);

        }
    }
}