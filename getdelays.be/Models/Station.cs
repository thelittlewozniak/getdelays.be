using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models
{
    public class Station
    {
        public string id { get; set; }
        public double locationX { get; set; }
        public double locationY { get; set; }
        public string standardname { get; set; }
        public string name { get; set; }
    }
}