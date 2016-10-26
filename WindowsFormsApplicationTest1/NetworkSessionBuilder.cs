using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlantWatererMonitor
{
    class NetworkSessionBuilder
    {
        IPAddress ipAddress;
        int portNo;

        public NetworkSessionBuilder setAddress(IPAddress ipAddress)
        {
            this.ipAddress = ipAddress;
            return this;
        }

        public NetworkSessionBuilder setPortNo(int portNo)
        {
            this.portNo = portNo;
            return this;
        }
    
        public NetworkSession build()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(address);
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            var ipEndPoint = new IPEndPoint(ipAddress, portNo);

            return new NetworkSession(socket, ipEndPoint);
        }
    }
}
