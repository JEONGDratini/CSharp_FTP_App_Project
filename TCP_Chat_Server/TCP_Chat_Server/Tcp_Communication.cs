using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCP_Chat_Server
{
    class Tcp_Communication
    {
        int MAX_SIZE = 8192;

        private Dictionary<string, TcpClient> ClientData = new Dictionary<string, TcpClient>();

        TcpClient client;
        NetworkStream stream = default(NetworkStream);
        string userID;
        Form1 serverForm;

        public Tcp_Communication(TcpClient client, string userID, Form1 serverForm) 
        {
            this.userID = userID;
            this.client = client;
        
        }
    }
}
