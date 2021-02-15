using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgroControl.DBContexts;
using AgroControl.Models;
using AgroControl.Utilities;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AgroControl.Controllers
{
    public class PrintoutController : Controller
    {
        private IConverter _converter;
        private GospodarstwoContext _context;

        public PrintoutController(IConverter converter, GospodarstwoContext context)
        {
            _converter = converter;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreatePDF(EventTypes eventType, DateTime from, DateTime to)
        {
            if(from == null)
            {
                from = DateTime.MinValue;
            }
            if(to == DateTime.MinValue)
            {
                to = DateTime.Now;
            }

            PDFGenerator pdfGenerator = new PDFGenerator();

            switch (eventType)
            {
                case EventTypes.Dezynfekcja:
                    pdfGenerator.AddEvents<EventDezynfekcja>(
                        _context.EventsDezynfekcja.Where(x => x.DataZabiegu >= from && x.DataZabiegu <= to).ToList()    
                    );
                    break;
                case EventTypes.RejestrTransportu:
                    pdfGenerator.AddEvents<EventRejestrTransportu>(
                        _context.EventsRejestrTransportu.Where(x => x.DataIGodzinaWjazdu >= from && x.DataIGodzinaWjazdu <= to).ToList()    
                    );
                    break;
                case EventTypes.RejestrWejscWyjsc:
                    pdfGenerator.AddEvents<EventRejestrWejscWyjsc>(
                        _context.EventsRejestrWejscWyjsc.Where(x => x.DataIGodzinaWejścia >= from && x.DataIGodzinaWejścia <= to).ToList()    
                    );
                    break;
                case EventTypes.PrzegladZabezpieczen:
                    pdfGenerator.AddEvents<EventPrzegladZabezpieczen>(
                        _context.EventsPrzegladZabezpieczen.Where(x => x.DataPrzegladu>= from && x.DataPrzegladu <= to).ToList()    
                    );
                    break;
                case EventTypes.SpisZwierzat:
                    pdfGenerator.AddEvents<EventSpisZwierzat>(
                        _context.EventsSpisZwierzat.Where(x => x.DataSpisu>= from && x.DataSpisu <= to).ToList()    
                    );
                    break;
                default:
                    pdfGenerator.AddEvents<EventDezynfekcja>(
                        _context.EventsDezynfekcja.Where(x => x.DataZabiegu >= from && x.DataZabiegu <= to).ToList()  
                    );
                    break;
            }
           
            _converter.Convert(pdfGenerator.GetHtmlToPdfDocument());


            //return GetDownload(pdfGenerator.FilePath, $"File_{DateTime.Now.ToString("ddMMyyyHHmm")}.pdf");
            return GetDownload(pdfGenerator.FilePath, $"File.pdf");
        }


        public IActionResult GetDownload(string link, string fileName)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            return File(content, contentType, fileName);
        }



    }

}
