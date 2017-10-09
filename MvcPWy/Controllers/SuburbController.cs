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
    public class SuburbController : ApiController
    {
        // GET: api/Suburb
        public IHttpActionResult Get()
        {
            SuburbHelper helper = new SuburbHelper();
            return Ok(helper.getAllSuburbs());
        }
    }
}