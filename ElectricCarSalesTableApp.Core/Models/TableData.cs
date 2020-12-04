using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ElectricCarSalesTableApp.Core.Models
{
    public class SalesTableData
    {
        private readonly DataTable _table;

        public SalesTableData(DataTable table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public IEnumerable<string> ColumnNames => _table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);

        public IEnumerable<object[]> Rows => _table.Rows.Cast<DataRow>().Select(c => c.ItemArray);
    }
}
