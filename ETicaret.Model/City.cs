using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblCity")]
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
