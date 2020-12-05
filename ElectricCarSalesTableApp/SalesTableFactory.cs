using ElectricCarSalesTableApp.Core.Interfaces;
using ElectricCarSalesTableApp.Core.Models;
using ElectricCarSalesTableApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ElectricCarSalesTableApp
{
    public class SalesTableFactory : ISalesTableFactory
    {
        private readonly string _filepath;
        private readonly ISalesDataTableLoader _tableLoader;

        public SalesTableFactory(ISalesDataTableLoader tableLoader, string filepath)
        {
            _filepath = !string.IsNullOrWhiteSpace(filepath) ? filepath : throw new ArgumentNullException(nameof(filepath));
            _tableLoader = tableLoader ?? throw new ArgumentNullException(nameof(tableLoader));
        }

        public async Task<SalesTableData> GetTable()
        {
            var table = await Task.Factory.StartNew(() => _tableLoader.GetTable(_filepath));

            return new SalesTableData(table);
        }
    }
}
