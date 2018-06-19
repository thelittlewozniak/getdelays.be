using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.DAL
{
    public class DALDay:IDay
    {
        private Context context;
        public DALDay()
        {
            context = Context.Instance();
        }
        public List<Day> GetDays()
        {
            return context.Days.ToList();
        }
        public Day GetDay(string dayname)
        {
            var d = (from Day day in context.Days where day.dayName == dayname select day).FirstOrDefault();
            return d;
        }
    }
}