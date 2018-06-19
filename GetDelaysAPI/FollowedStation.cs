using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETDELAYSAPI
{
    public class FollowedStation
    {
        public int Id { get; set; }
        public string stationName { get; set; }
        public virtual User user { get; set; }
    }
}