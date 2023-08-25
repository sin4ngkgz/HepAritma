using ETicaret.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(RepositoryContext context) : base(context)
        {

        }
        public void RoleDelete(int roleId)
        {
            RepositoryContext.Roles.Where(r => r.Id == roleId).ExecuteDelete();
        }
    }
}
