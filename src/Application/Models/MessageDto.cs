namespace PropertyCore.Application.Models
{
    /// <summary>
    /// Data transfer class used to pass message information.
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// String containing the email address of the sender.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// String containing the email address of the receipient.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// String containing the email subject.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// String containing the body of the email.
        /// </summary>
        public string Body { get; set; }
    }
}
