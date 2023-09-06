using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetLocationInventoryFile
{
    public class GetLocationInventoryFileQueryHandler : IRequestHandler<GetLocationInventoryFileQuery, LocationInventoryFileVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILocationInventorySpreadsheetBuilder _builder;
        private readonly IDateTime _dateTime;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        /// <param name="builder">An implementation of <see cref="ILocationInventorySpreadsheetBuilder"/></param>
        /// <param name="dateTime">An implementation of <see cref="IDateTime"/></param>
        public GetLocationInventoryFileQueryHandler(IDHStoreContext context, IMapper mapper, ILocationInventorySpreadsheetBuilder builder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _builder = builder;
            _dateTime = dateTime;
        }
        public async Task<LocationInventoryFileVm> Handle(GetLocationInventoryFileQuery request, CancellationToken cancellationToken)
        {
            var results = new LocationInventoryResults();
            results.Location = await _context.ListManagementCodes.Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D" && x.Id == request.SelectedLocationId)
                .ProjectTo<LocationInventoryFileLocationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            results.Items = await _context.PropertySheetTags.OrderBy(x => x.TagsCaseNoRtf)
                    .Where(x => x.CurrentLocationId == request.SelectedLocationId)
                    .ProjectTo<LocationInventoryFilePropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            var fileContent = _builder.Generate(results);
            var vm = new LocationInventoryFileVm
            {
                Content = fileContent,
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = $"Location Inventory Results - Location: {results.Location.Name} {_dateTime.Now:MM-dd-yy}.xlsx"
            };
            return vm;
        }
    }
}
