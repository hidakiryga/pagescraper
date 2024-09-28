using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        //Environment.SetEnvironmentVariable("PLAYWRIGHT_BROWSERS_PATH", Environment.GetEnvironmentVariable("HOME_EXPANDED"));
        //Microsoft.Playwright.Program.Main(new string[] { "install", "chromium", "--with-deps", });

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
