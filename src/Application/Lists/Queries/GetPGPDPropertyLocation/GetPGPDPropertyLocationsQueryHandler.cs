using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocation
{
    public class GetPGPDPropertyLocationsQueryHandler : IRequestHandler<GetPGPDPropertyLocationsQuery, List<PropertyLocationDto>>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context"></param>
        public GetPGPDPropertyLocationsQueryHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PropertyLocationDto>> Handle(GetPGPDPropertyLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ListManagementCodes.Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D")
                .ProjectTo<PropertyLocationDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
