using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblAddress")]
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressName { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public int ZipCode { get; set; }
    }
}
