using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamGameWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }
        public ActionResult verification()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult PrivacyandPolicy()
        {
            return View();
        }
        public ActionResult HowToPlay()
        {
            return View();
        }
        public ActionResult MyContest()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult AddPayment()
        {
            return View();
        }


    }
}