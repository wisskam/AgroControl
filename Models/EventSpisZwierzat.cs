using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class EventSpisZwierzat : EventModelBase
    {
        //public DateTime DataSpisu { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        public DateTime DataSpisu { get; set; } = DateTime.Now;

        [Display(Name = "Liczba prosiąt (od urodzenia do osadzenia)")]
        public int LiczbaProsiat { get; set; } = 0;

        [Display(Name = "Liczba warchlaków (od odsadzenia do 10 tyg. życia)")]
        public int LiczbaWarchlakow { get; set; } = 0;

        [Display(Name = "Liczba tuczników (od 10 tyg. życia do uboju)")]
        public int LiczbaTucznikow { get; set; } = 0;

        [Display(Name = "Liczba loch (samica po pierwszym wyproszeniu)")]
        public int LiczbaLoch { get; set; } = 0;

        [Display(Name = "Liczba loszek (dojrzała samica do pierwszego wyproszenia)")]
        public int LiczbaLoszek { get; set; } = 0;

        [Display(Name = "Liczba knurów (dojrzałe samce używane do rozrodu)")]
        public int LiczbaKnurow { get; set; } = 0;

        [Display(Name = "Liczba knurków (samiec od 10 tyg. życia do pierwszego krycia)")]
        public int LiczbaKnurkow { get; set; } = 0;
    }
}
