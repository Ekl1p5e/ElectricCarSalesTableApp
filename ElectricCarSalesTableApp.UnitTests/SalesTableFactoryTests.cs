using AutoFixture;
using ElectricCarSalesTableApp.Core.Interfaces;
using NSubstitute;
using System;
using System.Data;
using Xunit;

namespace ElectricCarSalesTableApp.UnitTests
{
    public class SalesTableFactoryTests
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
        public void Constructor_ThrowsArgumentNullException_NullTableLoader()
        {
            ISalesDataTableLoader loader = null;
            var path = Fixture.Create<string>();

            Assert.Throws<ArgumentNullException>(() => new SalesTableFactory(loader, path));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ThrowsArgumentNullException_NullOrEmptyPath(string path)
        {
            var loader = Substitute.For<ISalesDataTableLoader>();

            Assert.Throws<ArgumentNullException>(() => new SalesTableFactory(loader, path));
        }

        [Fact]
        public void Constructor_Constructs_ValidArguments()
        {
            var loader = Substitute.For<ISalesDataTableLoader>();
            var path = Fixture.Create<string>();

            var factory = new SalesTableFactory(loader, path);

            Assert.NotNull(factory);
        }

        [Fact]
        public void GetTable_ReturnsSameTableLoaderException_TableLoaderThrowsException()
        {
            var path = Fixture.Create<string>();
            var exc = Fixture.Create<Exception>();
            var loader = Substitute.For<ISalesDataTableLoader>();
            loader.GetTable(path).Returns(c => throw exc);

            var factory = new SalesTableFactory(loader, path);

            var exception = Assert.ThrowsAny<Exception>(() => factory.GetTable().GetAwaiter().GetResult());

            Assert.Same(exc, exception);
        }

        [Fact]
        public void GetTable_ReturnsSalesDataTable_FromTableLoaderTable()
        {
            var path = Fixture.Create<string>();
            var table = new DataTable();
            var loader = Substitute.For<ISalesDataTableLoader>();
            loader.GetTable(path).Returns(c => table);

            var factory = new SalesTableFactory(loader, path);

            var result = factory.GetTable().GetAwaiter().GetResult();

            Assert.NotNull(result);
        }
    }
}
