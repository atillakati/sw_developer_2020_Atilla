using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items.Tests
{
    [TestFixture]
    public class Mp3ItemTests
    {
        private IPlaylistItem _fixture;

        private string _mp3WithThumbnailPath;
        private string _mp3WithNoThumbnailPath;

        [OneTimeSetUp]
        public void InitTestFiles()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);

            _mp3WithThumbnailPath = Path.Combine(path, @"Assets\001 - Bruno Mars - Grenade.mp3");
            _mp3WithNoThumbnailPath = Path.Combine(path, @"Assets\002 - Lena - Taken By A Stranger.mp3");
        }


        [SetUp]
        public void TestInit()
        {            
            _fixture = new Mp3Item(_mp3WithThumbnailPath);
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
            //arrange

            //act
            var path = _fixture.Path;

            //assert            
            Assert.That(path, Is.EqualTo(_mp3WithThumbnailPath));
        }

        [Test]
        public void GetThumbnail()
        {            
            //arrange

            //act
            var thumbnail = _fixture.Thumbnail;

            //assert            
            Assert.That(thumbnail, Is.Not.Null);            
        }

        [Test]
        public void GetThumbnail_WithMp3FileWithNoImage()
        {                         
            //arrange
            _fixture = new Mp3Item(_mp3WithNoThumbnailPath);

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
