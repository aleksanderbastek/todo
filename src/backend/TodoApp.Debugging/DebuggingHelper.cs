using System.Diagnostics;
using System.Threading;
using System.Linq;
using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace TodoApp.Debugging
{
	public class DebuggingHelper {
		private HostThread hostThread = null;
		private DateTime lastDetachTime;

		public static bool IsRanWithDebuggingFlag(string[] args) {
			return args.Contains("--debug");
		}

		public DebuggingHelper(Func<IHost> hostFactory) {
			hostThread = new HostThread(hostFactory);
		}

		public void Run()
		{
			hostThread.StartApplication();

			while (true) {
				WaitForDebuggerDetach();
				WaitForDebuggerAttach();

				var maxWaitingTime = TimeSpan.FromSeconds(30);
				var timeFromLastDetach = DateTime.Now - lastDetachTime;

				if (timeFromLastDetach < maxWaitingTime) {
					Console.WriteLine("[DEBUG_HELPER] Debugger detached and attached within 30 seconds, interpreting as restart request, restarting application");
					hostThread.RestartApplication();
				}
			}
		}
		private void WaitForDebuggerAttach() {
			while (!Debugger.IsAttached) {
				Thread.Sleep(100);
				
				if (hostThread.IsFaulted) {
					Console.WriteLine("[DEBUG_HELPER] Application crashed, waiting for debugger attach");

					while (!Debugger.IsAttached)
					{
						Thread.Sleep(100);
					}

					Console.WriteLine("[DEBUG_HELPER] Debugger attached, restarting application after crash");
					hostThread.RestartApplication();
				}
			}
		}

		private void WaitForDebuggerDetach() {
			if (!Debugger.IsAttached) {
				return;
			}

			while (Debugger.IsAttached) {
				Thread.Sleep(100);
			}

			this.lastDetachTime = DateTime.Now;
		}
	}
}
