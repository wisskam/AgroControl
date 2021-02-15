using AgroControl.Models;
using AgroControl.Utilities;
using DinkToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AgroControl.Utilities
{
    public class PDFGenerator
    {
        private GlobalSettings _globalSettings;
        private ObjectSettings _objectSettings;

        public string FilePath {
            get { return _globalSettings.Out; }
        }
        //public string Header {
        //    get { return _objectSettings.HeaderSettings.Left; }
        //    set { _objectSettings.HeaderSettings.Left = value; }
        //}

        public PDFGenerator()
        {
            _globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "AgroControl - wydruk zdarzeń",
                Out = @"Files\Table.pdf",
                
            };

            _objectSettings = new ObjectSettings
            {
                PagesCount = true,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), @"assets\css", "site.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Strona [page] z [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "AgroControl - Molkapps.pl - Jakub Molka" },
            };

            if (!Directory.Exists(@"Files"))
            {
                Directory.CreateDirectory(@"Files");
            }

        }

        public void AddEvents<T>(List<T> events)
        {
            Type type = typeof(T);
            if(type == typeof(EventDezynfekcja))
            {
                MethodInfo method = typeof(TemplateGenerator).GetMethod("GetEventDezynfekcjaHTMLString");
                _objectSettings.HtmlContent = (string) method.Invoke(null, new object[] { events });
                _objectSettings.HeaderSettings.Left = "Zał. nr 6. Dokumentacja czyszczenia i dezynfekcji w gospodarstwie";
            }
            else if (type == typeof(EventRejestrTransportu))
            {
                MethodInfo method = typeof(TemplateGenerator).GetMethod("GetEventRejestrTransportuHTMLString");
                _objectSettings.HtmlContent = (string)method.Invoke(null, new object[] { events });
                _objectSettings.HeaderSettings.Left = "Zał. nr 2. Rejestr środków transportu wjeżdżajacych na teren gospodarstwa";
            }
            else if (type == typeof(EventRejestrWejscWyjsc))
            {
                MethodInfo method = typeof(TemplateGenerator).GetMethod("GetEventRejestrWejscWyjscHTMLString");
                _objectSettings.HtmlContent = (string)method.Invoke(null, new object[] { events });
                _objectSettings.HeaderSettings.Left = "Zał. nr 3. Rejestr osób wchodzących do pomieszczeń, w których utrzymywane są świnie";
            }
            else if (type == typeof(EventPrzegladZabezpieczen))
            {
                MethodInfo method = typeof(TemplateGenerator).GetMethod("GetEventPrzegladZabezpieczenHTMLString");
                _objectSettings.HtmlContent = (string)method.Invoke(null, new object[] { events });
                _objectSettings.HeaderSettings.Left = "Zał. nr 1. Przegląd zabezpieczeń budynków przed dostępem zwierząt wolno żyjacych oraz domowych";
            }
            else if (type == typeof(EventSpisZwierzat))
            {
                MethodInfo method = typeof(TemplateGenerator).GetMethod("GetEventSpisZwierzatHTMLString");
                _objectSettings.HtmlContent = (string)method.Invoke(null, new object[] { events });
                _objectSettings.HeaderSettings.Left = "Zał. nr 7. Spis świń w gospodarstwie *";
            }
        }

        public HtmlToPdfDocument GetHtmlToPdfDocument()
        {
            if(_objectSettings.HtmlContent != null)
            {
                return new HtmlToPdfDocument()
                {
                    GlobalSettings = _globalSettings,
                    Objects = { _objectSettings }
                };
            }
            return null;
        }


    }
}
