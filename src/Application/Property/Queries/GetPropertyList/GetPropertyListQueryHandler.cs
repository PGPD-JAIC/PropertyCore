using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetPropertyList
{
    public class GetPropertyListQueryHandler : IRequestHandler<GetPropertyListQuery, PropertyListVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;

        public GetPropertyListQueryHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PropertyListVm> Handle(GetPropertyListQuery request, CancellationToken cancellationToken)
        {
            PropertyListVm vm = new PropertyListVm
            {
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                }
            };
            vm.CurrentSort = string.IsNullOrEmpty(request.SortOrder) ? "" : request.SortOrder;
            vm.DateSort = string.IsNullOrEmpty(request.SortOrder) ? "dateObtained_asc" : "";
            vm.CaseNumberSort = request.SortOrder == "caseNumber_desc" ? "caseNumber" : "caseNumber_desc";
            vm.PropertySheetSort = request.SortOrder == "propertySheet_desc" ? "propertySheet" : "propertySheet_desc";
            vm.BarCodeSort = request.SortOrder == "barCode_desc" ? "barCode" : "barCode_desc";
            vm.PropertyTypeSort = request.SortOrder == "propertyType_desc" ? "propertyType" : "propertyType_desc";
            vm.PropertyCategorySort = request.SortOrder == "propertyCategory_desc" ? "propertyCategory" : "propertyCategory_desc";
            vm.DispositionSort = request.SortOrder == "disposition_desc" ? "disposition" : "disposition_desc";
            vm.LocationSort = request.SortOrder == "location_desc" ? "location" : "location_desc";
            vm.StatusSort = request.SortOrder == "status_desc" ? "status" : "status_desc";
            vm.HoldStatusSort = request.SortOrder == "holdStatus_desc" ? "holdStatus" : "holdStatus_desc";
            vm.AgencyNameSort = request.SortOrder == "agencyName_desc" ? "agencyName" : "agencyName_desc";
            vm.BarCode = request.BarCodeSearch;
            vm.CaseNumber = request.CaseNumberSearch;
            vm.PropertySheet = request.PropertySheetSearch;
            vm.PropertyTypes = _context.PropertySheetTags.Select(x => new DropDownListItem { Text = x.PropertyType, Value = x.PropertyTypeId}).Distinct().OrderBy(x => x.Text).ToList();
            vm.PropertyCategories = _context.PropertySheetTags.Select(x => new DropDownListItem { Text = x.PropertyCategory, Value = x.PropertyCategory }).Distinct().OrderBy(x => x.Text).ToList();
            vm.PropertyStatuses = _context.PropertySheetTags.Select(x => new DropDownListItem { Text = x.Status, Value = x.StatusId }).Distinct().OrderBy(x => x.Text).ToList();
            vm.HoldStatuses = _context.PropertySheetTags.Select(x => new DropDownListItem { Text = x.HoldStatus, Value = x.HoldStatusId }).Distinct().OrderBy(x => x.Text).ToList();
            vm.SelectedPropertyTypeId = request.SelectedPropertyTypeId;
            vm.SelectedPropertyCategory = request.SelectedPropertyCategory;
            vm.SelectedPropertyStatusId = request.SelectedPropertyStatusId;
            vm.SelectedPropertyHoldStatusId = request.SelectedPropertyHoldStatusId;
            vm.PropertyItems = request.SortOrder switch
            {
                "caseNumber" => await _context.PropertySheetTags.OrderBy(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "caseNumber_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch) 
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet" => await _context.PropertySheetTags.OrderBy(x => x.TagsSheetNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagsSheetNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "dateObtained_asc" => await _context.PropertySheetTags.OrderBy(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "barCode" => await _context.PropertySheetTags.OrderBy(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "barCode_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyType" => await _context.PropertySheetTags.OrderBy(x => x.PropertyType)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyType_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.PropertyType)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyCategory" => await _context.PropertySheetTags.OrderBy(x => x.PropertyCategory)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertyCategory_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.PropertyCategory)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "disposition" => await _context.PropertySheetTags.OrderBy(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "disposition_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "location" => await _context.PropertySheetTags.OrderBy(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "location_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.CurrentDisposition)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "status" => await _context.PropertySheetTags.OrderBy(x => x.Status)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "status_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.Status)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "holdStatus" => await _context.PropertySheetTags.OrderBy(x => x.HoldStatus)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "holdStatus_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.HoldStatus)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "agencyName" => await _context.PropertySheetTags.OrderBy(x => x.Instance.AgencyId)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "agencyName_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.Instance.AgencyId)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),

                _ => await _context.PropertySheetTags.OrderByDescending(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                        && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                        && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                        && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                        && x.ObtainedDate != null)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
            vm.PagingInfo.TotalItems = await _context.PropertySheetTags
                .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                    && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                    && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                    && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch)
                    && (string.IsNullOrEmpty(request.SelectedPropertyTypeId) || x.PropertyTypeId == request.SelectedPropertyTypeId)
                    && (string.IsNullOrEmpty(request.SelectedPropertyCategory) || x.PropertyCategory == request.SelectedPropertyCategory)
                    && (string.IsNullOrEmpty(request.SelectedPropertyStatusId) || x.StatusId == request.SelectedPropertyStatusId)
                    && (string.IsNullOrEmpty(request.SelectedPropertyHoldStatusId) || x.HoldStatusId == request.SelectedPropertyHoldStatusId)
                    && x.ObtainedDate != null)
                .CountAsync(cancellationToken);
            return vm;
        }
    }
}
