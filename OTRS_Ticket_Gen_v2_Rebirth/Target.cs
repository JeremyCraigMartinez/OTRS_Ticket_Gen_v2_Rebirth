using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    public class Target
    {
        #region Variables

        private string IP;
        private string MAC;
        private string User;
        private string Switch;
        private string Jack;
        private string Information_Source;
        private string Message;
        private string Count;
        private string DHCPD;
        private string DHCPC;
        private string Location;
        private string Room;
        private string Resident;
        private bool deleted;
        private bool send;
        private int index;

        #endregion

        public bool _SEND
        {
            get { return send; }
            set { send = value; }
        }
        public bool _DELETE
        {
            get
            {
                return deleted;
            }
            set
            {
                deleted = value;
            }
        }
        public int _INDEX
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
        public string _IP
        {
            get
            {
                return IP;
            }
            set
            {
                IP = value;
            }
        }
        public string _MAC
        {
            get
            {
                return MAC;
            }
            set
            {
                MAC = value;
            }
        }
        public string _userName
        {
            get
            {
                return User;
            }
            set
            {
                User = value;
            }
        }
        public string _SWITCH
        {
            get
            {
                return Switch;
            }
            set
            {
                Switch = value;
            }
        }
        public string _JACK
        {
            get
            {
                return Jack;
            }
            set
            {
                Jack = value;
            }
        }
        public string _SOURCE
        {
            get
            {
                return Information_Source;
            }
            set
            {
                Information_Source = value;
            }
        }
        public string _MESSAGE
        {
            get
            {
                return Message;
            }
            set
            {
                Message = value;
            }
        }
        public string _COUNT
        {
            get
            {
                return Count;
            }
            set
            {
                Count = value;
            }
        }
        public string _DHCPD
        {
            get
            {
                return DHCPD;
            }
            set
            {
                DHCPD = value;
            }
        }
        public string _DHCPC
        {
            get
            {
                return DHCPC;
            }
            set
            {
                DHCPC = value;
            }
        }
        public string _LOCATION
        {
            get
            {
                return Location;
            }
            set
            {
                Location = value;
            }
        }
        public string _ROOM
        {
            get
            {
                return Room;
            }
            set
            {
                Room = value;
            }
        }
        public string _RESIDENT
        {
            get
            {
                return Resident;
            }
            set
            {
                Resident = value;
            }
        }

        public string Meta()
        {
            string output = "";
            output = String.Format("IP:\t\t\t{0}\nMAC:\t\t\t{1}\nUser:\t\t\t{2}\nSwitch:\t\t\t{3}\nJack:\t\t\t{4}\nInformation Source:\t{5}\nMessage:\t\t{6}\nCount:\t\t\t{7}\nLocation:\t\t\t{8}\nRoom:\t\t\t{9}\nResident:\t\t{10}\nDHCP Department:\t{11}\nDHCP Contact:\t\t{12}\n\n",
                IP, MAC, User, Switch, Jack, Information_Source, Message, Count, Location, Room, Resident, DHCPD, DHCPC);
            return output;
        }
        public string emailFormat()
        {
            string output = "";
            if(IP != "")
                output += String.Format("IP:\t\t\t{0}\n", IP);
            if (MAC != "")
                output += String.Format("MAC:\t\t\t{0}\n", MAC);
            if (User != "")
                output += String.Format("User:\t\t\t{0}\n", User);
            if (Switch != "")
                output += String.Format("Switch:\t\t\t{0}\n", Switch);
            if (Jack != "")
                output += String.Format("Jack:\t\t\t{0}\n", Jack);
            if (Information_Source != "")
                output += String.Format("Information Source:\t{0}\n", Information_Source);
            if (Message != "")
                output += String.Format("Message:\t\t{0}\n", Message);
            if (Count != "")
                output += String.Format("Count:\t\t\t{0}\n", Count);
            if (Location != "")
                output += String.Format("Location:\t\t\t{0}\n", Location);
            if (Room != "")
                output += String.Format("Room:\t\t\t{0}\n", Room);
            if (Resident != "")
                output += String.Format("Resident:\t\t{0}\n", Resident);
            if (DHCPD != "")
                output += String.Format("DHCP Department:\t{0}\n", DHCPD);
            if (DHCPC != "")
                output += String.Format("DHCP Contact:\t\t{0}\n\n", DHCPC);
            return output;
        }
        public Target()
        {
            IP = "";
            MAC = "";
            User = "";
            Switch = "";
            Jack = "";
            Information_Source = "";
            Message = "";
            Count = "";
            DHCPD = "";
            DHCPC = "";
            Location = "";
            Room = "";
            Resident = "";
            deleted = false;
            index = 0;
            send = false;
        }
        
        public Target(string ip, string mac, string user, string _switch, string jack, string _is, string message, string count, string dhcpd, string dhcpc, string location, string room, string resident, int Index)
        {
            IP = ip;
            MAC = mac;
            User = user;
            Switch = _switch;
            Jack = jack;
            Information_Source = _is;
            Message = message;
            Count = count;
            DHCPD = dhcpd;
            DHCPC = dhcpc;
            Location = location;
            Room = room;
            Resident = resident;
            deleted = false;
            index = Index;
            send = false;
        }
        
        ~Target()
        {

        }
   }
}
