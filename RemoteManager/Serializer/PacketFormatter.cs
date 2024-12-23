using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager
{
	[Serializable] 
	public class Packet : IDisposable
    {
        public int Commandtype { get; set; }
        public List<object> Data { get; set; } 
        public Packet() {  
            Data = new List<object>();
        } 
		public Packet(int commandtype, List<object> data)
		{
			this.Commandtype = commandtype; 
			this.Data = data;
		}

		public void Dispose()
		{
			try
			{
				 
				if(Data.Count > 0)
				{
					Data.Clear();
				}	 
				
			}  
			catch{

			} 
			
			GC.SuppressFinalize(this);
		}
	}
	public abstract class PacketFormatter : IDisposable
    { 
        public PacketFormatter() { }  
        public abstract void Serialize(Packet pack,Stream outputStream); 
        public abstract Packet Deserialize(Stream inputStream);

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
