    using System.Diagnostics;
using ASC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ASC.Web.Configuration;
using ASC.Web.Services;
using Microsoft.CodeAnalysis.Options;
using ASC.Ultilites;

namespace ASC.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IOptions<ApplicationSettings> _settings;
        public HomeController(IOptions<ApplicationSettings> settings
            //, ILogger<HomeController>logger
            )
        {
            //_logger = logger
            _settings = settings;
        }

        //public IActionResult Index([FromServices] IEmailSender emailSender)
        //{
        //    var emailService = this.HttpContext.RequestServices.GetService(typeof(IEmailSender)) as IEmailSender;
        //    ViewBag.Title = _settings.Value.ApplicationTitle;
        //    return View();
        //}

        public IActionResult Index()
        {
            HttpContext.Session.SetSession("Test", _settings.Value);
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");
            ViewBag.Title = _settings.Value.ApplicationTitle;
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
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
