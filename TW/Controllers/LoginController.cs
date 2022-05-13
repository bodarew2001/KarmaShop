using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.Models;
using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using TW.Extension;

namespace TW.Controllers
{
     public class LoginController : BaseController
     {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BusinessLogic();
               _session = bl.GetSessionBL();
          }

          // GET: Login
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    Mapper.Reset();
                    Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginData>());
                    var data = Mapper.Map<ULoginData>(login);

                    data.LoginIp = Request.UserHostAddress;
                    data.LoginDateTime = DateTime.Now;

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(login.Credential);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }
               }

               return View();
          }
         /* public ActionResult Edit(int Id)
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    if(Id != user.Id)
                    {
                         return RedirectToAction("Error");
                    }
                    else
                    {
                         UserContext db = new UserContext();
                         var us = db.Users.FirstOrDefault(x => x.Id == Id);
                         return View(us);
                    }
               }
               return View();
          }
          [HttpPost]
          public ActionResult Edit(UDbTable user)
          {
               UserContext userContext = new UserContext();
               var us = userContext.Users.FirstOrDefault(x => x.Id == user.Id);
               userContext.Users.Remove(us);
               userContext.SaveChanges();
               userContext.Users.Add(user);
               return RedirectToAction("Index");
          }*/
     }
}