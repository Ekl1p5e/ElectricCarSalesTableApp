using AutoFixture;
using System.IO;
using Xunit;

namespace ElectricCarSalesTableApp.Core.UnitTests
{
    public class SalesDataTableLoaderTests
    {
        private static IFixture _fixture;

        private static IFixture Fixture
        {
            get
            {
                if (_fixture == null)
                {
                    _fixture = new Fixture().Customize(new CurrentDateTimeCustomization());

                    _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                    _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                }

                return _fixture;
            }
        }

        [Fact]
        public void Constructor_Constructs_WithoutParameters()
        {
            Assert.NotNull(new SalesDataTableLoader());
        }

        [Fact]
        public void GetTable_ThrowsException_FileDoesntExist()
        {
            var path = Fixture.Create<string>();

            var loader = new SalesDataTableLoader();

            var table = loader.GetTable(path);

            Assert.Null(table);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetTable_ReturnsNull_FilePathNullOrEmpty(string path)
        {
            var loader = new SalesDataTableLoader();

            var table = loader.GetTable(path);

            Assert.Null(table);
        }

        [Fact]
        public void GetTable_ReturnsNull_FileExists()
        {
            var path = Path.GetTempFileName();

            var loader = new SalesDataTableLoader();

            var table = loader.GetTable(path);

            Assert.NotNull(table);
        }
    }
}
