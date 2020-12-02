using System.Data;

namespace ElectricCarSalesTableApp.Core.Interfaces
{
    public interface ISalesDataTableViewer
    {
        void Display(DataTable dataTable);
    }
}