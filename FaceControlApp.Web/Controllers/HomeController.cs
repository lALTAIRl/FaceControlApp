namespace FaceControlApp.Web.Controllers
{
    using FaceControlApp.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    public class HomeController : AppController
    {
        private ILogger<HomeController> Logger
        {
            get;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            this.Logger = logger;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
