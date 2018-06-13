using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace getdelays.be.Models
{
    public class SearchPlaceAPI:IGetAPIGoogle
    {
        private string GetPlaceID(string location)
        {
            string key= "AIzaSyCvDBIPnMvMnl5kSiZ_oYiYCoB_XISW-OA";
            string type = "train_station";
            string urlAPI = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
            string url = string.Concat(urlAPI + "type=" + type + "&location=" + location + "&key=" + key + "&radius=150");
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<Results>(json);
            return dataAPI.results.First().place_id;
        }
        public DetailsPlace GetInfo(string location)
        {
            string key= "AIzaSyAjpoXXWhFi4r1D5d5_1tF-bzeeFRpmfG0";
            string placeid = GetPlaceID(location);
            string urlAPI = "https://maps.googleapis.com/maps/api/place/details/json?";
            string url = urlAPI + "placeid=" + placeid + "&key=" + key;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DetailsPlace>(json);
            if(dataAPI.result.opening_hours!=null)
            {
                for (int i = 0; i < dataAPI.result.opening_hours.weekday_text.Count; i++)
                {
                    byte[] by = Encoding.Default.GetBytes(dataAPI.result.opening_hours.weekday_text[i]);
                    dataAPI.result.opening_hours.weekday_text[i] = Encoding.UTF8.GetString(by);
                }
            }
            if(dataAPI.result.reviews!=null)
            {
                foreach (Review r in dataAPI.result.reviews)
                {
                    byte[] by = Encoding.Default.GetBytes(r.author_name);
                    byte[] b = Encoding.Default.GetBytes(r.text);
                    r.author_name = Encoding.UTF8.GetString(by);
                    r.text = Encoding.UTF8.GetString(b);
                }
            }
            return dataAPI;
        }
    }
}