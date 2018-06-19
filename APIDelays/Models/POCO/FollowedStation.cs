using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.POCO
{
    public class FollowedStation
    {
        public int Id { get; set; }
        public string stationName { get; set; }
        [JsonIgnore]
        public virtual User user { get; set; }
    }
}