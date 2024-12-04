using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using BLL.Models;
using DTO.Models;

namespace TidOgSagsregistrering.Controllers
{
    public class TimeController : Controller
    {
        public ActionResult ShowTimeRegistrations(int medarbejderId)
        {
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(medarbejderId);

            ViewBag.Medarbejder = medarbejder;
            ViewBag.Tidsregistreringer = tidsregistreringer;

            return View();
        }

        public ActionResult AddTimeRegistration(int medarbejderId)
        {
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);

            var sager = medarbejder.Afdeling != null ? SagBLL.GetSagerForAfdeling(medarbejder.Afdeling.Nummer) : new List<SagDTO>();

            ViewBag.Medarbejder = medarbejder;
            ViewBag.Sager = sager;

            return View();
        }


        [HttpPost]
        public ActionResult AddTimeRegistration(int medarbejderId, DateTime startTid, DateTime slutTid, int? sagId)
        {
            // Retrieve the employee
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);

            SagDTO sag = null;
            if (sagId.HasValue)
            {
                sag = SagBLL.GetSagById(sagId.Value);
                if (sag == null)
                {
                    ModelState.AddModelError("sagId", "Invalid Sag Id");
                }
            }

            if (medarbejder == null)
            {
                ModelState.AddModelError("medarbejderId", "Invalid Medarbejder Id");
            }

            if (startTid >= slutTid)
            {
                ModelState.AddModelError("slutTid", "Sluttid must be greater than Starttid");
            }

            if (!ModelState.IsValid)
            {
                // Repopulate dropdown data if validation fails
                ViewBag.Medarbejder = medarbejder;
                ViewBag.Sager = medarbejder?.Afdeling != null ? SagBLL.GetSagerForAfdeling(medarbejder.Afdeling.Nummer) : new List<SagDTO>();
                return View();
            }

            // Create the new TidsregistreringDTO without requiring a case
            TidsregistreringBLL.CreateTidsregistrering(startTid, slutTid, medarbejder, sag);

            // Redirect to ShowTimeRegistrations
            return RedirectToAction("ShowTimeRegistrations", new { medarbejderId = medarbejderId });
        }





    }
}
