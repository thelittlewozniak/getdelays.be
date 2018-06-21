using GoogleAPI;
using Newtonsoft.Json;
using SNCBAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GetDelaysAPI;

namespace api.getdelays.be.Controllers
{
    public class ConnectionController : ApiController
    {
        //// GET: Connection
        ///<summary>
        /// you pass in params the departure station and the arrival station and the API send you the Connection 
        ///</summary>
        /// <param name="dep">The departure Station.</param>
        /// <param name="arr">The arrival Station.</param>
        /// ///<returns>
        /// it returns a list of Connection
        /// <seealso cref="GetDelaysAPI.Connection"/>
        ///</returns>
        [HttpGet]
        public List<GetDelaysAPI.Connection> GetConnection(string dep, string arr)
        {
            if(dep!=null && arr!=null)
            {
                if(dep!="" && arr!="")
                {
                    IGetAll newaccessapi = SNCBAPI.GetAll.Instance();
                    DataApiConnection s = newaccessapi.GetConnection(dep, arr);
                    List<GetDelaysAPI.Connection> connections = new List<GetDelaysAPI.Connection>();
                    foreach (SNCBAPI.Connection c in s.connection)
                    {
                        GetDelaysAPI.Connection co = new GetDelaysAPI.Connection();
                        co.arrival.delay = c.arrival.delay;
                        co.arrival.station = c.arrival.station;
                        co.arrival.time = c.arrival.tForView;
                        co.arrival.vehicle = c.arrival.vehicle;
                        co.departure.delay = c.departure.delay;
                        co.departure.station = c.departure.station;
                        co.departure.time = c.departure.tForView;
                        co.departure.vehicle = c.departure.vehicle;
                        co.duration = c.duration;
                        if(c.vias!=null)
                        {
                            foreach (SNCBAPI.ViaInfo via in c.vias.via)
                            {
                                GetDelaysAPI.Via v = new GetDelaysAPI.Via();
                                v.arrival.delay = via.arrival.delay;
                                v.arrival.station = via.arrival.direction.name;
                                v.arrival.time = via.arrival.TForView;
                                v.arrival.vehicle = via.arrival.vehicule;
                                v.departure.delay = via.departure.delay;
                                v.departure.station = via.departure.direction.name;
                                v.departure.time = via.departure.TForView;
                                v.departure.vehicle = via.departure.vehicule;
                                co.vias.Add(v);
                            }
                        }
                        connections.Add(co);
                    }
                    return connections;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}