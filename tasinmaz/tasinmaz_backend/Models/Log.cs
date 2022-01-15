using System;
using System.ComponentModel.DataAnnotations;

namespace tasinmaz_backend.Models
{
    public class Log
    {
        [Key]
        public int id { get; set; }
        public string durum { get; set; }
        public string islemtipi { get; set; }
        public DateTime tarihsaat { get; set; }

        public string Ip { get; set; }

        public string Acikklama { get; set; }

    }
}