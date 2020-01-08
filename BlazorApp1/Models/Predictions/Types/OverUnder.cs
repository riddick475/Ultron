namespace BlazorApp1.Models.Predictions.Types
{
    public class OverUnder : PredictionEnumeration
    {
        public static OverUnder Over2And5 = new OverUnder(1, "Over2And5");

        protected OverUnder(int id, string name) : base(id, name)
        {
        }
    }
}
