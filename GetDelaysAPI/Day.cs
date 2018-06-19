using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETDELAYSAPI
{
    public class Day
    {
        public int Id { get; set; }
        public string dayName { get; set; }
        public virtual FollowedConnection followedConnection { get; set; }
    }
}