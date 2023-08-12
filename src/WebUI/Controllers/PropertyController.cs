using Microsoft.AspNetCore.Mvc;
using PropertyCore.Application.Property.Queries.GetPropertyDetail;
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
    }
}
