using MvcPWy.HelpClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcPWy.Controllers
{
    public class ReEngageController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReEngageHelper helper = new ReEngageHelper();
            return Ok(helper.getAllReEngage());
        }
    }
}