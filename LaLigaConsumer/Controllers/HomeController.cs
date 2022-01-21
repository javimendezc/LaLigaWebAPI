using System.Web.Mvc;

namespace LaLigaConsumer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Prueba técnica de Back End.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Datos de contacto:";

            return View();
        }
    }
}