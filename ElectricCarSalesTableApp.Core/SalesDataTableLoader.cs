using CsvReader;
using ElectricCarSalesTableApp.Core.Interfaces;
using System.Data;
using System.IO;

namespace ElectricCarSalesTableApp.Core
{
    public class SalesDataTableLoader : ISalesDataTableLoader
    {
        public DataTable GetTable(string path)
        {
            var table = new DataTable();
            using (var csv = new CachedCsvReader(new StreamReader(path), true))
            {
                table.Load(csv);
            }

            return table;
        }
    }
}
