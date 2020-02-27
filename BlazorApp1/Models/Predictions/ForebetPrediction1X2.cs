namespace BlazorApp1.Models.Predictions
{
    using System.ComponentModel.DataAnnotations;

    public class ForebetPrediction1X2
    {
        public double AverageGoals { get; set; }

        public string AwayTeam { get; set; }

        public int AwayTeamProbability { get; set; }

        public string? CorrectScore { get; set; }

        public string? CurrentMinute { get; set; }

        public string? CurrentResult { get; set; }

        public int DrawProbability { get; set; }

        public string? FinalScore { get; set; }

        public string? Head2HeadUrl { get; set; }

        public string HomeTeam { get; set; }

        public int HomeWinProbability { get; set; }

        public string LeagueCode { get; set; }

        public double Odds { get; set; }

        public int Prediction { get; set; }

        [Key]
        public int PredictionId { get; set; }

        public int Temperature { get; set; }
    }
}