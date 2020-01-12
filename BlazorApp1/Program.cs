using System;
using System.Linq;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;

namespace BlazorApp1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //ScrapingBrowser browser = new ScrapingBrowser();
            //browser.UserAgent = new FakeUserAgent("Mozilla",
            //    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36 OPR/65.0.3467.78");
            ////set UseDefaultCookiesParser as false if a website returns invalid cookies format
            ////browser.UseDefaultCookiesParser = false;

            //WebPage homePage = browser.NavigateToPage(new Uri("https://www.sofascore.com/"));

            //PageWebForm form = homePage.FindFormById("sb_form");
            //form["q"] = "scrapysharp";
            //form.Method = HttpVerb.Get;
            //WebPage resultsPage = form.Submit();

            //HtmlNode[] resultsLinks = resultsPage.Html.CssSelect("div.sb_tlst h3 a").ToArray();

            //WebPage blogPage = resultsPage.FindLinks(By.Text("romcyber blog | Just another WordPress site")).Single()
            //    .Click();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
