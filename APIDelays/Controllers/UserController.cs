using api.getdelays.POCO;
using api.getdelays.DAL;
using GetDelaysAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SNCBAPI;

namespace APIGetDelays.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public api.getdelays.POCO.User GetUser(string email)
        {
            IUser user = new DALUser();
            api.getdelays.POCO.User testUserInformation = user.GetUser(email);
            if (testUserInformation == null)
            {
                return null;
            }
            else
            {
                return testUserInformation;
            }
        }
        [HttpGet]
        public List<api.getdelays.POCO.User> GetUsers()
        {
            IUser user = new DALUser();
            List<api.getdelays.POCO.User> users = user.GetUsers();
            foreach (api.getdelays.POCO.User u in users)
            {
                u.followedConnections = null;
                u.followedStations = null;
                u.Id = 0;
                u.name = "";
                u.password = "";
                u.phoneNumber = 0;
                u.surname = "";
            }
            return users;
        }
        [HttpGet]
        public api.getdelays.POCO.User Login(string email, string password)
        {
            IUser user = new DALUser();
            api.getdelays.POCO.User testUserInformation = user.Login(email, password);
            if (testUserInformation == null)
            {
                return null;
            }
            else
            {
                return testUserInformation;
            }
        }
        [HttpGet]
        public api.getdelays.POCO.User MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            IUser userDAL = new DALUser();
            if (userDAL.GetUser(email) == null)
            {
                api.getdelays.POCO.User user = new api.getdelays.POCO.User { name = name, surname = surname, email = email, password = password, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.AddUser(user);
                return user;
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public bool DeleteUser(string userid)
        {
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User user = userDAL.GetUser(Convert.ToInt32(userid));
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
        public api.getdelays.POCO.User UpdateUser(string name, string surname, string phoneNumber, string userid)
        {
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User user = userDAL.GetUser(Convert.ToInt32(userid));
            if (user == null)
            {
                return null;
            }
            else
            {
                api.getdelays.POCO.User newUser = new api.getdelays.POCO.User {Id=Convert.ToInt32(userid), name = name, surname = surname, email = user.email, phoneNumber = Convert.ToInt32(phoneNumber),followedConnections=user.followedConnections,followedStations=user.followedStations };
                userDAL.UpdateUser(user, newUser);
                return newUser;
            }
        }
        [Route("api/User/FollowStation")]
        [HttpGet]
        public api.getdelays.POCO.User FollowStation(string station, string userid)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                followedStation.AddFollowedStation(new api.getdelays.POCO.FollowedStation { stationName = station, user = u });
                u.followedStations = followedStation.GetFollowedStations();
                return u;
            }
            else
            {
                return null;
            }
        }
        [Route("api/User/DeleteFollowStation")]
        [HttpGet]
        public api.getdelays.POCO.User DeleteFollowStation(string userid, string station)
        {
            IFollowedStation followedStation = new DALFollowedStation();
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                api.getdelays.POCO.FollowedStation f = followedStation.GetFollowedStation(station, u);
                followedStation.DeleteFollowedStation(f);
                u.followedStations = followedStation.GetFollowedStations();
                return u;
            }
            else
            {
                return null;
            }
        }
        [Route("api/User/FollowConnection")]
        [HttpGet]
        public api.getdelays.POCO.User FollowConnection(string arrival, string departure, string time, string userid, string repeat)
        {
            IFollowedConnection followedConnection = new DALFollowedConnection();
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                followedConnection.AddFollowedConnection(new api.getdelays.POCO.FollowedConnection { departure = departure, arrival = arrival, DateTime = Convert.ToDateTime(time), repeat = Convert.ToBoolean(repeat), user = u });
                u.followedConnections = followedConnection.GetFollowedConnections(u);
                return u;
            }
            else
            {
                return null;
            }
        }
        [Route("api/User/DeleteFollowConnection")]
        [HttpGet]
        public api.getdelays.POCO.User DeleteFollowConnection(string userid, string idConnection)
        {
            IFollowedConnection followedConnection = new DALFollowedConnection();
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            if (u != null)
            {
                api.getdelays.POCO.FollowedConnection f = followedConnection.GetFollowedConnection(Convert.ToInt32(idConnection));
                followedConnection.DeleteFollowedConnection(f);
                u.followedConnections = followedConnection.GetFollowedConnections(u);
                return u;
            }
            else
            {
                return null;
            }
        }
        [Route("api/User/GetNotificationStations")]
        [HttpGet]
        public List<NotificationStation> GetNotificationStations(string userid)
        {
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            List<NotificationStation> listS = new List<NotificationStation>();
            IGetAll newaccessapi = SNCBAPI.GetAll.Instance();
            DateTime now = DateTime.UtcNow;
            now = now.AddHours(2);
            if (u != null)
            {
                foreach (api.getdelays.POCO.FollowedStation s in u.followedStations)
                {
                    int delays = 0;
                    DataApiPerStations stat = newaccessapi.GetDelaysForStation(s.stationName);
                    foreach (SNCBAPI.ArrDep arrdep in stat.arrivals.arrival)
                    {
                        DateTime hourTrain = new DateTime();
                        hourTrain = hourTrain.AddHours(2);
                        hourTrain = hourTrain.AddSeconds(arrdep.time);
                        hourTrain = hourTrain.AddMinutes(arrdep.delay);
                        if (now.TimeOfDay < hourTrain.TimeOfDay)
                        {
                            delays += arrdep.delay;
                        }
                    }
                    foreach (SNCBAPI.ArrDep arrdep in stat.departures.departure)
                    {
                        DateTime hourTrain = new DateTime();
                        hourTrain = hourTrain.AddHours(2);
                        hourTrain = hourTrain.AddSeconds(arrdep.time);
                        hourTrain = hourTrain.AddMinutes(arrdep.delay);
                        if (now.TimeOfDay < hourTrain.TimeOfDay)
                        {
                            delays += arrdep.delay;
                        }
                    }
                    if (delays >= 15 && delays <30)
                    {
                        listS.Add(new NotificationStation { StationName = s.stationName, Delays = delays, Priority = "warning" });
                    }
                    else if(delays<15 && delays>0)
                    {
                        listS.Add(new NotificationStation { StationName = s.stationName, Delays = delays, Priority = "normal" });
                    }
                    else if(delays>=30)
                    {
                        listS.Add(new NotificationStation { StationName = s.stationName, Delays = delays, Priority = "danger" });
                    }
                }
                return listS;
            }
            else
            {
                return null;
            }
        }
        [Route("api/User/GetNotificationConnection")]
        [HttpGet]
        public List<NotificationConnection> GetNotificationConnections(string userid)
        {
            IUser userDAL = new DALUser();
            api.getdelays.POCO.User u = userDAL.GetUser(Convert.ToInt32(userid));
            List<NotificationConnection> listS = new List<NotificationConnection>();
            IGetAll newaccessapi = SNCBAPI.GetAll.Instance();
            DateTime now = DateTime.UtcNow;
            now = now.AddHours(2);
            if (u != null)
            {
                foreach (api.getdelays.POCO.FollowedConnection s in u.followedConnections)
                {
                    DataApiConnection stat = newaccessapi.GetConnection(s.departure,s.arrival,s.DateTime);
                    foreach (SNCBAPI.Connection c in stat.connection)
                    {
                        DateTime hourTrain = new DateTime();
                        hourTrain = hourTrain.AddHours(2);
                        hourTrain = hourTrain.AddSeconds(c.departure.time);
                        int year = DateTime.Now.Year - hourTrain.Year;
                        hourTrain = hourTrain.AddYears(year);
                        if (s.DateTime.TimeOfDay == hourTrain.TimeOfDay)
                        {
                            hourTrain = hourTrain.AddMinutes(c.departure.delay);
                            if(hourTrain.TimeOfDay>now.TimeOfDay)
                            {
                                if (c.departure.delay >= 15 && c.departure.delay < 30)
                                {
                                    listS.Add(new NotificationConnection { Arrival = s.arrival, Departure = s.departure, DelaysArrival = Convert.ToInt32(c.arrival.delay), DelaysDeparture = Convert.ToInt32(c.departure.delay), Time = hourTrain, Priority = "warning" });
                                }
                                else if (c.departure.delay < 15 && c.departure.delay >= 0)
                                {
                                    listS.Add(new NotificationConnection { Arrival = s.arrival, Departure = s.departure, DelaysArrival = Convert.ToInt32(c.arrival.delay), DelaysDeparture = Convert.ToInt32(c.departure.delay), Time = hourTrain, Priority = "normal" });
                                }
                                else if (c.departure.delay >= 30)
                                {
                                    listS.Add(new NotificationConnection { Arrival = s.arrival, Departure = s.departure, DelaysArrival = Convert.ToInt32(c.arrival.delay), DelaysDeparture = Convert.ToInt32(c.departure.delay), Priority = "danger" });
                                }
                            }
                        }
                    }
                }
                return listS;
            }
            else
            {
                return null;
            }
        }

    }
}
