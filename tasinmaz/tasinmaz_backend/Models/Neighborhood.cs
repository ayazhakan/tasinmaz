using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_backend.Models
{
    public class Neighborhood
    {
        [Key]
        public int neighborhoodid { get; set; }

        [ForeignKey("County")]
        public int countyid { get; set; }
        public virtual County county { get; set; }

        public string neighborhoodname { get; set; }

        

    }
}