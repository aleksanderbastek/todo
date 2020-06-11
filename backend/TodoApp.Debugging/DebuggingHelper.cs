using System.Diagnostics;
using System.Threading;
using System.Linq;
using System;
using Microsoft.Extensions.Hosting;

namespace TodoApp.Debugging
{
    public class DebuggingHelper
    {
		private IHost host = null;
		private Func<IHost> hostFactory = null;
		private DateTime lastDetachTime;

		public static bool IsRanWithDebuggingFlag(string[] args) {
			return args.Contains("--debug");
		}

		public DebuggingHelper(Func<IHost> hostFactory) {
			this.hostFactory = hostFactory;
			this.host = hostFactory();
		}

		public void Run() {
			host.RunAsync();

			while (true) {
				WaitForDebuggerDetach();
				WaitForDebuggerAttach();

				var timeFromLastDetach = DateTime.Now - lastDetachTime;
				var maxWaitingTime = TimeSpan.FromSeconds(30);

				if (timeFromLastDetach < maxWaitingTime) {
					RestartApplication();
				}
			}
		}

		private void WaitForDebuggerAttach() {
			while (!Debugger.IsAttached) {
				Thread.Sleep(100);
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

		private void RestartApplication() {
			Console.WriteLine("Stopping application...");
			host.StopAsync().ConfigureAwait(false);

			Console.WriteLine("Creating new application");
			host = hostFactory();

			Console.WriteLine("Starting application again");
			host.RunAsync();
		}
	}
}
