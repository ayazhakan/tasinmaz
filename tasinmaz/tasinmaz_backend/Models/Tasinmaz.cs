using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_backend.Models
{
    public class Tasinmaz
    {

        [Key]
        public int tasinmazid { get; set; }

        [ForeignKey("Neighborhood")]
        public int? neighborhoodid { get; set; }

        public int? cityid { get; set; }

        public int? countyid { get; set; }

        public virtual Neighborhood neighborhood { get; set; }

        public int ada { get; set; }

        public int parsel { get; set; }

        public string nitelik { get; set; }

        public string adres { get; set; }

        public bool? silindimi { get; set; }

        public string cityname { get; set; }

     public string countyname { get; set; }

    public string neighborhoodname { get; set; }
    }
}