namespace BlazorApp1.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using ExtensionMethods;
    using Models.Predictions;
    using HtmlAgilityPack;
    using RestSharp;
    public class WeatherForecastService
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly UltronContext context;


        public WeatherForecastService(UltronContext context)
        {
            this.context = context;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            try
            {
                var client = new RestClient("https://www.forebet.com/en/football-tips-and-predictions-for-today");

                var request = new RestRequest(Method.GET);
                var response2 = client.Execute(request);

                var doc = new HtmlDocument();
                doc.LoadHtml(response2.Content);


                var todayForebetPredictions = doc.DocumentNode.SelectSingleNode("//table[@class='schema tblen']")
                                                 .Descendants("tr")
                                                 .Skip(2)
                                                 .Where(tr => tr.Elements("td").Count() > 1)
                                                 .Select(tr =>
                                                     tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                                 .ToList();

                var forebetPredictions = new List<ForebetPrediction1X2>();

                foreach (var todayForebetPrediction in todayForebetPredictions)
                {
                    // Remove tabs and whitespaces
                    var firstRowData = todayForebetPrediction.First()
                                                             .Replace("\t", string.Empty,
                                                                 StringComparison.OrdinalIgnoreCase);
                    firstRowData = firstRowData.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase);

                    var forebetPrediction = new ForebetPrediction1X2();
                    var dataArraySplit = firstRowData.Split("\n");

                    forebetPrediction.LeagueCode = dataArraySplit.First();
                    forebetPrediction.HomeTeam = dataArraySplit[3];
                    forebetPrediction.AwayTeam = dataArraySplit[4];
                    forebetPrediction.HomeWinProbability = int.Parse(todayForebetPrediction[1], CultureInfo.InvariantCulture);
                    forebetPrediction.DrawProbability = int.Parse(todayForebetPrediction[2], CultureInfo.InvariantCulture);
                    forebetPrediction.AwayTeamProbability = int.Parse(todayForebetPrediction[3], CultureInfo.InvariantCulture);
                    forebetPrediction.Prediction = todayForebetPrediction[4].GetWinDrawWin();
                    forebetPrediction.CorrectScore = todayForebetPrediction[5];
                    forebetPrediction.Odds = double.Parse(todayForebetPrediction[6], CultureInfo.InvariantCulture);
                    forebetPrediction.CurrentMinute = todayForebetPrediction[7];
                    forebetPrediction.CurrentResult = todayForebetPrediction[8];
                    forebetPredictions.Add(forebetPrediction);
                }


                var clientYesterday = new RestClient("https://www.forebet.com/en/football-predictions-from-yesterday");
                var requestYesterday = new RestRequest(Method.GET);
                var responseYesterday = clientYesterday.Execute(requestYesterday);
                var docYesterday = new HtmlDocument();
                docYesterday.LoadHtml(responseYesterday.Content);

                var yesterdayForebetPredictions = docYesterday.DocumentNode.SelectSingleNode("//table[@class='schema tblen']")
                                                 .Descendants("tr")
                                                 .Skip(2)
                                                 .Where(tr => tr.Elements("td").Count() > 1)
                                                 .Select(tr =>
                                                     tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                                 .ToList();

                var forebetPredictionsYesterday = new List<ForebetPrediction1X2>();

                foreach (var todayForebetPrediction in yesterdayForebetPredictions)
                {
                    // Remove tabs and whitespaces
                    var firstRowData = todayForebetPrediction.First()
                                                             .Replace("\t", string.Empty,
                                                                 StringComparison.OrdinalIgnoreCase);
                    firstRowData = firstRowData.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase);

                    var forebetPrediction = new ForebetPrediction1X2();
                    var dataArraySplit = firstRowData.Split("\n");

                    forebetPrediction.LeagueCode = dataArraySplit.First();
                    forebetPrediction.HomeTeam = dataArraySplit[3];
                    forebetPrediction.AwayTeam = dataArraySplit[4];
                    forebetPrediction.HomeWinProbability = int.Parse(todayForebetPrediction[1], CultureInfo.InvariantCulture);
                    forebetPrediction.DrawProbability = int.Parse(todayForebetPrediction[2], CultureInfo.InvariantCulture);
                    forebetPrediction.AwayTeamProbability = int.Parse(todayForebetPrediction[3], CultureInfo.InvariantCulture);
                    forebetPrediction.Prediction = todayForebetPrediction[4].GetWinDrawWin();
                    forebetPrediction.CorrectScore = todayForebetPrediction[5];
                    forebetPrediction.Odds = double.Parse(todayForebetPrediction[6], CultureInfo.InvariantCulture);
                    forebetPrediction.CurrentMinute = todayForebetPrediction[10];
                    forebetPrediction.FinalScore = todayForebetPrediction[11];
                    forebetPredictionsYesterday.Add(forebetPrediction);
                }

                var rng = new Random();
                return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}