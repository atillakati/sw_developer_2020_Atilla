using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Entities
{
    public class PlaylistEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; }
        public string Author { get; set; }

        public string FilePath { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<PlaylistItemEntity> Items { get; set; }
    }
}
