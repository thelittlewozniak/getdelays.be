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
    }
}
