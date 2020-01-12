using BlazorApp1.Models.Fixtures;
using BlazorApp1.Models.Predictions.Types;

namespace BlazorApp1.Models.Predictions
{
    public class Prediction
    {
        public int PredictionId { get; set; }

        public PredictionEnumeration PredictedOutcome { get; set; }

        public decimal CalculatedOptimalStake { get; set; }

        public Fixture Fixture { get; set; }
    }
}
