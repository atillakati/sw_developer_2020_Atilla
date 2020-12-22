using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Tests
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        private IRepository _fixture;
        private Mock<IPlaylist> _mockedPlaylist;
        private Mock<IPlaylistItemFactory> _mockedPlaylistItemFactory;

        [SetUp]
        public void Init()
        {
            //create Item
            Mock<IPlaylistItem> mockedItem1 = CreateMockedItem(1);
            Mock<IPlaylistItem> mockedItem2 = CreateMockedItem(2);

            //create Playlist
            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedPlaylist.Setup(x => x.Author).Returns("Gandalf Sehrweise");
            _mockedPlaylist.Setup(x => x.Name).Returns("Megahits 2020");
            _mockedPlaylist.Setup(x => x.Count).Returns(2);
            _mockedPlaylist.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(175+175));
            _mockedPlaylist.Setup(x => x.CreatedAt).Returns(new DateTime(2020, 12, 25));
            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] { mockedItem1.Object, mockedItem2.Object});

            //create factory
            _mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();
            _mockedPlaylistItemFactory.Setup(x => x.Create(It.IsAny<string>())).Returns(mockedItem1.Object);

            _fixture = null;
        }

        private static Mock<IPlaylistItem> CreateMockedItem(int index)
        {            
            var mockedItem = new Mock<IPlaylistItem>();

            mockedItem.Setup(x => x.Artist).Returns($"Artist {index}");
            mockedItem.Setup(x => x.Path).Returns($@"c:\myHits\UnitTest Artist_{index}.mp3");
            mockedItem.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(175));
            mockedItem.Setup(x => x.Title).Returns($"So cool song {index}");

            return mockedItem;
        }

        [Test]
        public void GetExtension()
        {
            //assign            
            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);

            //act
            var ext = _fixture.Extension;

            //assert
            Assert.That(ext, Is.EqualTo(".m3u"));
        }

        [Test]
        public void GetDescription()
        {
            //assign            
            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);

            //act
            var description = _fixture.Description;

            //assert
            Assert.That(description, Is.EqualTo("m3u Playlist file"));
        }

        [Test]
        public void Save()
        {
            //assign            
            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);

            //act
            _fixture.Save(@"c:\temp\myMegahits2020.m3u", _mockedPlaylist.Object);

            //assert   
            Assert.That(File.Exists(@"c:\temp\myMegahits2020.m3u"), Is.True);
            Assert.That(_mockedPlaylist.Object.Count, Is.EqualTo(2));
        }

       
        [Test]
        public void Load()
        {
            //assign            
            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);
            _fixture.Save(@"c:\temp\myMegahits2020.m3u", _mockedPlaylist.Object);

            //act
            var playlist = _fixture.Load(@"c:\temp\myMegahits2020.m3u");

            //assert
            Assert.That(playlist.Count, Is.EqualTo(2));
            Assert.That(playlist.Duration, Is.EqualTo(TimeSpan.FromSeconds(175+175)));
            Assert.That(playlist.Author, Is.EqualTo("Gandalf Sehrweise"));
            Assert.That(playlist.Name, Is.EqualTo("Megahits 2020"));
            Assert.That(playlist.CreatedAt, Is.EqualTo(new DateTime(2020, 12, 25)));

            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void Load_PathIsEmpty()
        {
            //assign            
            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load(string.Empty);

            //assert
            Assert.That(playlist, Is.Null);            
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(0));
        }

        [Test]
        public void Save_EmptyPlaylist()
        {
            //assign            
            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[0]);
            _mockedPlaylist.Setup(x => x.Duration).Returns(TimeSpan.Zero);
            _mockedPlaylist.Setup(x => x.Count).Returns(0);

            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);

            //act
            _fixture.Save(@"c:\temp\myMegahits2020.m3u", _mockedPlaylist.Object);

            //assert              
        }

        [Test]
        public void Load_EmptyPlaylist()
        {
            //assign                        
            _mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[0]);
            _mockedPlaylist.Setup(x => x.Duration).Returns(TimeSpan.Zero);

            _fixture = new M3uRepository(_mockedPlaylistItemFactory.Object);
            _fixture.Save(@"c:\temp\myMegahits2020.m3u", _mockedPlaylist.Object);

            //act
            var playlist = _fixture.Load(@"c:\temp\myMegahits2020.m3u");

            //assert
            Assert.That(playlist.Count, Is.EqualTo(0));
            Assert.That(playlist.Duration, Is.EqualTo(TimeSpan.Zero));

            //check the default value due a bug in the ext. library
            Assert.That(playlist.Author, Is.EqualTo("NoName"));
            Assert.That(playlist.Name, Is.EqualTo("myMegahits2020"));
            Assert.That(playlist.CreatedAt, Is.EqualTo(DateTime.Now.Date));

            //Assert.That(playlist.Author, Is.EqualTo("Gandalf Sehrweise"));
            //Assert.That(playlist.Name, Is.EqualTo("Megahits 2020"));
            //Assert.That(playlist.CreatedAt, Is.EqualTo(new DateTime(2020, 12, 25)));

            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(0));
        }

    }
}
