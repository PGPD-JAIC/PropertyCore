using MediatR;
using PropertyCore.Application.Common.Interfaces;
using System.Collections.Generic;

namespace PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocation
{
    public class GetPGPDPropertyLocationsQuery : IRequest<List<PropertyLocationDto>>
    {
    }
}
