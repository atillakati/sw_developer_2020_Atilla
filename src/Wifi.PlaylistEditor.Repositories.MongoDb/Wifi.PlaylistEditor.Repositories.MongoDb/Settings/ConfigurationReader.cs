using System.Configuration;
using Wifi.PlaylistEditor.Repositories.MongoDb.Core;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Settings
{
    public class ConfigurationReader : IConfigurationReader
    {
        public ConfigurationReader()
        {

        }

        public string GetConfig(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            return value == null ? defaultValue : value;
        }
    }
}
