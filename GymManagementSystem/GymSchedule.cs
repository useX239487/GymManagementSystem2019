using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymSchedule
    {
        private int gymScheduleId;
        private int gymExercisePlanId;

        public GymSchedule(int trainerId, int exercisePlanId, DateTime startDateTime, string duration)
        {
            TimeSpan planDuration;

            try
            {
                planDuration = new TimeSpan(Int32.Parse(duration.Substring(0, 2)),
                    Int32.Parse(duration.Substring(3, 2)), Int32.Parse(duration.Substring(6, 2)));
            }
            catch (Exception ex)
            {
                throw new Exception($"Inavlid start time.\n\n{ex.Message}");
            }

            if (startDateTime + planDuration < DateTime.Now)
            {
                throw new Exception($"Cannot schedule {(startDateTime + planDuration).ToString()} " +
                    $"because this date/time is in the past.");
            }

            GymScheduleTableAdapter scheduleTableAdapter = new GymScheduleTableAdapter();
            scheduleTableAdapter.Insert(trainerId, exercisePlanId, startDateTime, planDuration);
        }

        
    }
}
