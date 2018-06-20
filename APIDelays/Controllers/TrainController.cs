using Newtonsoft.Json;
using SNCBAPI;
using GetDelaysAPI;
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
        public Train GetTrain(string idTrain)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain);
            Train train = new Train();
            train.vehicle = s.vehicle;
            foreach (SNCBAPI.Stop st in s.stops.stop)
            {
                train.stops.Add(new GetDelaysAPI.Stop { delay = st.delay, id = st.id, station = st.station, platform = st.platform, time = st.tForView });
            }
            return train;
        }
        [HttpGet]
        public Train GetTrainFromStation(string idTrain,string StationName)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain,StationName);
            Train train = new Train();
            train.vehicle = s.vehicle;
            foreach (SNCBAPI.Stop st in s.stops.stop)
            {
                train.stops.Add(new GetDelaysAPI.Stop { delay = st.delay, id = st.id, station = st.station, platform = st.platform, time = st.tForView });
            }
            return train;
        }

    }
}