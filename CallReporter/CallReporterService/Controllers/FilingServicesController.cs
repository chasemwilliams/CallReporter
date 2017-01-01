using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CallReporterService.Controllers
{
    [MobileAppController]
    public class FilingServicesController : ApiController
    {
        static string fsdate = "9/30/2016";

        // GET: api/FilingServices/FiledSinceDate
        public string GetFiledSinceDate()
        {
            return fsdate;
        }

        //// POST: api/FilingServices
        //// General service call, not an update
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/FilingServices/5
        // Add or update if it already exists
        public void PutFiledSinceDate([FromBody]string value)
        {
            fsdate = value;
        }

        //// DELETE: api/FilingServices/5
        //public void Delete(int id)
        //{
        //}
    }
}
