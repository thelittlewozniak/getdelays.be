using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getdelays.be.Models.DAL
{
    interface IDay
    {
        List<Day> GetDays();
        Day GetDay(string dayName);
    }
}
