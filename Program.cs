
using Nancy.Hosting.Self;
using System;
using System.Configuration;
namespace SIG.HOST
{
    class Program
    {
        const string escapeString = "/exit";

        static void Main(string[] args)
        {
            NancyHost host;
            ushort port = Convert.ToUInt16(ConfigurationManager.AppSettings.Get("httpPort"));

            var uri = new Uri("http://localhost:" + port + "/");
            var config = new HostConfiguration(); config.UrlReservations.CreateAutomatically = true;

            host = new NancyHost(config, uri);
            try
            {
                host.Start();

                Console.Write("\t\"" + uri + "\"\n" + "Salir: \"" + escapeString + "\".\n\n");
                do Console.Write("> "); while (Console.ReadLine() != escapeString);
         
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception \n" + e.Message);
                Console.ReadKey(true);
            }
            finally
            {
                host.Stop();
            }

            Console.WriteLine("Bye!!");
        }
    }
}
