using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNCBAPI
{
    public class ArrDep
    {
        public int id { get; set; }
        public int delay { get; set; }
        public string station { get; set; }
        public int time { get; set; }
        public string vehicle { get; set; }
        public string tForView { get; set; }
    }
}