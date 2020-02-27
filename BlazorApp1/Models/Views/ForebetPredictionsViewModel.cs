namespace BlazorApp1.Models.Views
{
    using System.Collections.Generic;

    using BlazorApp1.Models.Predictions;

    /// <summary>
    /// The forebet predictions view model.
    /// </summary>
    public class ForebetPredictionsViewModel
    {
        /// <summary>
        /// Gets or sets the yesterday predictions.
        /// </summary>
        public List<ForebetPrediction1X2> YesterdayPredictions { get; set; }

        /// <summary>
        /// Gets or sets the today predictions.
        /// </summary>
        public List<ForebetPrediction1X2> TodayPredictions { get; set; }
    }
}
