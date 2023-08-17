using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocation
{
    public class GetPGPDPropertyLocationsQueryHandler : IRequestHandler<GetPGPDPropertyLocationsQuery, List<DropDownListItem>>
    {
        private readonly IDHStoreContext _context;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context"></param>
        public GetPGPDPropertyLocationsQueryHandler(IDHStoreContext context)
        {
            _context = context;
        }
        public async Task<List<DropDownListItem>> Handle(GetPGPDPropertyLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.ListManagementCodeAttributes
                .Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D" && x.SeqNo2 == 0)
                .Select(z => new DropDownListItem { Text = z.Value, Value = z.Value }).Distinct().ToListAsync();
        }

    }
}
