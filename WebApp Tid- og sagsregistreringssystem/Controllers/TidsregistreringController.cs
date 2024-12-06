using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Tid__og_sagsregistreringssystem.Controllers
{
    public class TidsregistreringController : Controller
    {
        private static AfdelingBLL afdelingBLL = new AfdelingBLL();
        private static SagBLL sagBLL = new SagBLL();
        private static MedarbejderBLL medarbejderBLL = new MedarbejderBLL();
        private static TidsregistreringBLL tidsregistreringBLL = new TidsregistreringBLL();

        // GET: Tidsregistrering
        [HttpGet]
        public ActionResult Index()
        {
            // få alle afdelinger fra DB via BLL
            var afdelinger = afdelingBLL.GetAlleAfdelinger();

            // transform into SelectListItem for the dropdown-menu
            ViewBag.Afdelinger = afdelinger.Select(a => new SelectListItem
            {
                Value = a.AfdelingID.ToString(), // afdelingens ID == value
                Text = a.Navn
            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(int selectedAfdelingID)
        {
            var afdelinger = afdelingBLL.GetAlleAfdelinger();

            // få alle Sager og Medarbejdere fra den valgte afdeling
            var sager = sagBLL.GetAlleSager(selectedAfdelingID);
            var medarbejdere = medarbejderBLL.GetAlleMedarbejdere(selectedAfdelingID);

            // bruges i dropdown-lists
            ViewBag.Afdelinger = afdelinger.Select(a => new SelectListItem
            {
                Value = a.AfdelingID.ToString(),
                Text = a.Navn
            }).ToList();

            ViewBag.Sager = sager.Select(s => new SelectListItem
            {
                Value = s.SagID.ToString(),
                Text = s.ToString()
            }).ToList();

            ViewBag.Medarbejdere = medarbejdere.Select(m => new SelectListItem
            {
                Value = m.MedarbejderID.ToString(),
                Text = m.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult OpretTidsregistrering(int? selectedSagID, int? selectedMedarbejderID, DateTime date, int hours)
        {
            // validering af data
            if (selectedSagID == null || selectedMedarbejderID == null || selectedSagID <= 0 || selectedMedarbejderID <= 0)
            {
                TempData["Error"] = "Du skal vælge både en sag og en medarbejder!";
                return RedirectToAction("Index");
            }

            if (date > DateTime.Now)
            {
                TempData["Error"] = "Datoen kan ikke være i fremtiden!";
                return RedirectToAction("Index");
            }

            if (hours < 1)
            {
                TempData["Error"] = "Timer skal være mindst 1!";
                return RedirectToAction("Index");
            }

            bool harOvertid = hours + tidsregistreringBLL.GetArbejdstidSidsteUge((int)selectedMedarbejderID) > 37 ? true : false;
            if (harOvertid) 
            {
                TempData["Error"] = "Du må ikke arbejde mere end 37 timer per uge - slap lidt af! :)";
                return RedirectToAction("Index");
            }

            // bruger den valgte sag og medarbejder for at oprette en ny Tidsregistrering
            var tidsregistrering = new Tidsregistrering(date, date.AddHours(hours), (int)selectedMedarbejderID, (int)selectedSagID);

            // gem objektet via BLL
            tidsregistreringBLL.AddTidsregistrering(tidsregistrering);

            TempData["Success"] = "Tidsregistreringen blev oprettet!";
            return RedirectToAction("Index");
        }
    }
}