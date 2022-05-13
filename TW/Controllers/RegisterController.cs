using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.DBModel;
using AutoMapper;
using TW.Models;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers;
using System.Data.Entity;
namespace TW.Controllers
{
    public class RegisterController : Controller
    {
          // GET: Register
          private readonly ISession _session;
          public RegisterController()
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
          public ActionResult Index(UserRegister register)
          {
               using (var db = new UserContext()) {
                    if (ModelState.IsValid)
                    {
                         UDbTable user = new UDbTable();
                         user.Email = register.Email;
                         user.Password = LoginHelper.HashGen(register.Password);
                         user.Username = register.Username;
                         user.Level = eUseControl.Domain.Enums.URole.USER;
                         user.LastLogin = DateTime.Now;
                         user.LasIp = Request.UserHostAddress;
                         var result = db.Users.FirstOrDefault(u => u.Email == user.Email);
                         if (result == null)
                         {
                              db.Users.Add(user);
                              db.SaveChanges();
                              return RedirectToAction("Index", "Home");
                         }
                         else
                         {
                              return View();
                         }
                    }
               }

               return View();
          }
     }
}