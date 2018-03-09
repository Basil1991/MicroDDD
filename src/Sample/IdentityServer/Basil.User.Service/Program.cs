using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Basil.User.Service {
    public class Program {
        public static void Main(string[] args) {
            //var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            //logger.Info("init main");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseNlog()
                .Build();
    }
}
