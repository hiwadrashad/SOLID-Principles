using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SOLID_Principles_LIB.Interfaces;
using SOLID_Principles_LIB.Functions;

namespace SOLID_Principles_Frontend.Dependency_Injection
{
    public class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddSingleton<Program>();
                services.AddSingleton<Main_Loop>();
                services.AddSingleton<INon_Edge_Cases,SOLID_Principles_LIB.Functions.Sub_Functions>();
            });
        }
    }
}
