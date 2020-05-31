using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ClientInfo
    {
        public HardwareInfo HardwareInfo { get; set; }
        // campus-floor-room-computerNum-additionalInformation
        // example 1-4-13-8-forDisabledPeople
        public string ClientName { get; set; }
        public int Campus { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        /*public ClientInfo(string clientName, int campus, int floor, int room)
        {
            hardwareInfo = new HardwareInfo();
            this.clientName = clientName;
            this.campus = campus;
            this.floor = floor;
            this.room = room;
        }
        public ClientInfo(HardwareInfo hardwareInfo, string clientName, int campus, int floor, int room)
        {
            this.hardwareInfo = hardwareInfo;
            this.clientName = clientName;
            this.campus = campus;
            this.floor = floor;
            this.room = room;
        }*/
        public void InitialiseAll(string clientName, int campus, int floor, int room)
        {
            HardwareInfo = new HardwareInfo();
            HardwareInfo.InitialiseAll();
            this.ClientName = clientName;
            this.Campus = campus;
            this.Floor = floor;
            this.Room = room;
        }
        public override string ToString()
        {
            return "Hardware Info: {\n" + HardwareInfo.ToString() + "}\n" 
                + "ClientName:\t" + ClientName + '\n'
                + "Campus:\t" + Campus + '\n'
                + "Floor:\t " + Floor + '\n'
                + "Room:\t" + Room + '\n';
        }
    }
}
