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
        ///<summary>
        /// You pass in param the id of the train and the API send to you the information of this train like all the stops of the train 
        ///</summary>
        /// <param name="idTrain">It's the id of the train. You can find it in the arrivals and departures of Station</param>
        /// <returns>
        /// It return an object Train in wich you have a list of stops and the ID of the train
        /// <seealso cref="Train"/>
        /// </returns>
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
        ///<summary>
        /// You pass in param the id of the train and the station from where you want to have the data so the api send you from this station all stops of the train
        ///</summary>
        /// <param name="idTrain">It's the id of the train. You can find it in the arrivals and departures of Station</param>
        /// <param name="StationName">It's the sttion name from where you want to have the data</param>
        /// <returns>
        /// It return an object Train in wich you have a list of stops and the ID of the train
        /// <seealso cref="Train"/>
        /// </returns>
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