/*
	Author: Roshan Krishnan Thirikkott
*/
/*
using MvcPWy.Auth;
*/
using MvcPWy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPWy;

namespace MvcPWy.HelpClass
{
    public class ReEngageHelper
    {
        #region init and constructor
        MyDBContext context;
        string currentUserEmail;
        public ReEngageHelper()
        {
            //currentUserEmail = LoginHelper.getCurrentLoggedinUserEmail();
            context = new MyDBContext();
        }
        #endregion

        #region public functions
        /*
            Get all Students
        */
        public List<ReEngage> getAllReEngage()
        {
            return context.ReEngage.ToList();
        }
        #endregion



    }
}