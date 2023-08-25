using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Views
{
    [Table("V_CategoryList")]
    public class V_CategoryList
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int? TopCategoryId { get; set; }

        public string? TopCategoryName { get; set; }

        public bool Active { get; set; }

        public int? Place { get; set; }
    }
}
