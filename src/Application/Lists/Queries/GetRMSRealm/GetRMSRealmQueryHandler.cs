using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Lists.Queries.GetRMSRealmQuery
{
    public class GetRMSRealmQueryHandler : IRequestHandler<GetRMSRealmQuery, List<RMSRealmDto>>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context"></param>
        public GetRMSRealmQueryHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RMSRealmDto>> Handle(GetRMSRealmQuery request, CancellationToken cancellationToken)
        {
            return await _context.ListManagementCodes.Where(x => x.InstanceId.ToString() == "92614115-6D6A-4C6E-B428-5E0E2C537F4F")
                .ProjectTo<RMSRealmDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
