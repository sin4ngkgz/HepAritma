using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class CartProductRepository : RepositoryBase<CartProduct>
    {
        public CartProductRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
