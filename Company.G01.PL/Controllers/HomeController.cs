using System.Diagnostics;
using System.Text;
using Company.G01.PL.Models;
using Company.G01.PL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedSerivece scopedSerivece01;
        private readonly IScopedSerivece scopedSerivece02;
        private readonly ITransentService transentService01;
        private readonly ITransentService transentService02;
        private readonly ISengletonService sengletonService01;
        private readonly ISengletonService sengletonService02;

        public HomeController(
            ILogger<HomeController> logger,
            IScopedSerivece scopedSerivece01,
              IScopedSerivece scopedSerivece02,
              ITransentService transentService01,
              ITransentService transentService02,
              ISengletonService sengletonService01,
               ISengletonService sengletonService02
            )
        {
            _logger = logger;
            this.scopedSerivece01 = scopedSerivece01;
            this.scopedSerivece02 = scopedSerivece02;
            this.transentService01 = transentService01;
            this.transentService02 = transentService02;
            this.sengletonService01 = sengletonService01;
            this.sengletonService02 = sengletonService02;
        }

        public string TestLifeTime()
        {
            StringBuilder builder= new StringBuilder();
            builder.Append($"scopedServicecs01::{scopedSerivece01.GetGuid()}\n");
            builder.Append($"scopedServicecs02::{scopedSerivece02.GetGuid()}\n\n");
            builder.Append($"transentService01::{transentService01.GetGuid()}\n");
            builder.Append($"transentService02::{transentService02.GetGuid()} \n\n");
            builder.Append($"sengletonService01 ::{sengletonService01.GetGuid()} \n");
            builder.Append($"sengletonService02 ::{sengletonService02.GetGuid()}\n\n");

            return builder.ToString();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
