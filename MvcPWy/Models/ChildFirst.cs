/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPWy.Models
{
    public class ChildFirst
    {
        public int Id { get; set; }
        public string region { get; set; }
        public string phone { get; set; }
        public string type { get; set; }
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;

            if (region == null || phone == null || type == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}