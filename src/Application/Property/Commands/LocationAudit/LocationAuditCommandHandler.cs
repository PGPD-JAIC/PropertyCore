using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    public class LocationAuditCommandHandler : IRequestHandler<LocationAuditCommand, LocationAuditResultVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="mapper">Am implementation of <see cref="IMapper"/></param>
        public LocationAuditCommandHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LocationAuditResultVm> Handle(LocationAuditCommand command, CancellationToken cancellationToken)
        {
            List<string> barCodes = command.BarCodes.Split(new string[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None).ToList();
            var items = await _context.PropertySheetTags
                .Where(x => x.CurrentLocationId == command.LocationId)
                .ProjectTo<LocationAuditResultPropertyItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var vm = new LocationAuditResultVm();
            foreach (var item in items)
            {
                if (barCodes.Contains(item.BarCode))
                {
                    vm.FoundItemsCount++;
                    barCodes.RemoveAll(x => ((string)x) == item.BarCode);
                }
                else
                {
                    vm.NotScanned.Add(item);
                }
            }
            if (barCodes.Count > 0)
            {
                vm.NotPresent = await _context.PropertySheetTags
                    .Where(x => barCodes.Contains(x.TagNumber))
                    .ProjectTo<LocationAuditResultPropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
            return vm;
        }
    }
}
