using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.Models
{
    public class EventModelBase : IComparable<EventModelBase>
    {
        public int ID { get; set; }
        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Rodzaj zdarzenia")]
        public EventTypes EventType { get; set; }
        [Display(Name = "ID Gospodarstwa")]
        public int GospodarstwoID { get; set; }

        public int CompareTo([AllowNull] EventModelBase other)
        {
            if(this.CreatedDate.CompareTo(other.CreatedDate) != 0)
            {
                return this.CreatedDate.CompareTo(other.CreatedDate);
            }
            return 0;
        }
    }

    public enum EventTypes
    {
        [Display(Name = "Rejestr Transportu")]
        RejestrTransportu,
        [Display(Name = "Rejestr Wejść / Wyjść")]
        RejestrWejscWyjsc,
        [Display(Name = "Spis Zwierzat")]
        SpisZwierzat,
        [Display(Name = "Dezynfekcja")]
        Dezynfekcja,
        [Display(Name = "Przegląd zabezpieczeń")]
        PrzegladZabezpieczen
    }
}
