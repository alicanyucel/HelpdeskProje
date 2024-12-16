using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager.Serializer
{
    public class Packet
    {
        public int Commandtype { get; set; }
        public List<object> Data { get; set; }
    } 
    public abstract class PacketFormatter
    { 
        public PacketFormatter() { }  
        public abstract void Serialize(Packet pack,Stream outputStream); 
        public abstract Packet Deserialize(Stream inputStream);
        
    }
}
