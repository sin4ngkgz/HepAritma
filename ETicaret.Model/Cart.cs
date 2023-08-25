using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblCart")]
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TotalPrice { get; set; }
    }
}
