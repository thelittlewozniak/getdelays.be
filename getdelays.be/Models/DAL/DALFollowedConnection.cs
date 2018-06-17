﻿using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.DAL
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
            var f = (from FollowedConnection fo in context.FollowedConnections where fo.user == u select fo).ToList();
            return f;
        }
        public FollowedConnection GetFollowedConnection(int idFollowedConnection)
        {
            var f = (from FollowedConnection fo in context.FollowedConnections where fo.Id == idFollowedConnection select fo).First();
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
            var c = (from FollowedConnection fo in context.FollowedConnections where fo == OldConnection select fo).First();
            c = newConnection;
            context.SaveChanges();
        }
    }
}