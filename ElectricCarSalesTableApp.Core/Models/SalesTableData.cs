using ElectricCarSalesTableApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ElectricCarSalesTableApp.Core.Models
{
    /// <summary>
    /// Class representing sales data in tabular format
    /// </summary>
    public class SalesTableData : ISalesTableData
    {
        private const int BLANK_COLUMNS = 1;

        private readonly DataTable _table;

        /// <summary>
        /// Constructs instance of the <see cref="SalesTableData"/> class
        /// </summary>
        /// <param name="table">Data table of sales data</param>
        public SalesTableData(DataTable table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        /// <summary>
        /// Gets column names
        /// </summary>
        public IEnumerable<string> ColumnNames => _table.Columns.Cast<DataColumn>().Skip(BLANK_COLUMNS).Select(c => c.ColumnName);

        /// <summary>
        /// Gets rows
        /// </summary>
        public IEnumerable<string[]> Rows => _table.Rows.Cast<DataRow>().Select(c => c.ItemArray.Select(o => o.ToString()).ToArray());
    }
}
