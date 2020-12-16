using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Entities
{
    public class PlaylistItemEntity
    {
        [BsonElement("Name")]
        public string FilePath { get; set; }
        public string Extension { get; set; }
    }
}
