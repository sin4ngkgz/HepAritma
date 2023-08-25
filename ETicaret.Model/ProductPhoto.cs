using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblProductPhoto")]
    public class ProductPhoto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Photo { get; set; }
    }
}
