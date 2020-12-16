using Moq;
using NUnit.Framework;
using System;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items.Tests
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;


        [Test]
        public void GetItemCount()
        {
            //arrange
            var mockedItem1 = new Mock<IPlaylistItem>();
            var mockedItem2 = new Mock<IPlaylistItem>();

            _fixture = new Playlist("DemoPlaylist", "Gandalf", DateTime.Now);
            _fixture.Add(mockedItem1.Object);
            _fixture.Add(mockedItem2.Object);

            //act
            var count = _fixture.ItemCount;

            //assert            
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void GetPlaylistDuration()
        {
            //arrange
            var mockedItem1 = new Mock<IPlaylistItem>();
            mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(15));

            var mockedItem2 = new Mock<IPlaylistItem>();
            mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(65));

            _fixture = new Playlist("DemoPlaylist", "Gandalf", DateTime.Now);
            _fixture.Add(mockedItem1.Object);
            _fixture.Add(mockedItem2.Object);

            //act
            var duration = _fixture.Duration;

            //assert            
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(80)));
        }
    }
}
