using Autofac;
using Autofac.Extensions.DependencyInjection;
using AvaloniaWpfMessageDialogService.Shared.Service;
using AvaloniaWpfMessageDialogService.Shared.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaWpfMessageDialogService.Ava.Startup
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

            builder.Populate(_serviceCollection);

            return builder.Build();
        }
    }
}
