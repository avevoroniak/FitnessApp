using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            string userName = Guid.NewGuid().ToString();
            string activityName = Guid.NewGuid().ToString();
            Random random = new Random();
            UserController userController = new UserController(userName);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            Activity activity = new Activity(activityName, random.Next(10,100));
            //Act
            exerciseController.Add(activity, new DateTime(2020, random.Next(1,12),random.Next(1,28),15,0,0), new DateTime(2020, random.Next(1, 12), random.Next(1, 28), 15, random.Next(1, 59), random.Next(1, 59)));
            //Assert
            Assert.AreEqual(activityName, exerciseController.Activities.Last().Name);
        }
    }
}