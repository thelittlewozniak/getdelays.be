﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getdelays.be.Models.APIGOOGLE
{
    interface IGetAPIGoogle
    {
        DetailsPlace GetInfo(string location);
    }
}