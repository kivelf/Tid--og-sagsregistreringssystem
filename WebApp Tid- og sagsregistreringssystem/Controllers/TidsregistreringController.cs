using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Tid__og_sagsregistreringssystem.Controllers
{
    public class TidsregistreringViewModel
    {
        public int? SelectedAfdelingID { get; set; }
        public int? SelectedSagID { get; set; }
        public int? SelectedMedarbejderID { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }

        public List<SelectListItem> Afdelinger { get; set; }
        public List<SelectListItem> Sager { get; set; }
        public List<SelectListItem> Medarbejdere { get; set; }
    }

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
            var afdelinger = afdelingBLL.GetAlleAfdelinger();

            var model = new TidsregistreringViewModel
            {
                Afdelinger = afdelinger.Select(a => new SelectListItem
                {
                    Value = a.AfdelingID.ToString(),
                    Text = a.Navn
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TidsregistreringViewModel model)
        {
            if (model.SelectedAfdelingID == null)
            {
                TempData["Error"] = "Du skal vælge en afdeling!";
                return RedirectToAction("Index");
            }

            var afdelinger = afdelingBLL.GetAlleAfdelinger();
            var sager = sagBLL.GetAlleSager((int)model.SelectedAfdelingID);
            var medarbejdere = medarbejderBLL.GetAlleMedarbejdere((int)model.SelectedAfdelingID);

            model.Afdelinger = afdelinger.Select(a => new SelectListItem
            {
                Value = a.AfdelingID.ToString(),
                Text = a.Navn
            }).ToList();

            model.Sager = sager.Select(s => new SelectListItem
            {
                Value = s.SagID.ToString(),
                Text = s.ToString()
            }).ToList();

            model.Medarbejdere = medarbejdere.Select(m => new SelectListItem
            {
                Value = m.MedarbejderID.ToString(),
                Text = m.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult OpretTidsregistrering(TidsregistreringViewModel model)
        {
            if (model.SelectedSagID == null || model.SelectedMedarbejderID == null || model.SelectedSagID <= 0 || model.SelectedMedarbejderID <= 0)
            {
                TempData["Error"] = "Du skal vælge både en sag og en medarbejder!";
                return RedirectToAction("Index");
            }

            if (model.Date > DateTime.Now)
            {
                TempData["Error"] = "Datoen kan ikke være i fremtiden!";
                return RedirectToAction("Index");
            }

            if (model.Hours < 1)
            {
                TempData["Error"] = "Timer skal være mindst 1!";
                return RedirectToAction("Index");
            }

            bool harOvertid = model.Hours + tidsregistreringBLL.GetArbejdstidSidsteUge((int)model.SelectedMedarbejderID) > 37;
            if (harOvertid)
            {
                TempData["Error"] = "Du må ikke arbejde mere end 37 timer per uge - slap lidt af! :)";
                return RedirectToAction("Index");
            }

            var tidsregistrering = new Tidsregistrering(model.Date, model.Date.AddHours(model.Hours), 
                (int)model.SelectedMedarbejderID, (int)model.SelectedSagID);

            tidsregistreringBLL.AddTidsregistrering(tidsregistrering);

            TempData["Success"] = "Tidsregistreringen blev oprettet!";
            return RedirectToAction("Index");
        }
    }
}