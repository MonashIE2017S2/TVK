/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcPWy.Models
{
    public class Support
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int postCode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string webSite { get; set; }
        /*
           generate a web modell
       */
       
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;

            if (name == null || address == null || phone == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}