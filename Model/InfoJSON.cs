using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;


namespace TestTask.Model
{
    internal class InfoJSON
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Status { get; set; }
        public int AvgSteps { get; set; }
        public int MaxCountSteps { get; set; }
        public int MinCountSteps { get; set; }
        public InfoJSON (string name, string rank, string status, int avgSteps, int maxCount, int minCount)
        {
            this.Name = name;
            this.Rank = rank;
            this.Status = status;
            this.AvgSteps = avgSteps;
            this.MaxCountSteps = maxCount;
            this.MinCountSteps = minCount;
        }
        public void ToJSON()
        {
           string json = JsonSerializer.Serialize(this,options);
           File.WriteAllText(@"E:\Универ\TestTask\TestTask\PersonsInfo.json", json);
        }
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
    }
}
