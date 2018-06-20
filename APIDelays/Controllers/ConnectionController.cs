using GoogleAPI;
using Newtonsoft.Json;
using SNCBAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        [HttpGet]
        public string GetConnection(string dep, string arr)
        {
            if(dep!=null && arr!=null)
            {
                if(dep!="" && arr!="")
                {
                    IGetAll newaccessapi = GetAll.Instance();
                    DataApiConnection s = newaccessapi.GetConnection(dep, arr);
                    ///<returns>
                    ///</returns>
                    return JsonConvert.SerializeObject(s);
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