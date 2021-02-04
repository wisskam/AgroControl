using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AgroControl.DBContexts;
using AgroControl.Models;
using System.Text;

namespace AgroControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InsertData();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
        );

        private static void InsertData()
        {
            using (var context = new GospodarstwoContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var gospodarstwo = new Gospodarstwo
                {
                    Nazwa = "Gospodarstwo Rolne Jan Kowalski",
                    Wlasciciel = "Jan Kowalski"
                };
                context.Gospodarstwo.Add(gospodarstwo);

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new GospodarstwoContext())
            {
                var gospodarstwa = context.Gospodarstwo;
                foreach (var gospodarstwo in gospodarstwa)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID: {gospodarstwo.ID}");
                    data.AppendLine($"Nazwa: {gospodarstwo.Nazwa}");
                    data.AppendLine($"W³aœciciel: {gospodarstwo.Wlasciciel}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

    }
}
