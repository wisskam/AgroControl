using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class EventDezynfekcja : EventModelBase
    {
        public DateTime DataZabiegu { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

        [Display(Name = "Obiekt Gospodarczy")]
        public int ObiektGospodarczyID { get; set; }

        [Display(Name = "Zabieg dla obiektu gospodarczego")]
        public RodzajZabiegu ZabiegDlaObiektGospodarczy { get; set; } = RodzajZabiegu.CzyszczenieDezynfekcja;

        [Display(Name = "Zabieg dla sprzętu / narzędzi")]
        public RodzajZabiegu ZabiegDlaSprzetNarzędzia { get; set; } = RodzajZabiegu.CzyszczenieDezynfekcja;

        [Display(Name = "Maty przed wejściem / wyjściem do budynku, w którym utrzymywane są świnie")]
        public RodzajZabiegu ZabiegDlaWejscWyjsc { get; set; } = RodzajZabiegu.Uzupelnienie;
        
        [Display(Name = "Nazwa środka dezynfekującego")]
        public string SrodekDezynfekujacy { get; set; } = "Virkon S";
        
        [Display(Name = "Ilość sporządzonego roztworu")]
        public double IloscPrzyrzadzonegoRoztworu { get; set; } = 0;

        [Display(Name = "Ilość użytego roztworu")]
        public double IloscUzytegoRoztworu { get; set; } = 0;



    }

    public enum RodzajZabiegu
    {
        Czyszczenie,
        Dezynfekcja,

        [Display(Name = "Czyszczenie i dezynfekcja")]
        CzyszczenieDezynfekcja,

        [Display(Name = "Uzupełnienie")]
        Uzupelnienie
    }
}
