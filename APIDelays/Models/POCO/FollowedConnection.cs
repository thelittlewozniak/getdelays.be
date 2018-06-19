using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.POCO
{
    public class FollowedConnection
    {
        public int Id { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime DateTime { get; set; }
        public bool repeat { get; set; }

        [JsonIgnore]
        public virtual User user { get; set; }
        public virtual List<Day> days { get; set; }
    }
}