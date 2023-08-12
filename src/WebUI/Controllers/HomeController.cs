using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PropertyCore.WebUI.Controllers
{
    /// <summary>
    /// View Controller that returns Home Views.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Creates a new instance of the Controller.
        /// </summary>
        /// <param name="logger">An implementation of <see cref="ILogger"/></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About(string returnUrl)
        {
            ViewData["Title"] = "About PropertyCore";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public IActionResult Test()
        {
            ViewData["Title"] = "PropertyCore Test Page";
            return View();
        }
    }
}
