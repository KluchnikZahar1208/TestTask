using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    class User
    {
        public class Root
        {
            [JsonProperty("rank")]
            public int Rank { get; set; }
            [JsonProperty("user")]
            public string User { get; set; }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("steps")]
            public int Steps { get; set; }
            public Root(int rank, string user, string status, int steps)
            {
                Rank = rank;
                User = user;
                Status = status;
                Steps = steps;
            }
        }
    }
}
