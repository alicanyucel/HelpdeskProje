using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using RemoteManager.Serializer;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace RemoteManager
{

	public class Server : ServerBase
	{
		public override bool Listening => is_listening;
		public Server()
		{
			init();
		}
		public override int Port { get { return port_number; } set { port_number = value; } }
		bool is_listening=false;
		int port_number;
		protected Thread listen_thread;
		protected Thread recevie_thread;
		
		public override void SendAllClients(Packet pack)
		{
			for (int i = 0; i < sockets.Count; i++) {
				sockets.ElementAt(i).Value.SendData(pack);
			}
		}
		Socket sock;
		void init()
		{
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sockets = new Dictionary<string, ServerClient>(); 
			listen_thread = new Thread(listen);
			recevie_thread = new Thread(recevie);
			is_bound = false;
			is_listening = false; 
			port_number = 5876;
		}
		public override void SendData(string ip, Packet pack)
		{
			if (sockets.ContainsKey(ip) == true)
			{
				sockets[ip].SendData(pack);
			}
		}
		bool is_bound=false;
		void listen()
		{
			sock.Bind(new IPEndPoint(IPAddress.Any, port_number));
			
			sock.Listen(int.MaxValue); 
			is_bound = true;
			accept();
		}
		void accept()
		{
			while (is_listening)
			{
				if (is_bound == true)
				{
					Socket client = sock.Accept(); 
					var socketclient=new ServerClient(this,client);
					if (sockets.ContainsValue(socketclient) == false)
					{
						sockets.Add(client.RemoteEndPoint.ToString(), socketclient);
						raise_connected(client.RemoteEndPoint.ToString());
					}
				}

			}
		}
		
		void recevie()
		{
			while (is_listening)
			{
				for (int i = 0; i < sockets.Count; i++)
				{
					sockets.ElementAt(i).Value.read_data();
				}
			}
		}
		
		
		public override void Start()
		{
			is_listening = true;
			listen_thread.Start();
			recevie_thread.Start(); 
			
		}

		public override void Stop()
		{
			is_listening = false; 
			is_bound= false;
		}
	}
	public class ServerClient
	{
		public ServerClient(ServerBase _base,Socket sock) {
			checked_sock = sock; 
			connected=checked_sock.Connected;
			this.serbase = _base;
			writing_pending = new object();
			check_connection();
		}
		ServerBase serbase;
		Socket checked_sock;
		bool connected;
		object writing_pending;
		void check_connection()
		{
			if (checked_sock.Connected != connected)
			{
				connected = checked_sock.Connected;
				if (connected == false)
				{
					serbase.sockets.Remove(checked_sock.RemoteEndPoint.ToString()); 
					serbase.raise_disconnected(checked_sock.RemoteEndPoint.ToString());
				}
				else
				{
					serbase.raise_connected(checked_sock.RemoteEndPoint.ToString());
				}
				
			}
			
		}
		public void SendData(Packet pack)
		{

			check_connection(); 
			if (checked_sock.Connected == true)
			{
				lock (writing_pending)
				{
					using (NetworkStream netstream = new NetworkStream(checked_sock))
					{
						using (BufferedStream buf = new BufferedStream(netstream, serbase.BufferSize))
						{
							using (BinaryPacketSerializer serializer = new BinaryPacketSerializer())
							{
								serializer.Serialize(pack, buf);
							}
							
						} 
						
					}
				}
			}
			else
			{
				
				
			}
			check_connection();

		}
		public void read_data()
		{
			check_connection(); 
			if(checked_sock.Connected==true)
			{
				if (checked_sock.Available > 0)
				{
					using (NetworkStream networkStream = new NetworkStream(checked_sock))
					{
						using (BufferedStream buffer = new BufferedStream(networkStream, serbase.BufferSize))
						{
							using (BinaryPacketSerializer serializer = new BinaryPacketSerializer())
							{
								Packet pack = serializer.Deserialize(buffer);
								if(pack != null)
								{
									serbase.raise_packed_recevied(checked_sock.RemoteEndPoint.ToString(), pack);
								} 
								
							}
						}

					}
				}
			}


		}
	} 
}

