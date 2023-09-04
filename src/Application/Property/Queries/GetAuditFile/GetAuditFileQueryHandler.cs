using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyCore.Application.Property.Queries.GetAuditFile
{
    public class GetAuditFileQueryHandler : IRequestHandler<GetAuditFileQuery, AuditFileVm>
    {
        private readonly IDHStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ISpreadSheetBuilder _builder;
        private readonly IDateTime _dateTime;
        /// <summary>
        /// Creates a new instance of the handler.
        /// </summary>
        /// <param name="context">An implementation of <see cref="IDHStoreContext"/></param>
        /// <param name="mapper">An implementation of <see cref="IMapper"/></param>
        /// <param name="builder">An implementation of <see cref="ISpreadSheetBuilder"/></param>
        /// <param name="dateTime">An implementation of <see cref="IDateTime"/></param>
        public GetAuditFileQueryHandler(IDHStoreContext context, IMapper mapper, ISpreadSheetBuilder builder, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _builder = builder;
            _dateTime = dateTime;
        }
        public async Task<AuditFileVm> Handle(GetAuditFileQuery query, CancellationToken cancellationToken)
        {
            var results = new AuditFileResults();

            List<string> barCodes = query.BarCodes.Split(new string[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None).ToList();

            results.ScannedItemsCount = barCodes.Count;
            results.Location = await _context.ListManagementCodes.Where(x => x.InstanceId.ToString() == "04D52599-B589-4779-ACA8-D1A90C35F31D" && x.Id == query.LocationId)
                .ProjectTo<AuditFileLocationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            var items = await _context.PropertySheetTags
                .Where(x => x.CurrentLocationId == query.LocationId)
                .ProjectTo<AuditFilePropertyItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            foreach (var item in items)
            {
                if (barCodes.Contains(item.BarCode))
                {
                    results.FoundItems++;
                    barCodes.RemoveAll(x => ((string)x) == item.BarCode);
                }
                else
                {
                    results.NotScannedAtLocations.Add(item);
                }
            }
            if (barCodes.Count > 0)
            {
                results.ScannedAtOtherLocations = await _context.PropertySheetTags
                    .Where(x => barCodes.Contains(x.TagNumber))
                    .ProjectTo<AuditFilePropertyItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
            

            var fileContent = _builder.Generate(results);
            var vm = new AuditFileVm
            {
                Content = fileContent,
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = $"Audit Results - Location: {results.Location.Name} {_dateTime.Now.ToString("MM-dd-yy")}.xlsx"
            };
            return vm;
        }
    }
}
