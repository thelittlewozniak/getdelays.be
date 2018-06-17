using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace getdelays.be.Models.DAL
{
    public class DALFollowedStation:IFollowedStation
    {
        private Context context;
        public DALFollowedStation()
        {
            context = Context.Instance();
        }
        public List<FollowedStation> GetFollowedStations()
        {
            return context.FollowedStations.ToList();
        }
        public List<FollowedStation> GetFollowedStations(User u)
        {
            var fo = (from FollowedStation f in context.FollowedStations where f.user == u select f).ToList();
            return fo;
        }
        public FollowedStation GetFollowedStation(string stationName,User u)
        {
            var fo = (from FollowedStation f in context.FollowedStations where f.stationName == stationName && f.user.Id==u.Id select f).FirstOrDefault();
            return fo;
        }
        public void AddFollowedStation(FollowedStation followedStation)
        {
            context.FollowedStations.Add(followedStation);
            context.SaveChanges();
        }
        public void DeleteFollowedStation(FollowedStation followedStation)
        {
            context.FollowedStations.Remove(followedStation);
            context.SaveChanges();
        }
    }
}