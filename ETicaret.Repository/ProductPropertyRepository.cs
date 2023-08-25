using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class ProductPropertyRepository : RepositoryBase<ProductProperty>
    {
        public ProductPropertyRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
