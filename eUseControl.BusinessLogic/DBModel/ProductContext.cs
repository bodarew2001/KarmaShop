using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eUseControl.Domain.Entities.Products;
using System.Configuration;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("eUseControl")
        {
        }
        public virtual DbSet<PDbTable> Products { get; set; }
    }
}
