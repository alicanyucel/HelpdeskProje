using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using RemoteManager.Serializer;
using System.IO;
namespace RemoteManager
{
    internal class Server
    { 
        public Server() { }
        Socket sock; 
        void init_sock()
        {
            sock=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        } 
        List<Socket> sockets = new List<Socket>(); 
        public delegate void PacketRecevied(Packet packet);
        public event PacketRecevied OnPacketRecevied;
        
        void listen()
        {
            sock.Bind(new IPEndPoint(IPAddress.Parse("128.0.0.1"), 3235)); 
            sock.Listen(int.MaxValue); 
            
            while (true)
            {
                Socket client = sock.Accept();
                if (client != null) {
                    if (sockets.Contains(client) == false) {  
                        sockets.Add(client);
                    }
                }
                for (int i = 0; i < sockets.Count; i++) {  
                    readPacket(sockets[i]);
                }
                
            }
        } 
        void readPacket(Socket socket)
        {
            byte[] buffer = new byte[4096];
            socket.Receive(buffer, buffer.Length, SocketFlags.None); 
            BinarySerializer serializer = new BinarySerializer();
            using (MemoryStream ms = new MemoryStream(buffer))  
            {  
                Packet pack= serializer.Deserialize(ms);
                try
                {
                    OnPacketRecevied(pack);
                }
                catch (Exception e) {  
                }
            }
        }
        public Server(int port) { } 
        public int Port { get; set; } 
        public void Start() { } 
        public void Stop() { }
    }
}
