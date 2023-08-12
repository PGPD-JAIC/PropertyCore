using PropertyCore.Application.Models;
using System.Threading.Tasks;

namespace PropertyCore.Application.Common.Interfaces
{
    /// <summary>
    /// Interface that defines a message sending service.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">A <see cref="MessageDto"/></param>
        /// <returns></returns>
        Task SendAsync(MessageDto message);
    }
}
