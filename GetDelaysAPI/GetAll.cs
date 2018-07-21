using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class GetAll:IAPI
    {
        public User GetUser(string email)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/GetUser?email="+email;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if(dataAPI!=null && dataAPI.followedStations!=null && dataAPI.followedStations.Count>= 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count >= 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public User Login(string email,string password)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/Login?email="+email+"&password="+password;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if(dataAPI!=null && dataAPI.followedStations!=null && dataAPI.followedStations.Count>= 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count >= 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public User MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            string url = string.Concat("http://apigetdelays.azurewebsites.net/api/User/MakeAccount?email="+email+"&name="+name+"&surname="+surname+"&password="+password+"&phoneNumber="+phoneNumber);
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        //public bool DeleteUser(User user)
        //{
        //    string url = "http://apigetdelays.azurewebsites.net/api/User/DeleteUser?userid="+user.Id;
        //    var json = new WebClient().DownloadString(url);
        //    var dataAPI = JsonConvert.DeserializeObject<bool>(json);
        //    return dataAPI;
        //}
        public User UpdateUser(string name, string surname, string phoneNumber, User user)
        {
            string url = string.Concat("http://apigetdelays.azurewebsites.net/api/User/UpdateUser?name="+name+"&surname="+surname+"&phoneNumber="+phoneNumber+"&userid="+user.Id);
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        public User FollowStation(string station, User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/FollowStation?station="+station+"&userid="+user.Id;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if (dataAPI != null && dataAPI.followedStations != null && dataAPI.followedStations.Count >= 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count >= 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public User DeleteFollowStation(string station, User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/DeleteFollowStation?station="+station+"&userid="+user.Id;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if (dataAPI != null && dataAPI.followedStations != null && dataAPI.followedStations.Count >= 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count >= 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public User FollowConnection(string arrival, string departure, string time, string repeat, User user)
        {
            DateTime datetime = new DateTime();
            datetime=datetime.AddSeconds(Convert.ToInt32(time));
            int year = DateTime.Now.Year - datetime.Year;
            datetime = datetime.AddYears(year);
            datetime = datetime.AddHours(2);
            string url = string.Concat("http://apigetdelays.azurewebsites.net/api/User/FollowConnection?arrival=" + arrival + "&departure=" + departure + "&time=" + datetime + "&repeat=" + repeat + "&userid=" + user.Id);
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if (dataAPI != null && dataAPI.followedStations != null && dataAPI.followedStations.Count > 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count > 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public User DeleteFollowConnection(string idConnection,User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/DeleteFollowConnection?idConnection=" + idConnection + "&userid=" + user.Id;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            if (dataAPI != null && dataAPI.followedStations != null && dataAPI.followedStations.Count > 1)
            {
                foreach (FollowedStation s in dataAPI.followedStations)
                {
                    s.stationName = Encoder(s.stationName);
                }
            }
            if (dataAPI != null && dataAPI.followedConnections != null && dataAPI.followedConnections.Count > 1)
            {
                foreach (FollowedConnection s in dataAPI.followedConnections)
                {
                    s.arrival = Encoder(s.arrival);
                    s.departure = Encoder(s.departure);
                }
            }
            return dataAPI;
        }
        public List<StationData> SearchStation()
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Station/SearchStation";
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<List<StationData>>(json);
            foreach (StationData s in dataAPI)
            {
                s.name = Encoder(s.name);
            }
            return dataAPI;
        }
        public Station GetStationsByName(string station)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Station/GetStationByName?station="+station;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<Station>(json);
            dataAPI.stationinfo.name = Encoder(dataAPI.stationinfo.name);
            foreach (ArrivalDeparture a in dataAPI.arrivals)
            {
                a.station = Encoder(a.station);
            }
            foreach (ArrivalDeparture d in dataAPI.departures)
            {
                d.station = Encoder(d.station);
            }
            foreach (Review r in dataAPI.stationinfo.reviews)
            {
                r.author_name = Encoder(r.author_name);
                r.text = Encoder(r.text);
            }
            for(int i=0;i<dataAPI.stationinfo.opening_hours.Count;i++)
            {
                dataAPI.stationinfo.opening_hours[i] = Encoder(dataAPI.stationinfo.opening_hours[i]);
            }
            return dataAPI;
        }
        public Train GetTrain(string idTrain)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Train/GetTrain?idTrain=" + idTrain;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<Train>(json);
            foreach (Stop s in dataAPI.stops)
            {
                s.station = Encoder(s.station);
            }
            return dataAPI;
        }
        public Train GetTrainFromStation(string idTrain, string StationName)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Train/GetTrainFromStation?idTrain=" + idTrain +"&StationName="+StationName;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<Train>(json);
            foreach (Stop s in dataAPI.stops)
            {
                s.station = Encoder(s.station);
            }
            return dataAPI;
        }
        public List<Connection> GetConnection(string dep, string arr)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Connection/GetConnection?dep=" + dep + "&arr=" + arr;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<List<Connection>>(json);
            foreach (Connection c in dataAPI)
            {
                c.arrival.station = Encoder(c.arrival.station);
                c.departure.station = Encoder(c.departure.station);
                foreach (Via via in c.vias)
                {
                    via.arrival.station = Encoder(via.arrival.station);
                    via.departure.station = Encoder(via.departure.station);
                }
            }
            return dataAPI;
        }
        public Connection GetConnection(string dep, string arr,DateTime date)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/Connection/GetConnectionTime?dep=" + dep + "&arr=" + arr + "&t=" + date;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<Connection>(json);
            dataAPI.arrival.station = Encoder(dataAPI.arrival.station);
            dataAPI.departure.station = Encoder(dataAPI.departure.station);
            foreach (Via via in dataAPI.vias)
            {
                via.arrival.station = Encoder(via.arrival.station);
                via.departure.station = Encoder(via.departure.station);
            }
            return dataAPI;
        }
        public List<NotificationStation> GetNotificationStations(User user)
        {
            if (user != null)
            {
                string url = "http://apigetdelays.azurewebsites.net/api/user/GetNotificationStations?userid=" + user.Id;
                var json = new WebClient().DownloadString(url);
                var dataAPI = JsonConvert.DeserializeObject<List<NotificationStation>>(json);
                if(dataAPI!=null)
                {
                    foreach (NotificationStation s in dataAPI)
                    {
                        s.StationName = Encoder(s.StationName);
                    }
                }
                return dataAPI;
            }
            else
            {
                return null;
            }
        }
        public List<NotificationConnection> GetNotificationConnections(User user)
        {
            if (user != null)
            {
                string url = "http://apigetdelays.azurewebsites.net/api/user/GetNotificationConnection?userid=" + user.Id;
                var json = new WebClient().DownloadString(url);
                var dataAPI = JsonConvert.DeserializeObject<List<NotificationConnection>>(json);
                foreach (NotificationConnection s in dataAPI)
                {
                    s.Arrival = Encoder(s.Arrival);
                    s.Departure = Encoder(s.Departure);
                }
                return dataAPI;
            }
            else
            {
                return null;
            }
        }
        private string Encoder(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            var myString = Encoding.UTF8.GetString(bytes);
            return myString;
        }
    }
}
