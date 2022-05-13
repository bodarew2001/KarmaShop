using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eUseControl.Domain.Entities.Products;

namespace eUseControl.BusinessLogic.DBModel
{
     public class ProductContext : DbContext
     {
          public ProductContext() : base("name=eUseControl")
          {

          }
          public virtual DbSet<PDbTable> Products { get; set; }
     }
}
