using CsvHelper.Configuration;
using PropertyCore.Application.Property.Queries.GetPropertyFile;

namespace PropertyCore.Infrastructure.Files
{
    public sealed class PropertyListFileItemMap : ClassMap<PropertyListFileItemDto>
    {
        public PropertyListFileItemMap()
        {
            AutoMap();
        }
    }
}
