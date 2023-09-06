namespace PropertyCore.Application.Property.Queries.GetLocationInventoryFile
{
    // TODO: consider generic FileResult class
    public class LocationInventoryFileVm
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
