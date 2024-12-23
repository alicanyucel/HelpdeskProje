using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager
{
	public enum CommandTypes : int
	{
		GetInfo, Shutdown,Sleep, Restart, LockComputer, UnlockComputer, Login, ChangeNickName, SaveRecoveryKey,UpdateInfo,DesktopImage,StartDesktopViewer,StopDesktopViewer
	}
}
