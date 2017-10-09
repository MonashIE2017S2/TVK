/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPWy.Models.User
{
    public class UserSecret
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public virtual UserPersonal createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public virtual UserPersonal modifiedBy { get; set; }
        public DateTime modifiedAt { get; set; }

        #region timestamp function
        /*
            Update CreatedBy, CreatedAt, ModifiedBy and ModifiedAt
        */
        public void setCreatedTimeStamp(UserPersonal user)
        {
            this.createdBy = user;
            this.createdAt = DateTime.Now;
            setUpdatedTimeStamp(user);
        }
        /*
            Update ModifiedBy and ModifiedAt
        */
        public void setUpdatedTimeStamp(UserPersonal user)
        {
            this.modifiedBy = user;
            this.modifiedAt = DateTime.Now;
        }
        #endregion
    }
}