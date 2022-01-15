using System.ComponentModel.DataAnnotations;

namespace tasinmaz_backend.Models
{
    public class Kullanici
    {
        [Key]
        public int kullaniciid { get; set; }
        public string ad { get; set; }

        public string soyad { get; set; }

        [MinLength(8)]
        [MaxLength(12)]
        public string sifre { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public bool rol { get; set; }

        public string adres { get; set; }
 
        public bool? silindimi { get; set; }

    } 
}