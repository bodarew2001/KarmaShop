using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Products;

namespace eUseControl.BusinessLogic
{
    public class ProductBL : AdminApi, IProduct
    {
        public ProdResp Insert(PDbTable prod)
        {
            return InsertProduct(prod);
        }
        public List<PDbTable> Get()
        {
            return GetProducts();
        }
        public ProdResp Delete(int id)
        {
            return DeleteProduct(id);
        }
    }
}
