namespace getdelays.be.Migrations
{
    using getdelays.be.Models.POCO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<getdelays.be.Models.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(getdelays.be.Models.DAL.Context context)
        {
            //var u = new List<User>
            //{
            //    new User { name = "Nathan", surname="Pire",email="nathan.pire@gmail.com",password="azerty"},
            //};
            //u.ForEach(s => context.Users.AddOrUpdate(p => p.surname, s));
            //context.SaveChanges();
            //var d = new List<Day>
            //{
            //    new Day {dayName="Lundi"},
            //    new Day {dayName="Mardi"},
            //    new Day {dayName="Mercredi"},
            //    new Day {dayName="Jeudi"},
            //    new Day {dayName="Vendredi"},
            //    new Day {dayName="Samedi"},
            //    new Day {dayName="Dimanche"},
            //};
            //d.ForEach(da => context.Days.AddOrUpdate(dd => dd.dayName, da));
            //context.SaveChanges();
        }
    }
}
