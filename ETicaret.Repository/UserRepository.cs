using ETicaret.Model;
using ETicaret.Model.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }
        public List <V_ActiveUsers> GetActiveUsers()
        {
            return RepositoryContext.ActiveUsers.ToList<V_ActiveUsers>();
        }
        public void UserDelete(int userId)
        {
            RepositoryContext.Users.Where(r => r.Id == userId).ExecuteDelete();
        }
    }
}
