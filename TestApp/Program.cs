using Autofac;
using ElectricCarSalesTableApp.Core.Interfaces;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<TestAppModule>();

            var container = builder.Build();

            var dataTableLoader = container.Resolve<ISalesDataTableLoader>();
            var dataTable = await Task.Factory.StartNew(() => dataTableLoader.GetTable(args[0]));

            var dataViewer = container.Resolve<ISalesDataTableViewer>();
            dataViewer.Display(dataTable);
        }
    }
}
