using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class EventPrzegladZabezpieczen : EventModelBase
    {
        //public DateTime DataPrzegladu { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        public DateTime DataPrzegladu { get; set; } = DateTime.Now;

        // Ogólna szczelność budynku
        [Required]
        [Display(Name = "Obiekt gospodarczy")]
        public int ObiektGospodarczyID { get; set; }

        [Required]
        [Display(Name = "Ogólna szczelność - Budynek inwentarski (świnie)")]
        public OcenaSzczelnosci SzczelnoscBudynku { get; set; } = OcenaSzczelnosci.Pozytywna;

        [Required]
        [Display(Name = "Ogólna szczelność - Magazyn pasz")]
        public OcenaSzczelnosci SzczelnoscMagazynuPasz { get; set; } = OcenaSzczelnosci.Pozytywna;
    
        //Okna
        [Required]
        [Display(Name = "Szczelność okien - Budynek inwentarski (świnie)")]
        public OcenaSzczelnosci SzczelnoscOkienBudynku { get; set; } = OcenaSzczelnosci.Pozytywna;
    
        [Required]
        [Display(Name = "Szczelność okien - Magazyn pasz")]
        public OcenaSzczelnosci SzczelnoscOkienMagazynuPasz{ get; set; } = OcenaSzczelnosci.Pozytywna;
    
        //Drzwi zewnętrzne lub zasuwa otworu przy stosowaniu silosów
        [Required]
        [Display(Name = "Szczelność drzwi zewn. - Budynek inwentarski (świnie)")]
        public OcenaSzczelnosci SzczelnoscDrzwiZewnetrzychBudynku { get; set; } = OcenaSzczelnosci.Pozytywna;
    
        [Required]
        [Display(Name = "Szczelność drzwi zewn. - Magazyn pasz")]
        public OcenaSzczelnosci SzczelnoscDrzwiZewnetrzychMagazynuPasz { get; set; } = OcenaSzczelnosci.Pozytywna;
     
        //Drzwi wewnetrzne
        [Required]
        [Display(Name = "Szczelność drzwi wewn. - Budynek inwentarski (świnie)")]
        public OcenaSzczelnosci SzczelnoscDrzwiWewnętrzychBudynku { get; set; } = OcenaSzczelnosci.Pozytywna;
    
        [Required]
        [Display(Name = "Szczelność drzwi wewn. - Magazyn pasz")]
        public OcenaSzczelnosci SzczelnoscDrzwiWewnętrznychMagazynuPasz { get; set; } = OcenaSzczelnosci.Pozytywna;

        //Podjęte naprawy
        [Display(Name = "Naprawy - Budynek inwentarski (świnie)")]
        public string PodjeteNaprawyBudynek { get; set; }

        [Display(Name = "Naprawy - Magazyn pasz")]
        public string PodjeteNaprawyMagazynPasz { get; set; }

    }
}


public enum OcenaSzczelnosci
{
    Pozytywna,
    Negatywna,
    [Display(Name = "Nie dotyczy")]
    NieDotyczy
}