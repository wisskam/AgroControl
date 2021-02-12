using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AgroControl.DBContexts;
using AgroControl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroControl.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly GospodarstwoContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EventController(GospodarstwoContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            SetViewBagMessages();

            List<EventModelBase> baseEvents = new List<EventModelBase>();

            List<EventRejestrTransportu> eventsRejestrTransportu = 
                await _context.EventsRejestrTransportu.ToListAsync();
            baseEvents.AddRange(eventsRejestrTransportu.Cast<EventModelBase>().ToList());
            
            List<EventRejestrWejscWyjsc> eventsRejestrWejscWyjsc = 
                await _context.EventsRejestrWejscWyjsc.ToListAsync();
            baseEvents.AddRange(eventsRejestrWejscWyjsc.Cast<EventModelBase>().ToList());

            List<EventSpisZwierzat> eventSpisZwierzat = 
                await _context.EventsSpisZwierzat.ToListAsync();
            baseEvents.AddRange(eventSpisZwierzat.Cast<EventModelBase>().ToList());

            List<EventDezynfekcja> eventDezynfekcja = 
                await _context.EventsDezynfekcja.ToListAsync();
            baseEvents.AddRange(eventDezynfekcja.Cast<EventModelBase>().ToList());

            List<EventPrzegladZabezpieczen> eventPrzegladZabezpieczen = 
                await _context.EventsPrzegladZabezpieczen.ToListAsync();
            baseEvents.AddRange(eventPrzegladZabezpieczen.Cast<EventModelBase>().ToList());

            
            return View(baseEvents.OrderByDescending(x => x.CreatedDate).ToList());
        }

        public IActionResult CreateEventRejestrTransportu()
        {
            return View();
        }
        public async Task<IActionResult> CreateEventRejestrWejscWyjsc()
        {
            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] = 
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();
            return View();
        }
        public IActionResult CreateEventSpisZwierzat()
        {
            return View(new EventSpisZwierzat());
        }
        public async Task<IActionResult> CreateEventDezynfekcja()
        {
            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] =
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();
            return View(new EventDezynfekcja());
        }
        public async Task<IActionResult> CreateEventPrzegladZabezpieczen()
        {
            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] =
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();
            return View(new EventPrzegladZabezpieczen());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventRejestrTransportu(EventRejestrTransportu eventRejestrTransportu)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await CreateEvent(eventRejestrTransportu);
            SetViewBagMessages();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventRejestrWejscWyjsc(EventRejestrWejscWyjsc eventRejestrWejscWyjsc)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await CreateEvent(eventRejestrWejscWyjsc);
            SetViewBagMessages();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventSpisZwierzat(EventSpisZwierzat eventSpisZwierzat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await CreateEvent(eventSpisZwierzat);
            SetViewBagMessages();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventDezynfekcja(EventDezynfekcja eventDezynfekcja)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await CreateEvent(eventDezynfekcja);
            SetViewBagMessages();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEventPrzegladZabezpieczen(EventPrzegladZabezpieczen eventPrzegladZabezpieczen)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await CreateEvent(eventPrzegladZabezpieczen);
            SetViewBagMessages();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent<T>(T newEvent) where T : EventModelBase
        {
            try
            {
                var gospodarstwo = await GetCurrentGospodarstwo();

                newEvent.GospodarstwoID = gospodarstwo.ID;
                newEvent.CreatedDate = DateTime.Now;

                if (newEvent.GetType() == typeof(EventRejestrTransportu))
                {
                    EventRejestrTransportu eventRejestrTransportu = 
                        (EventRejestrTransportu)Convert.ChangeType(newEvent, typeof(EventRejestrTransportu));

                    eventRejestrTransportu.EventType = EventTypes.RejestrTransportu;
                    _context.Add(eventRejestrTransportu);
                }
                else if (newEvent.GetType() == typeof(EventRejestrWejscWyjsc))
                {
                    EventRejestrWejscWyjsc eventRejestrWejscWyjsc = 
                        (EventRejestrWejscWyjsc)Convert.ChangeType(newEvent, typeof(EventRejestrWejscWyjsc));

                    ObiektGospodarczy og = await _context.ObiektyGospodarcze.
                        FirstOrDefaultAsync(x => x.ID == int.Parse(eventRejestrWejscWyjsc.NazwaNumerBudynku));

                    eventRejestrWejscWyjsc.ObiektGospodarczyID = int.Parse(eventRejestrWejscWyjsc.NazwaNumerBudynku);
                    eventRejestrWejscWyjsc.NazwaNumerBudynku = og.Nazwa;
                    eventRejestrWejscWyjsc.EventType = EventTypes.RejestrWejscWyjsc;
                    _context.Add(eventRejestrWejscWyjsc);
                }
                else if (newEvent.GetType() == typeof(EventSpisZwierzat))
                {
                    EventSpisZwierzat eventSpisZwierzat =
                        (EventSpisZwierzat)Convert.ChangeType(newEvent, typeof(EventSpisZwierzat));

                    eventSpisZwierzat.EventType = EventTypes.SpisZwierzat;
                    _context.Add(eventSpisZwierzat);
                }
                else if (newEvent.GetType() == typeof(EventDezynfekcja))
                {
                    EventDezynfekcja eventDezynfekcja =
                        (EventDezynfekcja)Convert.ChangeType(newEvent, typeof(EventDezynfekcja));

                    eventDezynfekcja.EventType = EventTypes.Dezynfekcja;
                    _context.Add(eventDezynfekcja);
                }
                else if (newEvent.GetType() == typeof(EventPrzegladZabezpieczen))
                {
                    EventPrzegladZabezpieczen eventPrzegladZabezpieczen =
                        (EventPrzegladZabezpieczen)Convert.ChangeType(newEvent, typeof(EventPrzegladZabezpieczen));

                    eventPrzegladZabezpieczen.EventType = EventTypes.PrzegladZabezpieczen;
                    _context.Add(eventPrzegladZabezpieczen);
                }
                else
                {
                    TempData["Message"] += "Nieznany typ zdarzenia";
                    TempData["MessageType"] = "error";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] += ex.Message;
                TempData["MessageType"] = "error";
                return View();
            }

            TempData["Message"] += "Pomyślnie dodano zdarzenie do rejestru!";
            TempData["MessageType"] = "success";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> EditEventRejestrTransportu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRejestrTransportu = await _context.EventsRejestrTransportu.FindAsync(id);
            if (eventRejestrTransportu == null)
            {
                return NotFound();
            }
            return View(eventRejestrTransportu);
        }        
        public async Task<IActionResult> EditEventRejestrWejscWyjsc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] = 
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();

            var eventRejestrWejscWyjsc = await _context.EventsRejestrWejscWyjsc.FindAsync(id);
            if (eventRejestrWejscWyjsc == null)
            {
                return NotFound();
            }
            return View(eventRejestrWejscWyjsc);
        }
        public async Task<IActionResult> EditEventSpisZwierzat(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSpisZwierzat = await _context.EventsSpisZwierzat.FindAsync(id);
            if (eventSpisZwierzat == null)
            {
                return NotFound();
            }
            return View(eventSpisZwierzat);
        }
        public async Task<IActionResult> EditEventDezynfekcja(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] =
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();

            var eventDezynfekcja = await _context.EventsDezynfekcja.FindAsync(id);
            if (eventDezynfekcja == null)
            {
                return NotFound();
            }
            return View(eventDezynfekcja);
        }
        public async Task<IActionResult> EditEventPrzegladZabezpieczen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int gospodarstwoID = await GetCurrentGospodarstwoID();
            ViewData["ObiektyGospodarcze"] =
                await _context.ObiektyGospodarcze.Where(x => x.GospodarstwoID == gospodarstwoID).ToListAsync();

            var eventPrzegladZabezpieczen = await _context.EventsPrzegladZabezpieczen.FindAsync(id);
            if (eventPrzegladZabezpieczen == null)
            {
                return NotFound();
            }
            return View(eventPrzegladZabezpieczen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventRejestrTransportu(int id, EventRejestrTransportu eventRejestrTransportu)
        {

            if (id != eventRejestrTransportu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool result = await Edit(eventRejestrTransportu);

                SetViewBagMessages();

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(eventRejestrTransportu);
            }
            return View(eventRejestrTransportu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventRejestrWejscWyjsc(int id, EventRejestrWejscWyjsc eventRejestrWejscWyjsc)
        {

            if (id != eventRejestrWejscWyjsc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool result = await Edit(eventRejestrWejscWyjsc);

                SetViewBagMessages();

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(eventRejestrWejscWyjsc);
            }
            return View(eventRejestrWejscWyjsc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventSpisZwierzat(int id, EventSpisZwierzat eventSpisZwierzat)
        {

            if (id != eventSpisZwierzat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool result = await Edit(eventSpisZwierzat);

                SetViewBagMessages();

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(eventSpisZwierzat);
            }
            return View(eventSpisZwierzat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventDezynfekcja(int id, EventDezynfekcja eventDezynfekcja)
        {

            if (id != eventDezynfekcja.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool result = await Edit(eventDezynfekcja);

                SetViewBagMessages();

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(eventDezynfekcja);
            }
            return View(eventDezynfekcja);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventPrzegladZabezpieczen(int id, EventPrzegladZabezpieczen eventPrzegladZabezpieczen)
        {

            if (id != eventPrzegladZabezpieczen.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool result = await Edit(eventPrzegladZabezpieczen);

                SetViewBagMessages();

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(eventPrzegladZabezpieczen);
            }
            return View(eventPrzegladZabezpieczen);
        }

        [ValidateAntiForgeryToken]
        public async Task<bool> Edit<T>(T model) where T : EventModelBase
        {
            try
            {
                Type modelType = model.GetType();

                if (!EventExists(model.ID, modelType))
                {
                    TempData["Message"] += "Nie znaleziono takiego zdarzenia";
                    TempData["MessageType"] = "error";
                    return false;
                }
                if(modelType == typeof(EventRejestrWejscWyjsc))
                {
                    EventRejestrWejscWyjsc eventRejestrWejscWyjsc =
                        (EventRejestrWejscWyjsc)Convert.ChangeType(model, typeof(EventRejestrWejscWyjsc));

                    ObiektGospodarczy og = await _context.ObiektyGospodarcze.
                        FirstOrDefaultAsync(x => x.ID == int.Parse(eventRejestrWejscWyjsc.NazwaNumerBudynku));

                    eventRejestrWejscWyjsc.ObiektGospodarczyID = int.Parse(eventRejestrWejscWyjsc.NazwaNumerBudynku);

                    _context.Update(eventRejestrWejscWyjsc);
                }
                else
                {
                    _context.Update(model);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                TempData["Message"] += "DbUpdateConcurrencyException";
                TempData["MessageType"] = "error";
                return false;
            }
            TempData["Message"] += "Pomyślnie zaktualizowano zdarzenie!";
            TempData["MessageType"] = "success";
            return true;
        }

        public async Task<IActionResult> Delete(int id, string type)
        {
            //string type = "EventRejestrTransportu";
            EventModelBase eventToDelete;
            if(type == "EventRejestrTransportu")
            {
                eventToDelete = await _context.EventsRejestrTransportu.FindAsync(id);
                _context.Remove(eventToDelete);

            }
            else if(type == "EventRejestrWejscWyjsc")
            {
                eventToDelete = await _context.EventsRejestrWejscWyjsc.FindAsync(id);
                _context.Remove(eventToDelete);
            }
            else if(type == "EventSpisZwierzat")
            {
                eventToDelete = await _context.EventsSpisZwierzat.FindAsync(id);
                _context.Remove(eventToDelete);
            }
            else if (type == "EventDezynfekcja")
            {
                eventToDelete = await _context.EventsDezynfekcja.FindAsync(id);
                _context.Remove(eventToDelete);
            }
            else if (type == "EventPrzegladZabezpieczen")
            {
                eventToDelete = await _context.EventsPrzegladZabezpieczen.FindAsync(id);
                _context.Remove(eventToDelete);
            }
            else
            {
                TempData["Message"] = "Nieznany typ zdarzenia!";
                TempData["MessageType"] = "error";
                return RedirectToAction(nameof(Index));
            }

            TempData["Message"] = "Obiekt gospodarczy usunięty!";
            TempData["MessageType"] = "success";

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id, Type modelType)
        {
            if(modelType == typeof(EventRejestrTransportu))
            {
                return _context.EventsRejestrTransportu.Any(e => e.ID == id);
            }
            if(modelType == typeof(EventRejestrWejscWyjsc))
            {
                return _context.EventsRejestrWejscWyjsc.Any(e => e.ID == id);
            }
            if (modelType == typeof(EventSpisZwierzat))
            {
                return _context.EventsSpisZwierzat.Any(e => e.ID == id);
            }
            if (modelType == typeof(EventDezynfekcja))
            {
                return _context.EventsDezynfekcja.Any(e => e.ID == id);
            }
            if (modelType == typeof(EventPrzegladZabezpieczen))
            {
                return _context.EventsPrzegladZabezpieczen.Any(e => e.ID == id);
            }
            return false;
        }

        private void SetViewBagMessages()
        {
            ViewBag.Message += TempData["Message"];
            ViewBag.MessageType += TempData["MessageType"];
        }

        private async Task<int> GetCurrentGospodarstwoID()
        {
            Gospodarstwo gosp = await GetCurrentGospodarstwo();
            return  gosp.ID;
        }
        private async Task<Gospodarstwo> GetCurrentGospodarstwo()
        {
            int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var gospodarstwo = await _context.Gospodarstwo.FirstOrDefaultAsync(x => x.UserID == userID);

            return gospodarstwo;
        }
    }
}
