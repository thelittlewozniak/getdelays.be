﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SNCBAPI
{
    public class ViaInfo
    {
        public ArrivalVia arrival { get; set; }
        public ArrivalVia departure { get; set; }
        public double timeBetween { get; set; }
        public string station { get; set; }
    }
}
