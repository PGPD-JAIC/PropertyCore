using System.Collections;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    public class LocationAuditResultVm
    {
        /// <summary>
        /// A string containing a list of BarCodes separated by commas.
        /// </summary>
        public string BarCodes { get; set; }
        public LocationAuditLocationDto Location { get; set; }
        public int FoundItemsCount { get; set; } = 0;
        public List<LocationAuditResultPropertyItemDto> NotScanned { get; set; } = new List<LocationAuditResultPropertyItemDto>();
        public List<LocationAuditResultPropertyItemDto> NotPresent { get; set; } = new List<LocationAuditResultPropertyItemDto>();
    }    
}