using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Views
{
    [Table("V_ActiveUsers")]
    public class V_ActiveUsers
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role{ get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
