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
            vm.BarCode = request.BarCodeSearch;
            vm.CaseNumber = request.CaseNumberSearch;
            vm.PropertySheet = request.PropertySheetSearch;
            vm.PropertyItems = request.SortOrder switch
            {
                "caseNumber" => await _context.PropertySheetTags.OrderBy(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "caseNumber_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagsCaseNoRtf)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet" => await _context.PropertySheetTags.OrderBy(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "propertySheet_desc" => await _context.PropertySheetTags.OrderByDescending(x => x.TagNumber)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                "dateObtained_asc" => await _context.PropertySheetTags.OrderBy(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken),
                _ => await _context.PropertySheetTags.OrderByDescending(x => x.ObtainedDate)
                    .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                        && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                        && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<PropertyListPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            }; ;
            vm.PagingInfo.TotalItems = await _context.PropertySheetTags
                .Where(x => (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                    && (string.IsNullOrEmpty(request.CaseNumberSearch) || x.TagsCaseNoRtf == request.CaseNumberSearch)
                    && (string.IsNullOrEmpty(request.BarCodeSearch) || x.TagNumber == request.BarCodeSearch)
                    && (string.IsNullOrEmpty(request.PropertySheetSearch) || x.TagsSheetNoRtf == request.PropertySheetSearch))
                .CountAsync(cancellationToken);
            return vm;
        }
    }
}
