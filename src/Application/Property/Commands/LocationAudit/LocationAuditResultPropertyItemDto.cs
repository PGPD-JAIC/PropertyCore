using PropertyCore.Application.Common.Mappings;
using PropertyCore.Domain.Entities;
using System;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    public class LocationAuditResultPropertyItemDto : IMapFrom<PropertySheetTags>
    {
        /// <summary>
        /// The Instance Id of the entity.
        /// </summary>
        public Guid InstanceId { get; set; }
        /// <summary>
        /// The Sequence Number of the entity.
        /// </summary>
        public int SeqNo1 { get; set; }
        /// <summary>
        /// The Bar Code of the entity.
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// The Property Type of the entity.
        /// </summary>
        public string PropertyType { get; set; }
        /// <summary>
        /// The Category of the entity.
        /// </summary>
        public string PropertyCategory { get; set; }
        /// <summary>
        /// The current location of the entity.
        /// </summary>
        public string CurrentLocation { get; set; }
        /// <summary>
        /// The case number of the case associated with the entity.
        /// </summary>
        public string CaseNumber { get; set; }
        /// <summary>
        /// The property sheet number associated with the entity.
        /// </summary>
        public string PropertySheetNumber { get; set; }
        /// <summary>
        /// Creates a mapping between the entity class and the DTO.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PropertySheetTags, LocationAuditResultPropertyItemDto>()
                .ForMember(x => x.InstanceId, opt => opt.MapFrom(y => y.InstanceId))
                .ForMember(x => x.SeqNo1, opt => opt.MapFrom(y => y.SeqNo1))
                .ForMember(x => x.BarCode, opt => opt.MapFrom(y => y.TagNumber))
                .ForMember(x => x.PropertyType, opt => opt.MapFrom(y => y.PropertyTypeId))
                .ForMember(x => x.PropertyCategory, opt => opt.MapFrom(y => y.PropertyCategory))
                .ForMember(x => x.CaseNumber, opt => opt.MapFrom(y => y.TagsCaseNoRtf))
                .ForMember(x => x.PropertySheetNumber, opt => opt.MapFrom(y => y.TagsSheetNoRtf))
                .ForMember(x => x.CurrentLocation, opt => opt.MapFrom(y => y.CurrentLocation));
        }
    }
}
