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
        // GET: Connection
        [HttpGet]
        public string GetConnection(string dep, string arr)
        {
            if(dep!=null && arr!=null)
            {
                if(dep!="" && arr!="")
                {
                    IGetAPIGoogle googleApi = new SearchPlaceAPI();
                    IGetAll newaccessapi = GetAll.Instance();
                    DataApiConnection s = newaccessapi.GetConnection(dep, arr);
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