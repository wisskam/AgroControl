using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroControl.Models
{
    public class Gospodarstwo
    {
        public int ID { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        [Display(Name = "Właściciel")]
        public string Wlasciciel { get; set; }

        public int UserID { get; set; }


        public virtual ICollection<ObiektGospodarczy> ObiektyGospodarcze { get; set; }

    }
}
