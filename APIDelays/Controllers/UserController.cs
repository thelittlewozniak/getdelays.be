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
        [HttpGet]
        public string Login(string email, string password)
        {
            IUser user = new DALUser();
            User testUserInformation = user.Login(email, password);
            if (testUserInformation == null)
            {
                return JsonConvert.SerializeObject("Email or password incorrect.");
            }
            else
            {
                return JsonConvert.SerializeObject(testUserInformation);
            }
        }
        [HttpGet]
        public string MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            IUser userDAL = new DALUser();
            if (userDAL.GetUser(email) == null)
            {
                User user = new User { name = name, surname = surname, email = email, password = password, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.AddUser(user);
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                return JsonConvert.SerializeObject("An account is already link to this email.");
            }
        }
        [HttpGet]
        public bool DeleteUser(User user)
        {
            IUser userDAL = new DALUser();
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
        [HttpGet]
        public string UpdateUser(string email, string name, string surname, string phoneNumber,User user)
        {
            IUser userDAL = new DALUser();
            if (user == null)
            {
                return null;
            }
            else
            {
                User newUser = new User { name = name, surname = surname, email = email, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.UpdateUser(user, newUser);
                return JsonConvert.SerializeObject(newUser);
            }
        }
        [HttpGet]
        public string FollowStation(string station, User u)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            if (u != null)
            {
                followedStation.AddFollowedStation(new FollowedStation { stationName = station, user = u });
                u.followedStations=followedStation.GetFollowedStations();
                return JsonConvert.SerializeObject(u);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public string DeleteFollowStation(string station,User u)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            if (u != null)
            {
                FollowedStation f = followedStation.GetFollowedStation(station, u);
                followedStation.DeleteFollowedStation(f);
                u.followedStations = followedStation.GetFollowedStations();
                return JsonConvert.SerializeObject(u);
            }
            else
            {
                return null;
            }
        }
    }
}
