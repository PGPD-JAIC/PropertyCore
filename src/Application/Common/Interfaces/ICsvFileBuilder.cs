using PropertyCore.Application.Property.Queries.GetPropertyFile;
using System.Collections.Generic;

namespace PropertyCore.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<PropertyListFileItemDto> records);
    }
}
