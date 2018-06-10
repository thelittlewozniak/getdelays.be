using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.APIGOOGLE
{
    public class Result
    {
        public List<ComponentAddress> address_components { get; set; }
        public Hours opening_hours { get; set; }
        public double rating { get; set; }
        public List<Review> reviews { get; set; }
        public string place_id { get; set; }
    }
}