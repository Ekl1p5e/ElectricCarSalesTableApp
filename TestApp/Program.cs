using Autofac;
using ElectricCarSalesTableApp.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Application requires filepath as input.");
                return;
            }

            var builder = new ContainerBuilder();
            builder.RegisterModule<TestAppModule>();

            var container = builder.Build();

            var dataTableLoader = container.Resolve<ISalesDataTableLoader>();
            var dataTable = await Task.Factory.StartNew(() => dataTableLoader.GetTable(args[0]));

            if (dataTable != null)
            {
                var dataViewer = container.Resolve<ISalesDataTableViewer>();
                dataViewer.Display(dataTable);
            }
        }
    }
}
