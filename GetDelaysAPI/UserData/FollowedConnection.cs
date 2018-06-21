using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetDelaysAPI
{
    public class FollowedConnection
    {
        public int Id { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime DateTime { get; set; }
        public virtual User user { get; set; }
        public bool repeat { get; set; }
        public virtual List<Day> days { get; set; }
    }
}