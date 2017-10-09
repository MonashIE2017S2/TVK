using System.Web.Mvc;

namespace MvcPWy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
/*
            ViewBag.Link = TempData["ViewBagLink"];
*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Page of this Application.";
            return View();
        }

        public ActionResult EmailHelp()
        {
            ViewBag.Message = "Email Help Page.";
            return View();
        }
        /*
                [Authorize]
        */
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EducationalOutcomes()
        {
            ViewBag.Message = "Educational Outcomes Page.";
       
            return View();
        }

        public ActionResult IdentifyVulnerableKids()
        {
            ViewBag.Message = "Identify Vulnerable Kids Page.";

            return View();
        }

        public ActionResult SupportServices()
        {
            ViewBag.Message = "Support Services Page.";

            return View();
        }

        public ActionResult EducationPlan()
        {
            ViewBag.Message = "Education Plan Page.";

            return View();
        }

        public ActionResult EmailHelper()
        {
            ViewBag.Message = "Email Helper Page.";

            return View();
        }

        [Authorize]
        public ActionResult ChatHub()
        {
            ViewBag.Message = "ChatHub Page.";

            return View();
        }
    }
}