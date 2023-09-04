using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyCore.Infrastructure.Files.OpenXML.SpreadsheetML;

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
            ViewData["Title"] = "Home - PropertyCore";
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
            //SpreadSheetBuilder testBuilder = new SpreadSheetBuilder();

            //return File(testBuilder.Generate(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AuditTest.xlsx");
            return View();
        }
    }
}
