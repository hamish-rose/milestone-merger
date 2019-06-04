using System;
using System.Net.Http;
using System.Threading.Tasks;
using milestone_merger_console.GitLabClient;
using Microsoft.Extensions.Hosting;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace milestone_merger_console
{
    public class Program
    {
        public static Task<int> Main(string[] args)
        {
            return new HostBuilder()
            .ConfigureLogging((services, builder) =>
            {
                builder.AddConsole();
                builder.AddConfiguration(services.Configuration.GetSection("logging"));
            })
            .ConfigureAppConfiguration(configHost =>
            {
                configHost.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient<IGitLabService, GitLabService>();
            })
            .RunCommandLineApplicationAsync<MilestoneMerger>(args);
        }
    }
}

