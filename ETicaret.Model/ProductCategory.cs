using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblProductCategory")]
    public class ProductCategory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}
