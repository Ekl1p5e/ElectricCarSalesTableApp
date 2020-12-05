using ElectricCarSalesTableApp.Core.Interfaces;
using ElectricCarSalesTableApp.Core.Models;
using ElectricCarSalesTableApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ElectricCarSalesTableApp
{
    /// <summary>
    /// Class used to create sales data tables
    /// </summary>
    public class SalesTableFactory : ISalesTableFactory
    {
        private readonly string _filepath;
        private readonly ISalesDataTableLoader _tableLoader;

        /// <summary>
        /// Constructs and instance of the <see cref="SalesTableFactory"/> class
        /// </summary>
        /// <param name="tableLoader">class used to load table</param>
        /// <param name="filepath">source file path</param>
        public SalesTableFactory(ISalesDataTableLoader tableLoader, string filepath)
        {
            _filepath = !string.IsNullOrWhiteSpace(filepath) ? filepath : throw new ArgumentNullException(nameof(filepath));
            _tableLoader = tableLoader ?? throw new ArgumentNullException(nameof(tableLoader));
        }

        /// <summary>
        /// Gets table
        /// </summary>
        /// <returns>returns sales data table</returns>
        public async Task<SalesTableData> GetTable()
        {
            var table = await Task.Factory.StartNew(() => _tableLoader.GetTable(_filepath));

            return new SalesTableData(table);
        }
    }
}
