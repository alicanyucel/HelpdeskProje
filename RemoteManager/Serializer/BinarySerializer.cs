using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager.Serializer
{
    internal enum ValueType
    {
        Sbyte, Byte, Short, Int, Int64, Long, Float, Double
    }
    public class BinarySerializer : PacketFormatter
    {
        public BinarySerializer()
        {

        }
        public override Packet Deserialize(Stream inputStream)
        {
            Packet pack = (Packet)Activator.CreateInstance(typeof(Packet));
            using (BinaryReader reader = new BinaryReader(inputStream))
            {
                pack.Commandtype = reader.ReadInt32();
                int len = reader.ReadInt32();
                for (int i = 0; i < len; i++)
                {
                    long type_handle = reader.ReadInt64();




                }
            }
            return pack;
        }
        void write_object(object obj, BinaryWriter bw)
        {
            Type type = obj.GetType();
            bw.Write(type.IsValueType);
            bw.Write(type.IsArray);
            bw.Write(type.TypeHandle.Value.ToInt64());
            if (type.IsArray == false)
            {
                if (type.IsValueType == true)
                {
                    write_value_type(obj, type, bw);
                }

            }
            else
            {
                Array ary = (Array)obj;
                bw.Write(ary.Length);

                for (int i = 0; i < ary.Length; i++)
                {
                    object item = ary.GetValue(i);
                    if (item.GetType().IsValueType == true)
                    {
                        write_object(item, bw);
                    }

                }
            }

        }

        void write_value_type(object obj, Type typ, BinaryWriter bw)
        {


            bw.GetType().GetMethod("Write").Invoke(bw, new object[] { obj });



        }
        bool read_value_type(long type_handle,Packet pack, BinaryReader reader)
        {
            if (type_handle == typeof(Int16).TypeHandle.Value.ToInt64())
            {
                short shtr = reader.ReadInt16();
                pack.Data.Add(shtr);
                return true;
            }
            if (type_handle == typeof(UInt16).TypeHandle.Value.ToInt64())
            {
                ushort shtr = reader.ReadUInt16();
                pack.Data.Add(shtr); 
                return true;
            }
            if (type_handle == typeof(Int32).TypeHandle.Value.ToInt64())
            {
                int val = reader.ReadInt32();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(UInt32).TypeHandle.Value.ToInt64())
            {
                uint val = reader.ReadUInt32();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(Int64).TypeHandle.Value.ToInt64())
            {
                ulong val = reader.ReadUInt64();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(UInt64).TypeHandle.Value.ToInt64())
            {
                ulong val = reader.ReadUInt64();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(char).TypeHandle.Value.ToInt64())
            {
                char val = reader.ReadChar();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(decimal).TypeHandle.Value.ToInt64())
            {
                decimal val = reader.ReadDecimal();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(double).TypeHandle.Value.ToInt64())
            {
                double val = reader.ReadDouble();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(float).TypeHandle.Value.ToInt64())
            {
                float val = reader.ReadSingle();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(bool).TypeHandle.Value.ToInt64())
            {
                bool val = reader.ReadBoolean();
                pack.Data.Add(val); 
                return true;
            }
            if (type_handle == typeof(byte).TypeHandle.Value.ToInt64())
            {
                byte val = reader.ReadByte();
                pack.Data.Add(val); 
                return true;
            } 
            return false;
        }
        public override void Serialize(Packet pack, Stream outputStream)
        {


            using (MemoryStream mem = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(outputStream);
                writer.Write(pack.Commandtype);
                writer.Write(pack.Data.Count);
                for (int i = 0; i < pack.Data.Count; i++)
                {
                    write_value_type(pack.Data[i], writer);
                }

            }

        }
    }
}
