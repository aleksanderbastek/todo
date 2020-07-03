using System.Threading.Tasks;
using System;
using System.Threading;
using Microsoft.Extensions.Hosting;

namespace TodoApp.Debugging
{
	internal class HostThread
	{
		private readonly Func<IHost> hostFactory = null;
		private IHost host = null;
		private Mutex mutex = new Mutex();
		private bool isFaulted = false;

		public bool IsFaulted {
			get {
				using (mutex)
				{
					return isFaulted;
				}
			}

			private set
			{
				using (mutex)
				{
					isFaulted = value;
				}
			}
		}

		public HostThread(Func<IHost> hostFactory)
		{
			this.hostFactory = hostFactory;
		}

		public void StartApplication()
		{
			RestartApplication();
		}

		public void RestartApplication()
		{
			RunApplicationThread().Start();
		}

		private Task RunApplicationThread() {
			return new Task(() => {
				if (host != null && !IsFaulted)
				{
					Console.WriteLine("[DEBUG_HELPER] Stopping application");
					host.StopAsync().ConfigureAwait(false);
				}


				try
				{
					IsFaulted = false;

					Console.WriteLine("[DEBUG_HELPER] Creating new application");
					host = hostFactory();
					
					Console.WriteLine("[DEBUG_HELPER] Starting application");
					host.Run();
				} catch (Exception e)
				{
					Console.Write(e);
					IsFaulted = true;
				}
			});
		}
	}
}
