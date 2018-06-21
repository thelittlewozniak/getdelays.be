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
            string url = "http://apigetdelays.azurewebsites.net/api/User/GetUser";
            var values = new NameValueCollection();
            values["email"] = email;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;

        }
        public User Login(string email,string password)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/Login";
            var values = new NameValueCollection();
            values["email"] = email;
            values["password"] = password;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        public User MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/MakeAccount";
            var values = new NameValueCollection();
            values["email"] = email;
            values["password"] = password;
            values["name"] = name;
            values["surname"] = surname;
            values["phoneNumber"] = phoneNumber;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        public bool DeleteUser(User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/DeleteUser";
            var values = new NameValueCollection();
            values["userid"] = Convert.ToString(user.Id);
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<bool>(json);
            return dataAPI;
        }
        public User UpdateUser(string email, string name, string surname, string phoneNumber, User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/UpdateUser";
            var values = new NameValueCollection();
            values["userid"] = Convert.ToString(user.Id);
            values["email"] = email;
            values["name"] = name;
            values["surname"] = surname;
            values["phoneNumber"] = phoneNumber;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        public User FollowStation(string station, User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/FollowStation";
            var values = new NameValueCollection();
            values["userid"] = Convert.ToString(user.Id);
            values["station"] = station;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
        public User DeleteFollowStation(string station, User user)
        {
            string url = "http://apigetdelays.azurewebsites.net/api/User/FollowStation";
            var values = new NameValueCollection();
            values["userid"] = Convert.ToString(user.Id);
            values["station"] = station;
            WebClient client = new WebClient();
            byte[] response = client.UploadValues(url, values);
            string json = Encoding.Default.GetString(response);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
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
            foreach (string s in dataAPI.stationinfo.opening_hours)
            {
                s.Normalize();
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
        private string Encoder(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            var myString = Encoding.UTF8.GetString(bytes);
            return myString;
        }
    }
}
