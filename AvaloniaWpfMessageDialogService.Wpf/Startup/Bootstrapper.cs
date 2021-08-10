using Autofac;
using Autofac.Extensions.DependencyInjection;
using AvaloniaWpfMessageDialogService.Shared.Service;
using AvaloniaWpfMessageDialogService.Shared.ViewModel;
using AvaloniaWpfMessageDialogService.Wpf.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaWpfMessageDialogService.Wpf.Startup
{
    public class Bootstrapper
    {
        private readonly ServiceCollection _serviceCollection;

        public Bootstrapper(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
            builder.RegisterType<MessageBoxService>().As<IMessageBoxService>();

            builder.Populate(_serviceCollection);

            return builder.Build();
        }
    }
}
