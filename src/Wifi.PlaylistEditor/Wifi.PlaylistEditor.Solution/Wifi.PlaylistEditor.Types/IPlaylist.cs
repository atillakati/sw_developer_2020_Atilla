using System;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Types
{
    public interface IPlaylist
    {
        string Author { get; set; }
        int Count { get; }
        DateTime CreatedAt { get; }
        TimeSpan Duration { get; }
        IEnumerable<IPlaylistItem> Items { get; }
        string Name { get; set; }

        void Add(IPlaylistItem newItem);
        void ClearAllItems();
        void Remove(IPlaylistItem itemToRemove);
    }
}