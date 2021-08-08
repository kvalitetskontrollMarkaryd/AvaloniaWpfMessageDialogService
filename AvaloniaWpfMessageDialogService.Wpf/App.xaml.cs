using Autofac;
using AvaloniaWpfMessageDialogService.Wpf.Startup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Threading;

namespace AvaloniaWpfMessageDialogService.Wpf
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            // serviceCollection.AddHttpClient("ApplicationHttpClient", ConfigureClient());
            serviceCollection.BuildServiceProvider();

            var bootstrapper = new Bootstrapper(serviceCollection);
            Container = bootstrapper.Bootstrap();

            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private static Action<HttpClient> ConfigureClient()
        {
            return c =>
            {
                c.BaseAddress = new Uri("");
                c.Timeout = new TimeSpan(0, 0, 30);
                c.DefaultRequestHeaders.Clear();
            };
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unexpected error occured. Contact admin!"
                + Environment.NewLine + e.Exception.GetType(), "Unexpected error!");

            e.Handled = true;
        }
        public IContainer Container { get; private set; }
    }
}
