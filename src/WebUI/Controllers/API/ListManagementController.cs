using Microsoft.AspNetCore.Mvc;
using PropertyCore.Application.Lists.Queries.GetListByName;
using PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocation;
using System.Threading.Tasks;

namespace PropertyCore.WebUI.Controllers.API
{
    public class ListManagementController : BaseApiController
    {
        /// <summary>
        /// Returns a list of Ids and Values for List Management list items in a list with the provided name.
        /// </summary>
        /// <param name="query">An instance of <see cref="GetListByNameQuery"/> assembled from the query parameters.</param>
        /// <returns>A list of <see cref="Application.Common.Models.DropDownListItem"/> containing the items.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetListByName([FromQuery] GetListByNameQuery request)
        {
            return Ok(await Mediator.Send(request));
        }
        /// <summary>
        /// Returns a list of Ids and Values for PGPD Property Locations.
        /// </summary>
        /// <param name="query">An instance of <see cref="GetPGPDPropertyLocationsQuery"/> assembled from the query parameters.</param>
        /// <returns>A list of <see cref="Application.Common.Models.DropDownListItem"/> containing the items.</returns>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetPGPDPropertyLocations([FromQuery] GetPGPDPropertyLocationsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

    }
}
