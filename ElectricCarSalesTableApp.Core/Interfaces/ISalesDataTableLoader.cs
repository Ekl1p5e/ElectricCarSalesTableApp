using System.Data;

namespace ElectricCarSalesTableApp.Core.Interfaces
{
    public interface ISalesDataTableLoader
    {
        DataTable GetTable(string path);
    }
}