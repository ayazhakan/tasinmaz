using System.ComponentModel.DataAnnotations;

namespace tasinmaz_backend.Models
{
    public class City
    {
        [Key]
        public int cityid { get; set; }

        public string cityname { get; set; }

    }
}