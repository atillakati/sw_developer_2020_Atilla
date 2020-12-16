using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
