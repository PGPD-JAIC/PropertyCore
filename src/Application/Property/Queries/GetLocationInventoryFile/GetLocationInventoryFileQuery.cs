using MediatR;

namespace PropertyCore.Application.Property.Queries.GetLocationInventoryFile
{
    public class GetLocationInventoryFileQuery : IRequest<LocationInventoryFileVm>
    {
        public string SelectedLocationId { get; set; }
    }
}
