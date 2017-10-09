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
    public class ChildFirstHelper
    {
        #region init and constructor
        MyDBContext context;
        string currentUserEmail;
        public ChildFirstHelper()
        {
            //currentUserEmail = LoginHelper.getCurrentLoggedinUserEmail();
            context = new MyDBContext();
        }
        #endregion

        #region public functions
        /*
            Get all Students
        */
        public List<ChildFirst> getAllChildFirsts()
        {
            return context.ChildFirst.ToList();
        }
        #endregion

    }
}