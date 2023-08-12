using Microsoft.EntityFrameworkCore;

namespace PropertyCore.Persistence
{
    /// <summary>
    /// Implemention of <see cref="DHStoreDesignTimeDbContextFactoryBase{TContext}"></see>
    /// </summary>
    public class DHStoreContextFactory : DHStoreDesignTimeDbContextFactoryBase<DHStoreContext>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DHStoreDbContext"></see>
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions"></see> object.</param>
        /// <returns></returns>
        protected override DHStoreContext CreateNewInstance(DbContextOptions<DHStoreContext> options)
        {
            return new DHStoreContext(options);
        }
    }
}
