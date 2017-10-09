/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcPWy.Models.User
{
    public class UserPersonal
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public bool deleted { get; set; }
        public string empId { get; set; }
        public virtual UserRole UserRole { get; set; }

        [NotMapped]
        public string password { get; set; }
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;
            if (this.email == null || this.firstName == null || this.lastName == null || this.empId == null || this.UserRole == null)
                isValid = false;
            if (this.email.Trim().Length == 0 || this.firstName.Trim().Length == 0 || this.lastName.Trim().Length == 0 || this.empId.Trim().Length == 0)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}