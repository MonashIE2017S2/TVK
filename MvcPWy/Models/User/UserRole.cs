using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPWy.Models.User
{
    public class UserRole
    {
        public int Id { get; set; }
        public string roleName { get; set; }
        public int priority { get; set; }

        #region validation functions
        public bool isValid()
        {
            bool isValid = true;
            if (this.roleName == null || this.roleName.Length < 1)
                isValid = false;
            if (this.priority < 0)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}