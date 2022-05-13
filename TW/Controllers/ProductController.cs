using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using TW.Models;
using eUseControl.Domain.Entities.Products;
using eUseControl.BusinessLogic.Interfaces;
using TW.App_Start;
using System.IO;
using eUseControl.BusinessLogic;
using TW.Extension;

namespace TW.Controllers
{
     public class ProductController : BaseController
     {
          private readonly IProduct _product;
          public ProductController()
          {
               var bl = new BusinessLogic();
               _product = bl.GetProductBL();
          }
          // GET: Product
          public ActionResult Index()
          {
               ProductList prod = new ProductList();
               prod.Products = _product.Get();
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
               {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();

               }
               return View(prod);
          }
          [AdminMod]
          public ActionResult Add()
          {
               return View();
          }
          [AdminMod]
          [HttpPost]
          public ActionResult Add(ProductModel prod)
          {
               string fileName = Path.GetFileNameWithoutExtension(prod.Image.FileName);
               string extension = Path.GetExtension(prod.Image.FileName);
               fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
               prod.ImagePath = "~/Images/" + fileName;
               fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
               prod.Image.SaveAs(fileName);
               PDbTable product = new PDbTable()
               {
                    Name = prod.Name,
                    Price = prod.Price,
                    ImagePath = prod.ImagePath
               };

               _product.Insert(product);

               return RedirectToAction("Index");
          }
          public ActionResult Products()
          {
               SessionStatus();
               ProductList prod = new ProductList();
               prod.Products = _product.Get();
               return View(prod);
          }
          [ModeratorMod]
          [HttpGet]
          public ActionResult Edit(int Id)
          {
               ProductContext productContext = new ProductContext();
               var prod = productContext.Products.FirstOrDefault(x => x.Id == Id);
               return View(prod);
          }
          [HttpPost]
          [ModeratorMod]
          public ActionResult Edit(PDbTable product)
          {
               ProductContext productContext = new ProductContext();
               var prod = productContext.Products.FirstOrDefault(x=> x.Id == product.Id);
               productContext.Products.Remove(prod);
               productContext.Products.Add(product);
               productContext.SaveChanges();
               
               return RedirectToAction("Index");
          }
          [AdminMod]
          public ActionResult Delete(int Id)
          {
               ProductContext productContext = new ProductContext();
               var product = productContext.Products.FirstOrDefault(x => x.Id == Id);
               productContext.Products.Remove(product);
               productContext.SaveChanges();
               return RedirectToAction("Index");
          }
     }
}