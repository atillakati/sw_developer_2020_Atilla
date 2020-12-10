using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items.Tests
{
    [TestFixture]
    public class Mp3ItemTests
    {
        private IPlaylistItem _fixture;


        [Test]
        public void GetTitle()
        {
            //arrange
            _fixture = new Mp3Item(@"C:\Users\user\Music\TestMediaFiles\001 - Bruno Mars - Grenade.mp3");

            //act
            var title = _fixture.Title;

            //assert
            Assert.That(title, Is.Not.Null);
            Assert.That(title, Is.EqualTo("Grenade"));
        }

        [Test]
        public void GetDuration()
        {
            //arrange
            _fixture = new Mp3Item(@"C:\Users\user\Music\TestMediaFiles\001 - Bruno Mars - Grenade.mp3");

            //act
            var duration = _fixture.Duration;

            //assert            
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(222.188)));
        }

        [Test]
        public void GetTitle_FilePathIsNull()
        {
            //arrange
            var fixture = new Mp3Item(null);

            //act
            var title = fixture.Title;

            //assert            
            Assert.That(title, Is.EqualTo("--[File not found]--"));
        }

        [Test]
        public void GetTitle_FilePathIsEmpty()
        {
            //arrange
            var fixture = new Mp3Item(null);

            //act
            var title = fixture.Title;

            //assert            
            Assert.That(title, Is.EqualTo("--[File not found]--"));
        }

        [Test]
        public void GetTitle_FilePathNotExists()
        {
            //arrange
            var fixture = new Mp3Item(@"c:\mysupermusic\hits\gandalfSong.mp3");

            //act
            var title = fixture.Title;

            //assert            
            Assert.That(title, Is.EqualTo("--[File not found]--"));
        }
    }
}
