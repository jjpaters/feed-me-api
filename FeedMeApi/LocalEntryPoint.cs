using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FeedMeApi
{
    /// <summary>
    /// The Main function can be used to run the ASP.NET Core application locally using the Kestrel webserver.
    /// </summary>
    public class LocalEntryPoint
    {
        /// <summary>
        /// Main entry point for running the API locally.
        /// </summary>
        /// <param name="args">Input arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a generic host builder.
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <returns>Instace of IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
