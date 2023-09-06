using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetLocationInventory
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest}"/> that handles requests to view property items in a specific location.
    /// </summary>
    public class GetLocationInventoryQueryHandler : IRequestHandler<GetLocationInventoryQuery, LocationInventoryVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetLocationInventoryQueryHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="GetLocationInventoryQuery"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="LocationInventoryVm"/></returns>
        public async Task<LocationInventoryVm> Handle(GetLocationInventoryQuery request, CancellationToken cancellationToken)
        {
            var vm = new LocationInventoryVm
            {
                PagingInfo = new Common.Models.PagingInfo
                {
                    ItemsPerPage = request.PageSize,
                    CurrentPage = request.PageNumber
                },
                Locations = await _context.ListManagementCodes
                .Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D")
                .Select(x => new DropDownListItem { Text = x.ListManagementCodeGroupEntry.First().Description, Value = x.Id })
                .ToListAsync(cancellationToken),
                SelectedLocationId = request.SelectedLocationId
            };
            if (!string.IsNullOrWhiteSpace(request.SelectedLocationId))
            {
                vm.Items = await _context.PropertySheetTags.OrderBy(x => x.TagsCaseNoRtf)
                    .Where(x => x.CurrentLocationId == request.SelectedLocationId)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ProjectTo<LocationInventoryPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                vm.PagingInfo.TotalItems = await _context.PropertySheetTags.Where(x => x.CurrentLocationId == request.SelectedLocationId).CountAsync(cancellationToken);
            }
            return vm;
        }
    }
}
