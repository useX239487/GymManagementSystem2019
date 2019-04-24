using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymExercisePlan
    {
        private int gymExercisePlanId;
        private int gymTrainerId;
        private int gymCustomerId;
        private string gymExercisePlanDescription;

        public GymExercisePlan(string planDescription, string planDuration, int trainerId, int customerId)
        {
            GymExercisePlanDescription = planDescription;

            GymExercisePlanTableAdapter exercisePlanTableAdapter = new GymExercisePlanTableAdapter();
            exercisePlanTableAdapter.Insert(GymExercisePlanDescription, 
                ConvertDurationStringToTimespan(planDuration), trainerId, customerId);
        }

        public string GymExercisePlanDescription
        {
            get { return gymExercisePlanDescription; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a description to be blank. 
                    throw new Exception("Exercise plan cannot be blank.");
                else if (value.Trim().Length > 500)
                    throw new Exception("Exercise plan cannot be more than 500 characters.");
                else
                    gymExercisePlanDescription = value.Trim();
            }
        }

        private TimeSpan ConvertDurationStringToTimespan(string duration)
        {
            TimeSpan planDuration;

            if (duration == "30 Minutes")
                planDuration = new TimeSpan(0, 30, 0);
            else if (duration == "60 Minutes")
                planDuration = new TimeSpan(1, 0, 0);
            else if (duration == "90 Minutes")
                planDuration = new TimeSpan(1, 30, 0);
            else if (duration == "120 Minutes")
                planDuration = new TimeSpan(2, 0, 0);
            else
                throw new Exception($"Invalid duration selected.");

            return planDuration;
        }
    }
}
