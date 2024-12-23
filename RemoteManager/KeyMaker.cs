using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RemoteManager.Serializer;
namespace RemoteManager
{
	public class KeyMaker
	{  
		public KeyMaker(string Path,Guid key_guid,int numbers)
		{
			this.number = numbers;
			this.guid = key_guid;
			this.path = Path;
		}
		int number;
		Guid guid; 
		public void Save()
		{
			save();
		}
		void save()
		{
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite); 
			BinarySerializer serializer = new BinarySerializer();
			serializer.Serialize(new Packet(number, new List<object>() {guid.ToString() }),fs); 
			fs.Close();
		}
		string path = "";
		FileStream fs; 
		
	}
}
