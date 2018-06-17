using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models.DAL
{
    interface IFollowedStation
    {
        List<FollowedStation> GetFollowedStations();
        List<FollowedStation> GetFollowedStations(User u);
        FollowedConnection GetFollowedConnection(int id);
        void AddFollowedConnection(FollowedConnection followedConnection);
        void DeleteFollowedConnection(FollowedConnection followedConnection);
        void UpdateFollowedConnection(FollowedConnection oldFollowedConnection, FollowedConnection newFollowedConnection);
    }
}