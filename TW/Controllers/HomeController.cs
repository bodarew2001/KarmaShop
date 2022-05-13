using TW.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.App_Start;
using TW.Models;

namespace TW.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }
        public ActionResult Blog()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }        
        public ActionResult Cart()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               };
        }
          public ActionResult Logout()
          {
               System.Web.HttpContext.Current.Session.Clear();
               if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
               {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         cookie.Expires = DateTime.Now.AddDays(-1);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
               }
               System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
               return RedirectToAction("Index", "Home");
          }
          public ActionResult Checkout()
        {
                SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }
        public ActionResult Confirmation()
        {
                SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }
        public ActionResult Contact()
        {
                SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }

        public ActionResult Registration()
        {
                SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }

        public ActionResult Tracking()
        {
                SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    UserStatus up = new UserStatus
                    {
                         Username = user.Username,
                         Level = user.Level
                    };
                    return View(up);
               }
               else
               {
                    return View();
               }
          }
    }
}