using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlazorApp1.Models.Responses
{
    public class Head2HeadResponse
    {
        public Api api { get; set; }
    }

    public class Api
    {
        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams { get; set; }
        [JsonProperty(PropertyName = "results")]
        public int Results { get; set; }
        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture>? Fixtures { get; set; }
    }

    public class Team
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string team_logo { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Statistics
    {
        public Played played { get; set; }
        public Wins wins { get; set; }
        public Draws draws { get; set; }
        public Loses loses { get; set; }
    }

    public class Played
    {
        public int home { get; set; }
        public int away { get; set; }
        public int total { get; set; }
    }

    public class Wins
    {
        public int home { get; set; }
        public int away { get; set; }
        public int total { get; set; }
    }

    public class Draws
    {
        public int home { get; set; }
        public int away { get; set; }
        public int total { get; set; }
    }

    public class Loses
    {
        public int home { get; set; }
        public int away { get; set; }
        public int total { get; set; }
    }

    public class Fixture
    {
        public int fixture_id { get; set; }
        public int league_id { get; set; }
        public League league { get; set; }
        public DateTime event_date { get; set; }
        public int event_timestamp { get; set; }
        public object firstHalfStart { get; set; }
        public object secondHalfStart { get; set; }
        public string round { get; set; }
        public string status { get; set; }
        public string statusShort { get; set; }
        public int elapsed { get; set; }
        public string venue { get; set; }
        public object referee { get; set; }
        public Hometeam homeTeam { get; set; }
        public Awayteam awayTeam { get; set; }
        public int goalsHomeTeam { get; set; }
        public int goalsAwayTeam { get; set; }
        public Score score { get; set; }
    }

    public class League
    {
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
    }

    public class Hometeam
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string logo { get; set; }
    }

    public class Awayteam
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string logo { get; set; }
    }

    public class Score
    {
        public string halftime { get; set; }
        public string fulltime { get; set; }
        public object extratime { get; set; }
        public object penalty { get; set; }
    }
}