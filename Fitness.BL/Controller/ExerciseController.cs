using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
   public class ExerciseController : ControllerBase
    {
        private readonly User user;
        private const string EXERCISE_FILE_NAME = "exercises.dat";
        private const string ACTIVITYES_FILE_NAME = "activities.dat";
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }


        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercise();
            Activities = GetAllActivitie();
        }

        private List<Activity> GetAllActivitie()
        {
            return Load<List<Activity>>(ACTIVITYES_FILE_NAME, Activities) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            Activity act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                Exercises.Add(new Exercise(start, finish, activity, user));
                
            }
            else
            {
                Exercises.Add(new Exercise(start, finish, act, user));
            }
            Save();
        }
        private List<Exercise> GetAllExercise()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NAME, Exercises) ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
            Save(ACTIVITYES_FILE_NAME, Activities);
        }
    }
}
