using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using RemoteManager.Serializer;
using System.IO;
using System.ComponentModel;
using System.Net.NetworkInformation;
namespace RemoteManager
{
	public class Client : Component
	{
		Thread th;
		public Client() { init(); }

		public int Port { get; set; }
		Socket sock;
		void init()
		{
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			
			th = new Thread(connect); 
			writing = new object();

		}
		bool connected; 
		public bool ClientConnected { get { return sock.Connected;  } }
		object writing;
		
		int buffer_size = 1024;
		public int BufferSize { get { return buffer_size; } set { buffer_size = value; } }
		public delegate void PackRecevied(Packet packet);
		public event PackRecevied OnPacketRecevied;
		public delegate void Disconnected();
		public event Disconnected OnDisconnected;
		public delegate void Connected();
		public event Connected OnConnected; 

		void check_pack()
		{
			if (sock.Available > 0)
			{
				using(NetworkStream netstr=new NetworkStream(sock))
				{
					using(BufferedStream buffered=new BufferedStream(netstr, buffer_size))
					{
						using(BinaryPacketSerializer serializer=new BinaryPacketSerializer())
						{
							Packet pack=serializer.Deserialize(buffered); 
							if(pack != null)
							{
								if(OnPacketRecevied != null)
								{
									OnPacketRecevied(pack);
								}
							}
						}
						
						buffered.Close();
					}
				}
			}
		} 
		void check_connection()
		{
			if (sock.Connected != connected)
			{
				if (connected == true)
				{
					raise_connected_event();
				}
				else
				{
					raise_disconnected_event();
				}
				connected=sock.Connected; 
			} 
			
		}
		void connect()
		{
			while (connected)
			{
				check_connection(); 
				if (sock != null)
				{
					if (sock.Connected == true)
					{
						check_pack();
					}
					else
					{
						connected = false; 
						raise_disconnected_event();
						break;
					}
				} 
				

			}
			check_connection();
		} 
		void send(Packet packet)
		{
			check_connection(); 
			lock (writing)
			{
				using (NetworkStream netstr = new NetworkStream(sock))
				{
					using (BufferedStream bufstr = new BufferedStream(netstr, buffer_size))
					{
						using (BinaryPacketSerializer ser = new BinaryPacketSerializer())
						{
							ser.Serialize(packet, bufstr);
						}
						
					}
				}
			} 
			
			
		}
		public void Send(Packet packet)
		{
			try
			{
				if (sock.Connected == true)
				{
					send(packet);
				}
				
			}
			 
			catch (Exception ex) { }
			
		}
		public void Disconnect()
		{
			 
			connected = false;  
			try {
				sock.Disconnect(true);
			}
			catch { }
		} 
		void raise_connected_event()
		{
			if(OnConnected != null)
			{
				OnConnected();
			}
		}
		void raise_disconnected_event()
		{
			if (OnDisconnected != null)
			{
				OnDisconnected();
			}
		}
		public void Connect(string ip, int port)
		{
			try
			{
				sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				sock.Connect(new IPEndPoint(IPAddress.Parse(ip), port)); 
				
				if (sock.Connected == true)
				{
					connected = true;
					if (th.ThreadState == ThreadState.Stopped)
					{
						th=new Thread(connect);
					}
					th.Start(); 
					raise_connected_event();
				}
				else
				{

					raise_disconnected_event();
				}
			}
			catch
			{
				if (sock.Connected == false)
				{
					if(sock.Connected != connected)
					{
						connected = false;
						raise_disconnected_event();
					} 
					
				}
			}
		
		}
	}
}
