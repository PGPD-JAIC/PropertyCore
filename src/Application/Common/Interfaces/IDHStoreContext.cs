using Microsoft.EntityFrameworkCore;
using PropertyCore.Domain.Entities;

namespace PropertyCore.Application.Common.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for the DHStoreContext used in the application layer
    /// </summary>
    public interface IDHStoreContext
    {
        /// <summary>
        /// A <see cref="DbSet{Domain.Entities}"/> containing Property Entries.
        /// </summary>
        DbSet<Domain.Entities.Property> Property { get; }
        /// <summary>
        /// A <see cref="DbSet{PropertySheetTags}"/> containing property sheet tag entries.
        /// </summary>
        DbSet<PropertySheetTags> PropertySheetTags { get; }
        /// <summary>
        /// A <see cref="DbSet{PropertySheetMetadata}"/> containing property sheet metadata entires.
        /// </summary>
        DbSet<PropertySheetMetadata> PropertySheetMetadata { get; }
        /// <summary>
        /// A <see cref="DbSet{ListManagement}"/> containing List Management object entries.
        /// </summary>
        DbSet<ListManagement> ListManagement { get; }
        /// <summary>
        /// A <see cref="DbSet{ListManagementCode}"/> containing List Management Code entries.
        /// </summary>
        DbSet<ListManagementCode> ListManagementCodes { get; }
        /// <summary>
        /// A <see cref="DbSet{ListManagementCodeAttributes}"/> containing List Managemetn Code Attribute entries.
        /// </summary>
        DbSet<ListManagementCodeAttributes> ListManagementCodeAttributes { get; }
        /// <summary>
        /// A <see cref="DbSet{ListManagementCodeGroupEntry}"/> containing the List Management Code Group Entries.
        /// </summary>
        DbSet<ListManagementCodeGroupEntry> ListManagementCodeGroupEntries { get; }
    }
}
