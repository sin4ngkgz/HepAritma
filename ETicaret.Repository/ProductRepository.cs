using ETicaret.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }
        public void ProductDelete(int productId)
        {
            RepositoryContext.Products.Where(r => r.Id == productId).ExecuteDelete();
        }
        public List<Product> GetProductsByCategoryId(int categoryId) 
        { 
           List<Product> items = (from p in RepositoryContext.Products
                                  join k in RepositoryContext.ProductCategories on p.Id equals k.ProductId
                                  where k.CategoryId == categoryId
                                  select p).ToList<Product>();
            return items;
        
        }
    }
}
