using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgroControl.Models
{
    public class EventRejestrWejscWyjsc : EventModelBase
    {
        [Required(ErrorMessage = "Data i godzina wejścia jest wymagana")]
        [Display(Name = "Data i godzina wejścia")]
        //public DateTime DataIGodzinaWejścia { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        public DateTime DataIGodzinaWejścia { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Imię i nazwisko osoby wchodzącej do budynku jest wymagane")]
        [Display(Name = "Imię i nazwisko osoby wchodzącej do budynku")]
        public string NazwaOsobyWchodzacej { get; set; }

        [Required(ErrorMessage = "Nazwa firmy lub pracownik gospodarstwa jest wymagany")]
        [Display(Name = "Nazwa firmy lub pracownik gospodarstwa")]
        public string NazwaFirmy { get; set; }

        [Required(ErrorMessage = "Cel wejścia do budynku jest wymagany")]
        [Display(Name = "Cel wejścia do budynku jest wymagany")]
        public string CelWejscia { get; set; }

        [Required(ErrorMessage = "Data ostatniego pobytu w innym gospodarstwie jest wymagana")]
        [Display(Name = "Data ostatniego pobytu w innym gospodarstwie")]
        //public DateTime DataOstatniegoPobytu { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        public DateTime DataOstatniegoPobytu { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Miejsce ostatniego pobytu w innym gospodarstwie jest wymagane")]
        [Display(Name = "Miejsce ostatniego pobytu w innym gospodarstwie")]
        public string MiejsceOstatniegoPobytu { get; set; }

        [Required(ErrorMessage = "Informacja o użyciu odzieży ochronnej jest wymagana")]
        [Display(Name = "Czy zastosowano odzież ochronną?")]
        public bool CzyZastosowanoOchrone { get; set; } = true;

        public string DataMiejsceOstatniegoPobytu
        {
            get
            {
                return $"{DataOstatniegoPobytu} {MiejsceOstatniegoPobytu}";
            }
        }
        
        [Display(Name = "Obiekt gospodarczy")]
        public int ObiektGospodarczyID { get; set; }
        public virtual ObiektGospodarczy ObiektGospodarczy{ get; set; }



    }
}
