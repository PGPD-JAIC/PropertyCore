using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetPropertyDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler{TRequest, TResponse}"></see> that handles requests for details of a <see cref="Domain.Entities.BookingPgchargeGroup"> items that represent Booking Record Charges.</see>
    /// </summary>
    public class GetPropertyDetailQueryHandler : IRequestHandler<GetPropertyDetailQuery, PropertyDetailVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        public GetPropertyDetailQueryHandler(IDHStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="GetPropertyDetailQuery"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="PropertyDetailVm"/> containing the query results.</returns>
        public async Task<PropertyDetailVm> Handle(GetPropertyDetailQuery request, CancellationToken cancellationToken)
        {            
            var result = await _context.PropertySheetTags
                    .Where(x => (x.InstanceId == request.InstanceId && x.SeqNo1 == request.SeqNo1))
                    .ProjectTo<PropertyDetailVm>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
            return result;
        }
    }
}
