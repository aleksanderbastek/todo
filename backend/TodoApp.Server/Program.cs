using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TodoApp.Debugging;

namespace TodoApp.Server
{
	public class Program
    {
        public static void Main(string[] args)
        {
			if (DebuggingHelper.IsRanWithDebuggingFlag(args)) {
				Console.WriteLine("Running application in debugging mode (--debug flag is provided)");

				var debuggingHelper = new DebuggingHelper(
					() => CreateHostBuilder(args).Build()
				);

				debuggingHelper.Run();
			} else {
				Console.WriteLine("Running application in normal mode");
				CreateHostBuilder(args).Build().Run();
			}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
