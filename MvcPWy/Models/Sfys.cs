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
    public class Sfys
    {
        public int Id { get; set; }
        
        public string name { get; set; }
        public string DETArea { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int postCode { get; set; }
        public string website { get; set; }
        public string regionName { get; set; }
        [NotMapped]
        public virtual Region region { get; set; }
        /*
           generate a web modell
       */
        #region public function
        public void generateWebModel()
        {
            MyDBContext context = new MyDBContext();
            try
            {
                this.region = context.Region.FirstOrDefault(u => u.name == this.region.name);
            }
            catch (Exception e)
            {
                this.region = context.Region.FirstOrDefault(u => u.name == this.regionName);
            }
        }
        #endregion
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;

            if (name == null || address == null || phone == null)
                isValid = false;
            if (regionName == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}