using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.DBModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using eUseControl.Domain.Entities.Products;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi
    {
        internal ProdResp InsertProduct(PDbTable prod)
        {
            int result;
            using (var db = new ProductContext())
            {
                db.Products.Add(prod);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new ProdResp
                {
                    Status = false,
                    StatusMsg = "Produsule nu s-a salvat."
                };
            }
            return new ProdResp { Status = true };
        }
        internal List<PDbTable> GetProducts()
        {
            using (var db = new ProductContext())
            {
                var result = db.Products.Select(x => x).ToList<PDbTable>();
                return result;
            }
        }

        internal ProdResp DeleteProduct(int id)
        {
            using(var db = new ProductContext())
            {
                var result = db.Products.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    db.Products.Remove(result);
                    return new ProdResp() { Status = true };
                }
                else
                    return new ProdResp() { Status = false };
            }
        }
    }
}
