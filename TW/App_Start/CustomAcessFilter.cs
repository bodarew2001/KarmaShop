using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using TW.Extension;
using System.Web.Routing;
using eUseControl.Domain.Enums;
namespace TW.App_Start
{
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
     public class NoDirectAccessCustomAccesFilter : ActionFilterAttribute
     {
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               if (filterContext.HttpContext.Request.Url != null &&
               (filterContext.HttpContext.Request.UrlReferrer == null ||
               filterContext.HttpContext.Request.Url.Host !=
              filterContext.HttpContext.Request.UrlReferrer.Host))
               {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                         controller = "Error",
                         action =
                   "Error500"
                    }));
               }
          }
     }
     public class AdminModAttribute : ActionFilterAttribute
     {
          private readonly ISession _sessionBusinessLogic;

          public AdminModAttribute()
          {
               var businessLogic = new BusinessLogic();
               _sessionBusinessLogic = businessLogic.GetSessionBL();
          }

          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                    if (profile != null && profile.Level == URole.ADMIN    )
                    {
                         HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                         filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new
                             RouteValueDictionary(new { controller = "Home", action = "Error" }));
                    }
               }
               else
               {
                    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Home", action = "Error" }));
               }
          }
     }

     public class ModeratorMod : ActionFilterAttribute
     {
          private readonly ISession _sessionBusinessLogic;

          public ModeratorMod()
          {
               var businessLogic = new BusinessLogic();
               _sessionBusinessLogic = businessLogic.GetSessionBL();
          }

          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                    if (profile != null && (profile.Level == URole.MODERATOR || profile.Level == URole.ADMIN))
                    {
                         HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                         filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new
                             RouteValueDictionary(new { controller = "Home", action = "Error" }));
                    }
               }
               else
               {
                    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Home", action = "Error" }));
               }
          }
     }
     public class UserModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public UserModAttribute()
          {
               var bl = new BusinessLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var adminSession = HttpContext.Current.GetMySessionObject();
               if (adminSession == null)
               {
                    var cookie = HttpContext.Current.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                         var profile = _session.GetUserByCookie(cookie.Value);
                         if (profile != null && profile.Level == URole.USER)
                         {
                              HttpContext.Current.SetMySessionObject(profile);
                         }
                         else
                         {
                              filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(new
                              {
                                   controller = "Error",
                                   action =
                             "Error404"
                              }));
                         }
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(
                          new RouteValueDictionary(new
                          {
                               controller = "Error",
                               action =
                         "Error404"
                          }));
                    }
               }
          }
     }
}