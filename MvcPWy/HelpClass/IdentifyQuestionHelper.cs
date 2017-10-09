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
    public class IdentifyQuestionHelper
    {
        #region init and constructor
        MyDBContext context;
        string currentUserEmail;
        public IdentifyQuestionHelper()
        {
            //currentUserEmail = LoginHelper.getCurrentLoggedinUserEmail();
            context = new MyDBContext();
        }
        #endregion

        #region public functions
        /*
            Get all Students
        */
        public List<IdentifyQuestion> getAllStudents()
        {
            return context.IdentifyQuestions.ToList();
        }

        /*
            Get a student by id
        */
       /* public Student getStudentById(string id)
        {
            var found = context.Student.FirstOrDefault(u => u.studentId == id);
            found.generateWebModel();
            return found;
        }
        /*
            Create new Student
        #1#
        public Student createNewStudent(Student newObj)
        {
            if (newObj.isValid())
            {
                //remove not mapped objects
                newObj.schoolId = newObj.school.Id;
                newObj.school = null;

                context.Student.Add(newObj);
                context.SaveChanges();
                newObj.generateWebModel();
                return newObj;
            }
            return null;
        }
        /*
            Edit a Student
        #1#
        public Student editStudent(Student newObj)
        {
            Student old = context.Student.FirstOrDefault(u => u.studentId == newObj.studentId);
            if (newObj.isValid() && old != null)
            {
                old.courtOrderGiven = newObj.courtOrderGiven;
                old.yearLevel = newObj.yearLevel;
                old.programStuentDisability = newObj.programStuentDisability;
                old.disabilityCategory = newObj.disabilityCategory;
                old.dateCurrentPlan = newObj.dateCurrentPlan;
                old.dateNextPlan = newObj.dateNextPlan;
                newObj.deleted = false;
                context.SaveChanges();
                old.generateWebModel();
                return old;
            }
            return null;
        }
        /*
            Delete a Student
        #1#
        public bool deleteStudent(string id)
        {
            Student found = context.Student.FirstOrDefault(u => u.studentId == id);
            if (found != null)
            {
                found.deleted = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region private functions
        /*
            get web model
        #1#
        private List<Student> generateWebModel(List<Student> list)
        {
            foreach (var student in list)
                student.generateWebModel();
            return list;
        }*/
        #endregion
    }
}