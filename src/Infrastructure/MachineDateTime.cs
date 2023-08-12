using PropertyCore.Common;
using System;

namespace PropertyCore.Infrastructure
{
    /// <summary>
    /// Implementation of <see cref="IDateTime"/> that returns the current machine date/time.
    /// </summary>
    public class MachineDateTime : IDateTime
    {
        /// <summary>
        /// Returns the current date/time.
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}
