using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using F23.PresentationModelLnL.Web.VendorPortal.Models;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
