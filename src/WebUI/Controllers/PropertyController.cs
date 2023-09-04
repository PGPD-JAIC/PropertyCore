using Microsoft.AspNetCore.Mvc;
using PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocation;
using PropertyCore.Application.Property.Commands.LocationAudit;
using PropertyCore.Application.Property.Queries.GetAuditFile;
using PropertyCore.Application.Property.Queries.GetPropertyDetail;
using PropertyCore.Application.Property.Queries.GetPropertyFile;
using PropertyCore.Application.Property.Queries.GetPropertyList;
using System.Threading.Tasks;

namespace PropertyCore.WebUI.Controllers
{
    /// <summary>
    /// Controller used to handle interactions with Property items.
    /// </summary>
    public class PropertyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] GetPropertyListQuery request, string returnUrl)
        {
            ViewData["ActiveMenu"] = "Property";
            ViewData["ActiveLink"] = "PropertySearch";
            ViewData["Title"] = "Property Search";
            ViewBag.ReturnUrl = returnUrl;
            return View(await Mediator.Send(request));
        }
        /// <summary>
        /// Returns a detailed view of a charge.
        /// </summary>
        /// <param name="request">A <see cref="GetPropertyDetailQuery"/> object assembled from the query parameters.</param>
        /// <param name="returnUrl">An optional string returnUrl used to facilitate navigation.</param>
        /// <returns>A <see cref="IActionResult"/></returns>
        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] GetPropertyDetailQuery request, string returnUrl)
        {
            ViewData["ActiveMenu"] = "Property";
            ViewData["Title"] = "Property Detail";
            ViewBag.ReturnUrl = returnUrl;
            return View(await Mediator.Send(request));
        }
        [HttpGet]
        public async Task<FileResult> Download([FromQuery] GetPropertyFileQuery request, string returnUrl)
        {
            var vm = await Mediator.Send(request);
            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        [HttpGet]
        public async Task<IActionResult> LocationAudit([FromQuery] string returnUrl)
        {
            ViewData["ActiveMenu"] = "Property";
            ViewData["Title"] = "PropertyAudit";
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.PropertyLocations = await Mediator.Send(new GetPGPDPropertyLocationsQuery());
            return View(new LocationAuditCommand());
        }
        
        [HttpPost]
        public async Task<IActionResult> LocationAudit([FromForm] LocationAuditCommand command, [FromQuery] string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActiveMenu"] = "Property";
                ViewData["Title"] = "Property Audit: Error";
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.PropertyLocations = await Mediator.Send(new GetPGPDPropertyLocationsQuery());
                return View(command);
            }
            var result = await Mediator.Send(command);
            return View("AuditResults", result);
        }
        [HttpPost]
        public async Task<IActionResult> LocationFile([FromForm] GetAuditFileQuery request)
        {
            var vm = await Mediator.Send(request);
            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        public IActionResult AuditResults(LocationAuditResultVm request)
        {
            ViewData["ActiveMenu"] = "Property";
            ViewData["Title"] = "Property Audit Results";
            return View(request);
        }
    }
}
