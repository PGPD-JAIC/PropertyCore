namespace PropertyCore.Application.Property.Queries.GetPropertyFile
{
    /// <summary>
    /// Viewmodel class used to return a list of Property Items in a file.
    /// </summary>
    public class PropertyFileVm
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// The content type of the file.
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// The file contents.
        /// </summary>
        public byte[] Content { get; set; }
    }
}