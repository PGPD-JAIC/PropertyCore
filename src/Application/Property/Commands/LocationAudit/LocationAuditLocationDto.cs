using PropertyCore.Application.Common.Mappings;
using PropertyCore.Domain.Entities;
using System.Linq;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    public class LocationAuditLocationDto : IMapFrom<ListManagementCode>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ListManagementCode, LocationAuditLocationDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.ListManagementCodeGroupEntry.First().Description))
                .ForMember(x => x.Type, opt => opt.MapFrom(y => y.ListManagementCodeAttributes.First().Value));
        }
    }
}
