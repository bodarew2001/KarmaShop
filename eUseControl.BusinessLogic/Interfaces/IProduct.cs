using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Products;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          ProdResp Insert(PDbTable prod);
          List<PDbTable> Get();
     }
}