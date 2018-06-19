using api.getdelays.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.DAL
{
    interface IFollowedStation
    {
        List<FollowedStation> GetFollowedStations();
        List<FollowedStation> GetFollowedStations(User u);
        FollowedStation GetFollowedStation(string stationName,User u);
        void AddFollowedStation(FollowedStation followedStation);
        void DeleteFollowedStation(FollowedStation followedStation);
    }
}