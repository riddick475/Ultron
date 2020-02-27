namespace BlazorApp1.Models.Requests
{
    public class GetHead2HeadRequest
    {
        public int FirstTeamId { get; set; }

        public int SecondTeamId { get; set; }

        public string? Timezone { get; set; }
    }
}