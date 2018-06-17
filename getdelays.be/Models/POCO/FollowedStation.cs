using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.POCO
{
    public class FollowedStation
    {
        public int Id { get; set; }
        public string stationName { get; set; }
        public virtual User user { get; set; }
    }
}