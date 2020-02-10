using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models.Predictions
{
    public class ForebetPrediction1X2
    {
        [Key] public int PredictionId { get; set; }

        public string LeagueCode { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeWinProbability { get; set; }
        public int DrawProbability { get; set; }
        public int AwayTeamProbability { get; set; }
        public int Prediction { get; set; }
        public string CorrectScore { get; set; }
        public double AverageGoals { get; set; }
        public int Temperature { get; set; }
        public double Odds { get; set; }

        public string? CurrentMinute { get; set; }
        public string? CurrentResult { get; set; }
    }
}