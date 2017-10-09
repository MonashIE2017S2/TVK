using MvcPWy.HelpClass;
using MvcPWy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcPWy.Controllers
{
    public class RegionController : ApiController
    {
        // GET: api/Region
        public IHttpActionResult Get()
        {
            RegionHelper helper = new RegionHelper();
            return Ok(helper.getAllRegions());
        }
    }
}