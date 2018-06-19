using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.getdelays.DAL
{
    interface IFollowedConnection
    {
        List<FollowedConnection> GetFollowedConnections();
        List<FollowedConnection> GetFollowedConnections(User u);
        FollowedConnection GetFollowedConnection(int idFollowedConnection);
        void AddFollowedConnection(FollowedConnection c);
        void DeleteFollowedConnection(FollowedConnection c);
        void UpdateFollowedConnection(FollowedConnection OldConnection, FollowedConnection newConnection);
    }
}
