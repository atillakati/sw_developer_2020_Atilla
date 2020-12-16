namespace Wifi.PlaylistEditor.Repositories.MongoDb.Settings
{
    public interface IConfigurationReader
    {
        string GetConfig(string key, string defaultValue);
    }
}