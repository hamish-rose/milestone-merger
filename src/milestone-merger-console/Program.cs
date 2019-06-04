using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace milestone_merger_console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var host = new HostBuilder()
                            .ConfigureServices((hostContext, services) =>
                            {
                                
                            });

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gitlab.com/api/v4/");
            client.DefaultRequestHeaders.Add("Private-Token", "JQyH2VgS_AVoVcpSGCiq");

            var response = await client.GetStringAsync("groups");
            Console.WriteLine(response);
        }
    }
}
