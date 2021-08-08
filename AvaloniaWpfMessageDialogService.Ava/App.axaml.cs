using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaWpfMessageDialogService.Ava.Startup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace AvaloniaWpfMessageDialogService.Ava
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var serviceCollection = new ServiceCollection();

            // serviceCollection.AddHttpClient("ApplicationHttpClient", ConfigureClient());
            serviceCollection.BuildServiceProvider();

            var bootstrapper = new Bootstrapper(serviceCollection);
            Container = bootstrapper.Bootstrap();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        public IContainer Container { get; private set; }

        private static Action<HttpClient> ConfigureClient()
        {
            return c =>
            {
                c.BaseAddress = new Uri("");
                c.Timeout = new TimeSpan(0, 0, 30);
                c.DefaultRequestHeaders.Clear();
            };
        }
    }
}
