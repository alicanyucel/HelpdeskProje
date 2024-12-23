using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
namespace RemoteManager.Serializer
{
	public class BinaryPacketSerializer : PacketFormatter
	{
		public override Packet Deserialize(Stream inputStream)
		{
			BinaryReader reader = new BinaryReader(inputStream);
			string signature=reader.ReadString();
			Packet pack=new Packet(); 
			if(signature == "|DATA|")
			{
				int packet_size=reader.ReadInt32(); 
				byte[] data=reader.ReadBytes(packet_size);
				using (MemoryStream memoryStream = new MemoryStream(data)) {
					memoryStream.Position = 0; 
					memoryStream.Seek(0, SeekOrigin.Begin);  
					
					BinaryFormatter formatter = (BinaryFormatter)Activator.CreateInstance(typeof(BinaryFormatter));
					pack = (Packet)formatter.Deserialize(memoryStream);
					
					
					
				}
			} 

			else { 
				return null;
			}
			return pack;
		}

		public override void Serialize(Packet pack, Stream outputStream)
		{
			try
			{
				using (BinaryWriter writer = new BinaryWriter(outputStream))
				{
					writer.Write("|DATA|");
					int length = 0;
					using (MemoryStream mem = new MemoryStream())
					{
						mem.Position = 0;
						mem.Seek(0, SeekOrigin.Begin);
						try
						{
							BinaryFormatter binaryFormatter = (BinaryFormatter)Activator.CreateInstance(typeof(BinaryFormatter));
							binaryFormatter.Serialize(mem, pack);
							length = (int)mem.Length;
							writer.Write(length);
							writer.Write(mem.ToArray());
						}
						catch (Exception e)
						{

						}



					}

				}
			}
			catch (Exception e) {  
			}
		}
	}
}
