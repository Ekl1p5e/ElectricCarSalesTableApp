using ElectricCarSalesTableApp.Core.Models;
using System.Threading.Tasks;

namespace ElectricCarSalesTableApp.Interfaces
{
    public interface ISalesTableFactory
    {
        Task<SalesTableData> GetTable();
    }
}
