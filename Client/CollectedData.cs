using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class CollectedData
    {
        public ClientInfo ClientInfo { get; set; }
        public DateTime DateTime { get; set; }
        /*public CollectedData(ClientInfo clientInfo)
        {
            this.clientInfo = clientInfo;
            dateTime = DateTime.Now;
        }*/
        public void InitialiseAll(ClientInfo clientInfo)
        {
            ClientInfo = clientInfo;
            DateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return "Client Info: {\n" + ClientInfo.ToString()
                + "Time:\t" + DateTime.ToString();
        }
    }
}
