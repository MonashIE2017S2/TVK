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
    public class SuburbHelper
    {
        #region init and constructor
        MyDBContext context;
        string currentUserEmail;
        public SuburbHelper()
        {
            //currentUserEmail = LoginHelper.getCurrentLoggedinUserEmail();
            context = new MyDBContext();
        }
        #endregion

        #region public functions
        /*
            Get all Students
        */
        public List<Suburb> getAllSuburbs()
        {
            return generateWebModel(context.Suburb.ToList());
        }
        #endregion

        #region private functions
        /*
            get web model
        */
        private List<Suburb> generateWebModel(List<Suburb> list)
        {
            foreach (var sub in list)
                sub.generateWebModel();
            return list;
        }
        #endregion

    }
}