using RemoteManager.Serializer;
using RemoteManager;
using System.IO;
using System;
namespace RemoteManager { 
public class KeyChecker
{
	Packet pack;
	public KeyChecker(string guid,int number)
	{
			this.pack = new Packet(); 
			this.guid_id = guid;
			this.keynumber = number;
		
	} 
	public KeyChecker()
		{
			pack = new Packet();
			guid_id = System.Guid.Empty.ToString();
		}
	bool is_key_true;
	int keynumber= 4567;
	string guid_id;
	public string Guid { get { return guid_id; } set { guid_id = value; } }
	public DriveInfo selectedDrive;
	public bool IsKeyFind { get
			{
				try
				{
					check(); 
					return is_key_true; 
				}
				catch (Exception ex) { 
					return false;
				}
				
			}  
		}
	void check()
	{
		is_key_true = false;
		pack.Commandtype = keynumber;
		if (pack.Data.Count > 0)
		{
			pack.Data.Clear();
		}
		pack.Data.Add(guid_id);
		DriveInfo[] drives = DriveInfo.GetDrives();
		for (int i = 0; i < drives.Length; i++)
		{
			DriveInfo drive = drives[i];
			if (drive.DriveType == DriveType.Removable)
			{
				string FolderPath = drive.RootDirectory.FullName;
				string filepath = FolderPath + @"passwordkey.data";
				if (File.Exists(filepath))
				{
					FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite,FileShare.ReadWrite);
					BinarySerializer ser = new BinarySerializer();
					Packet filepack = ser.Deserialize(fs);
						if (filepack.Data.Count > 0)
						{
							if (filepack.Commandtype == pack.Commandtype && filepack.Data[0].ToString().Trim() == pack.Data[0].ToString().Trim())
							{
								is_key_true = true;
								selectedDrive = drive;
								break;
							}
						}
						else {
							if (filepack.Commandtype == pack.Commandtype)
							{
								is_key_true = true; 
								selectedDrive = drive;
								break;
							}
						}
					
				}
			}
		}

	}
} 
}