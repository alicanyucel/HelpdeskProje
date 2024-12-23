using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteManager
{
	public abstract class ComputerBlocker
	{
		Thread th;
		public ComputerBlocker()
		{
			th = new Thread(start);
			IsBlocking = true;
		}
		void start()
		{
			while (IsBlocking)
			{
				Lock();
				Thread.Sleep(10);
			}
			Unlock();
		}

		public void StartLocking()
		{
			if (th.IsAlive == false)
			{
				IsBlocking = true;
				th.Start();
			}


		}
		public void StopLocking()
		{
			IsBlocking = false;
			
		}

		internal abstract void Unlock();
		internal abstract void Lock();

		public bool IsBlocking { get; set; }
	}
}
