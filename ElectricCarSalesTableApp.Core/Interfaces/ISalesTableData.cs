using System.Collections.Generic;

namespace ElectricCarSalesTableApp.Core.Interfaces
{
    public interface ISalesTableData
    {
        IEnumerable<string> ColumnNames { get; }

        IEnumerable<string[]> Rows { get; }
    }
}
