using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
