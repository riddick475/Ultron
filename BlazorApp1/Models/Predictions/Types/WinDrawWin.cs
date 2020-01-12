namespace BlazorApp1.Models.Predictions.Types
{
    public class WinDrawWin : PredictionEnumeration
    {
        public static readonly WinDrawWin HomeTeamWin = new WinDrawWin(1, "HomeTeamWin");
        public static readonly WinDrawWin Draw = new WinDrawWin(2, "Draw");
        public static readonly WinDrawWin AwayTeamWin = new WinDrawWin(3, "AwayTeamWin");
        protected WinDrawWin(int id, string name) : base(id, name)
        {
        }
    }
}
