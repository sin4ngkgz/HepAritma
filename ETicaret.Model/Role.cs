using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblRole")]
    public class Role
    {
        public Role()
        {
            User = new HashSet<User>();   
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
