using PropertyCore.Application.Property.Queries.GetAuditFile;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Queries.GetLocationInventoryFile
{
    public class LocationInventoryResults
    {
        public LocationInventoryFileLocationDto Location { get; set; } = new LocationInventoryFileLocationDto();
        public List<LocationInventoryFilePropertyItemDto> Items { get; set; } = new List<LocationInventoryFilePropertyItemDto>();
    }
}
