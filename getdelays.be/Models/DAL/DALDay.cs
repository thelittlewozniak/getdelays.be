using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.DAL
{
    public class DALDay
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
        public Day GetDay(int Id)
        {
            var d = (from Day day in context.Days where day.Id == Id select day).First();
            return d;
        }
    }
}