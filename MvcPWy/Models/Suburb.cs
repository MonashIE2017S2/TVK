/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPWy.Models
{
    public class Suburb
    {
        public int Id { get; set; }
        public string postcode { get; set; }
        public string name { get; set; }
        public string regionName { get; set; }

        [NotMapped]
        public virtual Region region { get; set; }
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

            if (name == null || regionName == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}