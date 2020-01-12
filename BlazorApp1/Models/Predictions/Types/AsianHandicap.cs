namespace BlazorApp1.Models.Predictions.Types
{
    public class AsianHandicap : PredictionEnumeration
    {
        public static readonly AsianHandicap Minus1_5 = new AsianHandicap(1, "Minus1_5");

        public static readonly AsianHandicap Plus1_5 = new AsianHandicap(2, "Plus1_5");

        protected AsianHandicap(int id, string name) : base(id, name)
        {
        }
    }
}