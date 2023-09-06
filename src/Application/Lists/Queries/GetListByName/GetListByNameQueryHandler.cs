using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Exceptions;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Lists.Queries.GetListByName
{
    public class GetListByNameQueryHandler : IRequestHandler<GetListByNameQuery, List<DropDownListItem>>
    {
        private readonly IDHStoreContext _context;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        public GetListByNameQueryHandler(IDHStoreContext context)
        {
            _context = context;
        }

        public async Task<List<DropDownListItem>> Handle(GetListByNameQuery request, CancellationToken cancellationToken)
        {
            var listIds = _context.ListManagement
                .Where(x => (x.Name == request.Name && (x.ListManagementMetadata.OwnerId == Guid.Empty || x.ListManagementMetadata.OwnerId.ToString() == "9454125D-7B75-4453-BC5B-A37A48B248A7")))
                .Select(y => y.InstanceId)
                .ToList();
            return listIds == null
                ? throw new NotFoundException("No list found.", nameof(request.Name))
                : await _context.ListManagementCodes.Where(x => listIds.Contains(x.InstanceId)).Select(y => new DropDownListItem { Value = y.Id, Text = y.ListManagementCodeGroupEntry.First().Description }).ToListAsync();
        }
    }
}
