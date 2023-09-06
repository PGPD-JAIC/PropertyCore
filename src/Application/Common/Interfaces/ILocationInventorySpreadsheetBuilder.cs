using PropertyCore.Application.Property.Queries.GetLocationInventoryFile;

namespace PropertyCore.Application.Common.Interfaces
{
    public interface ILocationInventorySpreadsheetBuilder
    {
        byte[] Generate(LocationInventoryResults results);
    }
}
