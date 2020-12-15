using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types.Tests
{
    [TestFixture]
    public class PlaylistTests
    {
        private IPlaylist _fixture;

        [Test]
        public void GetCount()
        {
            //arrange
            _fixture = new Playlist("TestPlaylist", "Ganfalf", DateTime.Now);

            var mockedItem1 = new Mock<IPlaylistItem>();
            var mockedItem2 = new Mock<IPlaylistItem>();

            _fixture.Add(mockedItem1.Object);
            _fixture.Add(mockedItem2.Object);

            //act
            var count = _fixture.Count;

            //assert
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void GetDuration()
        {
            //arrange
            _fixture = new Playlist("TestPlaylist", "Ganfalf", DateTime.Now);

            var mockedItem1 = new Mock<IPlaylistItem>();
            mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(5));

            var mockedItem2 = new Mock<IPlaylistItem>();
            mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(65));

            _fixture.Add(mockedItem1.Object);
            _fixture.Add(mockedItem2.Object);

            //act
            var duration = _fixture.Duration;

            //assert
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(70)));
        }

    }
}
