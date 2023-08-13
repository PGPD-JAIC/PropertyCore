using CsvHelper;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Property.Queries.GetPropertyFile;
using System.Collections.Generic;
using System.IO;

namespace PropertyCore.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductsFile(IEnumerable<PropertyListFileItemDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.Configuration.RegisterClassMap<PropertyListFileItemMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
