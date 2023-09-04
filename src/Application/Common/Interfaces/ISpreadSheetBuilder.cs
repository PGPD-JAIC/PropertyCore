using PropertyCore.Application.Property.Queries.GetAuditFile;
using System.Collections.Generic;

namespace PropertyCore.Application.Common.Interfaces
{
    public interface ISpreadSheetBuilder
    {
        byte[] Generate(AuditFileResults results);
    }
}
