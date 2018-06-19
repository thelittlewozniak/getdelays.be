using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNCBAPI
{
    public class ArrsDeps
    {
        public int number { get; set; }
        public List<ArrDep> arrival { get; set; }
        public List<ArrDep> departure { get; set; }
    }
}