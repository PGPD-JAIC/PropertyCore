using MediatR;
using PropertyCore.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyCore.Application.Lists.Queries.GetPGPDPropertyLocationGroupType
{
    public class GetPGPDPropertyLocationGroupTypeQuery : IRequest<List<DropDownListItem>>
    {
    }
}
