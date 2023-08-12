using MediatR;
using System;

namespace PropertyCore.Application.Property.Queries.GetPropertyDetail
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> used to request details of a property item.
    /// </summary>
    public class GetPropertyDetailQuery : IRequest<PropertyDetailVm>
    {
        /// <summary>
        /// The InstanceId of the desired property item.
        /// </summary>
        public Guid InstanceId { get; set; }
        /// <summary>
        /// The SeqNo1 valur of the desired property item.
        /// </summary>
        public int SeqNo1 { get; set; }
    }
}
