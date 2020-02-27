namespace BlazorApp1.Models.Predictions.Types
{
    public class OverUnder : PredictionEnumeration
    {
        public static readonly OverUnder Over2_5 = new OverUnder(1, "Over2_5");

        public static readonly OverUnder Under2_5 = new OverUnder(2, "Under2_5");

        protected OverUnder(int id, string name)
            : base(id, name)
        {
        }
    }
}