using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Mappings;
using PropertyCore.Domain.Entities;
using System.Linq;

namespace PropertyCore.Application.Lists.Queries.GetRMSRealmQuery
{
    public class RMSRealmDto : IDropDownListItem, IMapFrom<ListManagementCode>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Creates a mapping between the entity class and the DTO.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ListManagementCode, RMSRealmDto>()
                .ForMember(x => x.Value, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(y => y.ListManagementCodeGroupEntry.First().Description));
        }
    }
}
