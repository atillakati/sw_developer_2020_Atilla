using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Repositories.MongoDb.Driver;
using Wifi.PlaylistEditor.Repositories.MongoDb.Entities;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.MongoDb.Tests
{
    [TestFixture]
    public class MongoDbRepositoryTests
    {
        private Mock<IDataProvider<PlaylistEntity>> _mockedDataProvider;
        private Mock<IPlaylistItemFactory> _mockedPlaylistItemFactory;
        private MongoDbRepository _fixture;

        [SetUp]
        public void Init()
        {
            //mocked DataProvider
            _mockedDataProvider = new Mock<IDataProvider<PlaylistEntity>>();
            _mockedDataProvider.Setup(x => x.LoadAllDocuments())
                               .Returns(new List<PlaylistEntity>() { CreatePlaylistEntity(2) });
            _mockedDataProvider.Setup(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()))
                               .Returns(CreatePlaylistEntity(3));

            //MongoDbRepository
            _mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();            
            _fixture = new MongoDbRepository(_mockedPlaylistItemFactory.Object, _mockedDataProvider.Object);
        }       

        [Test]      
        public void Load()
        {
            //arrange
            _mockedPlaylistItemFactory.Setup(x => x.Create(It.IsAny<string>()))
                                      .Returns(new Mock<IPlaylistItem>().Object);            
            //act
            var playlist = _fixture.Load(@"c:\temp\meineSuperPlaylist.mongodb");

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Once);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(3));
        }


        [Test]
        public void LoadAll()
        {
            //arrange
            _mockedPlaylistItemFactory.Setup(x => x.Create(It.IsAny<string>()))
                                      .Returns(new Mock<IPlaylistItem>().Object);
            //act
            var playlists = _fixture.LoadAll();

            //assert
            _mockedDataProvider.Verify(x => x.LoadAllDocuments(), Times.Once);
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Exactly(2));
        }


        [Test]
        public void Load_DocumentNotFound()
        {
            //arrange
            _mockedDataProvider.Setup(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()))
                               .Returns(CreatePlaylistEntity(-1));  //document doesn't exist
            //act
            var playlist = _fixture.Load(@"c:\temp\meineSuperPlaylist.mongodb");

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Once);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Load_FilePathIsEmpty()
        {            
            //act
            var playlist = _fixture.Load(string.Empty);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Load_FilePathIsNull()
        {
            //act
            var playlist = _fixture.Load(null);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedPlaylistItemFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Never);
        }

        [Test]        
        public void Save()
        {
            //arrange            
            _mockedDataProvider.Setup(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()))
                               .Returns(CreatePlaylistEntity(-1));  //document doesn't exist

            var mockedPlaylistItem_1 = CreatePlaylistItemMock(@"C:\temp\meinSong1.mp3");
            var mockedPlaylistItem_2 = CreatePlaylistItemMock(@"C:\temp\meinSong2.mp3");
            var mockedPlaylistItem_3 = CreatePlaylistItemMock(@"C:\temp\meinSong3.mp3");

            var mockedPlaylist = new Mock<IPlaylist>();
            mockedPlaylist.Setup(x => x.Title).Returns("Test Playlist 2020");
            mockedPlaylist.Setup(x => x.Author).Returns("Test Author");            
            mockedPlaylist.Setup(x => x.CreatedAt).Returns(DateTime.UtcNow);            
            mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] { mockedPlaylistItem_1,
                                                                             mockedPlaylistItem_2,
                                                                             mockedPlaylistItem_3});                       
            //act
            _fixture.Save(@"c:\temp\meineSuperPlaylist.mongodb", mockedPlaylist.Object);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Once);
            _mockedDataProvider.Verify(x => x.UpdateDocument(It.IsAny<PlaylistEntity>(), It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.InsertDocument(It.IsAny<PlaylistEntity>()), Times.Once);
        }

        [Test]
        public void Save_ExistingDocument()
        {
            //arrange            
            _mockedDataProvider.Setup(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()))
                               .Returns(CreatePlaylistEntity(3));  //document exists in the DB

            var mockedPlaylistItem_1 = CreatePlaylistItemMock(@"C:\temp\meinSong1.mp3");
            var mockedPlaylistItem_2 = CreatePlaylistItemMock(@"C:\temp\meinSong2.mp3");
            var mockedPlaylistItem_3 = CreatePlaylistItemMock(@"C:\temp\meinSong3.mp3");

            var mockedPlaylist = new Mock<IPlaylist>();
            mockedPlaylist.Setup(x => x.Title).Returns("Test Playlist 2020");
            mockedPlaylist.Setup(x => x.Author).Returns("Test Author");
            mockedPlaylist.Setup(x => x.CreatedAt).Returns(DateTime.UtcNow);
            mockedPlaylist.Setup(x => x.Items).Returns(new IPlaylistItem[] { mockedPlaylistItem_1,
                                                                             mockedPlaylistItem_2,
                                                                             mockedPlaylistItem_3});
            //act
            _fixture.Save(@"c:\temp\meineSuperPlaylist.mongodb", mockedPlaylist.Object);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Once);
            _mockedDataProvider.Verify(x => x.UpdateDocument(It.IsAny<PlaylistEntity>(), It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Once);
            _mockedDataProvider.Verify(x => x.InsertDocument(It.IsAny<PlaylistEntity>()), Times.Never);
        }

        [Test]
        public void Save_FilePathIsEmpty()
        {
            //arrange                        
            var mockedPlaylist = new Mock<IPlaylist>();

            //act
            _fixture.Save(string.Empty, mockedPlaylist.Object);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.UpdateDocument(It.IsAny<PlaylistEntity>(), It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.InsertDocument(It.IsAny<PlaylistEntity>()), Times.Never);
        }

        [Test]
        public void Save_PlaylistIsNull()
        {
            //arrange                        
            var mockedPlaylist = new Mock<IPlaylist>();

            //act
            _fixture.Save(@"c:\temp\meineSuperPlaylist.mongodb", null);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.UpdateDocument(It.IsAny<PlaylistEntity>(), It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.InsertDocument(It.IsAny<PlaylistEntity>()), Times.Never);
        }

        [Test]
        public void Save_FilePathIsNull()
        {
            //arrange                        
            var mockedPlaylist = new Mock<IPlaylist>();

            //act
            _fixture.Save(null, mockedPlaylist.Object);

            //assert
            _mockedDataProvider.Verify(x => x.LoadDocumentByFilter(It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.UpdateDocument(It.IsAny<PlaylistEntity>(), It.IsAny<Expression<Func<PlaylistEntity, bool>>>()), Times.Never);
            _mockedDataProvider.Verify(x => x.InsertDocument(It.IsAny<PlaylistEntity>()), Times.Never);
        }

        [Test]       
        public void GetExtension()
        {
            //act
            var extension = _fixture.Extension;

            //assert
            Assert.That(extension, Is.EqualTo(".mongodb"));
        }

        [Test]
        public void GetDescription()
        {
            //act
            var description = _fixture.Description;

            //assert
            Assert.That(description, Is.EqualTo("Store project data into MongoDb"));
        }

        private PlaylistEntity CreatePlaylistEntity(int itemCount)
        {
            List<PlaylistItemEntity> itemList = new List<PlaylistItemEntity>();

            if(itemCount == -1)
            {
                return null;
            }

            for (int i = 0; i < itemCount; i++)
            {
                itemList.Add(new PlaylistItemEntity()
                {
                    Extension = ".mp3",
                    FilePath = $@"c:\temp\mySongs\super_testsong_{i + 1}.mp3"
                });
            }

            var playlistEntity = new PlaylistEntity()
            {
                Author = "NUnit Test Author",
                Title = "Test Title",
                CreatedAt = DateTime.UtcNow,
                FilePath = "meinSuperPlaylist.mongodb",
                Id = Guid.NewGuid(),
                Items = itemList
            };

            return playlistEntity;
        }

        private IPlaylistItem CreatePlaylistItemMock(string filePath)
        {
            Mock<IPlaylistItem> mockedplaylistItem = new Mock<IPlaylistItem>();

            mockedplaylistItem.Setup(x => x.FilePath).Returns(filePath);
            mockedplaylistItem.Setup(x => x.Extension).Returns(Path.GetExtension(filePath));

            return mockedplaylistItem.Object;
        }
    }
}
