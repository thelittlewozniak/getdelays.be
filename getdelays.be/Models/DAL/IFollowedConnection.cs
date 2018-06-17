using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getdelays.be.Models.DAL
{
    interface IFollowedConnection:IDAL
    {
        List<FollowedConnection> GetFollowedConnections();
        List<FollowedConnection> GetFollowedConnections(User u);
        FollowedConnection GetFollowedConnection(int idFollowedConnection);
        void AddFollowedConnection(FollowedConnection c);
        void DeleteFollowedConnection(FollowedConnection c);
        void UpdateFollowedConnection(FollowedConnection OldConnection, FollowedConnection newConnection);
    }
}
