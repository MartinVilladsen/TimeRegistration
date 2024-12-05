using System.Web.Mvc;
using BLL;

namespace TidOgSagsregistrering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? afdelingId)
        {
            var afdelinger = AfdelingBLL.GetAllAfdelinger();
            ViewBag.Afdelinger = afdelinger;

            ViewBag.SelectedAfdelingId = afdelingId ?? 0;

            ViewBag.SelectedAfdeling = afdelingId.HasValue && afdelingId > 0
                ? AfdelingBLL.GetAfdelingById(afdelingId.Value)
                : null;


            var medarbejdere = afdelingId.HasValue && afdelingId > 0
                ? MedarbejderBLL.GetMedarbejdereForAfdeling(afdelingId.Value)
                : MedarbejderBLL.GetAllMedarbejder();

            return View(medarbejdere);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int afdelingId = int.Parse(form["afdelingDropdown"]);
            return RedirectToAction("Index", new { afdelingId });
        }
    }
}
