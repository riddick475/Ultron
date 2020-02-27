namespace BlazorApp1.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using BlazorApp1.ExtensionMethods;
    using BlazorApp1.Models.Predictions;
    using BlazorApp1.Models.Views;

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

        public string FindTextBetween(string text, string left, string right)
        {
            // TODO: Validate input arguments
            var beginIndex = text.IndexOf(left); // find occurence of left delimiter
            if (beginIndex == -1)
                return string.Empty; // or throw exception?

            beginIndex += left.Length;

            var endIndex = text.IndexOf(right, beginIndex); // find occurence of right delimiter
            if (endIndex == -1)
                return string.Empty; // or throw exception?

            return text.Substring(beginIndex, endIndex - beginIndex).Trim();
        }

        /// <summary>
        /// The get forecast async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ForebetPredictionsViewModel> GetForecastAsync()
        {
            var predictions = new ForebetPredictionsViewModel();
            try
            {
                var client = new RestClient("https://www.forebet.com/en/football-tips-and-predictions-for-today");

                var request = new RestRequest(Method.GET);
                var response2 = await client.ExecuteTaskAsync(request).ConfigureAwait(false);

                var doc = new HtmlDocument();
                doc.LoadHtml(response2.Content);

                var todayForebetPredictions = doc.DocumentNode.SelectSingleNode("//table[@class='schema tblen']")
                    .Descendants("tr").Skip(2).Where(tr => tr.Elements("td").Count() > 1).Select(
                        tr => tr.Elements("td").Select(
                            td => td.InnerText.Trim() + "\n" + this.FindTextBetween(
                                      td.OuterHtml,
                                      "<a class=\"tnmscn\" itemprop=\"url\" href=\"",
                                      "\">")).ToList()).ToList();

                var forebetPredictions = new List<ForebetPrediction1X2>();

                foreach (var todayForebetPrediction in todayForebetPredictions)
                {
                    // Remove tabs and whitespaces
                    var firstRowData = todayForebetPrediction.First().Replace(
                        "\t",
                        string.Empty,
                        StringComparison.OrdinalIgnoreCase);
                    firstRowData = firstRowData.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase);

                    var forebetPrediction = new ForebetPrediction1X2();
                    var dataArraySplit = firstRowData.Split("\n");

                    forebetPrediction.LeagueCode = dataArraySplit.First();
                    forebetPrediction.HomeTeam = dataArraySplit[3];
                     forebetPrediction.AwayTeam = dataArraySplit[4];
                    forebetPrediction.Head2HeadUrl = "https://www.forebet.com" + dataArraySplit[7];
                    forebetPrediction.HomeWinProbability = int.Parse(
                        todayForebetPrediction[1],
                        CultureInfo.InvariantCulture);
                    forebetPrediction.DrawProbability = int.Parse(
                        todayForebetPrediction[2],
                        CultureInfo.InvariantCulture);
                    forebetPrediction.AwayTeamProbability = int.Parse(
                        todayForebetPrediction[3],
                        CultureInfo.InvariantCulture);
                    forebetPrediction.Prediction = todayForebetPrediction[4].GetWinDrawWin();
                    forebetPrediction.CorrectScore = todayForebetPrediction[5];
                    forebetPrediction.Odds = double.Parse(todayForebetPrediction[6], CultureInfo.InvariantCulture);
                    forebetPrediction.CurrentMinute = todayForebetPrediction[7];
                    forebetPrediction.CurrentResult = todayForebetPrediction[8];
                    forebetPredictions.Add(forebetPrediction);
                }

                predictions.TodayPredictions = forebetPredictions;

                var clientYesterday = new RestClient("https://www.forebet.com/en/football-predictions-from-yesterday");
                var requestYesterday = new RestRequest(Method.GET);
                var responseYesterday = await clientYesterday.ExecuteTaskAsync(requestYesterday).ConfigureAwait(false);
                var docYesterday = new HtmlDocument();
                docYesterday.LoadHtml(responseYesterday.Content);

                var yesterdayForebetPredictions = docYesterday.DocumentNode
                    .SelectSingleNode("//table[@class='schema tblen']").Descendants("tr").Skip(2)
                    .Where(tr => tr.Elements("td").Count() > 1).Select(
                        tr => tr.Elements("td").Select(
                            td => td.InnerText.Trim() + "\n" + this.FindTextBetween(
                                      td.OuterHtml,
                                      "<a class=\"tnmscn\" itemprop=\"url\" href=\"",
                                      "\">")).ToList()).ToList();

                var forebetPredictionsYesterday = new List<ForebetPrediction1X2>();

                foreach (var yesterdayPrediction in yesterdayForebetPredictions)
                {
                    // Remove tabs and whitespaces
                    var firstRowData = yesterdayPrediction.First().Replace(
                        "\t",
                        string.Empty,
                        StringComparison.OrdinalIgnoreCase);
                    firstRowData = firstRowData.Replace(" ", string.Empty, StringComparison.OrdinalIgnoreCase);

                    var forebetPrediction = new ForebetPrediction1X2();
                    var dataArraySplit = firstRowData.Split("\n");
                    var yesterdayPredictionDataFieldsCount = yesterdayPrediction.Count;

                    forebetPrediction.LeagueCode = dataArraySplit.First();
                    forebetPrediction.HomeTeam = dataArraySplit[3];
                    forebetPrediction.AwayTeam = dataArraySplit[4];
                    forebetPrediction.Head2HeadUrl = "https://www.forebet.com" + dataArraySplit[7];
                    forebetPrediction.HomeWinProbability = yesterdayPredictionDataFieldsCount - 1 > 1
                                                               ? int.Parse(yesterdayPrediction[1], CultureInfo.InvariantCulture) : 0;

                    forebetPrediction.DrawProbability = int.Parse(yesterdayPrediction[2], CultureInfo.InvariantCulture);
                    forebetPrediction.AwayTeamProbability = int.Parse(
                        yesterdayPrediction[3],
                        CultureInfo.InvariantCulture);
                    forebetPrediction.Prediction = yesterdayPrediction[4].GetWinDrawWin();
                    forebetPrediction.CorrectScore = yesterdayPrediction[5];
                    forebetPrediction.Odds = double.Parse(yesterdayPrediction[6], CultureInfo.InvariantCulture);
                    forebetPrediction.CurrentMinute = yesterdayPrediction[10];
                    forebetPrediction.FinalScore = yesterdayPredictionDataFieldsCount - 1 > 11
                                                       ? yesterdayPrediction[11]
                                                       : string.Empty;
                    forebetPredictionsYesterday.Add(forebetPrediction);
                }

                predictions.YesterdayPredictions = forebetPredictionsYesterday;
                return predictions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}