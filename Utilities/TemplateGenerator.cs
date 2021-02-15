using AgroControl.Models;
using System.Collections.Generic;
using System.Text;

namespace AgroControl.Utilities
{
    public static class TemplateGenerator
    {
        public static int pageRowCount = 16;
        public static List<ObiektGospodarczy> obiektyGospodarcze { get; set; }

        public static string GetEventDezynfekcjaHTMLString(List<EventDezynfekcja> events)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                        <html>
                            <head>
                                <style>
                                   .ac-pdf-table{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table th{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table td{
                                        border: solid 1px black;
                                        height: 50px;
                                        border-collapse: collapse;
                                        text-align: center;
                                    }
                                    .ac-pdf-disabled{
                                        background-color: #777;
                                    }
                                </style>
                            </head>
                            <body>
                                <table class='ac-pdf-table' align='center'>
                                    <thead>
                                        <tr>
                                            <th rowspan='2'>Lp.</th>
                                            <th rowspan='2'>Data zabiegu</th>
                                            <th colspan='4'>rodzaj zabiegu: czyszczenie (C), dezynfekcja (D)/uzupełnienia środka dezynfekcyjnego (U)</th>
                                            <th rowspan='2'>Nazwa użytego środka dezynfekcyjnego</th>
                                            <th rowspan='2'>Ilość sporządzonego roztworu</th>
                                            <th rowspan='2'>Ilość zużytego roztworu</th>
                                            <th rowspan='2'>Podpis osoby odpowiedzialnej</th>
                                        </tr>
                                        <tr>
                                            <th>Budynek nr (jesli więcej niż 1)</th>
                                            <th style='width: 150px'>sprzęt / narzędzia</th>
                                            <th>Maty przed wjazdem / wyjazdem z/do gospodarstwa*</th>
                                            <th>Maty przed wejściem / wyjściem do budynku, w  którym utrzymywane są świnie</th>
                                        </tr>
                                    </thead>
            ");
            for (int i = 0; i < pageRowCount - (events.Count % pageRowCount); i++)
            {
                if (i < events.Count)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td class='ac-pdf-disabled'></td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td></td>
                                  </tr>",
                        i+1,
                        events[i].DataZabiegu,
                        events[i].ObiektGospodarczy.Nazwa,
                        EventDezynfekcja.NazwaSkroconaRodzajuZabiegu(events[i].ZabiegDlaSprzetNarzędzia),
                        EventDezynfekcja.NazwaSkroconaRodzajuZabiegu(events[i].ZabiegDlaWejscWyjsc),
                        events[i].SrodekDezynfekujacy,
                        events[i].IloscPrzyrzadzonegoRoztworu,
                        events[i].IloscUzytegoRoztworu
                    );
                }
                else
                {
                    sb.AppendFormat(@"<tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td class='ac-pdf-disabled'></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                  </tr>");
                }

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
     
        public static string GetEventRejestrTransportuHTMLString(List<EventRejestrTransportu> events)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                        <html>
                            <head>
                                <style>
                                   .ac-pdf-table{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table th{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table td{
                                        border: solid 1px black;
                                        height: 50px;
                                        border-collapse: collapse;
                                        text-align: center;
                                    }
                                    .ac-pdf-disabled{
                                        background-color: #777;
                                    }
                                </style>
                            </head>
                            <body>
                                <table class='ac-pdf-table' align='center'>
                                    <thead>
                                        <tr>
                                            <th >Lp.</th>
                                            <th >Data i godzina wjazdu</th>
                                            <th >Numer rejestracyjny pojazdu i/lub nazwa podmiotu wjeżdżajacego do gospodasrtwa </th>
                                            <th >Cel wjazdu (np. kupno/sprzedaż świń, odbiór padłych zwierząt)</th>
                                            <th >Informacje o miejscu ostatniego pobytu danego pojazdu/podmiotu przed wjazdem do gospodasrtwa (jeśli wiadomo)</th>
                                            <th >Podpis osoby odpwiedzialnej za prowadzenie rejestru</th>
                                        </tr>
                                    </thead>
            ");

            for(int i = 0; i < pageRowCount - (events.Count % pageRowCount); i++)
            {
                if(i < events.Count)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td></td>
                                  </tr>",
                        i+1,
                        events[i].DataIGodzinaWjazdu,
                        events[i].NazwaLubNrRejestracji,
                        events[i].CelWjazdu,
                        events[i].OstatniPobytPojazdu
                    );
                }
                else
                {
                    sb.AppendFormat(@"<tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                  </tr>");
                }
                
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetEventRejestrWejscWyjscHTMLString(List<EventRejestrWejscWyjsc> events)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                        <html>
                            <head>
                                <style>
                                   .ac-pdf-table{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table th{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table td{
                                        border: solid 1px black;
                                        height: 50px;
                                        border-collapse: collapse;
                                        text-align: center;
                                    }
                                    .ac-pdf-disabled{
                                        background-color: #777;
                                    }
                                </style>
                            </head>
                            <body>
                                <table class='ac-pdf-table' align='center'>
                                    <thead>
                                        <tr>
                                            <th >Lp.</th>
                                            <th >Data i godzina wejścia</th>
                                            <th >Imię i nazwisko osoby wchodzącej do pomieszczenia, w którym utryzmywane są świnie </th>
                                            <th >Nazwa firmy /instytucji lub pracownicy danego gospodarstwa </th>
                                            <th >Cel wejscia</th>
                                            <th >Numer budynku (jeśli więcej niż 1)</th>
                                            <th >Data i miejsce ostatniego pobytu w innym gospodarstwie, w którym utrzymywane są świnie oraz uczestniczenia w polowaniu lub odłowie zwierząt dzikich</th>
                                            <th >Czy zastosowano odzież i obuwie ochronne przed wejściem do budynku? TAK/NIE</th>
                                            <th >Podpis osoby odpowiedzialnej za prowadzenie rejestru</th>
                                        </tr>
                                    </thead>
            ");

            for (int i = 0; i < pageRowCount - (events.Count % pageRowCount); i++)
            {
                if (i < events.Count)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td></td>
                                  </tr>",
                        i + 1,
                        events[i].DataIGodzinaWejścia,
                        events[i].NazwaOsobyWchodzacej,
                        events[i].NazwaFirmy,
                        events[i].CelWejscia,
                        events[i].ObiektGospodarczy.Nazwa,
                        events[i].DataMiejsceOstatniegoPobytu,
                        events[i].CzyZastosowanoOchrone
                    );
                }
                else
                {
                    sb.AppendFormat(@"<tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                  </tr>");
                }

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetEventPrzegladZabezpieczenHTMLString(List<EventPrzegladZabezpieczen> events)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                        <html>
                            <head>
                                <style>
                                   .ac-pdf-table{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table th{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table td{
                                        border: solid 1px black;
                                        height: 50px;
                                        border-collapse: collapse;
                                        text-align: center;
                                    }
                                    .ac-pdf-disabled{
                                        background-color: #777;
                                    }
                                </style>
                            </head>
                            <body>
                                <table class='ac-pdf-table' align='center'>
                                    <thead>
                                        <tr>
                                            <th rowspan='2'>Lp.</th>
                                            <th rowspan='2'>Data sprawdzenia</th>
                                            <th colspan='2'>Ogólna szczelność budynku</th>
                                            <th colspan='2'>Okna</th>
                                            <th colspan='2'>Drzwi zewnętrzne lub zasuwa otworu przy stosowaniu silosów</th>
                                            <th colspan='2'>Drzwi wewnętrzne</th>
                                            <th colspan='2'>Podjęte naprawy</th>
                                            <th rowspan='2'>Podpis osoby odpowiedzialnej za dokonanie przeglądu</th>
                                        </tr>
                                        <tr>
                                            <th >budynek inwentarski (świnie)</th>
                                            <th >magazyn pasz</th>
                                            <th >budynek inwentarski (świnie)</th>
                                            <th >magazyn pasz</th>
                                            <th >budynek inwentarski (świnie)</th>
                                            <th >magazyn pasz</th>
                                            <th >budynek inwentarski (świnie)</th>
                                            <th >magazyn pasz</th>
                                            <th >budynek inwentarski (świnie)</th>
                                            <th >magazyn pasz</th>
                                        </tr>
                                    </thead>
            ");

            for (int i = 0; i < pageRowCount - (events.Count % pageRowCount); i++)
            {
                if (i < events.Count)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                    <td>{9}</td>
                                    <td>{10}</td>
                                    <td>{11}</td>
                                    <td></td>D
                                  </tr>",
                        i + 1,
                        events[i].DataPrzegladu,
                        events[i].SzczelnoscBudynku,
                        events[i].SzczelnoscMagazynuPasz,
                        events[i].SzczelnoscOkienBudynku,
                        events[i].SzczelnoscOkienMagazynuPasz,
                        events[i].SzczelnoscDrzwiZewnetrzychBudynku,
                        events[i].SzczelnoscDrzwiZewnetrzychMagazynuPasz,
                        events[i].SzczelnoscDrzwiWewnętrzychBudynku,
                        events[i].SzczelnoscDrzwiWewnętrznychMagazynuPasz,
                        events[i].PodjeteNaprawyBudynek,
                        events[i].PodjeteNaprawyMagazynPasz

                    );
                }
                else
                {
                    sb.AppendFormat(@"<tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                  </tr>");
                }

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetEventSpisZwierzatHTMLString(List<EventSpisZwierzat> events)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        
                        <html>
                            <head>
                                <style>
                                   .ac-pdf-table{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table th{
                                        border: solid 1px black;
                                        border-collapse: collapse;
                                    }
                                    .ac-pdf-table td{
                                        border: solid 1px black;
                                        height: 50px;
                                        border-collapse: collapse;
                                        text-align: center;
                                    }
                                    .ac-pdf-disabled{
                                        background-color: #777;
                                    }
                                </style>
                            </head>
                            <body>
                                <table class='ac-pdf-table' align='center'>
                                    <thead>
                                        <tr>
                                            <th >Lp.</th>
                                            <th >Data spisu </th>
                                            <th >Liczba prosiąt (zwierzę od urodzenia do odsadzenia) </th>
                                            <th >Liczba warchlaków (świnia od odsadzenia do 10 tygodnia życia) </th>
                                            <th >Liczba tuczników (świnie od 10 tygodnia życia do dnia uboju) </th>
                                            <th >Liczba loch (samica po pierwszym wyproszeniu) </th>
                                            <th >Liczba loszek (dojrzała samica do pierwszego wyproszenia) </th>
                                            <th >Liczba knurów (dojrzałe samce używane do rozrodu) </th>
                                            <th >Liczba knurków (samiec od 10 tyg. życia do pierwszego krycia) </th>
                                            <th >Podpis osoby spisującej </th>
                                        </tr>
                                    </thead>
            ");

            for (int i = 0; i < pageRowCount - (events.Count % pageRowCount); i++)
            {
                if (i < events.Count)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                    <td></td>D
                                  </tr>",
                        i + 1,
                        events[i].DataSpisu,
                        events[i].LiczbaProsiat,
                        events[i].LiczbaWarchlakow,
                        events[i].LiczbaTucznikow,
                        events[i].LiczbaLoch,
                        events[i].LiczbaLoszek,
                        events[i].LiczbaKnurow,
                        events[i].LiczbaKnurkow

                    );
                }
                else
                {
                    sb.AppendFormat(@"<tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                  </tr>");
                }

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}