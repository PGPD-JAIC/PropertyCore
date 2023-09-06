using PropertyCore.Application.Common.Models;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Queries.GetLocationInventory
{
    public class LocationInventoryVm
    {
        /// <summary>
        /// A collection of property items converted to <see cref="LocationInventoryPropertyItemDto"/>
        /// </summary>
        public ICollection<LocationInventoryPropertyItemDto> Items { get; set; } = new List<LocationInventoryPropertyItemDto>();
        /// <summary>
        /// A collection of Locations.
        /// </summary>
        public ICollection<DropDownListItem> Locations { get; set; } = new List<DropDownListItem>();
        /// <summary>
        /// The Id of the selected Location.
        /// </summary>
        public string SelectedLocationId { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}