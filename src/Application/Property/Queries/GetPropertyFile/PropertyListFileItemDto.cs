using PropertyCore.Application.Common.Mappings;
using PropertyCore.Domain.Entities;
using System;

namespace PropertyCore.Application.Property.Queries.GetPropertyFile
{
    /// <summary>
    /// Data transfer class used to relay details of a <see cref="PropertySheetTags"/> entity.
    /// </summary>
    public class PropertyListFileItemDto : IMapFrom<PropertySheetTags>
    {
        /// <summary>
        /// The Bar Code of the entity.
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// The Description of the entity.
        /// </summary>
        public string Description { get; set; }
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
        /// The current disposition of the entity.
        /// </summary>
        public string CurrentDisposition { get; set; }
        /// <summary>
        /// The Date/Time that the entity was obtained.
        /// </summary>
        public DateTime ObtainedDate { get; set; }
        /// <summary>
        /// The name of the person from whom the property item associated with the entity was obtained.
        /// </summary>
        public string ObtainedFrom { get; set; }
        /// <summary>
        /// The explanation of the entity.
        /// </summary>
        public string Explain { get; set; }
        /// <summary>
        /// The drop location of the property item associated with the entity.
        /// </summary>
        public string DropLocation { get; set; }
        /// <summary>
        /// The case number of the case associated with the entity.
        /// </summary>
        public string CaseNumber { get; set; }
        /// <summary>
        /// The property sheet number associated with the entity.
        /// </summary>
        public string PropertySheetNumber { get; set; }
        /// <summary>
        /// The status of the property.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The Hold Status of the property.
        /// </summary>
        public string HoldStatus { get; set; }
        /// <summary>
        /// Creates a mapping between the entity and the data transfer class.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PropertySheetTags, PropertyListFileItemDto>()
                .ForMember(x => x.BarCode, opt => opt.MapFrom(y => y.TagNumber))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.PropertyCategory, opt => opt.MapFrom(y => y.PropertyCategory))
                .ForMember(x => x.CurrentLocation, opt => opt.MapFrom(y => y.CurrentLocation))
                .ForMember(x => x.CurrentDisposition, opt => opt.MapFrom(y => y.CurrentDisposition))
                .ForMember(x => x.ObtainedFrom, opt => opt.MapFrom(y => y.ObtainedFrom))
                .ForMember(x => x.Explain, opt => opt.MapFrom(y => y.Explain))
                .ForMember(x => x.DropLocation, opt => opt.MapFrom(y => y.DropLocation))
                .ForMember(x => x.CaseNumber, opt => opt.MapFrom(y => y.TagsCaseNoRtf))
                .ForMember(x => x.PropertySheetNumber, opt => opt.MapFrom(y => y.TagsSheetNoRtf))
                .ForMember(x => x.Status, opt => opt.MapFrom(y => y.Status))
                .ForMember(x => x.HoldStatus, opt => opt.MapFrom(y => y.HoldStatus));
        }
    }
}
