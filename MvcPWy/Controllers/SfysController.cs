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
    public class SfysController : ApiController
    {
        // GET: api/Sfys
        public IHttpActionResult Get()
        {
            SfysHelper helper = new SfysHelper();
            return Ok(helper.getAllSfys());
        }
    }
}