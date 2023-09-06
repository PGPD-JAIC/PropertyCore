using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetPropertyFile
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler"/> that handles requests to retrieve a list of Property Items in a file.
    /// </summary>
    public class GetPropertyFileQueryHandler : IRequestHandler<GetPropertyFileQuery, PropertyFileVm>
    {
        private readonly IDHStoreContext _context;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="fileBuilder">An implementation of <see cref="ICsvFileBuilder"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        /// <param name="dateTime">An implementation of <see cref="IDateTime"/></param>
        public GetPropertyFileQueryHandler(IDHStoreContext context, ICsvFileBuilder fileBuilder, IMapper mapper, IDateTime dateTime)
        {
            _context = context;
            _fileBuilder = fileBuilder;
            _mapper = mapper;
            _dateTime = dateTime;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="GetPropertyFileQuery"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="PropertyFileVm"/> object.</returns>
        public async Task<PropertyFileVm> Handle(GetPropertyFileQuery request, CancellationToken cancellationToken)
        {
            var items = request.SortOrder switch
            {
                "caseNumber" => await _context.PropertySheetTags.OrderBy(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "caseNumber_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet" => await _context.PropertySheetTags.OrderBy(x => x.TagsSheetNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagsSheetNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "dateObtained_asc" => await _context.PropertySheetTags.OrderBy(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "barCode" => await _context.PropertySheetTags.OrderBy(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "barCode_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyType" => await _context.PropertySheetTags.OrderBy(x => x.PropertyType)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyType_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.PropertyType)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyCategory" => await _context.PropertySheetTags.OrderBy(x => x.PropertyCategory)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyCategory_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.PropertyCategory)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "disposition" => await _context.PropertySheetTags.OrderBy(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "disposition_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "location" => await _context.PropertySheetTags.OrderBy(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "location_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "status" => await _context.PropertySheetTags.OrderBy(x => x.Status)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "status_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.Status)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "holdStatus" => await _context.PropertySheetTags.OrderBy(x => x.HoldStatus)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "holdStatus_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.HoldStatus)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "agencyName" => await _context.PropertySheetTags.OrderBy(x => x.Instance.AgencyId)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "agencyName_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.Instance.AgencyId)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                _ => await _context.PropertySheetTags.OrderBy(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedHoldStatusId) || x.HoldStatusId == request.SelectedHoldStatusId)
                        && (string.IsNullOrEmpty(request.SelectedRealmId) || x.Instance.PropertySheetMetadata.OwnerId.ToString() == request.SelectedRealmId)
                        && x.ObtainedDate != null)
                    .ProjectTo<PropertyListFileItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };  

            var fileContent = _fileBuilder.BuildProductsFile(items);

            var vm = new PropertyFileVm
            {
                Content = fileContent,
                ContentType = "text/csv",
                FileName = $"{_dateTime.Now:MM-dd-yy}-Property.csv"
            };
            return vm;
        }
    }
}
