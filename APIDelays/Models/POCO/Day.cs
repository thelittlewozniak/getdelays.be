using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace api.getdelays.POCO
{
    public class Day
    {
        public int Id { get; set; }
        public string dayName { get; set; }
        [JsonIgnore]
        public virtual FollowedConnection followedConnection { get; set; }
    }
}