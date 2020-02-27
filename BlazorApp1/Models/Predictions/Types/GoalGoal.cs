namespace BlazorApp1.Models.Predictions.Types
{
    public class GoalGoal : PredictionEnumeration
    {
        public static readonly GoalGoal No = new GoalGoal(2, "No");

        public static readonly GoalGoal Yes = new GoalGoal(1, "Yes");

        protected GoalGoal(int id, string name)
            : base(id, name)
        {
        }
    }
}