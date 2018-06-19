using Newtonsoft.Json;
using SNCBAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace getdelays.be.Controllers
{
    public class TrainController : ApiController
    {
        // GET: Train
        [HttpGet]
        public string GetTrain(string idTrain)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain);
            return JsonConvert.SerializeObject(s);
        }
        [HttpGet]
        public string GetTrainFromStation(string idTrain,string StationName)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain,StationName);
            return JsonConvert.SerializeObject(s);
        }

    }
}