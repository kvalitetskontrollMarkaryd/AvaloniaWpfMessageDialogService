using AvaloniaWpfMessageDialogService.Shared.ViewModel;
using System.Windows;

namespace AvaloniaWpfMessageDialogService.Wpf
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }
    }
}
