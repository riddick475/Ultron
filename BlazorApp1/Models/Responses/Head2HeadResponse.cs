namespace BlazorApp1.Models.Responses
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Head2HeadResponse
    {
        public Api api { get; set; }
    }

    public class Api
    {
        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture>? Fixtures { get; set; }

        [JsonProperty(PropertyName = "results")]
        public int Results { get; set; }

        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams { get; set; }
    }

    public class Team
    {
        public Statistics statistics { get; set; }

        public int team_id { get; set; }

        public string team_logo { get; set; }

        public string team_name { get; set; }
    }

    public class Statistics
    {
        public Draws draws { get; set; }

        public Loses loses { get; set; }

        public Played played { get; set; }

        public Wins wins { get; set; }
    }

    public class Played
    {
        public int away { get; set; }

        public int home { get; set; }

        public int total { get; set; }
    }

    public class Wins
    {
        public int away { get; set; }

        public int home { get; set; }

        public int total { get; set; }
    }

    public class Draws
    {
        public int away { get; set; }

        public int home { get; set; }

        public int total { get; set; }
    }

    public class Loses
    {
        public int away { get; set; }

        public int home { get; set; }

        public int total { get; set; }
    }

    public class Fixture
    {
        public Awayteam awayTeam { get; set; }

        public int elapsed { get; set; }

        public DateTime event_date { get; set; }

        public int event_timestamp { get; set; }

        public object firstHalfStart { get; set; }

        public int fixture_id { get; set; }

        public int goalsAwayTeam { get; set; }

        public int goalsHomeTeam { get; set; }

        public Hometeam homeTeam { get; set; }

        public League league { get; set; }

        public int league_id { get; set; }

        public object referee { get; set; }

        public string round { get; set; }

        public Score score { get; set; }

        public object secondHalfStart { get; set; }

        public string status { get; set; }

        public string statusShort { get; set; }

        public string venue { get; set; }
    }

    public class League
    {
        public string country { get; set; }

        public string flag { get; set; }

        public string logo { get; set; }

        public string name { get; set; }
    }

    public class Hometeam
    {
        public string logo { get; set; }

        public int team_id { get; set; }

        public string team_name { get; set; }
    }

    public class Awayteam
    {
        public string logo { get; set; }

        public int team_id { get; set; }

        public string team_name { get; set; }
    }

    public class Score
    {
        public object extratime { get; set; }

        public string fulltime { get; set; }

        public string halftime { get; set; }

        public object penalty { get; set; }
    }
}