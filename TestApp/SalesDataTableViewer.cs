using ElectricCarSalesTableApp.Core.Interfaces;
using System;
using System.Data;
using System.Linq;

namespace TestApp
{
    internal class SalesDataTableViewer : ISalesDataTableViewer
    {
        public void Display(DataTable dataTable)
        {

            var headers = string.Join("\t", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            Console.WriteLine(headers);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var line = string.Join("\t", dataRow.ItemArray);

                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}