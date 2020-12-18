namespace Wifi.PlaylistEditor.Types
{
    /// <summary>
    /// Interface to describe file types and their default extension
    /// </summary>
    public interface IFileIdentifier
    {
        /// <summary>
        /// The default extension of the file. eg: .mp3 or .ogg
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// A short prosa description of the file type
        /// </summary>
        string Description { get; }
    }
}