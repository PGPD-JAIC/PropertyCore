using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PropertyCore.Application.Property.Queries.GetAuditFile
{
    public class AuditFileResults
    {
        public int ScannedItemsCount { get; set; } = 0; 
        public AuditFileLocationDto Location { get; set; } = new AuditFileLocationDto();
        public int FoundItems { get; set; } = 0;
        public List<AuditFilePropertyItemDto> ScannedAtOtherLocations { get; set; } = new List<AuditFilePropertyItemDto>();
        public List<AuditFilePropertyItemDto> NotScannedAtLocations { get; set; } = new List<AuditFilePropertyItemDto>();
    }
}
