using System;
using MvcPWy.HelpClass;
using MvcPWy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcPWy.Controllers
{
    public class ChildFirstController : ApiController
    {
        // GET: api/Suburb
        public IHttpActionResult Get()
        {
            ChildFirstHelper helper = new ChildFirstHelper();
            return Ok(helper.getAllChildFirsts());
        }
    }
}
