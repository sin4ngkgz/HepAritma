using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class PropertyRepository : RepositoryBase<Property>
    {
        public PropertyRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
