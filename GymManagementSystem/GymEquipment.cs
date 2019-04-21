using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    class GymEquipment
    {
        private int gymEquipmentId;
        private int gymRoomId;
        private string gymEquipmentDescription;

        public GymEquipment(int equipmentId, int roomId, string equipmentDescription)
        {
            GymEquipmentId = equipmentId;
            GymRoomId = roomId;
            GymEquipmentDescription = equipmentDescription;
        }

        // Public properties
        public int GymEquipmentId
        {
            get { return gymEquipmentId; }
            set
            {
                gymEquipmentId = value;
            }
        }

        public int GymRoomId
        {
            get { return gymRoomId; }
            set
            {
                gymRoomId = value;
            }
        }

        public string GymEquipmentDescription
        {
            get { return gymEquipmentDescription; }
            set
            {
                if (value.Trim().Length > 0)
                    gymEquipmentDescription = value;
                else
                    throw new Exception("Equipment description cannot be blank.");
            }
        }

    }
}
