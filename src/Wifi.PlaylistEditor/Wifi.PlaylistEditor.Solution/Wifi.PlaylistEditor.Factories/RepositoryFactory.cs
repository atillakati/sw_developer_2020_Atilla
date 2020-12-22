using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Repositories;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public RepositoryFactory(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }

        public IEnumerable<IFileIdentifier> KnownTypes
        {
            get
            {
                return new IFileIdentifier[]
                {
                    new M3uRepository(_playlistItemFactory),
                    new WplRepository(_playlistItemFactory)
                };
            }
        }

        public IRepository Create(string playlistPath)
        {
            IRepository repository = null;

            if (string.IsNullOrEmpty(playlistPath))
            {
                return null;
            }

            var extension = Path.GetExtension(playlistPath);

            switch (extension)
            {
                case ".m3u":
                    repository = new M3uRepository(_playlistItemFactory);
                    break;

                case ".wpl":
                    repository = new WplRepository(_playlistItemFactory);
                    break;

                default:
                    repository = null;
                    break;
            }

            return repository;
        }
    }
}
