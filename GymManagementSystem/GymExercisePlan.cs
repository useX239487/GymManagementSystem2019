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

        public GymExercisePlan(string planDescription)
        {
            GymExercisePlanDescription = planDescription;


        }

        public string GymExercisePlanDescription
        {
            get { return gymExercisePlanDescription; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a description to be blank. 
                    throw new Exception("Customer first name cannot be blank.");
                else if (value.Trim().Length > 500)
                    throw new Exception("Customer first name cannot be more than 500 characters.");
                else
                    gymExercisePlanDescription = value.Trim();
            }
        }
    }
}
