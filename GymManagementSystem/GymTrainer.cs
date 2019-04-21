using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymTrainer
    {
        private int gymTrainerId;
        private string gymTrainerFirstName;
        private string gymTrainerLastName;
        private string gymTrainerStartTime;
        private int gymRoomId;
        private readonly int gymTrainerMaxHours = 8;



        public GymTrainer(string firstName, string lastName, string startTime, int roomId)
        {
            GymTrainerFirstName = firstName;
            GymTrainerLastName = lastName;

            TimeSpan trainerStartTime;

            try
            {
                trainerStartTime = new TimeSpan(Int32.Parse(startTime.Substring(0, 2)),
                Int32.Parse(startTime.Substring(3, 2)), Int32.Parse(startTime.Substring(6, 2)));
            }
            catch (Exception ex)
            {
                throw new Exception($"Inavlid start time.\n\n{ex.Message}");
            }
            
            GymTrainerTableAdapter trainerTableAdapter = new GymTrainerTableAdapter();
            trainerTableAdapter.Insert(GymTrainerFirstName, GymTrainerLastName, trainerStartTime, roomId);
        }

        public string GymTrainerFirstName
        {
            get { return gymTrainerFirstName; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a name to be blank. 
                    throw new Exception("Trainer first name cannot be blank.");
                else if (value.Trim().Length > 50)
                    throw new Exception("Trainer first name cannot be more than 50 characters.");
                else
                    gymTrainerFirstName = value.Trim();
            }
        }
        public string GymTrainerLastName
        {
            get { return gymTrainerLastName; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a name to be blank. 
                    throw new Exception("Trainer last name cannot be blank.");
                else if (value.Trim().Length > 50)
                    throw new Exception("Trainer last name cannot be more than 50 characters.");
                else
                    gymTrainerLastName = value.Trim();
            }
        }
        public string GymTrainerStartTime
        {
            get { return gymTrainerStartTime; }
            set
            {
                gymTrainerStartTime = value;
            }
        }

    }
}
