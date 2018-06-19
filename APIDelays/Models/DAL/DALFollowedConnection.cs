using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.DAL
{
    public class DALFollowedConnection:IFollowedConnection
    {
        private Context context;
        public DALFollowedConnection()
        {
            context = Context.Instance();
        }
        public List<FollowedConnection> GetFollowedConnections()
        {
            return context.FollowedConnections.ToList();
        }
        public List<FollowedConnection> GetFollowedConnections(User u)
        {
            var f = (from FollowedConnection fo in context.FollowedConnections where fo.user.Id == u.Id select fo).ToList();
            return f;
        }
        public FollowedConnection GetFollowedConnection(int idFollowedConnection)
        {
            var f = (from FollowedConnection fo in context.FollowedConnections where fo.Id == idFollowedConnection select fo).FirstOrDefault();
            return f;
        }
        public void AddFollowedConnection(FollowedConnection c)
        {
            context.FollowedConnections.Add(c);
            context.SaveChanges();
        }
        public void DeleteFollowedConnection(FollowedConnection c)
        {
            context.FollowedConnections.Remove(c);
            context.SaveChanges();
        }
        public void UpdateFollowedConnection(FollowedConnection OldConnection,FollowedConnection newConnection)
        {
            var c = (from FollowedConnection fo in context.FollowedConnections where fo == OldConnection select fo).FirstOrDefault();
            c = newConnection;
            context.SaveChanges();
        }
    }
}