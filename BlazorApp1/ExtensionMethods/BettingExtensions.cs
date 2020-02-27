namespace BlazorApp1.ExtensionMethods
{
    public static class BettingExtensions
    {
        public static int GetWinDrawWin(this string prediction)
        {
            return prediction switch
                {
                    "1" => 1,
                    "2" => 2,
                    "x" => 0,
                    "X" => 0,
                    _ => -1
                };
        }
    }
}