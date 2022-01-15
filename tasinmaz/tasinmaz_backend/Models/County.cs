using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_backend.Models
{
    public class County
    {
        [Key]
        public int countyid { get; set; }

        [ForeignKey("City")]
        public int cityid { get; set; }
        public virtual City City { get; set; }
        public string countyname { get; set; }

    }
}