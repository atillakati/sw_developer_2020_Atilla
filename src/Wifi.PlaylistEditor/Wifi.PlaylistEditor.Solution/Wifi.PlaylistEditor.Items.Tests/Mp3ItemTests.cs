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


        [SetUp]
        public void TestInit()
        {
            _fixture = new Mp3Item(@"C:\Users\user\Music\TestMediaFiles\001 - Bruno Mars - Grenade.mp3");
        }

        [Test]
        public void GetTitle()
        {
            //arrange            

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

            //act
            var duration = _fixture.Duration;

            //assert            
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(222.188)));
        }

        [Test]
        public void GetArtist()
        {
            //arrange

            //act
            var artist = _fixture.Artist;

            //assert            
            Assert.That(artist, Is.EqualTo("Bruno Mars"));
        }

        [Test]
        public void GetPath()
        {
            var demoMp3Path = @"C:\Users\user\Music\TestMediaFiles\001 - Bruno Mars - Grenade.mp3";

            //arrange

            //act
            var path = _fixture.Path;

            //assert            
            Assert.That(path, Is.EqualTo(demoMp3Path));
        }


        [Test]
        public void GetThumbnail()
        {
            var demoMp3Path = @"C:\Users\user\Music\TestMediaFiles\001 - Bruno Mars - Grenade.mp3";

            //arrange

            //act
            var thumbnail = _fixture.Thumbnail;

            //assert            
            Assert.That(thumbnail, Is.Not.Null);            
        }

        [Test]
        public void GetThumbnail_WithMp3FileWithNoImage()
        {
            var demoMp3Path = @"C:\Users\user\Music\TestMediaFiles\002 - Lena - Taken By A Stranger.mp3";
             
            //arrange
            _fixture = new Mp3Item(demoMp3Path);

            //act
            var thumbnail = _fixture.Thumbnail;

            //assert            
            Assert.That(thumbnail, Is.Null);
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
            var fixture = new Mp3Item(string.Empty);

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
