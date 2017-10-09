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
    public class SfysHelper
    {
        #region init and constructor
        MyDBContext context;
        string currentUserEmail;
        public SfysHelper()
        {
            //currentUserEmail = LoginHelper.getCurrentLoggedinUserEmail();
            context = new MyDBContext();
        }
        #endregion

        #region public functions
        /*
            Get all Students
        */
        public List<Sfys> getAllSfys()
        {
            return generateWebModel(context.Sfys.ToList());
        }
        #endregion

        #region private functions
        /*
            get web model
        */
        private List<Sfys> generateWebModel(List<Sfys> list)
        {
            foreach (var sfys in list)
                sfys.generateWebModel();
            return list;
        }
        #endregion

    }
}