using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.POCO
{
    public class FollowedConnection
    {
        public int Id { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime DateTime { get; set; }
        public int idUser { get; set; }
        public virtual User user { get; set; }
    }
}