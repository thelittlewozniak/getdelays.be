using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.getdelays.DAL
{
    interface IDay
    {
        List<Day> GetDays();
        Day GetDay(string dayName);
    }
}
