
using Xunit;
using Moq;
using Services.Services;
using DataAccessLayer.Repository;
using System.Collections;

namespace Services.Test
{
    public class CatalogManagerTest
    {
        private readonly Mock<IGenericRepository<Book>> _bookRepositoryMock;
        private readonly CatalogManager _catalogManager;



        public CatalogManagerTest()
        {
            // Setup mock in constructor
            _bookRepositoryMock = new Mock<IGenericRepository<Book>>();
            _catalogManager = new CatalogManager(_bookRepositoryMock.Object);
        }

        [Fact]
        public void GetCatalog_WhenCalled_ReturnsCatalog()
        {
            // Arrange
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Name = "Test Book 1" },
                new Book { Id = 2, Name = "Test Book 2" }
            };

            _bookRepositoryMock.Setup(repo => repo.GetAll())
                .Returns(expectedBooks);

            // Act
            var result = _catalogManager.GetCatalog();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBooks.Count, result.Count());
            _bookRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        public static IEnumerable<object[]> GetCatalogByIdData()
        {
            yield return new object[] { 1, new Book { Id = 1, Name = "Test Book 1" } };
            yield return new object[] { 2, new Book { Id = 2, Name = "Test Book 2" } };
            yield return new object[] { 3, new Book { Id = 3, Name = "Test Book 3" } };
        }

        [Theory]
        [MemberData(nameof(GetCatalogByIdData))]
        public void Find_WhenCalledWithValidId_ReturnsMatchingBook(int input, Book expected)
        {
            // Arrange
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Name = "Test Book 1"},
                new Book { Id = 2, Name = "Test Book 2"},
                new Book { Id = 3, Name = "Test Book 3"},

            };

            _bookRepositoryMock.Setup(repo => repo.Get(input))
                .Returns(expected);

            // Act
            var result = _catalogManager.Find(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Name, result.Name);
            _bookRepositoryMock.Verify(repo => repo.Get(input), Times.Once);
        }

        public static IEnumerable<object[]> GetCatalogByTypeData()
        {
            yield return new object[] { TypeBook.Aventure, new Book { Id = 1, Name = "Test Book 1", Type = TypeBook.Aventure } };
            yield return new object[] { TypeBook.Fiction, new Book { Id = 2, Name = "Test Book 2", Type = TypeBook.Fiction } };
            yield return new object[] { TypeBook.SF, new Book { Id = 3, Name = "Test Book 3", Type = TypeBook.SF } };
        }

        [Theory]
        [MemberData(nameof(GetCatalogByTypeData))]
        public void GetCatalog_WhenCalledWithType_ReturnsMatchingBook(TypeBook input, Book expected)
        {
            // Arrange
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Name = "Test Book 1", Type = TypeBook.Aventure },
                new Book { Id = 2, Name = "Test Book 2", Type = TypeBook.Fiction },
                new Book { Id = 3, Name = "Test Book 3", Type = TypeBook.SF },
            };

            _bookRepositoryMock.Setup(repo => repo.GetAll())
                .Returns(expectedBooks);

            // Act
            var result = _catalogManager.GetCatalog(input);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(expected.Type, result.First().Type);
            _bookRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
        }


    }
}