using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration; // 1st line added

namespace TestASPNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
            // 2nd line added

            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";
            // 3rd line added

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
