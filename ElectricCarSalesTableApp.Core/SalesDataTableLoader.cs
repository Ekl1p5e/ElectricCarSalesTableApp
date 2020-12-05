using CsvReader;
using ElectricCarSalesTableApp.Core.Interfaces;
using System.Data;
using System.IO;

namespace ElectricCarSalesTableApp.Core
{
    /// <summary>
    /// Class used to load a data table
    /// </summary>
    public class SalesDataTableLoader : ISalesDataTableLoader
    {
        /// <summary>
        /// Gets table from csv file path
        /// </summary>
        /// <param name="path">file path of csv file</param>
        /// <remarks>first row contains column headers (first entry is empty), data rows contain month or year as first entry</remarks>
        /// <returns>data table if loaded, null otherwise</returns>
        public DataTable GetTable(string path)
        {
            DataTable table = null;

            try
            {
                using (var csv = new CachedCsvReader(new StreamReader(path), true))
                {
                    table = new DataTable();
                    table.Load(csv);
                }
            }
            catch { }

            return table;
        }
    }
}
