using getdelays.be.Models.POCO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            string url = "http://apigetdelays.azurewebsites.net/?email=" + email + "&password=" + password;
            var json= new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<User>(json);
            return dataAPI;
        }
    }
}
