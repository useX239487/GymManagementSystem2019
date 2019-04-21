using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymEquipment
    {
        // Private data
        private int gymEquipmentId;
        private int gymRoomId;
        private string gymEquipmentDescription;

        public GymEquipment(string equipmentDescription, int roomId)
        {
            GymEquipmentDescription = equipmentDescription;

            GymEquipmentTableAdapter equipmentTableAdapter = new GymEquipmentTableAdapter();
            equipmentTableAdapter.Insert(GymEquipmentDescription, roomId);
        }

        // Public properties

        public string GymEquipmentDescription
        {
            get { return gymEquipmentDescription; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a description to be blank. 
                    throw new Exception("Equipment description cannot be blank.");
                else if (value.Trim().Length > 500)
                    throw new Exception("Equipment description cannot be more than 500 characters.");
                else
                    gymEquipmentDescription = value.Trim();
            }
        }

    }
}
