using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblCartProduct")]
    public class CartProduct
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }
    }
}
