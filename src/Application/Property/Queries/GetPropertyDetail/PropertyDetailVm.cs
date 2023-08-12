﻿using PropertyCore.Application.Common.Mappings;
using PropertyCore.Application.Property.Queries.GetPropertyList;
using PropertyCore.Domain.Entities.DHStore;
using System;

namespace PropertyCore.Application.Property.Queries.GetPropertyDetail
{
    public class PropertyDetailVm : IMapFrom<PropertySheetTags>
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
        /// The Description of the entity.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The Identifier of the Property Type of the entity.
        /// </summary>
        public string PropertyTypeID { get; set; }
        /// <summary>
        /// The Property Type of the entity.
        /// </summary>
        public string PropertyType { get; set; }
        /// <summary>
        /// The Category of the entity.
        /// </summary>
        public string PropertyCategory { get; set; }
        /// <summary>
        /// The Id of the current location of the entity.
        /// </summary>
        public string CurrentLocationID { get; set; }
        /// <summary>
        /// The current location of the entity.
        /// </summary>
        public string CurrentLocation { get; set; }
        /// <summary>
        /// The Id of the current disposition of the entity.
        /// </summary>
        public string CurrentDispositionID { get; set; }
        /// <summary>
        /// The current disposition of the entity.
        /// </summary>
        public string CurrentDisposition { get; set; }
        /// <summary>
        /// The Id of the individual who obtained the property item associated with the entity.
        /// </summary>
        public string ObtainedById { get; set; }
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
        /// The Id of the drop location of the property item associated with the entity.
        /// </summary>
        public string DropLocationID { get; set; }
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
        /// Creates a mapping between the entity and the data transfer class.
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PropertySheetTags, PropertyListPropertyItemDto>()
                .ForMember(x => x.InstanceId, opt => opt.MapFrom(y => y.InstanceId))
                .ForMember(x => x.SeqNo1, opt => opt.MapFrom(y => y.SeqNo1))
                .ForMember(x => x.BarCode, opt => opt.MapFrom(y => y.TagNumber))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.PropertyTypeID, opt => opt.MapFrom(y => y.PropertyTypeId))
                .ForMember(x => x.PropertyCategory, opt => opt.MapFrom(y => y.PropertyCategory))
                .ForMember(x => x.CurrentLocationID, opt => opt.MapFrom(y => y.CurrentLocationId))
                .ForMember(x => x.CurrentLocation, opt => opt.MapFrom(y => y.CurrentLocation))
                .ForMember(x => x.CurrentDispositionID, opt => opt.MapFrom(y => y.CurrentDispositionId))
                .ForMember(x => x.CurrentDisposition, opt => opt.MapFrom(y => y.CurrentDisposition))
                .ForMember(x => x.ObtainedFrom, opt => opt.MapFrom(y => y.ObtainedFrom))
                .ForMember(x => x.Explain, opt => opt.MapFrom(y => y.Explain))
                .ForMember(x => x.DropLocationID, opt => opt.MapFrom(y => y.DropLocationId))
                .ForMember(x => x.DropLocation, opt => opt.MapFrom(y => y.DropLocation))
                .ForMember(x => x.CaseNumber, opt => opt.MapFrom(y => y.TagsCaseNoRtf))
                .ForMember(x => x.PropertySheetNumber, opt => opt.MapFrom(y => y.TagsSheetNoRtf));
        }
    }
}