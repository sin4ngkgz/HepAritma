using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblOrder")]
    public class Order
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int OrderPrice { get; set; }

        public DateTime Date { get; set; }

        public int AddressId { get; set; }

        public string OrderStatus { get; set; }
    }
}
