using System.Collections.Generic;
using System.Linq;
using Wifi.PlaylistEditor.Repositories.MongoDb.Driver;
using Wifi.PlaylistEditor.Repositories.MongoDb.Entities;
using Wifi.PlaylistEditor.Repositories.MongoDb.Mapper;
using Wifi.PlaylistEditor.Repositories.MongoDb.Settings;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb
{
    public class MongoDbRepository : IRepository
    {
        private IDataProvider<PlaylistEntity> _provider;
        private IConfigurationReader _configurationReader;

        private string _connectionString = "mongodb://admin:password@192.168.10.200:27017";
        private string _dbName = "PlaylistDb";
        private string _collectionName = "PlaylistCollection";
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public MongoDbRepository(IPlaylistItemFactory playlistItemFactory, IDataProvider<PlaylistEntity> provider)
        {
            _playlistItemFactory = playlistItemFactory;
            _provider = provider;
        }

        public MongoDbRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
            ReadAppSettings();

            _provider = new MongoDbProvider<PlaylistEntity>(_connectionString, _dbName, _collectionName);
        }

        private void ReadAppSettings()
        {
            _configurationReader = new ConfigurationReader();

            _connectionString = _configurationReader.GetConfig("connectionString", _connectionString);
            _dbName = _configurationReader.GetConfig("dbName", _dbName);
            _collectionName = _configurationReader.GetConfig("collectionName", _collectionName);
        }

        public string Extension => ".mongodb";

        public string Description => "Store project data into MongoDb";

        public IPlaylist Load(string filePath)
        {
            IPlaylist playlist = null;

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                var entity = _provider.LoadDocumentByFilter(x => x.FilePath == filePath);
                if (entity != null)
                {
                    playlist = entity.MapToDomain(_playlistItemFactory);
                }
            }

            return playlist;
        }

        public void Save(string filePath, IPlaylist playlist)
        {
            if (string.IsNullOrWhiteSpace(filePath) || playlist == null)
            {
                return;
            }

            var entity = playlist.MapToEntity(filePath);

            var existingEntity = _provider.LoadDocumentByFilter(x => x.FilePath == filePath);
            if (existingEntity != null)
            {
                entity.Id = existingEntity.Id;
                _provider.UpdateDocument(entity, x => x.FilePath == entity.FilePath);
            }
            else
            {
                _provider.InsertDocument(entity);
            }
        }

        public IEnumerable<IPlaylist> LoadAll()
        {
            List<IPlaylist> playlists = new List<IPlaylist>();

            playlists = _provider.LoadAllDocuments()?
                                 .Select(x => x.MapToDomain(_playlistItemFactory))
                                 .ToList();
            return playlists;
        }
    }
}
