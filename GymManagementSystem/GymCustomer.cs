using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymCustomer
    {
        private int gymCustomerId;
        private string gymCustomerFirstName;
        private string gymCustomerLastName;

        public GymCustomer(string firstName, string lastName, int trainerId)
        {
            GymCustomerFirstName = firstName;
            GymCustomerLastName = lastName;

            GymCustomerTableAdapter customerTableAdapter = new GymCustomerTableAdapter();
            customerTableAdapter.Insert(GymCustomerFirstName, GymCustomerLastName, trainerId);
        }

        public string GymCustomerFirstName
        {
            get { return gymCustomerFirstName; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a name to be blank. 
                    throw new Exception("Customer first name cannot be blank.");
                else if (value.Trim().Length > 50)
                    throw new Exception("Customer first name cannot be more than 50 characters.");
                else
                    gymCustomerFirstName = value.Trim();
            }
        }
        public string GymCustomerLastName
        {
            get { return gymCustomerLastName; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a name to be blank. 
                    throw new Exception("Customer first name cannot be blank.");
                else if (value.Trim().Length > 50)
                    throw new Exception("Customer first name cannot be more than 50 characters.");
                else
                    gymCustomerLastName = value.Trim();
            }
        }
    }
}
