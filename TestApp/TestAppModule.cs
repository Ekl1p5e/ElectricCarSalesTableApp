using Autofac;
using ElectricCarSalesTableApp.Core;
using ElectricCarSalesTableApp.Core.Interfaces;

namespace TestApp
{
    internal class TestAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SalesDataTableLoader>().
                As<ISalesDataTableLoader>().
                SingleInstance();

            builder.RegisterType<SalesDataTableViewer>().
                As<ISalesDataTableViewer>().
                SingleInstance();
        }
    }
}
