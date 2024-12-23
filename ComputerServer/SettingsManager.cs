using RemoteManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ComputerServer
{
	 
	internal class SettingsManager
	{ 
		public SettingsManager()
		{
			Path=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\ManagerAppSettings.dat";
		}
		public Packet pack;
		public string Path="";
		public void Create()
		{
			BinaryFormatter bf = new BinaryFormatter(); 
			
		}
	}
}
