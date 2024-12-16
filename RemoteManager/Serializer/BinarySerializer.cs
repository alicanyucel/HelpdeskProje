using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
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
            inputStream.Position = 0; 
            inputStream.Seek(0, SeekOrigin.Begin);
            Packet pack = (Packet)Activator.CreateInstance(typeof(Packet));
            using (BinaryReader reader = new BinaryReader(inputStream))
            {
                string pack_signature=reader.ReadString(); 
                if(pack_signature == "|PACKET|")
                {
                    pack.Commandtype = reader.ReadInt32();
                    int len = reader.ReadInt32();
                    for (int i = 0; i < len; i++)
                    {
                        read_object(pack, reader);




                    }
                }
                else
                {
                    return null;
                }
            }
            return pack;
        } 
        void read_object(Packet pack,BinaryReader reader)
        {
           
            bool IsClass=reader.ReadBoolean();
            bool IsValueType=reader.ReadBoolean();
            bool IsArray=reader.ReadBoolean();
            long type_handle=reader.ReadInt64();
           
            if (IsArray == false)
            {
                if (IsValueType == true)
                {
                    read_value_type(type_handle,pack, reader);
                }
                else
                {
                   if(IsClass==true && type_handle == typeof(string).TypeHandle.Value.ToInt64())
                    {
                        string data=reader.ReadString();
                        pack.Data.Add(data);
                    }

                }

            }
            else
            {
                string type_name = reader.ReadString();
                Type typ = Type.GetType(type_name);
                int element_len=reader.ReadInt32();
                Array arr=Array.CreateInstance(Type.GetType(type_name), element_len); 
                for(int i = 0; i < element_len; i++)
                {
                    read_array_Item(ref arr, typ, i, reader);
                }
                
                
            }
        } 
        void read_array_Item(ref Array array,Type type,int index,BinaryReader reader)
        {
            bool IsValueType = reader.ReadBoolean();
            bool IsArray = reader.ReadBoolean();
            long type_handle = reader.ReadInt64();

            if (type.IsArray == false)
            {
                if (type.IsValueType == true)
                {
                    //read_value_type(type_handle, pack, reader);
                }

            }
            else
            {
                string type_name = reader.ReadString();
                int element_len = reader.ReadInt32(); 
                Type array_item_type= Type.GetType(type_name);
                Array arr = Array.CreateInstance(array_item_type, element_len); 
                long handle_number=array_item_type.TypeHandle.Value.ToInt64();
                for (int i = 0; i < element_len; i++)
                {
                   read_value_type_array(ref arr,i,handle_number,reader);
                }


            }
        }
        void write_object(object obj, BinaryWriter bw)
        {
            Type type = obj.GetType(); 
            bw.Write(type.IsClass);
            bw.Write(type.IsValueType);
            bw.Write(type.IsArray);
            bw.Write(type.TypeHandle.Value.ToInt64());
            if (type.IsArray == false)
            {
                if (type.IsValueType == true)
                {
                    write_value_type(obj, type, bw);
                }else if (typeof(string) == type)
                {
                    bw.Write((string)obj);
                }

            }
            else
            {
                Array ary = (Array)obj;
                bw.Write(type.Name);
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
        bool read_value_type_array(ref Array arr,int index,long type_handle,BinaryReader reader)
        {
            if (type_handle == typeof(Int16).TypeHandle.Value.ToInt64())
            {
                short shtr = reader.ReadInt16();
                arr.SetValue(index, shtr);
                return true;
            }
            if (type_handle == typeof(UInt16).TypeHandle.Value.ToInt64())
            {
                ushort shtr = reader.ReadUInt16(); 
                arr.SetValue(index, shtr);
                
                return true;
            }
            if (type_handle == typeof(Int32).TypeHandle.Value.ToInt64())
            {
                int val = reader.ReadInt32();
                arr.SetValue(index, val);
                return true;
            }
            if (type_handle == typeof(UInt32).TypeHandle.Value.ToInt64())
            {
                uint val = reader.ReadUInt32();
                arr.SetValue(index, val);
                return true;
            }
            if (type_handle == typeof(Int64).TypeHandle.Value.ToInt64())
            {
                long val = reader.ReadInt64();
                arr.SetValue(val,index);
                return true;
            }
            if (type_handle == typeof(UInt64).TypeHandle.Value.ToInt64())
            {
                ulong val = reader.ReadUInt64();
                arr.SetValue(val, index);
                return true;
            }
            if (type_handle == typeof(char).TypeHandle.Value.ToInt64())
            {
                char val = reader.ReadChar();
                arr.SetValue(index, val);
                return true;
            }
            if (type_handle == typeof(decimal).TypeHandle.Value.ToInt64())
            {
                decimal val = reader.ReadDecimal();
                arr.SetValue(val, index);
                return true;
            }
            if (type_handle == typeof(double).TypeHandle.Value.ToInt64())
            {
                double val = reader.ReadDouble();
                arr.SetValue(val, index);
                return true;
            }
            if (type_handle == typeof(float).TypeHandle.Value.ToInt64())
            {
                float val = reader.ReadSingle();
                arr.SetValue(val, index);
                return true;
            }
            if (type_handle == typeof(bool).TypeHandle.Value.ToInt64())
            {
                bool val = reader.ReadBoolean();
                arr.SetValue(val, index);
                return true;
            }
            if (type_handle == typeof(byte).TypeHandle.Value.ToInt64())
            {
                byte val = reader.ReadByte();
                arr.SetValue(index, val);
                return true;
            } 
            return false;
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


                BinaryWriter writer = new BinaryWriter(outputStream); 
                //Packet yazmamın amacı paketin sağlam gelip gelmediğini kontrol etmek
                writer.Write("|PACKET|");
                writer.Write(pack.Commandtype);
                writer.Write(pack.Data.Count);
                for (int i = 0; i < pack.Data.Count; i++)
                {
                    write_object(pack.Data[i],writer);
                }

            }

        }
    }


            
                