namespace Wifi.PlaylistEditor.Repositories.MongoDb.Core
{
    public interface IConfigurationReader
    {
        string GetConfig(string key, string defaultValue);
    }
}