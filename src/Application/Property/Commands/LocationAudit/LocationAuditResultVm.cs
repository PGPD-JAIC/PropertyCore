using System.Collections;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    public class LocationAuditResultVm
    {
        public int FoundItemsCount { get; set; } = 0;
        public List<LocationAuditResultPropertyItemDto> NotScanned { get; set; } = new List<LocationAuditResultPropertyItemDto>();
        public List<LocationAuditResultPropertyItemDto> NotPresent { get; set; } = new List<LocationAuditResultPropertyItemDto>();
    }    
}