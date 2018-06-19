using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using api.getdelays.POCO;

namespace api.getdelays.DAL
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FollowedStation> FollowedStations { get; set; }
        public DbSet<FollowedConnection> FollowedConnections { get; set; }
        public DbSet<Day> Days { get; set; }
        private static Context instance;
        public Context() { }
        public static Context Instance()
        {
            if(instance==null)
            {
                instance = new Context();
            }
            return instance;
        }
    }
}