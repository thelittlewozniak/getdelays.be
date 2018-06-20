using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class StationData
    {
        public string id { get; set; }
        public double locationX { get; set; }
        public double locationY { get; set; }
        public string name { get; set; }
        public List<string> opening_hours { get; set; }
        public double rating { get; set; }
        public List<Review> reviews { get; set; }
        public StationData()
        {
            opening_hours = new List<string>();
            reviews = new List<Review>();
        }
    }
}
