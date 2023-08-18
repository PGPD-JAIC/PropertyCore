using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocationGroupType
{
    /// <summary>
    /// Implementation of <see cref="IRequestHandler"/> that retrieves a list of PGPD Property Location Group Types.
    /// </summary>
    public class GetPGPDPropertyLocationGroupTypeQueryHandler : IRequestHandler<GetPGPDPropertyLocationGroupTypeQuery, List<DropDownListItem>>
    {
        private readonly IDHStoreContext _context;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context"></param>
        public GetPGPDPropertyLocationGroupTypeQueryHandler(IDHStoreContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">A <see cref="GetPGPDPropertyLocationGroupTypeQuery"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="List{DropDownListItem}"/></returns>
        public async Task<List<DropDownListItem>> Handle(GetPGPDPropertyLocationGroupTypeQuery request, CancellationToken cancellationToken)
        {
            return await _context.ListManagementCodeAttributes
                .Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D" && x.SeqNo2 == 0)
                .Select(z => new DropDownListItem { Text = z.Value, Value = z.Value }).Distinct().ToListAsync();
        }
    }
}
