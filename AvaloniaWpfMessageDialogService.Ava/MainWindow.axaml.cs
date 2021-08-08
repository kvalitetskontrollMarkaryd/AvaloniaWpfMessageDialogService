using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaWpfMessageDialogService.Shared.ViewModel;

namespace AvaloniaWpfMessageDialogService.Ava
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            var container = ((App)Application.Current).Container;
            _viewModel = container.Resolve<MainViewModel>();
            DataContext = _viewModel;

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
