using AutoFixture;
using ElectricCarSalesTableApp.Core.Models;
using System;
using System.Data;
using System.Linq;
using Xunit;

namespace ElectricCarSalesTableApp.Core.UnitTests.ModelsTests
{
    public class SalesTableDataTests
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
        public void Constructor_ThrowsArgumentNullException_NullDataTable()
        {
            DataTable table = null;

            Assert.Throws<ArgumentNullException>(() => new SalesTableData(table));
        }

        [Fact]
        public void Constructor_Constructs_NonNullDataTable()
        {
            DataTable table = new DataTable();

            var salesTable = new SalesTableData(table);

            Assert.NotNull(salesTable);
        }

        [Fact]
        public void ColumnNames_ReturnsColumnNamesSkippingFirstColumn_FromDataTable()
        {
            DataTable table = new DataTable();

            var columns = Fixture.CreateMany<string>();
            table.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            var salesTable = new SalesTableData(table);

            Assert.True(salesTable.ColumnNames.SequenceEqual(columns.Skip(1)));
        }

        [Fact]
        public void Rows_ReturnsRowValues_FromDataTable()
        {
            int colNo = Fixture.Create<int>();
            DataTable table = new DataTable();

            var columnNames = Fixture.CreateMany<string>(colNo).ToList();
            table.Columns.AddRange(columnNames.Select(s => new DataColumn(s)).ToArray());

            var columns = Fixture.CreateMany<string[]>(colNo).ToList();
            columns.ForEach(c => table.Rows.Add(c));

            var salesTable = new SalesTableData(table);

            Assert.True(salesTable.Rows.Zip(columns, (first, second) => first.SequenceEqual(second)).All(b => true));
        }
    }
}
