using System;
using System.Collections.Generic;
using System.Linq;
using MvcPWy.HelpClass;
using MvcPWy.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcPWy.Controllers
{
    public class SupportController : ApiController
    {
        // GET: api/Support
        public IHttpActionResult Get()
        {
            SupportHelper helper = new SupportHelper();
            return Ok(helper.getAllSupport());
        }
    }
}
