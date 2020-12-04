using ElectricCarSalesTableApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ElectricCarSalesTableApp.Core.Models
{
    public class SalesTableData : ISalesTableData
    {
        private const int BLANK_COLUMNS = 1;

        private readonly DataTable _table;

        public SalesTableData(DataTable table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public IEnumerable<string> ColumnNames => _table.Columns.Cast<DataColumn>().Skip(BLANK_COLUMNS).Select(c => c.ColumnName);

        public IEnumerable<string[]> Rows => _table.Rows.Cast<DataRow>().Select(c => c.ItemArray.Select(o => (string)o).ToArray());
    }
}
