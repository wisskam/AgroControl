using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class EventRejestrTransportu : EventModelBase
    {
        [Required(ErrorMessage = "Data i godzina wjazdu jest wymagana")]
        [Display(Name = "Data i godzina wjazdu")]
        public DateTime DataIGodzinaWjazdu { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Nazwa podmiotu i/lub nr rejestracyjny są wymagane")]
        [Display(Name = "Nazwa podmiotu i/lub nr rejestracyjny")]
        public string NazwaLubNrRejestracji { get; set; }

        [Required(ErrorMessage = "Cel wjazdu jest wymagany")]
        [Display(Name = "Cel wjazdu")]
        public string CelWjazdu { get; set; }

        [Required(ErrorMessage = "Miejsce ostatniego pobytu pojazdu jest wymagane")]
        [Display(Name = "Miejsce ostatniego pobytu pojazdu")]
        public string OstatniPobytPojazdu { get; set; }
    }
}
