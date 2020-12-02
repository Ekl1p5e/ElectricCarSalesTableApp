using System.Data;

namespace ElectricCarSalesTableApp.Core.Interfaces
{
    public interface ISalesDataTable
    {
        DataRowCollection Rows { get; }

        void Load(string v);
    }
}