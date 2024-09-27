using System;
using System.Security.Policy;
using HtmlAgilityPack;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
//using Microsoft.Playwright;

namespace TestTimer
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task Run([TimerTrigger("0 */6 * * * *",RunOnStartup =true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            List<string> url = Environment.GetEnvironmentVariable("EcomUrls").Split(";").ToList();
            Console.WriteLine(url);
            Console.WriteLine(url[0]);


            //// Use Playwright to load the page
            //using var playwright = await Playwright.CreateAsync();
            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            //var context = await browser.NewContextAsync();
            //var page = await context.NewPageAsync();

            //// Set the required request headers
            //await page.SetExtraHTTPHeadersAsync(getReqHeaders(url[0]));

            //// Navigate to the URL and wait for the content to load
            //await page.GotoAsync(url[0], new PageGotoOptions { WaitUntil = WaitUntilState.Load });

            //// Get the page content (fully rendered HTML including dynamically loaded content)
            //var content = await page.ContentAsync();

            //// Close the browser
            //await browser.CloseAsync();

            //// Load HTML into HtmlDocument from HtmlAgilityPack
            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(content);

            //// Select the body node
            //var bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");
            //if (bodyNode == null)
            //{
            //    _logger.LogInformation("NO BODY FOUND");
            //}
            //else
            //{
            //    _logger.LogInformation("BODY FOUND");

            //}

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
        public Dictionary<string, string> getReqHeaders(string url)
        {
            var uri = new Uri(url);
            var baseUrl = $"{uri.Scheme}://{uri.Host}";
            return (new()
            {
                { "accept", "*/*" },
                { "accept-encoding", "gzip, deflate, br, zstd" },
                { "accept-language", "en-GB,en;q=0.9,en-US;q=0.8" },
                { "sec-ch-ua", $"\"Microsoft Edge\";v=\"129\", \"Not=A?Brand\";v=\"8\", \"Chromium\";v=\"129\"" },
                { "sec-ch-ua-platform", $"\"Windows\"" },
                { "sec-fetch-dest", "document" },
                { "sec-fetch-mode", "navigate" },
                { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36 Edg/129.0.0.0" },
            });
        }
    }
}
