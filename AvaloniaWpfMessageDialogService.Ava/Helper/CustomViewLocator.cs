using Autofac;
using Avalonia;
using AvaloniaWpfMessageDialogService.Shared.Helper;
using AvaloniaWpfMessageDialogService.Shared.ViewModel;
using System;

namespace AvaloniaWpfMessageDialogService.Ava.Helper
{
    // TODO: Should be something better
    public class CustomViewLocator : ICustomViewLocator
    {
        public object GetViewFor<TViewModel>(TViewModel viewModel)
        {
            if (viewModel.GetType() == typeof(MainViewModel))
            {
                return ((App)Application.Current).Container.Resolve<MainWindow>();
            }

            throw new NotSupportedException();
        }
    }
}
