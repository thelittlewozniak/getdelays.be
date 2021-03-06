﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.getdelays.POCO
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int phoneNumber { get; set; }
        public virtual List<FollowedStation> followedStations { get; set; }
        public virtual List<FollowedConnection> followedConnections { get; set; }
        //public User()
        //{
        //    followedConnections = new List<FollowedConnection>();
        //    followedStations = new List<FollowedStation>();
        //}
    }
}