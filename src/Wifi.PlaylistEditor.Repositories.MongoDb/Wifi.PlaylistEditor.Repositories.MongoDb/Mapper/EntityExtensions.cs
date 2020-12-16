using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Repositories.MongoDb.Entities;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Mapper
{
    public static class EntityExtensions
    {
        public static IPlaylist MapToDomain(this PlaylistEntity entity, IPlaylistItemFactory playlistItemFactory)
        {
            IPlaylist playlist = new Playlist(entity.Title, entity.Author);

            foreach (var item in entity.Items)
            {
                var playlistItem = playlistItemFactory.Create(item.FilePath);
                playlist.Add(playlistItem);
            }

            return playlist;
        }

        public static PlaylistItemEntity MapToEntity(this IPlaylistItem playlistItem)
        {
            var entity = new PlaylistItemEntity()
            {
                Extension = playlistItem.Extension,
                FilePath = playlistItem.FilePath
            };

            return entity;
        }

        public static PlaylistEntity MapToEntity(this IPlaylist playlist, string filePath)
        {
            var entity = new PlaylistEntity()
            {
                Id = Guid.NewGuid(),
                Author = playlist.Author,
                CreatedAt = playlist.CreatedAt,
                Title = playlist.Title,
                Items = playlist.Items.Select(x => x.MapToEntity()),
                FilePath = filePath
            };

            return entity;
        }
    }
}
