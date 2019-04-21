using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Odbc;
using System.Data.OleDb;
using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;

namespace GymManagementSystem
{
    class GymRoom
    {
        // Private data
        private int gymRoomId;
        private string gymRoomName;
        private string gymRoomDescription;

        // Constructor
        public GymRoom (string roomName, string roomDescription)
        {
            GymRoomName = roomName;
            GymRoomDescription = roomDescription;

            GymRoomTableAdapter roomTableAdapter = new GymRoomTableAdapter();
            roomTableAdapter.Insert(GymRoomName, GymRoomDescription);
        }

        // Public properties
        public int GymRoomId { get { return gymRoomId; }  } // Never set Id, this is auto-assigned by the database. 

        public string GymRoomName
        {
            get { return gymRoomName; }
            set
            {
                if (value.Trim().Length == 0) // Don't allow a name to be blank. 
                    throw new Exception("Room name cannot be blank.");
                else if (value.Trim().Length > 100)
                    throw new Exception("Room name cannot be more than 100 characters.");
                else
                    gymRoomName = value.Trim();
            }
        }

        public string GymRoomDescription
        {
            get { return gymRoomDescription; }
            set
            {
                if (value.Trim().Length > 500)
                    throw new Exception("Room description cannot be more than 500 characters.");
                else
                    gymRoomDescription = value.Trim();
            }
        }
    }
}
