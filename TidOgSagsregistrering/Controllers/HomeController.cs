using System.Web.Mvc;
using BLL;

namespace TidOgSagsregistrering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? afdelingId)
        {
            ViewBag.Afdelinger = AfdelingBLL.GetAllAfdelinger();

            if (!afdelingId.HasValue)
            {
                ViewBag.Medarbejdere = MedarbejderBLL.GetAllMedarbejder();
                ViewBag.SelectedAfdelingId = null;
            }
            else if (afdelingId == 0)
            {
                ViewBag.Medarbejdere = MedarbejderBLL.GetAllMedarbejder();
                ViewBag.SelectedAfdelingId = 0;
            }
            else
            {
                ViewBag.Medarbejdere = MedarbejderBLL.GetMedarbejdereForAfdeling(afdelingId.Value);
                ViewBag.SelectedAfdelingId = afdelingId.Value;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int afdelingId = int.Parse(form["afdelingDropdown"]);
            return RedirectToAction("Index", new { afdelingId });
        }
    }
}
