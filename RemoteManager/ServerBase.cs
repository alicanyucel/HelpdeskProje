using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager
{
	public abstract class ServerBase: Component
	{
		public abstract bool Listening { get; }
		public abstract int Port { get; set; }
		public abstract void Start();
		public abstract void Stop(); 
		
		public abstract void SendData(string ip, Packet pack);

		public abstract void SendAllClients(Packet pack);
		public Dictionary<string, ServerClient> sockets;
		public delegate void PacketRecevied(string ip, Packet packet);
		public event PacketRecevied OnPacketRecevied;
		int buffer_size = 1024;
		public int BufferSize { get { return buffer_size; } set { buffer_size = value; } }
		public void raise_packed_recevied(string ip, Packet packet)
		{
			if(OnPacketRecevied != null)
			{
				OnPacketRecevied(ip, packet);
			}
		}
		public delegate void Disconnected(string ip);
		public event Disconnected OnDisconnected;
		public void raise_disconnected(string ip)
		{
			if (OnDisconnected != null) {
				OnDisconnected(ip);
			}
		} 

		public delegate void Connected(string ip);
		public event Connected OnConnected;
		public void raise_connected(string ip)
		{
			if (OnConnected != null)
			{
				OnConnected(ip);
			}
		}
	}
}
