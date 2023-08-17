using MediatR;
using PropertyCore.Application.Common.Models;
using System.Collections.Generic;

namespace PropertyCore.Application.Lists.Queries.GetListByName
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that retrives list values for a list with the matching name.
    /// </summary>
    public class GetListByNameQuery : IRequest<List<DropDownListItem>>
    {
        /// <summary>
        /// The name of the list.
        /// </summary>
        public string Name { get; set; }
    }
}
