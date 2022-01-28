using System.Threading.Tasks;
using AuctionPortal.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AuctionPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async()=> await CategoryManager.InitializeCategories());
            Task.Run(async()=> await CardManager.InitializeCards());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}