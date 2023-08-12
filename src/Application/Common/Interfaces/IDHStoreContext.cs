using Microsoft.EntityFrameworkCore;
using PropertyCore.Domain.Entities.DHStore;

namespace PropertyCore.Application.Common.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for the DHStoreContext used in the application layer
    /// </summary>
    public interface IDHStoreContext
    {
        /// <summary>
        /// A <see cref="DbSet{Domain.Entities.DHStore.Property}"/> containing Property Entries.
        /// </summary>
        DbSet<Domain.Entities.DHStore.Property> Property { get; }
        /// <summary>
        /// A <see cref="DbSet{PropertySheetTags}"/> containing property sheet tag entries.
        /// </summary>
        DbSet<PropertySheetTags> PropertySheetTags { get; }
        /// <summary>
        /// A <see cref="DbSet{PropertySheetMetadata}"/> containing property sheet metadata entires.
        /// </summary>
        DbSet<PropertySheetMetadata> PropertySheetMetadata { get; }
    }
}
