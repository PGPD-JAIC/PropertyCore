using MediatR;
using PropertyCore.Application.Common.Interfaces;
using System.Collections.Generic;

namespace PropertyCore.Application.Lists.Queries.GetRMSRealmQuery
{
    public class GetRMSRealmQuery : IRequest<List<RMSRealmDto>>
    {
    }
}
