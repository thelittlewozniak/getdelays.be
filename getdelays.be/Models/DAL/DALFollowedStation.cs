using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public FollowedConnection GetFollowedConnection(int id)
        {
            var fo = (from FollowedConnection f in context.FollowedConnections where f.Id == id select f).First();
            return fo;
        }
        public void AddFollowedConnection(FollowedConnection followedConnection)
        {
            context.FollowedConnections.Add(followedConnection);
            context.SaveChanges();
        }
        public void DeleteFollowedConnection(FollowedConnection followedConnection)
        {
            context.FollowedConnections.Remove(followedConnection);
            context.SaveChanges();
        }
        public void UpdateFollowedConnection(FollowedConnection oldFollowedConnection, FollowedConnection newFollowedConnection)
        {
            var fo = (from FollowedConnection f in context.FollowedConnections where f == oldFollowedConnection select f).First();
            fo = newFollowedConnection;
            context.SaveChanges();
        }
    }
}