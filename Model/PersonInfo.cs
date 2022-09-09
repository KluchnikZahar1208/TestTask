using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public int AvgSteps { get; set; }

        public PersonInfo(string name, int avgSteps)
        {
            Name = name;
            AvgSteps = avgSteps;
        }
    }
}
