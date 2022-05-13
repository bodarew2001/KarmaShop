using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Entities.Products;
using eUseControl.Domain.Enums;

namespace TW.Models
{
     public class ProductList
     {
          public List<PDbTable> Products { get; set; }
     }
}