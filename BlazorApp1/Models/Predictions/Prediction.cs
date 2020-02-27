namespace BlazorApp1.Models.Predictions
{
    using BlazorApp1.Models.Fixtures;
    using BlazorApp1.Models.Predictions.Types;

    public class Prediction
    {
        public decimal CalculatedOptimalStake { get; set; }

        public Fixture Fixture { get; set; }

        public PredictionEnumeration PredictedOutcome { get; set; }

        public int PredictionId { get; set; }
    }
}