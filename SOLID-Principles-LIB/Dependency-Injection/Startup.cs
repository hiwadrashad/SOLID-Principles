using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SOLID_Principles_LIB.Functions;
using SOLID_Principles_LIB.Interfaces;

namespace SOLID_Principles_LIB.Dependency_Injection
{
    public class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddSingleton<Main_Loop>();
                services.AddSingleton<Adjusted_Conjured_Item_Main_Loop>();
                services.AddSingleton<IBack_Stage_Pass, Sub_Functions>();
                services.AddSingleton<INon_Edge_Cases, Sub_Functions>();
                services.AddSingleton<IBelow_Zero_Days, Sub_Functions>();
            });
        }
    }

}
