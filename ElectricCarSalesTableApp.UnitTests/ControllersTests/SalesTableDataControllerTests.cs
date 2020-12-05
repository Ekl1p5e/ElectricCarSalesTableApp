using AutoFixture;
using ElectricCarSalesTableApp.Controllers;
using ElectricCarSalesTableApp.Core.Models;
using ElectricCarSalesTableApp.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ElectricCarSalesTableApp.UnitTests.ControllersTests
{
    public class SalesTableDataControllerTests
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
        public void Constructor_ThrowsArgumentNullException_NullLogger()
        {
            ILogger<SalesTableDataController> logger = null;
            var salesTableFactory = Substitute.For<ISalesTableFactory>();

            Assert.Throws<ArgumentNullException>(() => new SalesTableDataController(logger, salesTableFactory));
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullFactory()
        {
            var logger = Substitute.For<ILogger<SalesTableDataController>>();
            ISalesTableFactory salesTableFactory = null;

            Assert.Throws<ArgumentNullException>(() => new SalesTableDataController(logger, salesTableFactory));
        }

        [Fact]
        public void Constructor_Constructs_ValidArguments()
        {
            var logger = Substitute.For<ILogger<SalesTableDataController>>();
            var salesTableFactory = Substitute.For<ISalesTableFactory>();

            var controller = new SalesTableDataController(logger, salesTableFactory);
            Assert.NotNull(controller);
        }

        [Fact]
        public void Get_ReturnsSameFactoryException_FactoryThrowsException()
        {
            var logger = Substitute.For<ILogger<SalesTableDataController>>();

            var exc = Fixture.Create<Exception>();
            var salesTableFactory = Substitute.For<ISalesTableFactory>();
            salesTableFactory.GetTable().Returns<Task<SalesTableData>>(c => throw exc);

            var controller = new SalesTableDataController(logger, salesTableFactory);

            var exception = Assert.ThrowsAny<Exception>(() => controller.Get().GetAwaiter().GetResult());
            Assert.Same(exc, exception);
        }
    }
}
