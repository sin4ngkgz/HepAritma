using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Views
{
    [Table("V_AddressList")]
    public class V_AddressList
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string AdresBasligi { get; set; }

        public string AdresBilgileri { get; set; }

        public string SehirAdi { get; set; }

        public int SehirId { get; set; }

        public string IlceAdi { get; set; }

        public int IlceId { get; set; }

        public string UlkeAdi { get; set; }

        public int UlkeId { get; set; }

        public int PostaKodu { get; set; }

    }
}
