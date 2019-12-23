using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Models.Fixtures;
using Newtonsoft.Json;
using RestSharp;

namespace BlazorApp1.Data
{
    public class WeatherForecastService
    {
        private readonly UltronContext context;

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(UltronContext context)
        {
            this.context = context;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            try
            {
                var client =
                    new RestClient(
                        $"https://api-football-v1.p.rapidapi.com/v2/fixtures/date/{DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "zIK6YrpYwYmshLl2FBDvVTt5ag8ep1OsaPejsnZlrsiOhoDpkT");
                var response = client.Execute(request);
                var serializedResponse = JsonConvert.DeserializeObject<Rootobject>(response.Content);

                context.Fixtures.AddRange(serializedResponse.Api.Fixtures);
                context.SaveChanges();
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