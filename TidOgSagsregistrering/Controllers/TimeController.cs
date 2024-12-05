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


        public ActionResult ShowTidsregistrering(int medarbejderId)
        {
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(medarbejderId);

            ViewBag.Medarbejder = medarbejder;
            ViewBag.Tidsregistreringer = tidsregistreringer;

            return View();
        }

        public ActionResult AddTidsregistrering(int medarbejderId)
        {
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);

            var sager = medarbejder.Afdeling != null ? SagBLL.GetSagerForAfdeling(medarbejder.Afdeling.Nummer) : new List<SagDTO>();

            ViewBag.Medarbejder = medarbejder;
            ViewBag.Sager = sager;

            return View();
        }


        [HttpPost]
        public ActionResult AddTidsregistrering(int medarbejderId, DateTime startTid, DateTime slutTid, int? sagId)
        {
            var medarbejder = MedarbejderBLL.GetMedarbejderById(medarbejderId);

            SagDTO sag = null;
            if (sagId.HasValue)
            {
                sag = SagBLL.GetSagById(sagId.Value);
                if (sag == null)
                {
                    ModelState.AddModelError("sagId", "Ugyldig Sag");
                }
            }

            if (medarbejder == null)
            {
                ModelState.AddModelError("medarbejderId", "Ugyldig Medarbejder");
            }

            if (startTid >= slutTid)
            {
                ModelState.AddModelError("slutTid", "Sluttidspunkt skal være efter startstidspunkt :) ");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Medarbejder = medarbejder;
                ViewBag.Sager = medarbejder?.Afdeling != null ? SagBLL.GetSagerForAfdeling(medarbejder.Afdeling.Nummer) : new List<SagDTO>();
                return View();
            }

            TidsregistreringBLL.CreateTidsregistrering(startTid, slutTid, medarbejder, sag);

            return RedirectToAction("ShowTidsregistrering", new { medarbejderId = medarbejderId });
        }





    }
}
