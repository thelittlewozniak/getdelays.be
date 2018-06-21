using api.getdelays.POCO;
using api.getdelays.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIGetDelays.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public User Login(string email, string password)
        {
            IUser user = new DALUser();
            User testUserInformation = user.Login(email, password);
            if (testUserInformation == null)
            {
                return null;
            }
            else
            {
                return testUserInformation;
            }
        }
        [HttpPost]
        public User MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            IUser userDAL = new DALUser();
            if (userDAL.GetUser(email) == null)
            {
                User user = new User { name = name, surname = surname, email = email, password = password, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.AddUser(user);
                return user;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public bool DeleteUser(string userid)
        {
            IUser userDAL = new DALUser();
            User user = userDAL.GetUser(Convert.ToInt32(userid));
            if (user == null)
            {
                return false;
            }
            else
            {
                userDAL.DeleteUser(user);
                return true;
            }
        }
        [HttpPost]
        public User UpdateUser(string email, string name, string surname, string phoneNumber,string userid)
        {
            IUser userDAL = new DALUser();
            User user = userDAL.GetUser(Convert.ToInt32(userid));
            if (user == null)
            {
                return null;
            }
            else
            {
                User newUser = new User { name = name, surname = surname, email = email, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.UpdateUser(user, newUser);
                return newUser;
            }
        }
        [HttpPost]
        public User FollowStation(string station, string userid)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            IUser userDAL = new DALUser();
            User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                followedStation.AddFollowedStation(new FollowedStation { stationName = station, user = u });
                u.followedStations=followedStation.GetFollowedStations();
                return u;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public User DeleteFollowStation(string station,string userid)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            IUser userDAL = new DALUser();
            User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                FollowedStation f = followedStation.GetFollowedStation(station, u);
                followedStation.DeleteFollowedStation(f);
                u.followedStations = followedStation.GetFollowedStations();
                return u;
            }
            else
            {
                return null;
            }
        }
    }
}
